namespace MultiSupplierMTPlugin
{
    partial class MultiSupplierMTOptionsForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxRequestType = new System.Windows.Forms.ComboBox();
            this.labelRequestType = new System.Windows.Forms.Label();
            this.labelServiceProvider = new System.Windows.Forms.Label();
            this.comboBoxServiceProvider = new System.Windows.Forms.ComboBox();
            this.checkBoxTranslateCache = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBoxNormalizeWhitespace = new System.Windows.Forms.CheckBox();
            this.checkBoxTagsToEnd = new System.Windows.Forms.CheckBox();
            this.checkBoxCustomRequestLimit = new System.Windows.Forms.CheckBox();
            this.linkLabelCustomRequestLimit = new System.Windows.Forms.LinkLabel();
            this.linkLabelCustomDisplayName = new System.Windows.Forms.LinkLabel();
            this.checkBoxCustomDisplayName = new System.Windows.Forms.CheckBox();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.linkLabelTranslateCache = new System.Windows.Forms.LinkLabel();
            this.linkLabelStatsAndLog = new System.Windows.Forms.LinkLabel();
            this.checkBoxStatsAndLog = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(288, 270);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 14;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(395, 270);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 27);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxRequestType
            // 
            this.comboBoxRequestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRequestType.FormattingEnabled = true;
            this.comboBoxRequestType.Location = new System.Drawing.Point(215, 75);
            this.comboBoxRequestType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxRequestType.Name = "comboBoxRequestType";
            this.comboBoxRequestType.Size = new System.Drawing.Size(380, 23);
            this.comboBoxRequestType.TabIndex = 3;
            this.comboBoxRequestType.SelectedIndexChanged += new System.EventHandler(this.comboBoxRequestType_SelectedIndexChanged);
            // 
            // labelRequestType
            // 
            this.labelRequestType.Location = new System.Drawing.Point(14, 80);
            this.labelRequestType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRequestType.Name = "labelRequestType";
            this.labelRequestType.Size = new System.Drawing.Size(165, 18);
            this.labelRequestType.TabIndex = 2;
            this.labelRequestType.Text = "Request Type";
            // 
            // labelServiceProvider
            // 
            this.labelServiceProvider.Location = new System.Drawing.Point(14, 28);
            this.labelServiceProvider.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelServiceProvider.Name = "labelServiceProvider";
            this.labelServiceProvider.Size = new System.Drawing.Size(203, 18);
            this.labelServiceProvider.TabIndex = 0;
            this.labelServiceProvider.Text = "Service Provider";
            // 
            // comboBoxServiceProvider
            // 
            this.comboBoxServiceProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServiceProvider.FormattingEnabled = true;
            this.comboBoxServiceProvider.Location = new System.Drawing.Point(215, 25);
            this.comboBoxServiceProvider.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxServiceProvider.Name = "comboBoxServiceProvider";
            this.comboBoxServiceProvider.Size = new System.Drawing.Size(380, 23);
            this.comboBoxServiceProvider.TabIndex = 1;
            // 
            // checkBoxTranslateCache
            // 
            this.checkBoxTranslateCache.AutoSize = true;
            this.checkBoxTranslateCache.Location = new System.Drawing.Point(312, 216);
            this.checkBoxTranslateCache.Name = "checkBoxTranslateCache";
            this.checkBoxTranslateCache.Size = new System.Drawing.Size(18, 17);
            this.checkBoxTranslateCache.TabIndex = 12;
            this.checkBoxTranslateCache.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(570, 337);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(570, 337);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBoxNormalizeWhitespace
            // 
            this.checkBoxNormalizeWhitespace.AutoSize = true;
            this.checkBoxNormalizeWhitespace.Location = new System.Drawing.Point(312, 124);
            this.checkBoxNormalizeWhitespace.Name = "checkBoxNormalizeWhitespace";
            this.checkBoxNormalizeWhitespace.Size = new System.Drawing.Size(285, 19);
            this.checkBoxNormalizeWhitespace.TabIndex = 5;
            this.checkBoxNormalizeWhitespace.Text = "Normalize Whitespace Around Tags";
            this.checkBoxNormalizeWhitespace.UseVisualStyleBackColor = true;
            // 
            // checkBoxTagsToEnd
            // 
            this.checkBoxTagsToEnd.AutoSize = true;
            this.checkBoxTagsToEnd.Location = new System.Drawing.Point(12, 124);
            this.checkBoxTagsToEnd.Name = "checkBoxTagsToEnd";
            this.checkBoxTagsToEnd.Size = new System.Drawing.Size(245, 19);
            this.checkBoxTagsToEnd.TabIndex = 4;
            this.checkBoxTagsToEnd.Text = "Insert Required Tags To End";
            this.checkBoxTagsToEnd.UseVisualStyleBackColor = true;
            // 
            // checkBoxCustomRequestLimit
            // 
            this.checkBoxCustomRequestLimit.AutoSize = true;
            this.checkBoxCustomRequestLimit.Location = new System.Drawing.Point(12, 171);
            this.checkBoxCustomRequestLimit.Name = "checkBoxCustomRequestLimit";
            this.checkBoxCustomRequestLimit.Size = new System.Drawing.Size(18, 17);
            this.checkBoxCustomRequestLimit.TabIndex = 6;
            this.checkBoxCustomRequestLimit.UseVisualStyleBackColor = true;
            // 
            // linkLabelCustomRequestLimit
            // 
            this.linkLabelCustomRequestLimit.AutoSize = true;
            this.linkLabelCustomRequestLimit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelCustomRequestLimit.Location = new System.Drawing.Point(33, 171);
            this.linkLabelCustomRequestLimit.Name = "linkLabelCustomRequestLimit";
            this.linkLabelCustomRequestLimit.Size = new System.Drawing.Size(223, 15);
            this.linkLabelCustomRequestLimit.TabIndex = 7;
            this.linkLabelCustomRequestLimit.TabStop = true;
            this.linkLabelCustomRequestLimit.Text = "Enable Custom Request Limit";
            this.linkLabelCustomRequestLimit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCustomRequestLimit_LinkClicked);
            // 
            // linkLabelCustomDisplayName
            // 
            this.linkLabelCustomDisplayName.AutoSize = true;
            this.linkLabelCustomDisplayName.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelCustomDisplayName.Location = new System.Drawing.Point(333, 171);
            this.linkLabelCustomDisplayName.Name = "linkLabelCustomDisplayName";
            this.linkLabelCustomDisplayName.Size = new System.Drawing.Size(215, 15);
            this.linkLabelCustomDisplayName.TabIndex = 9;
            this.linkLabelCustomDisplayName.TabStop = true;
            this.linkLabelCustomDisplayName.Text = "Enable Custom Display Name";
            this.linkLabelCustomDisplayName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCustomDisplayName_LinkClicked);
            // 
            // checkBoxCustomDisplayName
            // 
            this.checkBoxCustomDisplayName.AutoSize = true;
            this.checkBoxCustomDisplayName.Location = new System.Drawing.Point(312, 171);
            this.checkBoxCustomDisplayName.Name = "checkBoxCustomDisplayName";
            this.checkBoxCustomDisplayName.Size = new System.Drawing.Size(18, 17);
            this.checkBoxCustomDisplayName.TabIndex = 8;
            this.checkBoxCustomDisplayName.UseVisualStyleBackColor = true;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHelp.Location = new System.Drawing.Point(502, 270);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(100, 27);
            this.buttonHelp.TabIndex = 16;
            this.buttonHelp.Text = "&Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // linkLabelTranslateCache
            // 
            this.linkLabelTranslateCache.AutoSize = true;
            this.linkLabelTranslateCache.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelTranslateCache.Location = new System.Drawing.Point(333, 216);
            this.linkLabelTranslateCache.Name = "linkLabelTranslateCache";
            this.linkLabelTranslateCache.Size = new System.Drawing.Size(183, 15);
            this.linkLabelTranslateCache.TabIndex = 13;
            this.linkLabelTranslateCache.TabStop = true;
            this.linkLabelTranslateCache.Text = "Enable Translate Cache";
            this.linkLabelTranslateCache.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelTranslateCache_LinkClicked);
            // 
            // linkLabelStatsAndLog
            // 
            this.linkLabelStatsAndLog.AutoSize = true;
            this.linkLabelStatsAndLog.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelStatsAndLog.Location = new System.Drawing.Point(33, 216);
            this.linkLabelStatsAndLog.Name = "linkLabelStatsAndLog";
            this.linkLabelStatsAndLog.Size = new System.Drawing.Size(167, 15);
            this.linkLabelStatsAndLog.TabIndex = 11;
            this.linkLabelStatsAndLog.TabStop = true;
            this.linkLabelStatsAndLog.Text = "Enable Stats And Log";
            this.linkLabelStatsAndLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelStatsAndLog_LinkClicked);
            // 
            // checkBoxStatsAndLog
            // 
            this.checkBoxStatsAndLog.AutoSize = true;
            this.checkBoxStatsAndLog.Location = new System.Drawing.Point(12, 216);
            this.checkBoxStatsAndLog.Name = "checkBoxStatsAndLog";
            this.checkBoxStatsAndLog.Size = new System.Drawing.Size(18, 17);
            this.checkBoxStatsAndLog.TabIndex = 10;
            this.checkBoxStatsAndLog.UseVisualStyleBackColor = true;
            // 
            // MultiSupplierMTOptionsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(609, 313);
            this.Controls.Add(this.linkLabelStatsAndLog);
            this.Controls.Add(this.checkBoxStatsAndLog);
            this.Controls.Add(this.linkLabelTranslateCache);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.linkLabelCustomDisplayName);
            this.Controls.Add(this.checkBoxCustomDisplayName);
            this.Controls.Add(this.linkLabelCustomRequestLimit);
            this.Controls.Add(this.checkBoxCustomRequestLimit);
            this.Controls.Add(this.checkBoxTagsToEnd);
            this.Controls.Add(this.checkBoxNormalizeWhitespace);
            this.Controls.Add(this.checkBoxTranslateCache);
            this.Controls.Add(this.comboBoxServiceProvider);
            this.Controls.Add(this.labelServiceProvider);
            this.Controls.Add(this.labelRequestType);
            this.Controls.Add(this.comboBoxRequestType);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MultiSupplierMTOptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Multi Supplier MT Plugin Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MultiSupplierMTOptionsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxRequestType;
        private System.Windows.Forms.Label labelRequestType;
        private System.Windows.Forms.Label labelServiceProvider;
        private System.Windows.Forms.ComboBox comboBoxServiceProvider;
        private System.Windows.Forms.CheckBox checkBoxTranslateCache;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox checkBoxNormalizeWhitespace;
        private System.Windows.Forms.CheckBox checkBoxTagsToEnd;
        private System.Windows.Forms.CheckBox checkBoxCustomRequestLimit;
        private System.Windows.Forms.LinkLabel linkLabelCustomRequestLimit;
        private System.Windows.Forms.LinkLabel linkLabelCustomDisplayName;
        private System.Windows.Forms.CheckBox checkBoxCustomDisplayName;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.LinkLabel linkLabelTranslateCache;
        private System.Windows.Forms.LinkLabel linkLabelStatsAndLog;
        private System.Windows.Forms.CheckBox checkBoxStatsAndLog;
    }
}