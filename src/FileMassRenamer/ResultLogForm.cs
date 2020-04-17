using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMassRenamer
{
    public partial class FRMResultLog : Form
    {
        public FRMResultLog()
        {
            InitializeComponent();
        }

        public void InitializeData(bool success, string logText)
        {
            if (!success)
                LBLSuccess.Text = "Operation had errors";

            TBLog.Text = logText;
        }
    }
}
