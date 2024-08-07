namespace MultiSupplierMTPlugin.Forms
{
    partial class FormClaude
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
            this.linkLabelCheck = new System.Windows.Forms.LinkLabel();
            this.labelCheckResult = new System.Windows.Forms.Label();
            this.labelModel = new System.Windows.Forms.Label();
            this.comboBoxModels = new System.Windows.Forms.ComboBox();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.labelPrompt = new System.Windows.Forms.Label();
            this.textBoxPrompt = new System.Windows.Forms.TextBox();
            this.labelXApiKey = new System.Windows.Forms.Label();
            this.labelMaxTokens = new System.Windows.Forms.Label();
            this.textBoxBaseUrl = new System.Windows.Forms.TextBox();
            this.textBoxXApiKey = new System.Windows.Forms.TextBox();
            this.numericUpDownTemperature = new System.Windows.Forms.NumericUpDown();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.numericUpDownMaxTokens = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTokens)).BeginInit();
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
            // linkLabelCheck
            // 
            this.linkLabelCheck.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabelCheck.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelCheck.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linkLabelCheck.Location = new System.Drawing.Point(19, 338);
            this.linkLabelCheck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelCheck.Name = "linkLabelCheck";
            this.linkLabelCheck.Size = new System.Drawing.Size(94, 23);
            this.linkLabelCheck.TabIndex = 14;
            this.linkLabelCheck.TabStop = true;
            this.linkLabelCheck.Text = "Check";
            this.linkLabelCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCheck_Click);
            // 
            // labelCheckResult
            // 
            this.labelCheckResult.Location = new System.Drawing.Point(144, 337);
            this.labelCheckResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCheckResult.Name = "labelCheckResult";
            this.labelCheckResult.Size = new System.Drawing.Size(380, 25);
            this.labelCheckResult.TabIndex = 15;
            // 
            // labelModel
            // 
            this.labelModel.Location = new System.Drawing.Point(19, 106);
            this.labelModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(99, 18);
            this.labelModel.TabIndex = 4;
            this.labelModel.Text = "Model";
            // 
            // comboBoxModels
            // 
            this.comboBoxModels.FormattingEnabled = true;
            this.comboBoxModels.Location = new System.Drawing.Point(144, 104);
            this.comboBoxModels.Name = "comboBoxModels";
            this.comboBoxModels.Size = new System.Drawing.Size(378, 23);
            this.comboBoxModels.TabIndex = 5;
            // 
            // labelTemperature
            // 
            this.labelTemperature.Location = new System.Drawing.Point(285, 146);
            this.labelTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(99, 18);
            this.labelTemperature.TabIndex = 8;
            this.labelTemperature.Text = "Temperature";
            // 
            // labelPrompt
            // 
            this.labelPrompt.Location = new System.Drawing.Point(19, 224);
            this.labelPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrompt.Name = "labelPrompt";
            this.labelPrompt.Size = new System.Drawing.Size(99, 18);
            this.labelPrompt.TabIndex = 12;
            this.labelPrompt.Text = "Prompt";
            // 
            // textBoxPrompt
            // 
            this.textBoxPrompt.Location = new System.Drawing.Point(144, 224);
            this.textBoxPrompt.Multiline = true;
            this.textBoxPrompt.Name = "textBoxPrompt";
            this.textBoxPrompt.Size = new System.Drawing.Size(380, 99);
            this.textBoxPrompt.TabIndex = 13;
            // 
            // labelXApiKey
            // 
            this.labelXApiKey.Location = new System.Drawing.Point(19, 185);
            this.labelXApiKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelXApiKey.Name = "labelXApiKey";
            this.labelXApiKey.Size = new System.Drawing.Size(99, 18);
            this.labelXApiKey.TabIndex = 10;
            this.labelXApiKey.Text = "X Api Key";
            // 
            // labelMaxTokens
            // 
            this.labelMaxTokens.Location = new System.Drawing.Point(19, 146);
            this.labelMaxTokens.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaxTokens.Name = "labelMaxTokens";
            this.labelMaxTokens.Size = new System.Drawing.Size(117, 18);
            this.labelMaxTokens.TabIndex = 6;
            this.labelMaxTokens.Text = "Max Tokens";
            // 
            // textBoxBaseUrl
            // 
            this.textBoxBaseUrl.Location = new System.Drawing.Point(144, 23);
            this.textBoxBaseUrl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxBaseUrl.Name = "textBoxBaseUrl";
            this.textBoxBaseUrl.Size = new System.Drawing.Size(380, 25);
            this.textBoxBaseUrl.TabIndex = 1;
            // 
            // textBoxXApiKey
            // 
            this.textBoxXApiKey.Location = new System.Drawing.Point(144, 182);
            this.textBoxXApiKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxXApiKey.Name = "textBoxXApiKey";
            this.textBoxXApiKey.PasswordChar = '*';
            this.textBoxXApiKey.Size = new System.Drawing.Size(380, 25);
            this.textBoxXApiKey.TabIndex = 11;
            // 
            // numericUpDownTemperature
            // 
            this.numericUpDownTemperature.DecimalPlaces = 1;
            this.numericUpDownTemperature.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTemperature.Location = new System.Drawing.Point(408, 143);
            this.numericUpDownTemperature.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDownTemperature.Name = "numericUpDownTemperature";
            this.numericUpDownTemperature.Size = new System.Drawing.Size(116, 25);
            this.numericUpDownTemperature.TabIndex = 9;
            this.numericUpDownTemperature.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHelp.Location = new System.Drawing.Point(422, 377);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(100, 27);
            this.buttonHelp.TabIndex = 19;
            this.buttonHelp.Text = "&Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(144, 342);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(380, 14);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 16;
            this.progressBar.Visible = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(313, 377);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(103, 27);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(207, 377);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 17;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // numericUpDownMaxTokens
            // 
            this.numericUpDownMaxTokens.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownMaxTokens.Location = new System.Drawing.Point(144, 143);
            this.numericUpDownMaxTokens.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numericUpDownMaxTokens.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMaxTokens.Name = "numericUpDownMaxTokens";
            this.numericUpDownMaxTokens.Size = new System.Drawing.Size(116, 25);
            this.numericUpDownMaxTokens.TabIndex = 7;
            this.numericUpDownMaxTokens.Value = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            // 
            // FormClaude
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(534, 416);
            this.Controls.Add(this.numericUpDownMaxTokens);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.numericUpDownTemperature);
            this.Controls.Add(this.textBoxXApiKey);
            this.Controls.Add(this.labelMaxTokens);
            this.Controls.Add(this.labelXApiKey);
            this.Controls.Add(this.textBoxPrompt);
            this.Controls.Add(this.labelPrompt);
            this.Controls.Add(this.labelTemperature);
            this.Controls.Add(this.comboBoxModels);
            this.Controls.Add(this.labelModel);
            this.Controls.Add(this.labelCheckResult);
            this.Controls.Add(this.linkLabelCheck);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.textBoxBaseUrl);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.labelBaseUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormClaude";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Claude";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTokens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBaseUrl;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.LinkLabel linkLabelCheck;
        private System.Windows.Forms.Label labelCheckResult;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.ComboBox comboBoxModels;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Label labelPrompt;
        private System.Windows.Forms.TextBox textBoxPrompt;
        private System.Windows.Forms.Label labelXApiKey;
        private System.Windows.Forms.Label labelMaxTokens;
        private System.Windows.Forms.TextBox textBoxBaseUrl;
        private System.Windows.Forms.TextBox textBoxXApiKey;
        private System.Windows.Forms.NumericUpDown numericUpDownTemperature;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxTokens;
    }
}