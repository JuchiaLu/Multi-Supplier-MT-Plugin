namespace MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM
{
    partial class PromptTemplateManage
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.comboBoxTemplates = new System.Windows.Forms.ComboBox();
            this.labelTemplates = new System.Windows.Forms.Label();
            this.textBoxUserPrompt = new System.Windows.Forms.TextBox();
            this.labelUserPrompt = new System.Windows.Forms.Label();
            this.textBoxSystemPrompt = new System.Windows.Forms.TextBox();
            this.labelSystemPrompt = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonRename = new System.Windows.Forms.Button();
            this.textBoxTemplate = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.textBoxBathTranslateUserPrompt = new System.Windows.Forms.TextBox();
            this.labelBathTranslateUserPrompt = new System.Windows.Forms.Label();
            this.textBoxBathTranslateSystemPrompt = new System.Windows.Forms.TextBox();
            this.labelBathTranslateSystemPrompt = new System.Windows.Forms.Label();
            this.labelAction = new System.Windows.Forms.Label();
            this.groupBoxSingleTranslate = new System.Windows.Forms.GroupBox();
            this.groupBoxBathTranslate = new System.Windows.Forms.GroupBox();
            this.groupBoxSingleTranslate.SuspendLayout();
            this.groupBoxBathTranslate.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(424, 638);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(103, 27);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(315, 638);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 15;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // comboBoxTemplates
            // 
            this.comboBoxTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTemplates.FormattingEnabled = true;
            this.comboBoxTemplates.Location = new System.Drawing.Point(152, 55);
            this.comboBoxTemplates.Name = "comboBoxTemplates";
            this.comboBoxTemplates.Size = new System.Drawing.Size(362, 23);
            this.comboBoxTemplates.TabIndex = 5;
            this.comboBoxTemplates.SelectedIndexChanged += new System.EventHandler(this.comboBoxTemplates_SelectedIndexChanged);
            // 
            // labelTemplates
            // 
            this.labelTemplates.Location = new System.Drawing.Point(13, 57);
            this.labelTemplates.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTemplates.Name = "labelTemplates";
            this.labelTemplates.Size = new System.Drawing.Size(120, 18);
            this.labelTemplates.TabIndex = 4;
            this.labelTemplates.Text = "Templates";
            // 
            // textBoxUserPrompt
            // 
            this.textBoxUserPrompt.AcceptsReturn = true;
            this.textBoxUserPrompt.AcceptsTab = true;
            this.textBoxUserPrompt.Location = new System.Drawing.Point(142, 139);
            this.textBoxUserPrompt.Multiline = true;
            this.textBoxUserPrompt.Name = "textBoxUserPrompt";
            this.textBoxUserPrompt.Size = new System.Drawing.Size(362, 99);
            this.textBoxUserPrompt.TabIndex = 10;
            this.textBoxUserPrompt.WordWrap = false;
            this.textBoxUserPrompt.TextChanged += new System.EventHandler(this.textBoxUserPrompt_TextChanged);
            // 
            // labelUserPrompt
            // 
            this.labelUserPrompt.Location = new System.Drawing.Point(7, 139);
            this.labelUserPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUserPrompt.Name = "labelUserPrompt";
            this.labelUserPrompt.Size = new System.Drawing.Size(120, 18);
            this.labelUserPrompt.TabIndex = 9;
            this.labelUserPrompt.Text = "User Prompt^";
            // 
            // textBoxSystemPrompt
            // 
            this.textBoxSystemPrompt.AcceptsReturn = true;
            this.textBoxSystemPrompt.AcceptsTab = true;
            this.textBoxSystemPrompt.Location = new System.Drawing.Point(142, 24);
            this.textBoxSystemPrompt.Multiline = true;
            this.textBoxSystemPrompt.Name = "textBoxSystemPrompt";
            this.textBoxSystemPrompt.Size = new System.Drawing.Size(362, 99);
            this.textBoxSystemPrompt.TabIndex = 8;
            this.textBoxSystemPrompt.WordWrap = false;
            this.textBoxSystemPrompt.TextChanged += new System.EventHandler(this.textBoxSystemPrompt_TextChanged);
            // 
            // labelSystemPrompt
            // 
            this.labelSystemPrompt.Location = new System.Drawing.Point(7, 24);
            this.labelSystemPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSystemPrompt.Name = "labelSystemPrompt";
            this.labelSystemPrompt.Size = new System.Drawing.Size(120, 18);
            this.labelSystemPrompt.TabIndex = 7;
            this.labelSystemPrompt.Text = "System Prompt^";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(152, 10);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(76, 27);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(297, 10);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(74, 27);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(440, 10);
            this.buttonRename.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(74, 27);
            this.buttonRename.TabIndex = 3;
            this.buttonRename.Text = "Rename";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // textBoxTemplate
            // 
            this.textBoxTemplate.Location = new System.Drawing.Point(152, 54);
            this.textBoxTemplate.Name = "textBoxTemplate";
            this.textBoxTemplate.Size = new System.Drawing.Size(362, 25);
            this.textBoxTemplate.TabIndex = 6;
            this.textBoxTemplate.Visible = false;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 60000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // textBoxBathTranslateUserPrompt
            // 
            this.textBoxBathTranslateUserPrompt.AcceptsReturn = true;
            this.textBoxBathTranslateUserPrompt.AcceptsTab = true;
            this.textBoxBathTranslateUserPrompt.Location = new System.Drawing.Point(142, 139);
            this.textBoxBathTranslateUserPrompt.Multiline = true;
            this.textBoxBathTranslateUserPrompt.Name = "textBoxBathTranslateUserPrompt";
            this.textBoxBathTranslateUserPrompt.Size = new System.Drawing.Size(362, 99);
            this.textBoxBathTranslateUserPrompt.TabIndex = 14;
            this.textBoxBathTranslateUserPrompt.WordWrap = false;
            this.textBoxBathTranslateUserPrompt.TextChanged += new System.EventHandler(this.textBoxBathTranslateUserPrompt_TextChanged);
            // 
            // labelBathTranslateUserPrompt
            // 
            this.labelBathTranslateUserPrompt.Location = new System.Drawing.Point(7, 139);
            this.labelBathTranslateUserPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBathTranslateUserPrompt.Name = "labelBathTranslateUserPrompt";
            this.labelBathTranslateUserPrompt.Size = new System.Drawing.Size(120, 18);
            this.labelBathTranslateUserPrompt.TabIndex = 13;
            this.labelBathTranslateUserPrompt.Text = "User Prompt^";
            // 
            // textBoxBathTranslateSystemPrompt
            // 
            this.textBoxBathTranslateSystemPrompt.AcceptsReturn = true;
            this.textBoxBathTranslateSystemPrompt.AcceptsTab = true;
            this.textBoxBathTranslateSystemPrompt.Location = new System.Drawing.Point(142, 24);
            this.textBoxBathTranslateSystemPrompt.Multiline = true;
            this.textBoxBathTranslateSystemPrompt.Name = "textBoxBathTranslateSystemPrompt";
            this.textBoxBathTranslateSystemPrompt.Size = new System.Drawing.Size(362, 99);
            this.textBoxBathTranslateSystemPrompt.TabIndex = 12;
            this.textBoxBathTranslateSystemPrompt.WordWrap = false;
            this.textBoxBathTranslateSystemPrompt.TextChanged += new System.EventHandler(this.textBoxBathTranslateSystemPrompt_TextChanged);
            // 
            // labelBathTranslateSystemPrompt
            // 
            this.labelBathTranslateSystemPrompt.Location = new System.Drawing.Point(7, 24);
            this.labelBathTranslateSystemPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBathTranslateSystemPrompt.Name = "labelBathTranslateSystemPrompt";
            this.labelBathTranslateSystemPrompt.Size = new System.Drawing.Size(120, 18);
            this.labelBathTranslateSystemPrompt.TabIndex = 11;
            this.labelBathTranslateSystemPrompt.Text = "System Prompt\r\n\r\n^";
            // 
            // labelAction
            // 
            this.labelAction.Location = new System.Drawing.Point(13, 14);
            this.labelAction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAction.Name = "labelAction";
            this.labelAction.Size = new System.Drawing.Size(120, 18);
            this.labelAction.TabIndex = 0;
            this.labelAction.Text = "Action";
            // 
            // groupBoxSingleTranslate
            // 
            this.groupBoxSingleTranslate.Controls.Add(this.textBoxSystemPrompt);
            this.groupBoxSingleTranslate.Controls.Add(this.labelSystemPrompt);
            this.groupBoxSingleTranslate.Controls.Add(this.labelUserPrompt);
            this.groupBoxSingleTranslate.Controls.Add(this.textBoxUserPrompt);
            this.groupBoxSingleTranslate.Location = new System.Drawing.Point(10, 96);
            this.groupBoxSingleTranslate.Name = "groupBoxSingleTranslate";
            this.groupBoxSingleTranslate.Size = new System.Drawing.Size(516, 253);
            this.groupBoxSingleTranslate.TabIndex = 45;
            this.groupBoxSingleTranslate.TabStop = false;
            this.groupBoxSingleTranslate.Text = "Use For Single Translate";
            // 
            // groupBoxBathTranslate
            // 
            this.groupBoxBathTranslate.Controls.Add(this.textBoxBathTranslateSystemPrompt);
            this.groupBoxBathTranslate.Controls.Add(this.labelBathTranslateSystemPrompt);
            this.groupBoxBathTranslate.Controls.Add(this.textBoxBathTranslateUserPrompt);
            this.groupBoxBathTranslate.Controls.Add(this.labelBathTranslateUserPrompt);
            this.groupBoxBathTranslate.Location = new System.Drawing.Point(10, 369);
            this.groupBoxBathTranslate.Name = "groupBoxBathTranslate";
            this.groupBoxBathTranslate.Size = new System.Drawing.Size(516, 253);
            this.groupBoxBathTranslate.TabIndex = 33;
            this.groupBoxBathTranslate.TabStop = false;
            this.groupBoxBathTranslate.Text = "Use For Bath Translate";
            // 
            // PromptTemplateManage
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(540, 677);
            this.Controls.Add(this.groupBoxBathTranslate);
            this.Controls.Add(this.groupBoxSingleTranslate);
            this.Controls.Add(this.labelAction);
            this.Controls.Add(this.buttonRename);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelTemplates);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxTemplates);
            this.Controls.Add(this.textBoxTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PromptTemplateManage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prompt Templates (Shared by all LLM providers)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PromptTemplateManage_FormClosing);
            this.groupBoxSingleTranslate.ResumeLayout(false);
            this.groupBoxSingleTranslate.PerformLayout();
            this.groupBoxBathTranslate.ResumeLayout(false);
            this.groupBoxBathTranslate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ComboBox comboBoxTemplates;
        private System.Windows.Forms.Label labelTemplates;
        private System.Windows.Forms.TextBox textBoxUserPrompt;
        private System.Windows.Forms.Label labelUserPrompt;
        private System.Windows.Forms.TextBox textBoxSystemPrompt;
        private System.Windows.Forms.Label labelSystemPrompt;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.TextBox textBoxTemplate;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox textBoxBathTranslateUserPrompt;
        private System.Windows.Forms.Label labelBathTranslateUserPrompt;
        private System.Windows.Forms.TextBox textBoxBathTranslateSystemPrompt;
        private System.Windows.Forms.Label labelBathTranslateSystemPrompt;
        private System.Windows.Forms.Label labelAction;
        private System.Windows.Forms.GroupBox groupBoxSingleTranslate;
        private System.Windows.Forms.GroupBox groupBoxBathTranslate;
    }
}