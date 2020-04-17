namespace FileMassRenamer
{
    partial class FRMAbout
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
            this.label1 = new System.Windows.Forms.Label();
            this.LBLVersion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LLGithub = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Simple File Mass Renamer";
            // 
            // LBLVersion
            // 
            this.LBLVersion.AutoSize = true;
            this.LBLVersion.Location = new System.Drawing.Point(143, 77);
            this.LBLVersion.Name = "LBLVersion";
            this.LBLVersion.Size = new System.Drawing.Size(37, 13);
            this.LBLVersion.TabIndex = 1;
            this.LBLVersion.Text = "v1.0.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "by Jussi Saarivirta";
            // 
            // LLGithub
            // 
            this.LLGithub.AutoSize = true;
            this.LLGithub.Location = new System.Drawing.Point(100, 125);
            this.LLGithub.Name = "LLGithub";
            this.LLGithub.Size = new System.Drawing.Size(138, 13);
            this.LLGithub.TabIndex = 3;
            this.LLGithub.TabStop = true;
            this.LLGithub.Text = "Source available on Github!";
            this.LLGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLGithub_LinkClicked);
            // 
            // FRMAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 179);
            this.Controls.Add(this.LLGithub);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LBLVersion);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "About...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBLVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel LLGithub;
    }
}