namespace FileMassRenamer
{
    partial class FRMMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LLDateTimeRef = new System.Windows.Forms.LinkLabel();
            this.LBLDateTimeErr = new System.Windows.Forms.Label();
            this.TXTDateTimeFormat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CBMakeUnique = new System.Windows.Forms.CheckBox();
            this.CBAppendDateTime = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TBLogFilename = new System.Windows.Forms.TextBox();
            this.CBSaveLogfile = new System.Windows.Forms.CheckBox();
            this.TXTAddSuffix = new System.Windows.Forms.TextBox();
            this.TXTAddPrefix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DGRenames = new System.Windows.Forms.DataGridView();
            this.SelectColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OriginalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RenamedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTNCancel = new System.Windows.Forms.Button();
            this.BTNRename = new System.Windows.Forms.Button();
            this.TTCommon = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGRenames)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.LLDateTimeRef);
            this.groupBox1.Controls.Add(this.LBLDateTimeErr);
            this.groupBox1.Controls.Add(this.TXTDateTimeFormat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CBMakeUnique);
            this.groupBox1.Controls.Add(this.CBAppendDateTime);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quick rename";
            // 
            // LLDateTimeRef
            // 
            this.LLDateTimeRef.AutoSize = true;
            this.LLDateTimeRef.Location = new System.Drawing.Point(429, 25);
            this.LLDateTimeRef.Name = "LLDateTimeRef";
            this.LLDateTimeRef.Size = new System.Drawing.Size(74, 13);
            this.LLDateTimeRef.TabIndex = 6;
            this.LLDateTimeRef.TabStop = true;
            this.LLDateTimeRef.Text = "See reference";
            this.LLDateTimeRef.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLDateTimeRef_LinkClicked);
            // 
            // LBLDateTimeErr
            // 
            this.LBLDateTimeErr.AutoSize = true;
            this.LBLDateTimeErr.ForeColor = System.Drawing.Color.Red;
            this.LBLDateTimeErr.Location = new System.Drawing.Point(428, 25);
            this.LBLDateTimeErr.Name = "LBLDateTimeErr";
            this.LBLDateTimeErr.Size = new System.Drawing.Size(0, 13);
            this.LBLDateTimeErr.TabIndex = 5;
            // 
            // TXTDateTimeFormat
            // 
            this.TXTDateTimeFormat.Location = new System.Drawing.Point(287, 22);
            this.TXTDateTimeFormat.Name = "TXTDateTimeFormat";
            this.TXTDateTimeFormat.Size = new System.Drawing.Size(135, 20);
            this.TXTDateTimeFormat.TabIndex = 4;
            this.TXTDateTimeFormat.Text = "_yyyy-MM-ddTHH-mm";
            this.TTCommon.SetToolTip(this.TXTDateTimeFormat, "The DateTime format to use:\r\n\r\nExamples: \r\n2021-12-01T02:45:15\r\nyy      -> 21\r\nyy" +
        "yy  ->2021\r\nMM   -> 12\r\ndd      -> 01\r\nd        -> 1\r\nHH    -> 02\r\nH       -> 2\r" +
        "\nmm   -> 45\r\nss       -> 15");
            this.TXTDateTimeFormat.TextChanged += new System.EventHandler(this.TXTDateTimeFormat_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Date/time format:";
            // 
            // CBMakeUnique
            // 
            this.CBMakeUnique.AutoSize = true;
            this.CBMakeUnique.Location = new System.Drawing.Point(15, 48);
            this.CBMakeUnique.Name = "CBMakeUnique";
            this.CBMakeUnique.Size = new System.Drawing.Size(88, 17);
            this.CBMakeUnique.TabIndex = 1;
            this.CBMakeUnique.Text = "Make unique";
            this.TTCommon.SetToolTip(this.CBMakeUnique, resources.GetString("CBMakeUnique.ToolTip"));
            this.CBMakeUnique.UseVisualStyleBackColor = true;
            this.CBMakeUnique.CheckedChanged += new System.EventHandler(this.CBMakeUnique_CheckedChanged);
            // 
            // CBAppendDateTime
            // 
            this.CBAppendDateTime.AutoSize = true;
            this.CBAppendDateTime.Location = new System.Drawing.Point(15, 24);
            this.CBAppendDateTime.Name = "CBAppendDateTime";
            this.CBAppendDateTime.Size = new System.Drawing.Size(130, 17);
            this.CBAppendDateTime.TabIndex = 0;
            this.CBAppendDateTime.Text = "Append date and time";
            this.TTCommon.SetToolTip(this.CBAppendDateTime, "Appends date and time to the filename when enabled");
            this.CBAppendDateTime.UseVisualStyleBackColor = true;
            this.CBAppendDateTime.CheckedChanged += new System.EventHandler(this.CBAppendDateTime_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.TBLogFilename);
            this.groupBox2.Controls.Add(this.CBSaveLogfile);
            this.groupBox2.Controls.Add(this.TXTAddSuffix);
            this.groupBox2.Controls.Add(this.TXTAddPrefix);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 92);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Advanced";
            // 
            // TBLogFilename
            // 
            this.TBLogFilename.Location = new System.Drawing.Point(102, 56);
            this.TBLogFilename.Name = "TBLogFilename";
            this.TBLogFilename.Size = new System.Drawing.Size(320, 20);
            this.TBLogFilename.TabIndex = 5;
            // 
            // CBSaveLogfile
            // 
            this.CBSaveLogfile.AutoSize = true;
            this.CBSaveLogfile.Location = new System.Drawing.Point(15, 58);
            this.CBSaveLogfile.Name = "CBSaveLogfile";
            this.CBSaveLogfile.Size = new System.Drawing.Size(81, 17);
            this.CBSaveLogfile.TabIndex = 4;
            this.CBSaveLogfile.Text = "Save logfile";
            this.TTCommon.SetToolTip(this.CBSaveLogfile, "Saves a log file to the specified filename");
            this.CBSaveLogfile.UseVisualStyleBackColor = true;
            // 
            // TXTAddSuffix
            // 
            this.TXTAddSuffix.Location = new System.Drawing.Point(287, 23);
            this.TXTAddSuffix.Name = "TXTAddSuffix";
            this.TXTAddSuffix.Size = new System.Drawing.Size(135, 20);
            this.TXTAddSuffix.TabIndex = 3;
            this.TXTAddSuffix.TextChanged += new System.EventHandler(this.TXTAddSuffix_TextChanged);
            // 
            // TXTAddPrefix
            // 
            this.TXTAddPrefix.Location = new System.Drawing.Point(75, 23);
            this.TXTAddPrefix.Name = "TXTAddPrefix";
            this.TXTAddPrefix.Size = new System.Drawing.Size(135, 20);
            this.TXTAddPrefix.TabIndex = 2;
            this.TXTAddPrefix.TextChanged += new System.EventHandler(this.TXTAddPrefix_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Add suffix:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add prefix:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.DGRenames);
            this.groupBox3.Location = new System.Drawing.Point(12, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(545, 229);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select and preview before rename";
            // 
            // DGRenames
            // 
            this.DGRenames.AllowUserToAddRows = false;
            this.DGRenames.AllowUserToDeleteRows = false;
            this.DGRenames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGRenames.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGRenames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectColumn,
            this.OriginalColumn,
            this.RenamedColumn});
            this.DGRenames.Location = new System.Drawing.Point(15, 19);
            this.DGRenames.Name = "DGRenames";
            this.DGRenames.Size = new System.Drawing.Size(515, 193);
            this.DGRenames.TabIndex = 1;
            this.TTCommon.SetToolTip(this.DGRenames, "Preview of rename effects.\r\nFile names that will not be affected are greyed out.");
            this.DGRenames.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGRenames_CellFormatting);
            // 
            // SelectColumn
            // 
            this.SelectColumn.HeaderText = "";
            this.SelectColumn.MinimumWidth = 20;
            this.SelectColumn.Name = "SelectColumn";
            this.SelectColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SelectColumn.TrueValue = "true";
            this.SelectColumn.Width = 20;
            // 
            // OriginalColumn
            // 
            this.OriginalColumn.HeaderText = "Original";
            this.OriginalColumn.MinimumWidth = 220;
            this.OriginalColumn.Name = "OriginalColumn";
            this.OriginalColumn.Width = 220;
            // 
            // RenamedColumn
            // 
            this.RenamedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RenamedColumn.HeaderText = "Renamed";
            this.RenamedColumn.MinimumWidth = 220;
            this.RenamedColumn.Name = "RenamedColumn";
            // 
            // BTNCancel
            // 
            this.BTNCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNCancel.Location = new System.Drawing.Point(437, 433);
            this.BTNCancel.Name = "BTNCancel";
            this.BTNCancel.Size = new System.Drawing.Size(120, 32);
            this.BTNCancel.TabIndex = 3;
            this.BTNCancel.Text = "&Cancel";
            this.BTNCancel.UseVisualStyleBackColor = true;
            this.BTNCancel.Click += new System.EventHandler(this.BTNCancel_Click);
            // 
            // BTNRename
            // 
            this.BTNRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNRename.Location = new System.Drawing.Point(311, 433);
            this.BTNRename.Name = "BTNRename";
            this.BTNRename.Size = new System.Drawing.Size(120, 32);
            this.BTNRename.TabIndex = 4;
            this.BTNRename.Text = "&Rename";
            this.BTNRename.UseVisualStyleBackColor = true;
            this.BTNRename.Click += new System.EventHandler(this.BTNRename_Click);
            // 
            // FRMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 477);
            this.Controls.Add(this.BTNRename);
            this.Controls.Add(this.BTNCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMMain";
            this.Text = "Rename selected files";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.FRMMain_HelpButtonClicked);
            this.Shown += new System.EventHandler(this.FRMMain_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGRenames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CBAppendDateTime;
        private System.Windows.Forms.CheckBox CBMakeUnique;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TXTAddSuffix;
        private System.Windows.Forms.TextBox TXTAddPrefix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTDateTimeFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BTNCancel;
        private System.Windows.Forms.Button BTNRename;
        private System.Windows.Forms.DataGridView DGRenames;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RenamedColumn;
        private System.Windows.Forms.Label LBLDateTimeErr;
        private System.Windows.Forms.LinkLabel LLDateTimeRef;
        private System.Windows.Forms.ToolTip TTCommon;
        private System.Windows.Forms.TextBox TBLogFilename;
        private System.Windows.Forms.CheckBox CBSaveLogfile;
    }
}