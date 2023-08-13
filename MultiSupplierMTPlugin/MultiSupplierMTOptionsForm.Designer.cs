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
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(389, 170);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(495, 170);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 27);
            this.buttonCancel.TabIndex = 8;
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
            this.checkBoxTranslateCache.Location = new System.Drawing.Point(12, 174);
            this.checkBoxTranslateCache.Name = "checkBoxTranslateCache";
            this.checkBoxTranslateCache.Size = new System.Drawing.Size(205, 19);
            this.checkBoxTranslateCache.TabIndex = 6;
            this.checkBoxTranslateCache.Text = "Enable Translate Cache";
            this.checkBoxTranslateCache.UseVisualStyleBackColor = true;
            this.checkBoxTranslateCache.Visible = false;
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
            // MultiSupplierMTOptionsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(609, 209);
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
    }
}