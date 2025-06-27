namespace MultiSupplierMTPlugin.ProviderdsCommon.Forms
{
    partial class CommonBottomControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonHelp = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelSuccess = new System.Windows.Forms.Label();
            this.linkLabelCheck = new System.Windows.Forms.LinkLabel();
            this.linkLabelFailed = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHelp.Location = new System.Drawing.Point(435, 43);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(100, 27);
            this.buttonHelp.TabIndex = 7;
            this.buttonHelp.Text = "&Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(155, 13);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(380, 14);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 4;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(323, 43);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(103, 27);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(214, 43);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // labelSuccess
            // 
            this.labelSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSuccess.ForeColor = System.Drawing.Color.Green;
            this.labelSuccess.Location = new System.Drawing.Point(154, 6);
            this.labelSuccess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(380, 25);
            this.labelSuccess.TabIndex = 2;
            this.labelSuccess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSuccess.Visible = false;
            // 
            // linkLabelCheck
            // 
            this.linkLabelCheck.AutoSize = true;
            this.linkLabelCheck.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelCheck.Location = new System.Drawing.Point(-3, 12);
            this.linkLabelCheck.Name = "linkLabelCheck";
            this.linkLabelCheck.Size = new System.Drawing.Size(47, 15);
            this.linkLabelCheck.TabIndex = 1;
            this.linkLabelCheck.TabStop = true;
            this.linkLabelCheck.Text = "Check";
            this.linkLabelCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCheck_LinkClicked);
            // 
            // linkLabelFailed
            // 
            this.linkLabelFailed.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLabelFailed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelFailed.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelFailed.LinkColor = System.Drawing.Color.Red;
            this.linkLabelFailed.Location = new System.Drawing.Point(154, 6);
            this.linkLabelFailed.Name = "linkLabelFailed";
            this.linkLabelFailed.Size = new System.Drawing.Size(380, 25);
            this.linkLabelFailed.TabIndex = 3;
            this.linkLabelFailed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabelFailed.Visible = false;
            this.linkLabelFailed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelFailed_LinkClicked);
            // 
            // CommonBottomControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.linkLabelCheck);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.linkLabelFailed);
            this.Name = "CommonBottomControl";
            this.Size = new System.Drawing.Size(535, 71);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelSuccess;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.LinkLabel linkLabelCheck;
        private System.Windows.Forms.LinkLabel linkLabelFailed;
    }
}
