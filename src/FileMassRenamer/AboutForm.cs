using System.Diagnostics;
using System.Windows.Forms;

namespace FileMassRenamer
{
    public partial class FRMAbout : Form
    {
        public FRMAbout()
        {
            InitializeComponent();
            var assembly = this.GetType().Assembly;
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            LBLVersion.Text = fvi.FileVersion;
        }

        private void LLGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Jusas/SimpleFileMassRenamer");
        }
    }
}
