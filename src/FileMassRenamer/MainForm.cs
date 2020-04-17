using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileMassRenamer.Services;
using FileMassRenamer.Transforms;

namespace FileMassRenamer
{
    public partial class FRMMain : Form
    {

        private RenameService _renameService;
        private FRMResultLog _resultLogForm;
        public List<string> SourceFilenames { get; set; } = new List<string>();

        public FRMMain()
        {
            InitializeComponent();
            _renameService = new RenameService();
        }

        public void InitializeFormData()
        {
            TBLogFilename.Text = Path.Combine(GetCommonRootDirectory(), 
                "renamelog_" + DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss") + ".txt");
        }

        private string GetCommonRootDirectory()
        {
            var longestPath = SourceFilenames.FirstOrDefault(x => x.Length == SourceFilenames.Max(f => f.Length));
            if (longestPath != null)
            {
                var parts = longestPath.Split(Path.DirectorySeparatorChar);
                var commonStartPath = "";
                for (var i = 0; i < parts.Length; i++)
                {
                    if (i == 0)
                    {
                        commonStartPath = parts[0];
                        if (commonStartPath.EndsWith(":"))
                            commonStartPath += @"\";
                        continue;
                    }

                    if (SourceFilenames.All(x => x.StartsWith(Path.Combine(commonStartPath, parts[i]))))
                        commonStartPath = Path.Combine(commonStartPath, parts[i]);
                    else
                        break;
                }

                return commonStartPath;
            }

            return @"C:";
        }

        private void CBAppendDateTime_CheckedChanged(object sender, EventArgs e)
        {
            var control = (CheckBox) sender;
            _renameService.SetTransformActive<DateTimeAppenderTransform>(control.Checked);
            _renameService.GetTransform<DateTimeAppenderTransform>().DateTimeFormat = TXTDateTimeFormat.Text;
            UpdatePreview();
        }

        private void CBMakeUnique_CheckedChanged(object sender, EventArgs e)
        {
            var control = (CheckBox)sender;
            _renameService.SetTransformActive<UniqueFilenameTransform>(control.Checked);
            UpdatePreview();
        }

        private void TXTDateTimeFormat_TextChanged(object sender, EventArgs e)
        {
            var control = (TextBox)sender;
            var dateTimeAppender = _renameService.GetTransform<DateTimeAppenderTransform>();
            dateTimeAppender.DateTimeFormat = control.Text;
            if (dateTimeAppender.IsValid)
            {
                control.ForeColor = DefaultForeColor;
                control.Refresh();
            }
            else
            {
                control.ForeColor = Color.Red;
                control.Refresh();
            }

            UpdatePreview();
        }

        private void TXTAddPrefix_TextChanged(object sender, EventArgs e)
        {
            var control = (TextBox)sender;
            _renameService.SetTransformActive<PrefixAddingTransform>(control.Text.Length > 0);
            _renameService.GetTransform<PrefixAddingTransform>().Prefix = control.Text;
            UpdatePreview();
        }

        private void TXTAddSuffix_TextChanged(object sender, EventArgs e)
        {
            var control = (TextBox)sender;
            _renameService.SetTransformActive<SuffixAddingTransform>(control.Text.Length > 0);
            _renameService.GetTransform<SuffixAddingTransform>().Suffix = control.Text;
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            var renameResults = _renameService.PreviewTransformedFilenames(SourceFilenames);

            if (DGRenames.Rows.Count == 0)
            {
                for (var i = 0; i < renameResults.Count; i++)
                {
                    var newFullFilename = Path.Combine(Path.GetDirectoryName(renameResults[i].FileInfo.FullName),
                        renameResults[i].FilenameWithoutExtension + renameResults[i].FileExtension);
                    var oldFullFileName = renameResults[i].FileInfo.FullName;
                    DGRenames.Rows.Add(true, oldFullFileName, newFullFilename);
                    DGRenames.Rows[i].Tag = renameResults[i];
                    DGRenames.InvalidateRow(i);
                }
            }
            else
            {
                for (var i = 0; i < renameResults.Count; i++)
                {
                    var newFullFilename = Path.Combine(Path.GetDirectoryName(renameResults[i].FileInfo.FullName),
                        renameResults[i].FilenameWithoutExtension + renameResults[i].FileExtension);
                    var oldFullFileName = renameResults[i].FileInfo.FullName;
                    DGRenames.Rows[i].SetValues(DGRenames.Rows[i].Cells[0].Value, oldFullFileName, newFullFilename);
                    DGRenames.Rows[i].Tag = renameResults[i];
                    DGRenames.InvalidateRow(i);
                }
            }
            
        }

        private void DGRenames_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = (DataGridView) sender;

            var row = grid.Rows[e.RowIndex];
            if(row.Cells[1].Value.ToString() == row.Cells[2].Value.ToString())
                e.CellStyle.ForeColor = Color.DarkGray;
        }

        private void FRMMain_Shown(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void BTNCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void LLDateTimeRef_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings");
        }

        private void BTNRename_Click(object sender, EventArgs e)
        {
            // IMPORTANT: Since the transform stack requires the whole context to work with,
            // we must pass it the whole list of file names even if we only want to rename the selected
            // files - otherwise transforms like Unique cannot work, since it absolutely needs to
            // know the other file names in order to actually make file names unique.
            // We run the renaming logic for the whole batch, but we just don't execute the renaming
            // to those files that are not checked in the list.

            var filesToRename = new List<(string filename, bool execute)>();
            for (var i = 0; i < DGRenames.Rows.Count; i++)
            {
                var row = DGRenames.Rows[i];
                bool execute = false;
                bool.TryParse(row.Cells[0].Value.ToString(), out execute);

                var sourceRenameResult = row.Tag as RenameResult;

                if (row.Cells[1].Value.ToString() == row.Cells[2].Value.ToString())
                {
                    execute = false;
                }

                filesToRename.Add((sourceRenameResult.FileInfo.FullName, execute));
            }

            var executionResult = _renameService.ExecuteRenames(filesToRename, 
                CBSaveLogfile.Checked ? TBLogFilename.Text : null);

            _resultLogForm = new FRMResultLog();
            _resultLogForm.InitializeData(executionResult.Success, executionResult.ExecutionLog);
            var dialogResult = _resultLogForm.ShowDialog(this);
            
            if (dialogResult == DialogResult.Cancel)
            {
                _resultLogForm.Dispose();
                var newFilenames = executionResult.FileRenameResults.Keys.Select(x => x.FileInfo.FullName).ToList();

                for (var i = 0; i < newFilenames.Count; i++)
                {
                    SourceFilenames[i] = newFilenames[i];
                }

                UpdatePreview();
            }
            else
            {
                _resultLogForm.Dispose();
                this.Close();
                this.Dispose();
            }
        }

        private void FRMMain_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var aboutForm = new FRMAbout();
            aboutForm.ShowDialog(this);
            aboutForm.Dispose();
            e.Cancel = true;
        }
    }
}
