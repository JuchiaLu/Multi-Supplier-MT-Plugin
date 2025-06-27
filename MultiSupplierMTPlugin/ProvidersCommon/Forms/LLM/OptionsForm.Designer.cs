using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.ProviderdsCommon;
using MultiSupplierMTPlugin.ProviderdsCommon.Forms;

namespace MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM
{
    partial class OptionsForm
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
            this.labelBaseUrl = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.comboBoxModels = new System.Windows.Forms.ComboBox();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.labelSystemPrompt = new System.Windows.Forms.Label();
            this.textBoxSystemPrompt = new System.Windows.Forms.TextBox();
            this.textBoxBaseUrl = new System.Windows.Forms.TextBox();
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.textBoxOrganization = new System.Windows.Forms.TextBox();
            this.numericUpDownTemperature = new System.Windows.Forms.NumericUpDown();
            this.textBoxUserPrompt = new System.Windows.Forms.TextBox();
            this.labelUserPrompt = new System.Windows.Forms.Label();
            this.linkLabelMoreSettings = new System.Windows.Forms.LinkLabel();
            this.linkLabelModel = new System.Windows.Forms.LinkLabel();
            this.linkLabelApiKey = new System.Windows.Forms.LinkLabel();
            this.numericUpDownMaxTokens = new System.Windows.Forms.NumericUpDown();
            this.labelMaxTokens = new System.Windows.Forms.Label();
            this.buttonListModels = new System.Windows.Forms.Button();
            this.labelPromptTemplate = new System.Windows.Forms.Label();
            this.comboBoxPromptTemplate = new System.Windows.Forms.ComboBox();
            this.buttonManage = new System.Windows.Forms.Button();
            this.checkBoxBathTranslate = new System.Windows.Forms.CheckBox();
            this.labelOrganization = new System.Windows.Forms.Label();
            this.linkLabelBathTranslate = new System.Windows.Forms.LinkLabel();
            this.labelOtherOptions = new System.Windows.Forms.Label();
            this.commonBottomControl = new MultiSupplierMTPlugin.ProviderdsCommon.Forms.CommonBottomControl();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTokens)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBaseUrl
            // 
            this.labelBaseUrl.Location = new System.Drawing.Point(11, 15);
            this.labelBaseUrl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBaseUrl.Name = "labelBaseUrl";
            this.labelBaseUrl.Size = new System.Drawing.Size(130, 18);
            this.labelBaseUrl.TabIndex = 0;
            this.labelBaseUrl.Text = "Base Url";
            // 
            // labelPath
            // 
            this.labelPath.Location = new System.Drawing.Point(11, 55);
            this.labelPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(130, 18);
            this.labelPath.TabIndex = 2;
            this.labelPath.Text = "Path";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(148, 52);
            this.textBoxPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(380, 25);
            this.textBoxPath.TabIndex = 3;
            // 
            // comboBoxModels
            // 
            this.comboBoxModels.FormattingEnabled = true;
            this.comboBoxModels.Location = new System.Drawing.Point(148, 211);
            this.comboBoxModels.Name = "comboBoxModels";
            this.comboBoxModels.Size = new System.Drawing.Size(299, 23);
            this.comboBoxModels.TabIndex = 13;
            // 
            // labelTemperature
            // 
            this.labelTemperature.Location = new System.Drawing.Point(306, 93);
            this.labelTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(99, 18);
            this.labelTemperature.TabIndex = 6;
            this.labelTemperature.Text = "Temperature";
            this.labelTemperature.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelSystemPrompt
            // 
            this.labelSystemPrompt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelSystemPrompt.Location = new System.Drawing.Point(11, 291);
            this.labelSystemPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSystemPrompt.Name = "labelSystemPrompt";
            this.labelSystemPrompt.Size = new System.Drawing.Size(130, 18);
            this.labelSystemPrompt.TabIndex = 18;
            this.labelSystemPrompt.Text = "System Prompt^";
            // 
            // textBoxSystemPrompt
            // 
            this.textBoxSystemPrompt.AcceptsReturn = true;
            this.textBoxSystemPrompt.AcceptsTab = true;
            this.textBoxSystemPrompt.Location = new System.Drawing.Point(148, 291);
            this.textBoxSystemPrompt.Multiline = true;
            this.textBoxSystemPrompt.Name = "textBoxSystemPrompt";
            this.textBoxSystemPrompt.Size = new System.Drawing.Size(380, 99);
            this.textBoxSystemPrompt.TabIndex = 19;
            this.textBoxSystemPrompt.WordWrap = false;
            this.textBoxSystemPrompt.TextChanged += new System.EventHandler(this.textBoxSystemPrompt_TextChanged);
            // 
            // textBoxBaseUrl
            // 
            this.textBoxBaseUrl.Location = new System.Drawing.Point(148, 12);
            this.textBoxBaseUrl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxBaseUrl.Name = "textBoxBaseUrl";
            this.textBoxBaseUrl.Size = new System.Drawing.Size(380, 25);
            this.textBoxBaseUrl.TabIndex = 1;
            // 
            // textBoxApiKey
            // 
            this.textBoxApiKey.Location = new System.Drawing.Point(148, 171);
            this.textBoxApiKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.PasswordChar = '*';
            this.textBoxApiKey.Size = new System.Drawing.Size(379, 25);
            this.textBoxApiKey.TabIndex = 11;
            // 
            // textBoxOrganization
            // 
            this.textBoxOrganization.Location = new System.Drawing.Point(147, 131);
            this.textBoxOrganization.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxOrganization.Name = "textBoxOrganization";
            this.textBoxOrganization.Size = new System.Drawing.Size(381, 25);
            this.textBoxOrganization.TabIndex = 9;
            // 
            // numericUpDownTemperature
            // 
            this.numericUpDownTemperature.DecimalPlaces = 1;
            this.numericUpDownTemperature.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTemperature.Location = new System.Drawing.Point(412, 90);
            this.numericUpDownTemperature.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownTemperature.Name = "numericUpDownTemperature";
            this.numericUpDownTemperature.Size = new System.Drawing.Size(116, 25);
            this.numericUpDownTemperature.TabIndex = 7;
            this.numericUpDownTemperature.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            // 
            // textBoxUserPrompt
            // 
            this.textBoxUserPrompt.AcceptsReturn = true;
            this.textBoxUserPrompt.AcceptsTab = true;
            this.textBoxUserPrompt.Location = new System.Drawing.Point(148, 406);
            this.textBoxUserPrompt.Multiline = true;
            this.textBoxUserPrompt.Name = "textBoxUserPrompt";
            this.textBoxUserPrompt.Size = new System.Drawing.Size(380, 99);
            this.textBoxUserPrompt.TabIndex = 21;
            this.textBoxUserPrompt.WordWrap = false;
            this.textBoxUserPrompt.TextChanged += new System.EventHandler(this.textBoxUserPrompt_TextChanged);
            // 
            // labelUserPrompt
            // 
            this.labelUserPrompt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelUserPrompt.Location = new System.Drawing.Point(10, 406);
            this.labelUserPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUserPrompt.Name = "labelUserPrompt";
            this.labelUserPrompt.Size = new System.Drawing.Size(130, 18);
            this.labelUserPrompt.TabIndex = 20;
            this.labelUserPrompt.Text = "User Prompt^";
            // 
            // linkLabelMoreSettings
            // 
            this.linkLabelMoreSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelMoreSettings.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelMoreSettings.Location = new System.Drawing.Point(416, 526);
            this.linkLabelMoreSettings.Name = "linkLabelMoreSettings";
            this.linkLabelMoreSettings.Size = new System.Drawing.Size(111, 15);
            this.linkLabelMoreSettings.TabIndex = 25;
            this.linkLabelMoreSettings.TabStop = true;
            this.linkLabelMoreSettings.Text = "More Settings";
            this.linkLabelMoreSettings.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.linkLabelMoreSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMoreSettings_LinkClicked);
            // 
            // linkLabelModel
            // 
            this.linkLabelModel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelModel.Location = new System.Drawing.Point(11, 215);
            this.linkLabelModel.Name = "linkLabelModel";
            this.linkLabelModel.Size = new System.Drawing.Size(130, 15);
            this.linkLabelModel.TabIndex = 12;
            this.linkLabelModel.TabStop = true;
            this.linkLabelModel.Text = "Model";
            this.linkLabelModel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelModel_LinkClicked);
            // 
            // linkLabelApiKey
            // 
            this.linkLabelApiKey.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelApiKey.Location = new System.Drawing.Point(11, 176);
            this.linkLabelApiKey.Name = "linkLabelApiKey";
            this.linkLabelApiKey.Size = new System.Drawing.Size(130, 15);
            this.linkLabelApiKey.TabIndex = 10;
            this.linkLabelApiKey.TabStop = true;
            this.linkLabelApiKey.Text = "Api Key";
            this.linkLabelApiKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelApiKey_LinkClicked);
            // 
            // numericUpDownMaxTokens
            // 
            this.numericUpDownMaxTokens.Increment = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownMaxTokens.Location = new System.Drawing.Point(148, 90);
            this.numericUpDownMaxTokens.Maximum = new decimal(new int[] {
            64000,
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
            this.numericUpDownMaxTokens.TabIndex = 5;
            this.numericUpDownMaxTokens.Value = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            // 
            // labelMaxTokens
            // 
            this.labelMaxTokens.Location = new System.Drawing.Point(11, 93);
            this.labelMaxTokens.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaxTokens.Name = "labelMaxTokens";
            this.labelMaxTokens.Size = new System.Drawing.Size(130, 18);
            this.labelMaxTokens.TabIndex = 4;
            this.labelMaxTokens.Text = "Max Tokens";
            // 
            // buttonListModels
            // 
            this.buttonListModels.Location = new System.Drawing.Point(454, 210);
            this.buttonListModels.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonListModels.Name = "buttonListModels";
            this.buttonListModels.Size = new System.Drawing.Size(74, 25);
            this.buttonListModels.TabIndex = 14;
            this.buttonListModels.Text = "&List";
            this.buttonListModels.UseVisualStyleBackColor = true;
            this.buttonListModels.Click += new System.EventHandler(this.buttonListModels_Click);
            // 
            // labelPromptTemplate
            // 
            this.labelPromptTemplate.Location = new System.Drawing.Point(11, 252);
            this.labelPromptTemplate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPromptTemplate.Name = "labelPromptTemplate";
            this.labelPromptTemplate.Size = new System.Drawing.Size(130, 18);
            this.labelPromptTemplate.TabIndex = 15;
            this.labelPromptTemplate.Text = "Prompt Templace";
            // 
            // comboBoxPromptTemplate
            // 
            this.comboBoxPromptTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPromptTemplate.FormattingEnabled = true;
            this.comboBoxPromptTemplate.Location = new System.Drawing.Point(149, 250);
            this.comboBoxPromptTemplate.Name = "comboBoxPromptTemplate";
            this.comboBoxPromptTemplate.Size = new System.Drawing.Size(298, 23);
            this.comboBoxPromptTemplate.TabIndex = 16;
            this.comboBoxPromptTemplate.SelectedIndexChanged += new System.EventHandler(this.comboBoxPromptTemplate_SelectedIndexChanged);
            // 
            // buttonManage
            // 
            this.buttonManage.Location = new System.Drawing.Point(454, 247);
            this.buttonManage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonManage.Name = "buttonManage";
            this.buttonManage.Size = new System.Drawing.Size(74, 27);
            this.buttonManage.TabIndex = 17;
            this.buttonManage.Text = "&Manage";
            this.buttonManage.UseVisualStyleBackColor = true;
            this.buttonManage.Click += new System.EventHandler(this.buttonManage_Click);
            // 
            // checkBoxBathTranslate
            // 
            this.checkBoxBathTranslate.AutoSize = true;
            this.checkBoxBathTranslate.Location = new System.Drawing.Point(149, 524);
            this.checkBoxBathTranslate.Name = "checkBoxBathTranslate";
            this.checkBoxBathTranslate.Size = new System.Drawing.Size(18, 17);
            this.checkBoxBathTranslate.TabIndex = 23;
            this.checkBoxBathTranslate.CheckedChanged += new System.EventHandler(this.checkBoxBathTranslate_CheckedChanged);
            // 
            // labelOrganization
            // 
            this.labelOrganization.Location = new System.Drawing.Point(11, 134);
            this.labelOrganization.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOrganization.Name = "labelOrganization";
            this.labelOrganization.Size = new System.Drawing.Size(130, 18);
            this.labelOrganization.TabIndex = 8;
            this.labelOrganization.Text = "Organization";
            // 
            // linkLabelBathTranslate
            // 
            this.linkLabelBathTranslate.AutoSize = true;
            this.linkLabelBathTranslate.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelBathTranslate.Location = new System.Drawing.Point(171, 525);
            this.linkLabelBathTranslate.Name = "linkLabelBathTranslate";
            this.linkLabelBathTranslate.Size = new System.Drawing.Size(119, 15);
            this.linkLabelBathTranslate.TabIndex = 24;
            this.linkLabelBathTranslate.TabStop = true;
            this.linkLabelBathTranslate.Text = "Bath Translate";
            this.linkLabelBathTranslate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBathTranslate_LinkClicked);
            // 
            // labelOtherOptions
            // 
            this.labelOtherOptions.AutoSize = true;
            this.labelOtherOptions.Location = new System.Drawing.Point(12, 526);
            this.labelOtherOptions.Name = "labelOtherOptions";
            this.labelOtherOptions.Size = new System.Drawing.Size(111, 15);
            this.labelOtherOptions.TabIndex = 22;
            this.labelOtherOptions.Text = "Other Options";
            // 
            // commonBottomControl
            // 
            this.commonBottomControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commonBottomControl.ButtonOkState = true;
            this.commonBottomControl.FailedDetailsMsg = null;
            this.commonBottomControl.Location = new System.Drawing.Point(15, 556);
            this.commonBottomControl.Name = "commonBottomControl";
            this.commonBottomControl.Size = new System.Drawing.Size(513, 75);
            this.commonBottomControl.TabIndex = 26;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 639);
            this.Controls.Add(this.labelOtherOptions);
            this.Controls.Add(this.linkLabelBathTranslate);
            this.Controls.Add(this.commonBottomControl);
            this.Controls.Add(this.labelOrganization);
            this.Controls.Add(this.checkBoxBathTranslate);
            this.Controls.Add(this.buttonManage);
            this.Controls.Add(this.comboBoxPromptTemplate);
            this.Controls.Add(this.labelPromptTemplate);
            this.Controls.Add(this.buttonListModels);
            this.Controls.Add(this.numericUpDownMaxTokens);
            this.Controls.Add(this.labelMaxTokens);
            this.Controls.Add(this.linkLabelApiKey);
            this.Controls.Add(this.linkLabelModel);
            this.Controls.Add(this.textBoxUserPrompt);
            this.Controls.Add(this.labelUserPrompt);
            this.Controls.Add(this.numericUpDownTemperature);
            this.Controls.Add(this.textBoxOrganization);
            this.Controls.Add(this.textBoxApiKey);
            this.Controls.Add(this.labelSystemPrompt);
            this.Controls.Add(this.labelTemperature);
            this.Controls.Add(this.comboBoxModels);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.textBoxBaseUrl);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.labelBaseUrl);
            this.Controls.Add(this.linkLabelMoreSettings);
            this.Controls.Add(this.textBoxSystemPrompt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LLM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTokens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBaseUrl;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.ComboBox comboBoxModels;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Label labelSystemPrompt;
        private System.Windows.Forms.TextBox textBoxSystemPrompt;
        private System.Windows.Forms.TextBox textBoxBaseUrl;
        private System.Windows.Forms.TextBox textBoxApiKey;
        private System.Windows.Forms.TextBox textBoxOrganization;
        private System.Windows.Forms.NumericUpDown numericUpDownTemperature;
        private System.Windows.Forms.TextBox textBoxUserPrompt;
        private System.Windows.Forms.Label labelUserPrompt;
        private System.Windows.Forms.LinkLabel linkLabelMoreSettings;
        private System.Windows.Forms.LinkLabel linkLabelModel;
        private System.Windows.Forms.LinkLabel linkLabelApiKey;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxTokens;
        private System.Windows.Forms.Label labelMaxTokens;
        private System.Windows.Forms.Button buttonListModels;
        private System.Windows.Forms.Label labelPromptTemplate;
        private System.Windows.Forms.ComboBox comboBoxPromptTemplate;
        private System.Windows.Forms.Button buttonManage;
        private System.Windows.Forms.CheckBox checkBoxBathTranslate;
        private System.Windows.Forms.Label labelOrganization;
        private CommonBottomControl commonBottomControl;
        private System.Windows.Forms.LinkLabel linkLabelBathTranslate;
        private System.Windows.Forms.Label labelOtherOptions;
        private System.Windows.Forms.ToolTip toolTip;
    }
}