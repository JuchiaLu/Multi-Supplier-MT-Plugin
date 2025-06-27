using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.ProviderdsCommon;
using MultiSupplierMTPlugin.ProviderdsCommon.Forms;

namespace MultiSupplierMTPlugin.Providers.Yandex
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
            this.textBoxKeyOrToken = new System.Windows.Forms.TextBox();
            this.linkLabelKeyOrToken = new System.Windows.Forms.LinkLabel();
            this.labelTyep = new System.Windows.Forms.Label();
            this.radioButtonApiKey = new System.Windows.Forms.RadioButton();
            this.radioButtonIamToken = new System.Windows.Forms.RadioButton();
            this.labelFolderId = new System.Windows.Forms.Label();
            this.labelModel = new System.Windows.Forms.Label();
            this.labelSpeller = new System.Windows.Forms.Label();
            this.textBoxFolderId = new System.Windows.Forms.TextBox();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.radioButtonSpellerEnable = new System.Windows.Forms.RadioButton();
            this.radioButtonSpellerDisable = new System.Windows.Forms.RadioButton();
            this.groupBoxGlossary = new System.Windows.Forms.GroupBox();
            this.radioButtonExactDisable = new System.Windows.Forms.RadioButton();
            this.textBoxGlossaryDelimiter = new System.Windows.Forms.TextBox();
            this.labelGlossaryExact = new System.Windows.Forms.Label();
            this.buttonGlossarySelect = new System.Windows.Forms.Button();
            this.radioButtonExactEnable = new System.Windows.Forms.RadioButton();
            this.textBoxGlossaryFilePath = new System.Windows.Forms.TextBox();
            this.labelGlossaryFilePath = new System.Windows.Forms.Label();
            this.labelGlossaryDelimiter = new System.Windows.Forms.Label();
            this.groupBoxAuthorization = new System.Windows.Forms.GroupBox();
            this.groupBoxOther = new System.Windows.Forms.GroupBox();
            this.commonBottomControl = new MultiSupplierMTPlugin.ProviderdsCommon.Forms.CommonBottomControl();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxGlossary.SuspendLayout();
            this.groupBoxAuthorization.SuspendLayout();
            this.groupBoxOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxKeyOrToken
            // 
            this.textBoxKeyOrToken.Location = new System.Drawing.Point(128, 67);
            this.textBoxKeyOrToken.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxKeyOrToken.Name = "textBoxKeyOrToken";
            this.textBoxKeyOrToken.PasswordChar = '*';
            this.textBoxKeyOrToken.Size = new System.Drawing.Size(372, 25);
            this.textBoxKeyOrToken.TabIndex = 5;
            // 
            // linkLabelKeyOrToken
            // 
            this.linkLabelKeyOrToken.AutoSize = true;
            this.linkLabelKeyOrToken.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelKeyOrToken.Location = new System.Drawing.Point(13, 72);
            this.linkLabelKeyOrToken.Name = "linkLabelKeyOrToken";
            this.linkLabelKeyOrToken.Size = new System.Drawing.Size(95, 15);
            this.linkLabelKeyOrToken.TabIndex = 4;
            this.linkLabelKeyOrToken.TabStop = true;
            this.linkLabelKeyOrToken.Text = "Key | Token";
            this.linkLabelKeyOrToken.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelKeyOrToken_LinkClicked);
            // 
            // labelTyep
            // 
            this.labelTyep.AutoSize = true;
            this.labelTyep.Location = new System.Drawing.Point(13, 31);
            this.labelTyep.Name = "labelTyep";
            this.labelTyep.Size = new System.Drawing.Size(39, 15);
            this.labelTyep.TabIndex = 1;
            this.labelTyep.Text = "Type";
            // 
            // radioButtonApiKey
            // 
            this.radioButtonApiKey.AutoSize = true;
            this.radioButtonApiKey.Location = new System.Drawing.Point(128, 29);
            this.radioButtonApiKey.Name = "radioButtonApiKey";
            this.radioButtonApiKey.Size = new System.Drawing.Size(84, 19);
            this.radioButtonApiKey.TabIndex = 2;
            this.radioButtonApiKey.TabStop = true;
            this.radioButtonApiKey.Text = "API Key";
            this.radioButtonApiKey.UseVisualStyleBackColor = true;
            // 
            // radioButtonIamToken
            // 
            this.radioButtonIamToken.AutoSize = true;
            this.radioButtonIamToken.Location = new System.Drawing.Point(334, 29);
            this.radioButtonIamToken.Name = "radioButtonIamToken";
            this.radioButtonIamToken.Size = new System.Drawing.Size(100, 19);
            this.radioButtonIamToken.TabIndex = 3;
            this.radioButtonIamToken.TabStop = true;
            this.radioButtonIamToken.Text = "IAM Token";
            this.radioButtonIamToken.UseVisualStyleBackColor = true;
            // 
            // labelFolderId
            // 
            this.labelFolderId.AutoSize = true;
            this.labelFolderId.Location = new System.Drawing.Point(13, 120);
            this.labelFolderId.Name = "labelFolderId";
            this.labelFolderId.Size = new System.Drawing.Size(79, 15);
            this.labelFolderId.TabIndex = 6;
            this.labelFolderId.Text = "Folder Id";
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(13, 81);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(47, 15);
            this.labelModel.TabIndex = 21;
            this.labelModel.Text = "Model";
            // 
            // labelSpeller
            // 
            this.labelSpeller.AutoSize = true;
            this.labelSpeller.Location = new System.Drawing.Point(13, 35);
            this.labelSpeller.Name = "labelSpeller";
            this.labelSpeller.Size = new System.Drawing.Size(63, 15);
            this.labelSpeller.TabIndex = 18;
            this.labelSpeller.Text = "Speller";
            // 
            // textBoxFolderId
            // 
            this.textBoxFolderId.Location = new System.Drawing.Point(128, 115);
            this.textBoxFolderId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxFolderId.Name = "textBoxFolderId";
            this.textBoxFolderId.Size = new System.Drawing.Size(372, 25);
            this.textBoxFolderId.TabIndex = 7;
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(128, 76);
            this.textBoxModel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(372, 25);
            this.textBoxModel.TabIndex = 22;
            // 
            // radioButtonSpellerEnable
            // 
            this.radioButtonSpellerEnable.AutoSize = true;
            this.radioButtonSpellerEnable.Location = new System.Drawing.Point(128, 33);
            this.radioButtonSpellerEnable.Name = "radioButtonSpellerEnable";
            this.radioButtonSpellerEnable.Size = new System.Drawing.Size(76, 19);
            this.radioButtonSpellerEnable.TabIndex = 19;
            this.radioButtonSpellerEnable.TabStop = true;
            this.radioButtonSpellerEnable.Text = "Enable";
            this.radioButtonSpellerEnable.UseVisualStyleBackColor = true;
            // 
            // radioButtonSpellerDisable
            // 
            this.radioButtonSpellerDisable.AutoSize = true;
            this.radioButtonSpellerDisable.Location = new System.Drawing.Point(334, 33);
            this.radioButtonSpellerDisable.Name = "radioButtonSpellerDisable";
            this.radioButtonSpellerDisable.Size = new System.Drawing.Size(84, 19);
            this.radioButtonSpellerDisable.TabIndex = 20;
            this.radioButtonSpellerDisable.TabStop = true;
            this.radioButtonSpellerDisable.Text = "Disable";
            this.radioButtonSpellerDisable.UseVisualStyleBackColor = true;
            // 
            // groupBoxGlossary
            // 
            this.groupBoxGlossary.Controls.Add(this.radioButtonExactDisable);
            this.groupBoxGlossary.Controls.Add(this.textBoxGlossaryDelimiter);
            this.groupBoxGlossary.Controls.Add(this.labelGlossaryExact);
            this.groupBoxGlossary.Controls.Add(this.buttonGlossarySelect);
            this.groupBoxGlossary.Controls.Add(this.radioButtonExactEnable);
            this.groupBoxGlossary.Controls.Add(this.textBoxGlossaryFilePath);
            this.groupBoxGlossary.Controls.Add(this.labelGlossaryFilePath);
            this.groupBoxGlossary.Controls.Add(this.labelGlossaryDelimiter);
            this.groupBoxGlossary.Location = new System.Drawing.Point(9, 215);
            this.groupBoxGlossary.Name = "groupBoxGlossary";
            this.groupBoxGlossary.Size = new System.Drawing.Size(516, 167);
            this.groupBoxGlossary.TabIndex = 8;
            this.groupBoxGlossary.TabStop = false;
            this.groupBoxGlossary.Text = "Glossary";
            // 
            // radioButtonExactDisable
            // 
            this.radioButtonExactDisable.AutoSize = true;
            this.radioButtonExactDisable.Location = new System.Drawing.Point(334, 30);
            this.radioButtonExactDisable.Name = "radioButtonExactDisable";
            this.radioButtonExactDisable.Size = new System.Drawing.Size(84, 19);
            this.radioButtonExactDisable.TabIndex = 11;
            this.radioButtonExactDisable.TabStop = true;
            this.radioButtonExactDisable.Text = "Disable";
            this.radioButtonExactDisable.UseVisualStyleBackColor = true;
            // 
            // textBoxGlossaryDelimiter
            // 
            this.textBoxGlossaryDelimiter.Location = new System.Drawing.Point(128, 69);
            this.textBoxGlossaryDelimiter.MaxLength = 1;
            this.textBoxGlossaryDelimiter.Name = "textBoxGlossaryDelimiter";
            this.textBoxGlossaryDelimiter.Size = new System.Drawing.Size(372, 25);
            this.textBoxGlossaryDelimiter.TabIndex = 13;
            // 
            // labelGlossaryExact
            // 
            this.labelGlossaryExact.AutoSize = true;
            this.labelGlossaryExact.Location = new System.Drawing.Point(13, 32);
            this.labelGlossaryExact.Name = "labelGlossaryExact";
            this.labelGlossaryExact.Size = new System.Drawing.Size(47, 15);
            this.labelGlossaryExact.TabIndex = 9;
            this.labelGlossaryExact.Text = "Exact";
            // 
            // buttonGlossarySelect
            // 
            this.buttonGlossarySelect.Location = new System.Drawing.Point(425, 119);
            this.buttonGlossarySelect.Name = "buttonGlossarySelect";
            this.buttonGlossarySelect.Size = new System.Drawing.Size(75, 27);
            this.buttonGlossarySelect.TabIndex = 16;
            this.buttonGlossarySelect.Text = "Select";
            this.buttonGlossarySelect.UseVisualStyleBackColor = true;
            this.buttonGlossarySelect.Click += new System.EventHandler(this.buttonGlossarySelect_Click);
            // 
            // radioButtonExactEnable
            // 
            this.radioButtonExactEnable.AutoSize = true;
            this.radioButtonExactEnable.Location = new System.Drawing.Point(128, 30);
            this.radioButtonExactEnable.Name = "radioButtonExactEnable";
            this.radioButtonExactEnable.Size = new System.Drawing.Size(76, 19);
            this.radioButtonExactEnable.TabIndex = 10;
            this.radioButtonExactEnable.TabStop = true;
            this.radioButtonExactEnable.Text = "Enable";
            this.radioButtonExactEnable.UseVisualStyleBackColor = true;
            // 
            // textBoxGlossaryFilePath
            // 
            this.textBoxGlossaryFilePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxGlossaryFilePath.Location = new System.Drawing.Point(128, 120);
            this.textBoxGlossaryFilePath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxGlossaryFilePath.Name = "textBoxGlossaryFilePath";
            this.textBoxGlossaryFilePath.Size = new System.Drawing.Size(290, 25);
            this.textBoxGlossaryFilePath.TabIndex = 15;
            // 
            // labelGlossaryFilePath
            // 
            this.labelGlossaryFilePath.AutoSize = true;
            this.labelGlossaryFilePath.Location = new System.Drawing.Point(13, 125);
            this.labelGlossaryFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGlossaryFilePath.Name = "labelGlossaryFilePath";
            this.labelGlossaryFilePath.Size = new System.Drawing.Size(79, 15);
            this.labelGlossaryFilePath.TabIndex = 14;
            this.labelGlossaryFilePath.Text = "File Path";
            // 
            // labelGlossaryDelimiter
            // 
            this.labelGlossaryDelimiter.AutoSize = true;
            this.labelGlossaryDelimiter.Location = new System.Drawing.Point(13, 74);
            this.labelGlossaryDelimiter.Name = "labelGlossaryDelimiter";
            this.labelGlossaryDelimiter.Size = new System.Drawing.Size(79, 15);
            this.labelGlossaryDelimiter.TabIndex = 12;
            this.labelGlossaryDelimiter.Text = "Delimiter";
            // 
            // groupBoxAuthorization
            // 
            this.groupBoxAuthorization.Controls.Add(this.linkLabelKeyOrToken);
            this.groupBoxAuthorization.Controls.Add(this.labelFolderId);
            this.groupBoxAuthorization.Controls.Add(this.labelTyep);
            this.groupBoxAuthorization.Controls.Add(this.radioButtonApiKey);
            this.groupBoxAuthorization.Controls.Add(this.textBoxKeyOrToken);
            this.groupBoxAuthorization.Controls.Add(this.radioButtonIamToken);
            this.groupBoxAuthorization.Controls.Add(this.textBoxFolderId);
            this.groupBoxAuthorization.Location = new System.Drawing.Point(9, 21);
            this.groupBoxAuthorization.Name = "groupBoxAuthorization";
            this.groupBoxAuthorization.Size = new System.Drawing.Size(516, 165);
            this.groupBoxAuthorization.TabIndex = 0;
            this.groupBoxAuthorization.TabStop = false;
            this.groupBoxAuthorization.Text = "Authorization";
            // 
            // groupBoxOther
            // 
            this.groupBoxOther.Controls.Add(this.textBoxModel);
            this.groupBoxOther.Controls.Add(this.labelModel);
            this.groupBoxOther.Controls.Add(this.radioButtonSpellerDisable);
            this.groupBoxOther.Controls.Add(this.labelSpeller);
            this.groupBoxOther.Controls.Add(this.radioButtonSpellerEnable);
            this.groupBoxOther.Location = new System.Drawing.Point(9, 410);
            this.groupBoxOther.Name = "groupBoxOther";
            this.groupBoxOther.Size = new System.Drawing.Size(516, 126);
            this.groupBoxOther.TabIndex = 17;
            this.groupBoxOther.TabStop = false;
            this.groupBoxOther.Text = "Other";
            // 
            // commonBottomControl
            // 
            this.commonBottomControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commonBottomControl.ButtonOkState = true;
            this.commonBottomControl.FailedDetailsMsg = null;
            this.commonBottomControl.Location = new System.Drawing.Point(25, 545);
            this.commonBottomControl.Name = "commonBottomControl";
            this.commonBottomControl.Size = new System.Drawing.Size(500, 75);
            this.commonBottomControl.TabIndex = 23;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 100;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 629);
            this.Controls.Add(this.commonBottomControl);
            this.Controls.Add(this.groupBoxOther);
            this.Controls.Add(this.groupBoxAuthorization);
            this.Controls.Add(this.groupBoxGlossary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yandex";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.groupBoxGlossary.ResumeLayout(false);
            this.groupBoxGlossary.PerformLayout();
            this.groupBoxAuthorization.ResumeLayout(false);
            this.groupBoxAuthorization.PerformLayout();
            this.groupBoxOther.ResumeLayout(false);
            this.groupBoxOther.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxKeyOrToken;
        private System.Windows.Forms.LinkLabel linkLabelKeyOrToken;
        private System.Windows.Forms.Label labelTyep;
        private System.Windows.Forms.RadioButton radioButtonApiKey;
        private System.Windows.Forms.RadioButton radioButtonIamToken;
        private System.Windows.Forms.Label labelFolderId;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.Label labelSpeller;
        private System.Windows.Forms.TextBox textBoxFolderId;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.RadioButton radioButtonSpellerEnable;
        private System.Windows.Forms.RadioButton radioButtonSpellerDisable;
        private System.Windows.Forms.GroupBox groupBoxGlossary;
        private System.Windows.Forms.TextBox textBoxGlossaryDelimiter;
        private System.Windows.Forms.Button buttonGlossarySelect;
        private System.Windows.Forms.TextBox textBoxGlossaryFilePath;
        private System.Windows.Forms.Label labelGlossaryFilePath;
        private System.Windows.Forms.Label labelGlossaryDelimiter;
        private System.Windows.Forms.GroupBox groupBoxAuthorization;
        private System.Windows.Forms.GroupBox groupBoxOther;
        private System.Windows.Forms.RadioButton radioButtonExactDisable;
        private System.Windows.Forms.Label labelGlossaryExact;
        private System.Windows.Forms.RadioButton radioButtonExactEnable;
        private CommonBottomControl commonBottomControl;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
    }
}