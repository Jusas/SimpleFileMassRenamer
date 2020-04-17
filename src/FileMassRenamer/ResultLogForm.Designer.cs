namespace FileMassRenamer
{
    partial class FRMResultLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMResultLog));
            this.TBLog = new System.Windows.Forms.TextBox();
            this.BTNFinished = new System.Windows.Forms.Button();
            this.BTNReturn = new System.Windows.Forms.Button();
            this.LBLSuccess = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TTCommon = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // TBLog
            // 
            this.TBLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBLog.Location = new System.Drawing.Point(12, 62);
            this.TBLog.Multiline = true;
            this.TBLog.Name = "TBLog";
            this.TBLog.ReadOnly = true;
            this.TBLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TBLog.Size = new System.Drawing.Size(747, 336);
            this.TBLog.TabIndex = 0;
            // 
            // BTNFinished
            // 
            this.BTNFinished.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNFinished.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTNFinished.Location = new System.Drawing.Point(513, 407);
            this.BTNFinished.Name = "BTNFinished";
            this.BTNFinished.Size = new System.Drawing.Size(120, 32);
            this.BTNFinished.TabIndex = 5;
            this.BTNFinished.Text = "&Finished!";
            this.TTCommon.SetToolTip(this.BTNFinished, "Close and accept");
            this.BTNFinished.UseVisualStyleBackColor = true;
            // 
            // BTNReturn
            // 
            this.BTNReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTNReturn.Location = new System.Drawing.Point(639, 407);
            this.BTNReturn.Name = "BTNReturn";
            this.BTNReturn.Size = new System.Drawing.Size(120, 32);
            this.BTNReturn.TabIndex = 6;
            this.BTNReturn.Text = "&Return to renaming";
            this.TTCommon.SetToolTip(this.BTNReturn, "Return back to renaming dialog");
            this.BTNReturn.UseVisualStyleBackColor = true;
            // 
            // LBLSuccess
            // 
            this.LBLSuccess.AutoSize = true;
            this.LBLSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLSuccess.ForeColor = System.Drawing.Color.Green;
            this.LBLSuccess.Location = new System.Drawing.Point(13, 13);
            this.LBLSuccess.Name = "LBLSuccess";
            this.LBLSuccess.Size = new System.Drawing.Size(82, 20);
            this.LBLSuccess.TabIndex = 7;
            this.LBLSuccess.Text = "Success!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "See the log for further details.";
            // 
            // FRMResultLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 448);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBLSuccess);
            this.Controls.Add(this.BTNReturn);
            this.Controls.Add(this.BTNFinished);
            this.Controls.Add(this.TBLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRMResultLog";
            this.Text = "Rename results";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBLog;
        private System.Windows.Forms.Button BTNFinished;
        private System.Windows.Forms.Button BTNReturn;
        private System.Windows.Forms.Label LBLSuccess;
        private System.Windows.Forms.ToolTip TTCommon;
        private System.Windows.Forms.Label label1;
    }
}