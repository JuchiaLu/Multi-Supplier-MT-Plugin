namespace MultiSupplierMTPlugin.Forms
{
    partial class FreeOpenSourceTip
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
            this.buttonGotIt = new System.Windows.Forms.Button();
            this.buttonNeverShow = new System.Windows.Forms.Button();
            this.labelFreeOpenSourceTip = new System.Windows.Forms.Label();
            this.linkLabelViweOnGithub = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // buttonGotIt
            // 
            this.buttonGotIt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGotIt.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGotIt.Location = new System.Drawing.Point(331, 137);
            this.buttonGotIt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonGotIt.Name = "buttonGotIt";
            this.buttonGotIt.Size = new System.Drawing.Size(100, 27);
            this.buttonGotIt.TabIndex = 2;
            this.buttonGotIt.Text = "&Got it";
            this.buttonGotIt.UseVisualStyleBackColor = true;
            // 
            // buttonNeverShow
            // 
            this.buttonNeverShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNeverShow.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.buttonNeverShow.Location = new System.Drawing.Point(437, 137);
            this.buttonNeverShow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonNeverShow.Name = "buttonNeverShow";
            this.buttonNeverShow.Size = new System.Drawing.Size(103, 27);
            this.buttonNeverShow.TabIndex = 3;
            this.buttonNeverShow.Text = "&Never show";
            this.buttonNeverShow.UseVisualStyleBackColor = true;
            // 
            // labelFreeOpenSourceTip
            // 
            this.labelFreeOpenSourceTip.AutoSize = true;
            this.labelFreeOpenSourceTip.Location = new System.Drawing.Point(28, 36);
            this.labelFreeOpenSourceTip.MaximumSize = new System.Drawing.Size(550, 0);
            this.labelFreeOpenSourceTip.Name = "labelFreeOpenSourceTip";
            this.labelFreeOpenSourceTip.Size = new System.Drawing.Size(503, 75);
            this.labelFreeOpenSourceTip.TabIndex = 0;
            this.labelFreeOpenSourceTip.Text = "This plugin is open-source and free of charge.\r\n\r\nYou can download and upgrade th" +
    "e plugin for free on GitHub.\r\n\r\nIf someone tries to sell it to you, you may have" +
    " been scammed.";
            // 
            // linkLabelViweOnGithub
            // 
            this.linkLabelViweOnGithub.AutoSize = true;
            this.linkLabelViweOnGithub.Location = new System.Drawing.Point(28, 143);
            this.linkLabelViweOnGithub.Name = "linkLabelViweOnGithub";
            this.linkLabelViweOnGithub.Size = new System.Drawing.Size(135, 15);
            this.linkLabelViweOnGithub.TabIndex = 1;
            this.linkLabelViweOnGithub.TabStop = true;
            this.linkLabelViweOnGithub.Text = "View on Github ?";
            this.linkLabelViweOnGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelViweOnGithub_LinkClicked);
            // 
            // FormFreeOpenSourceTip
            // 
            this.AcceptButton = this.buttonGotIt;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonGotIt;
            this.ClientSize = new System.Drawing.Size(552, 175);
            this.Controls.Add(this.linkLabelViweOnGithub);
            this.Controls.Add(this.labelFreeOpenSourceTip);
            this.Controls.Add(this.buttonNeverShow);
            this.Controls.Add(this.buttonGotIt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFreeOpenSourceTip";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tip";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FreeOpenSourceTip_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonGotIt;
        private System.Windows.Forms.Button buttonNeverShow;
        private System.Windows.Forms.Label labelFreeOpenSourceTip;
        private System.Windows.Forms.LinkLabel linkLabelViweOnGithub;
    }
}