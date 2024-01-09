namespace MultiSupplierMTPlugin.Forms
{
    partial class OptionsFormXunfei
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
            this.labelApiId = new System.Windows.Forms.Label();
            this.labelApiKey = new System.Windows.Forms.Label();
            this.textBoxApiId = new System.Windows.Forms.TextBox();
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.linkLabelCheck = new System.Windows.Forms.LinkLabel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelCheckResult = new System.Windows.Forms.Label();
            this.textApiSecret = new System.Windows.Forms.TextBox();
            this.labelApiSecret = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelApiId
            // 
            this.labelApiId.Location = new System.Drawing.Point(17, 17);
            this.labelApiId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApiId.Name = "labelApiId";
            this.labelApiId.Size = new System.Drawing.Size(99, 18);
            this.labelApiId.TabIndex = 0;
            this.labelApiId.Text = "Api Id";
            // 
            // labelApiKey
            // 
            this.labelApiKey.Location = new System.Drawing.Point(17, 55);
            this.labelApiKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApiKey.Name = "labelApiKey";
            this.labelApiKey.Size = new System.Drawing.Size(99, 18);
            this.labelApiKey.TabIndex = 2;
            this.labelApiKey.Text = "Api Key";
            // 
            // textBoxApiId
            // 
            this.textBoxApiId.Location = new System.Drawing.Point(121, 14);
            this.textBoxApiId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxApiId.Name = "textBoxApiId";
            this.textBoxApiId.Size = new System.Drawing.Size(380, 25);
            this.textBoxApiId.TabIndex = 1;
            // 
            // textBoxApiKey
            // 
            this.textBoxApiKey.Location = new System.Drawing.Point(121, 52);
            this.textBoxApiKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.Size = new System.Drawing.Size(380, 25);
            this.textBoxApiKey.TabIndex = 3;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(292, 160);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(398, 160);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(103, 27);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // linkLabelCheck
            // 
            this.linkLabelCheck.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabelCheck.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelCheck.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linkLabelCheck.Location = new System.Drawing.Point(17, 127);
            this.linkLabelCheck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelCheck.Name = "linkLabelCheck";
            this.linkLabelCheck.Size = new System.Drawing.Size(99, 18);
            this.linkLabelCheck.TabIndex = 6;
            this.linkLabelCheck.TabStop = true;
            this.linkLabelCheck.Text = "Check";
            this.linkLabelCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCheck_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(17, 166);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(264, 14);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 8;
            this.progressBar.Visible = false;
            // 
            // labelCheckResult
            // 
            this.labelCheckResult.Location = new System.Drawing.Point(121, 124);
            this.labelCheckResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCheckResult.Name = "labelCheckResult";
            this.labelCheckResult.Size = new System.Drawing.Size(380, 25);
            this.labelCheckResult.TabIndex = 7;
            // 
            // textApiSecret
            // 
            this.textApiSecret.Location = new System.Drawing.Point(121, 89);
            this.textApiSecret.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textApiSecret.Name = "textApiSecret";
            this.textApiSecret.PasswordChar = '*';
            this.textApiSecret.Size = new System.Drawing.Size(380, 25);
            this.textApiSecret.TabIndex = 5;
            // 
            // labelApiSecret
            // 
            this.labelApiSecret.Location = new System.Drawing.Point(17, 92);
            this.labelApiSecret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApiSecret.Name = "labelApiSecret";
            this.labelApiSecret.Size = new System.Drawing.Size(99, 18);
            this.labelApiSecret.TabIndex = 4;
            this.labelApiSecret.Text = "Api Secret";
            // 
            // OptionsFormXunfei
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(510, 198);
            this.Controls.Add(this.textApiSecret);
            this.Controls.Add(this.labelApiSecret);
            this.Controls.Add(this.labelCheckResult);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.linkLabelCheck);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxApiKey);
            this.Controls.Add(this.textBoxApiId);
            this.Controls.Add(this.labelApiKey);
            this.Controls.Add(this.labelApiId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsFormXunfei";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xunfei";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelApiId;
        private System.Windows.Forms.Label labelApiKey;
        private System.Windows.Forms.TextBox textBoxApiId;
        private System.Windows.Forms.TextBox textBoxApiKey;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.LinkLabel linkLabelCheck;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelCheckResult;
        private System.Windows.Forms.TextBox textApiSecret;
        private System.Windows.Forms.Label labelApiSecret;
    }
}