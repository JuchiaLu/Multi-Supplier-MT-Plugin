namespace MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM
{
    partial class PromptPlaceholders
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxGlossaryText = new System.Windows.Forms.GroupBox();
            this.textBoxGlossaryDelimiter = new System.Windows.Forms.TextBox();
            this.buttonGlossarySelect = new System.Windows.Forms.Button();
            this.textBoxGlossaryFilePath = new System.Windows.Forms.TextBox();
            this.labelGlossaryFilePath = new System.Windows.Forms.Label();
            this.labelGlossaryDelimiter = new System.Windows.Forms.Label();
            this.groupBoxSummaryText = new System.Windows.Forms.GroupBox();
            this.linkLabelSummaryCacheDir = new System.Windows.Forms.LinkLabel();
            this.radioButtonAutoGenerate = new System.Windows.Forms.RadioButton();
            this.radioButtonManualSelect = new System.Windows.Forms.RadioButton();
            this.buttonSummarySelect = new System.Windows.Forms.Button();
            this.textBoxSummaryFilePath = new System.Windows.Forms.TextBox();
            this.labelSummaryFilePath = new System.Windows.Forms.Label();
            this.labelSummaryType = new System.Windows.Forms.Label();
            this.textBoxSummaryPrompt = new System.Windows.Forms.TextBox();
            this.labelSummaryPrompt = new System.Windows.Forms.Label();
            this.groupBoxAboveText = new System.Windows.Forms.GroupBox();
            this.labelAboveTextIncludeTarget = new System.Windows.Forms.Label();
            this.labelAboveTextIncludeSource = new System.Windows.Forms.Label();
            this.numericUpDownAboveTextMaxCharacters = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAboveTextMaxSegments = new System.Windows.Forms.NumericUpDown();
            this.checkBoxAboveTextIncludeTarget = new System.Windows.Forms.CheckBox();
            this.checkBoxAboveTextIncludeSource = new System.Windows.Forms.CheckBox();
            this.labelAboveTextMaxCharacters = new System.Windows.Forms.Label();
            this.labelAboveTextMaxSegments = new System.Windows.Forms.Label();
            this.groupBoxBelowText = new System.Windows.Forms.GroupBox();
            this.labelBelowTextIncludeTarget = new System.Windows.Forms.Label();
            this.labelBelowTextIncludeSource = new System.Windows.Forms.Label();
            this.numericUpDownBelowTextMaxCharacters = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBelowTextMaxSegments = new System.Windows.Forms.NumericUpDown();
            this.checkBoxBelowTextIncludeTarget = new System.Windows.Forms.CheckBox();
            this.checkBoxBelowTextIncludeSource = new System.Windows.Forms.CheckBox();
            this.labelBelowTextMaxCharacters = new System.Windows.Forms.Label();
            this.labelBelowTextMaxSegments = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.labelGlossaryEncoding = new System.Windows.Forms.Label();
            this.textBoxGlossaryEncoding = new System.Windows.Forms.TextBox();
            this.groupBoxGlossaryText.SuspendLayout();
            this.groupBoxSummaryText.SuspendLayout();
            this.groupBoxAboveText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAboveTextMaxCharacters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAboveTextMaxSegments)).BeginInit();
            this.groupBoxBelowText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBelowTextMaxCharacters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBelowTextMaxSegments)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(317, 601);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 30;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(427, 601);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(103, 27);
            this.buttonCancel.TabIndex = 31;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBoxGlossaryText
            // 
            this.groupBoxGlossaryText.Controls.Add(this.textBoxGlossaryEncoding);
            this.groupBoxGlossaryText.Controls.Add(this.labelGlossaryEncoding);
            this.groupBoxGlossaryText.Controls.Add(this.textBoxGlossaryDelimiter);
            this.groupBoxGlossaryText.Controls.Add(this.buttonGlossarySelect);
            this.groupBoxGlossaryText.Controls.Add(this.textBoxGlossaryFilePath);
            this.groupBoxGlossaryText.Controls.Add(this.labelGlossaryFilePath);
            this.groupBoxGlossaryText.Controls.Add(this.labelGlossaryDelimiter);
            this.groupBoxGlossaryText.Location = new System.Drawing.Point(12, 12);
            this.groupBoxGlossaryText.Name = "groupBoxGlossaryText";
            this.groupBoxGlossaryText.Size = new System.Drawing.Size(516, 95);
            this.groupBoxGlossaryText.TabIndex = 0;
            this.groupBoxGlossaryText.TabStop = false;
            this.groupBoxGlossaryText.Text = "{{glossary-text}}";
            // 
            // textBoxGlossaryDelimiter
            // 
            this.textBoxGlossaryDelimiter.Location = new System.Drawing.Point(128, 23);
            this.textBoxGlossaryDelimiter.MaxLength = 1;
            this.textBoxGlossaryDelimiter.Name = "textBoxGlossaryDelimiter";
            this.textBoxGlossaryDelimiter.Size = new System.Drawing.Size(84, 25);
            this.textBoxGlossaryDelimiter.TabIndex = 1;
            // 
            // buttonGlossarySelect
            // 
            this.buttonGlossarySelect.Location = new System.Drawing.Point(425, 58);
            this.buttonGlossarySelect.Name = "buttonGlossarySelect";
            this.buttonGlossarySelect.Size = new System.Drawing.Size(75, 25);
            this.buttonGlossarySelect.TabIndex = 4;
            this.buttonGlossarySelect.Text = "Select";
            this.buttonGlossarySelect.UseVisualStyleBackColor = true;
            this.buttonGlossarySelect.Click += new System.EventHandler(this.buttonGlossarySelect_Click);
            // 
            // textBoxGlossaryFilePath
            // 
            this.textBoxGlossaryFilePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxGlossaryFilePath.Location = new System.Drawing.Point(128, 58);
            this.textBoxGlossaryFilePath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxGlossaryFilePath.Name = "textBoxGlossaryFilePath";
            this.textBoxGlossaryFilePath.Size = new System.Drawing.Size(290, 25);
            this.textBoxGlossaryFilePath.TabIndex = 3;
            // 
            // labelGlossaryFilePath
            // 
            this.labelGlossaryFilePath.AutoSize = true;
            this.labelGlossaryFilePath.Location = new System.Drawing.Point(13, 61);
            this.labelGlossaryFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGlossaryFilePath.Name = "labelGlossaryFilePath";
            this.labelGlossaryFilePath.Size = new System.Drawing.Size(79, 15);
            this.labelGlossaryFilePath.TabIndex = 2;
            this.labelGlossaryFilePath.Text = "File Path";
            // 
            // labelGlossaryDelimiter
            // 
            this.labelGlossaryDelimiter.AutoSize = true;
            this.labelGlossaryDelimiter.Location = new System.Drawing.Point(13, 28);
            this.labelGlossaryDelimiter.Name = "labelGlossaryDelimiter";
            this.labelGlossaryDelimiter.Size = new System.Drawing.Size(79, 15);
            this.labelGlossaryDelimiter.TabIndex = 0;
            this.labelGlossaryDelimiter.Text = "Delimiter";
            // 
            // groupBoxSummaryText
            // 
            this.groupBoxSummaryText.Controls.Add(this.linkLabelSummaryCacheDir);
            this.groupBoxSummaryText.Controls.Add(this.radioButtonAutoGenerate);
            this.groupBoxSummaryText.Controls.Add(this.radioButtonManualSelect);
            this.groupBoxSummaryText.Controls.Add(this.buttonSummarySelect);
            this.groupBoxSummaryText.Controls.Add(this.textBoxSummaryFilePath);
            this.groupBoxSummaryText.Controls.Add(this.labelSummaryFilePath);
            this.groupBoxSummaryText.Controls.Add(this.labelSummaryType);
            this.groupBoxSummaryText.Controls.Add(this.textBoxSummaryPrompt);
            this.groupBoxSummaryText.Controls.Add(this.labelSummaryPrompt);
            this.groupBoxSummaryText.Location = new System.Drawing.Point(12, 122);
            this.groupBoxSummaryText.Name = "groupBoxSummaryText";
            this.groupBoxSummaryText.Size = new System.Drawing.Size(516, 225);
            this.groupBoxSummaryText.TabIndex = 6;
            this.groupBoxSummaryText.TabStop = false;
            this.groupBoxSummaryText.Text = "{{summary-text}}";
            // 
            // linkLabelSummaryCacheDir
            // 
            this.linkLabelSummaryCacheDir.AutoSize = true;
            this.linkLabelSummaryCacheDir.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelSummaryCacheDir.Location = new System.Drawing.Point(14, 155);
            this.linkLabelSummaryCacheDir.Name = "linkLabelSummaryCacheDir";
            this.linkLabelSummaryCacheDir.Size = new System.Drawing.Size(95, 15);
            this.linkLabelSummaryCacheDir.TabIndex = 13;
            this.linkLabelSummaryCacheDir.TabStop = true;
            this.linkLabelSummaryCacheDir.Text = "Cache dir ?";
            this.linkLabelSummaryCacheDir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSummaryCacheDir_LinkClicked);
            // 
            // radioButtonAutoGenerate
            // 
            this.radioButtonAutoGenerate.AutoSize = true;
            this.radioButtonAutoGenerate.Location = new System.Drawing.Point(285, 27);
            this.radioButtonAutoGenerate.Name = "radioButtonAutoGenerate";
            this.radioButtonAutoGenerate.Size = new System.Drawing.Size(132, 19);
            this.radioButtonAutoGenerate.TabIndex = 7;
            this.radioButtonAutoGenerate.TabStop = true;
            this.radioButtonAutoGenerate.Text = "Auto generate";
            this.radioButtonAutoGenerate.UseVisualStyleBackColor = true;
            // 
            // radioButtonManualSelect
            // 
            this.radioButtonManualSelect.AutoSize = true;
            this.radioButtonManualSelect.Location = new System.Drawing.Point(132, 28);
            this.radioButtonManualSelect.Name = "radioButtonManualSelect";
            this.radioButtonManualSelect.Size = new System.Drawing.Size(132, 19);
            this.radioButtonManualSelect.TabIndex = 6;
            this.radioButtonManualSelect.TabStop = true;
            this.radioButtonManualSelect.Text = "Manual select";
            this.radioButtonManualSelect.UseVisualStyleBackColor = true;
            this.radioButtonManualSelect.CheckedChanged += new System.EventHandler(this.radioButtonManualSelect_CheckedChanged);
            // 
            // buttonSummarySelect
            // 
            this.buttonSummarySelect.Location = new System.Drawing.Point(425, 58);
            this.buttonSummarySelect.Name = "buttonSummarySelect";
            this.buttonSummarySelect.Size = new System.Drawing.Size(75, 25);
            this.buttonSummarySelect.TabIndex = 10;
            this.buttonSummarySelect.Text = "Select";
            this.buttonSummarySelect.UseVisualStyleBackColor = true;
            this.buttonSummarySelect.Click += new System.EventHandler(this.buttonSummarySelect_Click);
            // 
            // textBoxSummaryFilePath
            // 
            this.textBoxSummaryFilePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxSummaryFilePath.Location = new System.Drawing.Point(128, 58);
            this.textBoxSummaryFilePath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxSummaryFilePath.Name = "textBoxSummaryFilePath";
            this.textBoxSummaryFilePath.Size = new System.Drawing.Size(290, 25);
            this.textBoxSummaryFilePath.TabIndex = 9;
            // 
            // labelSummaryFilePath
            // 
            this.labelSummaryFilePath.AutoSize = true;
            this.labelSummaryFilePath.Location = new System.Drawing.Point(14, 61);
            this.labelSummaryFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSummaryFilePath.Name = "labelSummaryFilePath";
            this.labelSummaryFilePath.Size = new System.Drawing.Size(79, 15);
            this.labelSummaryFilePath.TabIndex = 8;
            this.labelSummaryFilePath.Text = "File Path";
            // 
            // labelSummaryType
            // 
            this.labelSummaryType.AutoSize = true;
            this.labelSummaryType.Location = new System.Drawing.Point(14, 30);
            this.labelSummaryType.Name = "labelSummaryType";
            this.labelSummaryType.Size = new System.Drawing.Size(95, 15);
            this.labelSummaryType.TabIndex = 5;
            this.labelSummaryType.Text = "Source Type";
            // 
            // textBoxSummaryPrompt
            // 
            this.textBoxSummaryPrompt.AcceptsReturn = true;
            this.textBoxSummaryPrompt.AcceptsTab = true;
            this.textBoxSummaryPrompt.Location = new System.Drawing.Point(127, 97);
            this.textBoxSummaryPrompt.Multiline = true;
            this.textBoxSummaryPrompt.Name = "textBoxSummaryPrompt";
            this.textBoxSummaryPrompt.Size = new System.Drawing.Size(372, 111);
            this.textBoxSummaryPrompt.TabIndex = 12;
            this.textBoxSummaryPrompt.WordWrap = false;
            this.textBoxSummaryPrompt.TextChanged += new System.EventHandler(this.textBoxSummaryPrompt_TextChanged);
            // 
            // labelSummaryPrompt
            // 
            this.labelSummaryPrompt.AutoSize = true;
            this.labelSummaryPrompt.Location = new System.Drawing.Point(14, 97);
            this.labelSummaryPrompt.Name = "labelSummaryPrompt";
            this.labelSummaryPrompt.Size = new System.Drawing.Size(55, 15);
            this.labelSummaryPrompt.TabIndex = 11;
            this.labelSummaryPrompt.Text = "Prompt";
            // 
            // groupBoxAboveText
            // 
            this.groupBoxAboveText.Controls.Add(this.labelAboveTextIncludeTarget);
            this.groupBoxAboveText.Controls.Add(this.labelAboveTextIncludeSource);
            this.groupBoxAboveText.Controls.Add(this.numericUpDownAboveTextMaxCharacters);
            this.groupBoxAboveText.Controls.Add(this.numericUpDownAboveTextMaxSegments);
            this.groupBoxAboveText.Controls.Add(this.checkBoxAboveTextIncludeTarget);
            this.groupBoxAboveText.Controls.Add(this.checkBoxAboveTextIncludeSource);
            this.groupBoxAboveText.Controls.Add(this.labelAboveTextMaxCharacters);
            this.groupBoxAboveText.Controls.Add(this.labelAboveTextMaxSegments);
            this.groupBoxAboveText.Location = new System.Drawing.Point(12, 366);
            this.groupBoxAboveText.Name = "groupBoxAboveText";
            this.groupBoxAboveText.Size = new System.Drawing.Size(516, 100);
            this.groupBoxAboveText.TabIndex = 9;
            this.groupBoxAboveText.TabStop = false;
            this.groupBoxAboveText.Text = "{{above-text}}";
            // 
            // labelAboveTextIncludeTarget
            // 
            this.labelAboveTextIncludeTarget.AutoSize = true;
            this.labelAboveTextIncludeTarget.Location = new System.Drawing.Point(259, 29);
            this.labelAboveTextIncludeTarget.Name = "labelAboveTextIncludeTarget";
            this.labelAboveTextIncludeTarget.Size = new System.Drawing.Size(119, 15);
            this.labelAboveTextIncludeTarget.TabIndex = 16;
            this.labelAboveTextIncludeTarget.Text = "Include Target";
            // 
            // labelAboveTextIncludeSource
            // 
            this.labelAboveTextIncludeSource.AutoSize = true;
            this.labelAboveTextIncludeSource.Location = new System.Drawing.Point(14, 29);
            this.labelAboveTextIncludeSource.Name = "labelAboveTextIncludeSource";
            this.labelAboveTextIncludeSource.Size = new System.Drawing.Size(111, 15);
            this.labelAboveTextIncludeSource.TabIndex = 14;
            this.labelAboveTextIncludeSource.Text = "Includ Source";
            // 
            // numericUpDownAboveTextMaxCharacters
            // 
            this.numericUpDownAboveTextMaxCharacters.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownAboveTextMaxCharacters.Location = new System.Drawing.Point(384, 64);
            this.numericUpDownAboveTextMaxCharacters.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownAboveTextMaxCharacters.Name = "numericUpDownAboveTextMaxCharacters";
            this.numericUpDownAboveTextMaxCharacters.Size = new System.Drawing.Size(116, 25);
            this.numericUpDownAboveTextMaxCharacters.TabIndex = 21;
            this.numericUpDownAboveTextMaxCharacters.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numericUpDownAboveTextMaxSegments
            // 
            this.numericUpDownAboveTextMaxSegments.Location = new System.Drawing.Point(128, 64);
            this.numericUpDownAboveTextMaxSegments.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownAboveTextMaxSegments.Name = "numericUpDownAboveTextMaxSegments";
            this.numericUpDownAboveTextMaxSegments.Size = new System.Drawing.Size(116, 25);
            this.numericUpDownAboveTextMaxSegments.TabIndex = 19;
            this.numericUpDownAboveTextMaxSegments.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // checkBoxAboveTextIncludeTarget
            // 
            this.checkBoxAboveTextIncludeTarget.AutoSize = true;
            this.checkBoxAboveTextIncludeTarget.Location = new System.Drawing.Point(384, 30);
            this.checkBoxAboveTextIncludeTarget.Name = "checkBoxAboveTextIncludeTarget";
            this.checkBoxAboveTextIncludeTarget.Size = new System.Drawing.Size(18, 17);
            this.checkBoxAboveTextIncludeTarget.TabIndex = 17;
            this.checkBoxAboveTextIncludeTarget.UseVisualStyleBackColor = true;
            // 
            // checkBoxAboveTextIncludeSource
            // 
            this.checkBoxAboveTextIncludeSource.AutoSize = true;
            this.checkBoxAboveTextIncludeSource.Location = new System.Drawing.Point(128, 30);
            this.checkBoxAboveTextIncludeSource.Name = "checkBoxAboveTextIncludeSource";
            this.checkBoxAboveTextIncludeSource.Size = new System.Drawing.Size(18, 17);
            this.checkBoxAboveTextIncludeSource.TabIndex = 15;
            this.checkBoxAboveTextIncludeSource.UseVisualStyleBackColor = true;
            // 
            // labelAboveTextMaxCharacters
            // 
            this.labelAboveTextMaxCharacters.AutoSize = true;
            this.labelAboveTextMaxCharacters.Location = new System.Drawing.Point(259, 69);
            this.labelAboveTextMaxCharacters.Name = "labelAboveTextMaxCharacters";
            this.labelAboveTextMaxCharacters.Size = new System.Drawing.Size(119, 15);
            this.labelAboveTextMaxCharacters.TabIndex = 20;
            this.labelAboveTextMaxCharacters.Text = "Max Characters";
            // 
            // labelAboveTextMaxSegments
            // 
            this.labelAboveTextMaxSegments.AutoSize = true;
            this.labelAboveTextMaxSegments.Location = new System.Drawing.Point(14, 69);
            this.labelAboveTextMaxSegments.Name = "labelAboveTextMaxSegments";
            this.labelAboveTextMaxSegments.Size = new System.Drawing.Size(103, 15);
            this.labelAboveTextMaxSegments.TabIndex = 18;
            this.labelAboveTextMaxSegments.Text = "Max Segments";
            // 
            // groupBoxBelowText
            // 
            this.groupBoxBelowText.Controls.Add(this.labelBelowTextIncludeTarget);
            this.groupBoxBelowText.Controls.Add(this.labelBelowTextIncludeSource);
            this.groupBoxBelowText.Controls.Add(this.numericUpDownBelowTextMaxCharacters);
            this.groupBoxBelowText.Controls.Add(this.numericUpDownBelowTextMaxSegments);
            this.groupBoxBelowText.Controls.Add(this.checkBoxBelowTextIncludeTarget);
            this.groupBoxBelowText.Controls.Add(this.checkBoxBelowTextIncludeSource);
            this.groupBoxBelowText.Controls.Add(this.labelBelowTextMaxCharacters);
            this.groupBoxBelowText.Controls.Add(this.labelBelowTextMaxSegments);
            this.groupBoxBelowText.Location = new System.Drawing.Point(12, 482);
            this.groupBoxBelowText.Name = "groupBoxBelowText";
            this.groupBoxBelowText.Size = new System.Drawing.Size(516, 100);
            this.groupBoxBelowText.TabIndex = 16;
            this.groupBoxBelowText.TabStop = false;
            this.groupBoxBelowText.Text = "{{below-text}}";
            // 
            // labelBelowTextIncludeTarget
            // 
            this.labelBelowTextIncludeTarget.AutoSize = true;
            this.labelBelowTextIncludeTarget.Location = new System.Drawing.Point(260, 29);
            this.labelBelowTextIncludeTarget.Name = "labelBelowTextIncludeTarget";
            this.labelBelowTextIncludeTarget.Size = new System.Drawing.Size(119, 15);
            this.labelBelowTextIncludeTarget.TabIndex = 24;
            this.labelBelowTextIncludeTarget.Text = "Include Target";
            // 
            // labelBelowTextIncludeSource
            // 
            this.labelBelowTextIncludeSource.AutoSize = true;
            this.labelBelowTextIncludeSource.Location = new System.Drawing.Point(15, 29);
            this.labelBelowTextIncludeSource.Name = "labelBelowTextIncludeSource";
            this.labelBelowTextIncludeSource.Size = new System.Drawing.Size(111, 15);
            this.labelBelowTextIncludeSource.TabIndex = 22;
            this.labelBelowTextIncludeSource.Text = "Includ Source";
            // 
            // numericUpDownBelowTextMaxCharacters
            // 
            this.numericUpDownBelowTextMaxCharacters.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownBelowTextMaxCharacters.Location = new System.Drawing.Point(385, 64);
            this.numericUpDownBelowTextMaxCharacters.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownBelowTextMaxCharacters.Name = "numericUpDownBelowTextMaxCharacters";
            this.numericUpDownBelowTextMaxCharacters.Size = new System.Drawing.Size(116, 25);
            this.numericUpDownBelowTextMaxCharacters.TabIndex = 29;
            this.numericUpDownBelowTextMaxCharacters.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numericUpDownBelowTextMaxSegments
            // 
            this.numericUpDownBelowTextMaxSegments.Location = new System.Drawing.Point(129, 64);
            this.numericUpDownBelowTextMaxSegments.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownBelowTextMaxSegments.Name = "numericUpDownBelowTextMaxSegments";
            this.numericUpDownBelowTextMaxSegments.Size = new System.Drawing.Size(116, 25);
            this.numericUpDownBelowTextMaxSegments.TabIndex = 27;
            this.numericUpDownBelowTextMaxSegments.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // checkBoxBelowTextIncludeTarget
            // 
            this.checkBoxBelowTextIncludeTarget.AutoSize = true;
            this.checkBoxBelowTextIncludeTarget.Location = new System.Drawing.Point(385, 30);
            this.checkBoxBelowTextIncludeTarget.Name = "checkBoxBelowTextIncludeTarget";
            this.checkBoxBelowTextIncludeTarget.Size = new System.Drawing.Size(18, 17);
            this.checkBoxBelowTextIncludeTarget.TabIndex = 25;
            this.checkBoxBelowTextIncludeTarget.UseVisualStyleBackColor = true;
            // 
            // checkBoxBelowTextIncludeSource
            // 
            this.checkBoxBelowTextIncludeSource.AutoSize = true;
            this.checkBoxBelowTextIncludeSource.Location = new System.Drawing.Point(129, 30);
            this.checkBoxBelowTextIncludeSource.Name = "checkBoxBelowTextIncludeSource";
            this.checkBoxBelowTextIncludeSource.Size = new System.Drawing.Size(18, 17);
            this.checkBoxBelowTextIncludeSource.TabIndex = 23;
            this.checkBoxBelowTextIncludeSource.UseVisualStyleBackColor = true;
            // 
            // labelBelowTextMaxCharacters
            // 
            this.labelBelowTextMaxCharacters.AutoSize = true;
            this.labelBelowTextMaxCharacters.Location = new System.Drawing.Point(260, 69);
            this.labelBelowTextMaxCharacters.Name = "labelBelowTextMaxCharacters";
            this.labelBelowTextMaxCharacters.Size = new System.Drawing.Size(119, 15);
            this.labelBelowTextMaxCharacters.TabIndex = 28;
            this.labelBelowTextMaxCharacters.Text = "Max Characters";
            // 
            // labelBelowTextMaxSegments
            // 
            this.labelBelowTextMaxSegments.AutoSize = true;
            this.labelBelowTextMaxSegments.Location = new System.Drawing.Point(15, 69);
            this.labelBelowTextMaxSegments.Name = "labelBelowTextMaxSegments";
            this.labelBelowTextMaxSegments.Size = new System.Drawing.Size(103, 15);
            this.labelBelowTextMaxSegments.TabIndex = 26;
            this.labelBelowTextMaxSegments.Text = "Max Segments";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 100;
            // 
            // labelEncoding
            // 
            this.labelGlossaryEncoding.AutoSize = true;
            this.labelGlossaryEncoding.Location = new System.Drawing.Point(240, 28);
            this.labelGlossaryEncoding.Name = "labelEncoding";
            this.labelGlossaryEncoding.Size = new System.Drawing.Size(71, 15);
            this.labelGlossaryEncoding.TabIndex = 5;
            this.labelGlossaryEncoding.Text = "Encoding";
            // 
            // textBoxEncoding
            // 
            this.textBoxGlossaryEncoding.Location = new System.Drawing.Point(334, 23);
            this.textBoxGlossaryEncoding.MaxLength = 1;
            this.textBoxGlossaryEncoding.Name = "textBoxEncoding";
            this.textBoxGlossaryEncoding.ReadOnly = true;
            this.textBoxGlossaryEncoding.Size = new System.Drawing.Size(84, 25);
            this.textBoxGlossaryEncoding.TabIndex = 6;
            // 
            // PromptPlaceholders
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(540, 639);
            this.Controls.Add(this.groupBoxBelowText);
            this.Controls.Add(this.groupBoxAboveText);
            this.Controls.Add(this.groupBoxSummaryText);
            this.Controls.Add(this.groupBoxGlossaryText);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PromptPlaceholders";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prompt Placeholders  (Shared by all LLM providers)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PromptPlaceholders_FormClosing);
            this.groupBoxGlossaryText.ResumeLayout(false);
            this.groupBoxGlossaryText.PerformLayout();
            this.groupBoxSummaryText.ResumeLayout(false);
            this.groupBoxSummaryText.PerformLayout();
            this.groupBoxAboveText.ResumeLayout(false);
            this.groupBoxAboveText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAboveTextMaxCharacters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAboveTextMaxSegments)).EndInit();
            this.groupBoxBelowText.ResumeLayout(false);
            this.groupBoxBelowText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBelowTextMaxCharacters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBelowTextMaxSegments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxGlossaryText;
        private System.Windows.Forms.Label labelGlossaryDelimiter;
        private System.Windows.Forms.GroupBox groupBoxSummaryText;
        private System.Windows.Forms.Label labelSummaryPrompt;
        private System.Windows.Forms.GroupBox groupBoxAboveText;
        private System.Windows.Forms.Label labelAboveTextMaxCharacters;
        private System.Windows.Forms.Label labelAboveTextMaxSegments;
        private System.Windows.Forms.GroupBox groupBoxBelowText;
        private System.Windows.Forms.CheckBox checkBoxAboveTextIncludeTarget;
        private System.Windows.Forms.CheckBox checkBoxAboveTextIncludeSource;
        private System.Windows.Forms.TextBox textBoxSummaryPrompt;
        private System.Windows.Forms.NumericUpDown numericUpDownAboveTextMaxCharacters;
        private System.Windows.Forms.NumericUpDown numericUpDownAboveTextMaxSegments;
        private System.Windows.Forms.Button buttonGlossarySelect;
        private System.Windows.Forms.TextBox textBoxGlossaryFilePath;
        private System.Windows.Forms.Label labelGlossaryFilePath;
        private System.Windows.Forms.NumericUpDown numericUpDownBelowTextMaxCharacters;
        private System.Windows.Forms.NumericUpDown numericUpDownBelowTextMaxSegments;
        private System.Windows.Forms.CheckBox checkBoxBelowTextIncludeTarget;
        private System.Windows.Forms.CheckBox checkBoxBelowTextIncludeSource;
        private System.Windows.Forms.Label labelBelowTextMaxCharacters;
        private System.Windows.Forms.Label labelBelowTextMaxSegments;
        private System.Windows.Forms.TextBox textBoxGlossaryDelimiter;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelAboveTextIncludeTarget;
        private System.Windows.Forms.Label labelAboveTextIncludeSource;
        private System.Windows.Forms.Label labelBelowTextIncludeTarget;
        private System.Windows.Forms.Label labelBelowTextIncludeSource;
        private System.Windows.Forms.Button buttonSummarySelect;
        private System.Windows.Forms.TextBox textBoxSummaryFilePath;
        private System.Windows.Forms.Label labelSummaryFilePath;
        private System.Windows.Forms.Label labelSummaryType;
        private System.Windows.Forms.RadioButton radioButtonAutoGenerate;
        private System.Windows.Forms.RadioButton radioButtonManualSelect;
        private System.Windows.Forms.LinkLabel linkLabelSummaryCacheDir;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label labelGlossaryEncoding;
        private System.Windows.Forms.TextBox textBoxGlossaryEncoding;
    }
}