namespace MultiSupplierMTPlugin.Forms
{
    partial class OptionsFormAliyun
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
            this.labelKeyId = new System.Windows.Forms.Label();
            this.labelKeySecret = new System.Windows.Forms.Label();
            this.textBoxKeyId = new System.Windows.Forms.TextBox();
            this.textBoxKeySecret = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.linkLabelCheck = new System.Windows.Forms.LinkLabel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelServiceType = new System.Windows.Forms.Label();
            this.radioButtonGeneral = new System.Windows.Forms.RadioButton();
            this.radioButtonProfessional = new System.Windows.Forms.RadioButton();
            this.labelCheckResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelKeyId
            // 
            this.labelKeyId.Location = new System.Drawing.Point(17, 25);
            this.labelKeyId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelKeyId.Name = "labelKeyId";
            this.labelKeyId.Size = new System.Drawing.Size(99, 18);
            this.labelKeyId.TabIndex = 0;
            this.labelKeyId.Text = "Key Id";
            // 
            // labelKeySecret
            // 
            this.labelKeySecret.Location = new System.Drawing.Point(17, 66);
            this.labelKeySecret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelKeySecret.Name = "labelKeySecret";
            this.labelKeySecret.Size = new System.Drawing.Size(99, 18);
            this.labelKeySecret.TabIndex = 2;
            this.labelKeySecret.Text = "Key Secret";
            // 
            // textBoxKeyId
            // 
            this.textBoxKeyId.Location = new System.Drawing.Point(118, 22);
            this.textBoxKeyId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxKeyId.Name = "textBoxKeyId";
            this.textBoxKeyId.Size = new System.Drawing.Size(383, 25);
            this.textBoxKeyId.TabIndex = 1;
            // 
            // textBoxKeySecret
            // 
            this.textBoxKeySecret.Location = new System.Drawing.Point(118, 63);
            this.textBoxKeySecret.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxKeySecret.Name = "textBoxKeySecret";
            this.textBoxKeySecret.PasswordChar = '*';
            this.textBoxKeySecret.Size = new System.Drawing.Size(383, 25);
            this.textBoxKeySecret.TabIndex = 3;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(292, 178);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(398, 178);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(103, 27);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // linkLabelCheck
            // 
            this.linkLabelCheck.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabelCheck.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelCheck.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linkLabelCheck.Location = new System.Drawing.Point(17, 145);
            this.linkLabelCheck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelCheck.Name = "linkLabelCheck";
            this.linkLabelCheck.Size = new System.Drawing.Size(96, 23);
            this.linkLabelCheck.TabIndex = 7;
            this.linkLabelCheck.TabStop = true;
            this.linkLabelCheck.Text = "Check";
            this.linkLabelCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCheck_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(17, 184);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(264, 14);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 9;
            this.progressBar.Visible = false;
            // 
            // labelServiceType
            // 
            this.labelServiceType.Location = new System.Drawing.Point(17, 104);
            this.labelServiceType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelServiceType.Name = "labelServiceType";
            this.labelServiceType.Size = new System.Drawing.Size(99, 18);
            this.labelServiceType.TabIndex = 4;
            this.labelServiceType.Text = "Type";
            // 
            // radioButtonGeneral
            // 
            this.radioButtonGeneral.AutoSize = true;
            this.radioButtonGeneral.Location = new System.Drawing.Point(118, 104);
            this.radioButtonGeneral.Name = "radioButtonGeneral";
            this.radioButtonGeneral.Size = new System.Drawing.Size(84, 19);
            this.radioButtonGeneral.TabIndex = 5;
            this.radioButtonGeneral.TabStop = true;
            this.radioButtonGeneral.Text = "General";
            this.radioButtonGeneral.UseVisualStyleBackColor = true;
            // 
            // radioButtonProfessional
            // 
            this.radioButtonProfessional.AutoSize = true;
            this.radioButtonProfessional.Location = new System.Drawing.Point(374, 104);
            this.radioButtonProfessional.Name = "radioButtonProfessional";
            this.radioButtonProfessional.Size = new System.Drawing.Size(124, 19);
            this.radioButtonProfessional.TabIndex = 6;
            this.radioButtonProfessional.TabStop = true;
            this.radioButtonProfessional.Text = "Professional";
            this.radioButtonProfessional.UseVisualStyleBackColor = true;
            // 
            // labelCheckResult
            // 
            this.labelCheckResult.Location = new System.Drawing.Point(118, 144);
            this.labelCheckResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCheckResult.Name = "labelCheckResult";
            this.labelCheckResult.Size = new System.Drawing.Size(383, 25);
            this.labelCheckResult.TabIndex = 8;
            // 
            // OptionsFormAliyun
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(510, 216);
            this.Controls.Add(this.labelCheckResult);
            this.Controls.Add(this.radioButtonProfessional);
            this.Controls.Add(this.radioButtonGeneral);
            this.Controls.Add(this.labelServiceType);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.linkLabelCheck);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxKeySecret);
            this.Controls.Add(this.textBoxKeyId);
            this.Controls.Add(this.labelKeySecret);
            this.Controls.Add(this.labelKeyId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsFormAliyun";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aliyun";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelKeyId;
        private System.Windows.Forms.Label labelKeySecret;
        private System.Windows.Forms.TextBox textBoxKeyId;
        private System.Windows.Forms.TextBox textBoxKeySecret;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.LinkLabel linkLabelCheck;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelServiceType;
        private System.Windows.Forms.RadioButton radioButtonGeneral;
        private System.Windows.Forms.RadioButton radioButtonProfessional;
        private System.Windows.Forms.Label labelCheckResult;
    }
}