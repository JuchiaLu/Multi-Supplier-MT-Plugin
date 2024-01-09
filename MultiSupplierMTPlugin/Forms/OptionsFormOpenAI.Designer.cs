namespace MultiSupplierMTPlugin.Forms
{
    partial class OptionsFormOpenai
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
            this.labelBaseUrl = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.linkLabelCheck = new System.Windows.Forms.LinkLabel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelCheckResult = new System.Windows.Forms.Label();
            this.labelModel = new System.Windows.Forms.Label();
            this.comboBoxModels = new System.Windows.Forms.ComboBox();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.textBoxTemperature = new System.Windows.Forms.TextBox();
            this.labelPrompt = new System.Windows.Forms.Label();
            this.textBoxPrompt = new System.Windows.Forms.TextBox();
            this.labelApiKey = new System.Windows.Forms.Label();
            this.labelOrganization = new System.Windows.Forms.Label();
            this.textBoxBaseUrl = new System.Windows.Forms.TextBox();
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.textBoxOrganization = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelBaseUrl
            // 
            this.labelBaseUrl.Location = new System.Drawing.Point(19, 26);
            this.labelBaseUrl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBaseUrl.Name = "labelBaseUrl";
            this.labelBaseUrl.Size = new System.Drawing.Size(99, 18);
            this.labelBaseUrl.TabIndex = 0;
            this.labelBaseUrl.Text = "Base Url";
            // 
            // labelPath
            // 
            this.labelPath.Location = new System.Drawing.Point(19, 66);
            this.labelPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(99, 18);
            this.labelPath.TabIndex = 2;
            this.labelPath.Text = "Path";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(144, 63);
            this.textBoxPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(380, 25);
            this.textBoxPath.TabIndex = 3;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(314, 377);
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
            this.buttonCancel.Location = new System.Drawing.Point(420, 377);
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
            this.linkLabelCheck.Location = new System.Drawing.Point(19, 338);
            this.linkLabelCheck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelCheck.Name = "linkLabelCheck";
            this.linkLabelCheck.Size = new System.Drawing.Size(94, 23);
            this.linkLabelCheck.TabIndex = 7;
            this.linkLabelCheck.TabStop = true;
            this.linkLabelCheck.Text = "Check";
            this.linkLabelCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCheck_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(19, 383);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(265, 14);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 9;
            this.progressBar.Visible = false;
            // 
            // labelCheckResult
            // 
            this.labelCheckResult.Location = new System.Drawing.Point(144, 337);
            this.labelCheckResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCheckResult.Name = "labelCheckResult";
            this.labelCheckResult.Size = new System.Drawing.Size(380, 25);
            this.labelCheckResult.TabIndex = 8;
            // 
            // labelModel
            // 
            this.labelModel.Location = new System.Drawing.Point(19, 106);
            this.labelModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(99, 18);
            this.labelModel.TabIndex = 12;
            this.labelModel.Text = "Model";
            // 
            // comboBoxModels
            // 
            this.comboBoxModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModels.FormattingEnabled = true;
            this.comboBoxModels.Location = new System.Drawing.Point(144, 104);
            this.comboBoxModels.Name = "comboBoxModels";
            this.comboBoxModels.Size = new System.Drawing.Size(181, 23);
            this.comboBoxModels.TabIndex = 13;
            // 
            // labelTemperature
            // 
            this.labelTemperature.Location = new System.Drawing.Point(342, 106);
            this.labelTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(99, 18);
            this.labelTemperature.TabIndex = 14;
            this.labelTemperature.Text = "Temperature";
            // 
            // textBoxTemperature
            // 
            this.textBoxTemperature.Location = new System.Drawing.Point(459, 103);
            this.textBoxTemperature.Name = "textBoxTemperature";
            this.textBoxTemperature.Size = new System.Drawing.Size(65, 25);
            this.textBoxTemperature.TabIndex = 15;
            // 
            // labelPrompt
            // 
            this.labelPrompt.Location = new System.Drawing.Point(19, 224);
            this.labelPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrompt.Name = "labelPrompt";
            this.labelPrompt.Size = new System.Drawing.Size(99, 18);
            this.labelPrompt.TabIndex = 16;
            this.labelPrompt.Text = "Prompt";
            // 
            // textBoxPrompt
            // 
            this.textBoxPrompt.Location = new System.Drawing.Point(144, 224);
            this.textBoxPrompt.Multiline = true;
            this.textBoxPrompt.Name = "textBoxPrompt";
            this.textBoxPrompt.Size = new System.Drawing.Size(380, 99);
            this.textBoxPrompt.TabIndex = 17;
            // 
            // labelApiKey
            // 
            this.labelApiKey.Location = new System.Drawing.Point(19, 144);
            this.labelApiKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApiKey.Name = "labelApiKey";
            this.labelApiKey.Size = new System.Drawing.Size(99, 18);
            this.labelApiKey.TabIndex = 18;
            this.labelApiKey.Text = "Api Key";
            // 
            // labelOrganization
            // 
            this.labelOrganization.Location = new System.Drawing.Point(19, 184);
            this.labelOrganization.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOrganization.Name = "labelOrganization";
            this.labelOrganization.Size = new System.Drawing.Size(117, 18);
            this.labelOrganization.TabIndex = 19;
            this.labelOrganization.Text = "Organization";
            // 
            // textBoxBaseUrl
            // 
            this.textBoxBaseUrl.Location = new System.Drawing.Point(144, 23);
            this.textBoxBaseUrl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxBaseUrl.Name = "textBoxBaseUrl";
            this.textBoxBaseUrl.Size = new System.Drawing.Size(380, 25);
            this.textBoxBaseUrl.TabIndex = 1;
            // 
            // textBoxApiKey
            // 
            this.textBoxApiKey.Location = new System.Drawing.Point(144, 141);
            this.textBoxApiKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.PasswordChar = '*';
            this.textBoxApiKey.Size = new System.Drawing.Size(380, 25);
            this.textBoxApiKey.TabIndex = 20;
            // 
            // textBoxOrganization
            // 
            this.textBoxOrganization.Location = new System.Drawing.Point(144, 181);
            this.textBoxOrganization.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxOrganization.Name = "textBoxOrganization";
            this.textBoxOrganization.PasswordChar = '*';
            this.textBoxOrganization.Size = new System.Drawing.Size(380, 25);
            this.textBoxOrganization.TabIndex = 21;
            // 
            // OptionsFormOpenai
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(534, 416);
            this.Controls.Add(this.textBoxOrganization);
            this.Controls.Add(this.textBoxApiKey);
            this.Controls.Add(this.labelOrganization);
            this.Controls.Add(this.labelApiKey);
            this.Controls.Add(this.textBoxPrompt);
            this.Controls.Add(this.labelPrompt);
            this.Controls.Add(this.textBoxTemperature);
            this.Controls.Add(this.labelTemperature);
            this.Controls.Add(this.comboBoxModels);
            this.Controls.Add(this.labelModel);
            this.Controls.Add(this.labelCheckResult);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.linkLabelCheck);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.textBoxBaseUrl);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.labelBaseUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsFormOpenai";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OpenAI GPT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBaseUrl;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.LinkLabel linkLabelCheck;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelCheckResult;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.ComboBox comboBoxModels;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.TextBox textBoxTemperature;
        private System.Windows.Forms.Label labelPrompt;
        private System.Windows.Forms.TextBox textBoxPrompt;
        private System.Windows.Forms.Label labelApiKey;
        private System.Windows.Forms.Label labelOrganization;
        private System.Windows.Forms.TextBox textBoxBaseUrl;
        private System.Windows.Forms.TextBox textBoxApiKey;
        private System.Windows.Forms.TextBox textBoxOrganization;
    }
}