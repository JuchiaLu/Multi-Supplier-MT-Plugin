namespace MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM
{
    partial class BathTranslate
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
            this.radioButtonShorter = new System.Windows.Forms.RadioButton();
            this.groupBoxOutputSchema = new System.Windows.Forms.GroupBox();
            this.labelLonger = new System.Windows.Forms.Label();
            this.labelShorter = new System.Windows.Forms.Label();
            this.radioButtonLonger = new System.Windows.Forms.RadioButton();
            this.groupBoxOutputFormat = new System.Windows.Forms.GroupBox();
            this.labelJsonSchema = new System.Windows.Forms.Label();
            this.labelJsonObject = new System.Windows.Forms.Label();
            this.labelText = new System.Windows.Forms.Label();
            this.radioButtonJsonSchema = new System.Windows.Forms.RadioButton();
            this.radioButtonJsonObject = new System.Windows.Forms.RadioButton();
            this.radioButtonText = new System.Windows.Forms.RadioButton();
            this.groupBoxRequestSizeLimit = new System.Windows.Forms.GroupBox();
            this.labelMaxCharacters = new System.Windows.Forms.Label();
            this.labelMaxSegments = new System.Windows.Forms.Label();
            this.numericUpDownMaxCharacters = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxSegments = new System.Windows.Forms.NumericUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxOutputSchema.SuspendLayout();
            this.groupBoxOutputFormat.SuspendLayout();
            this.groupBoxRequestSizeLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxCharacters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSegments)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(411, 376);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 17;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(517, 376);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(103, 27);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // radioButtonShorter
            // 
            this.radioButtonShorter.AutoSize = true;
            this.radioButtonShorter.Location = new System.Drawing.Point(6, 29);
            this.radioButtonShorter.Name = "radioButtonShorter";
            this.radioButtonShorter.Size = new System.Drawing.Size(84, 19);
            this.radioButtonShorter.TabIndex = 6;
            this.radioButtonShorter.TabStop = true;
            this.radioButtonShorter.Text = "Shorter";
            this.radioButtonShorter.UseVisualStyleBackColor = true;
            // 
            // groupBoxOutputSchema
            // 
            this.groupBoxOutputSchema.Controls.Add(this.labelLonger);
            this.groupBoxOutputSchema.Controls.Add(this.labelShorter);
            this.groupBoxOutputSchema.Controls.Add(this.radioButtonLonger);
            this.groupBoxOutputSchema.Controls.Add(this.radioButtonShorter);
            this.groupBoxOutputSchema.Location = new System.Drawing.Point(11, 125);
            this.groupBoxOutputSchema.Name = "groupBoxOutputSchema";
            this.groupBoxOutputSchema.Size = new System.Drawing.Size(610, 93);
            this.groupBoxOutputSchema.TabIndex = 5;
            this.groupBoxOutputSchema.TabStop = false;
            this.groupBoxOutputSchema.Text = "Expect Output JSON Schema";
            // 
            // labelLonger
            // 
            this.labelLonger.AutoSize = true;
            this.labelLonger.Location = new System.Drawing.Point(157, 66);
            this.labelLonger.Name = "labelLonger";
            this.labelLonger.Size = new System.Drawing.Size(431, 15);
            this.labelLonger.TabIndex = 9;
            this.labelLonger.Text = "{\"texts\":[{\"id\":1,\"text\":\"t1\"},{\"id\":2,\"text\":\"t2\"}]}";
            // 
            // labelShorter
            // 
            this.labelShorter.AutoSize = true;
            this.labelShorter.Location = new System.Drawing.Point(157, 31);
            this.labelShorter.Name = "labelShorter";
            this.labelShorter.Size = new System.Drawing.Size(159, 15);
            this.labelShorter.TabIndex = 7;
            this.labelShorter.Text = "{\"1\":\"t1\",\"2\":\"t2\"}";
            // 
            // radioButtonLonger
            // 
            this.radioButtonLonger.AutoSize = true;
            this.radioButtonLonger.Location = new System.Drawing.Point(6, 62);
            this.radioButtonLonger.Name = "radioButtonLonger";
            this.radioButtonLonger.Size = new System.Drawing.Size(76, 19);
            this.radioButtonLonger.TabIndex = 8;
            this.radioButtonLonger.TabStop = true;
            this.radioButtonLonger.Text = "Longer";
            this.radioButtonLonger.UseVisualStyleBackColor = true;
            // 
            // groupBoxOutputFormat
            // 
            this.groupBoxOutputFormat.Controls.Add(this.labelJsonSchema);
            this.groupBoxOutputFormat.Controls.Add(this.labelJsonObject);
            this.groupBoxOutputFormat.Controls.Add(this.labelText);
            this.groupBoxOutputFormat.Controls.Add(this.radioButtonJsonSchema);
            this.groupBoxOutputFormat.Controls.Add(this.radioButtonJsonObject);
            this.groupBoxOutputFormat.Controls.Add(this.radioButtonText);
            this.groupBoxOutputFormat.Location = new System.Drawing.Point(11, 231);
            this.groupBoxOutputFormat.Name = "groupBoxOutputFormat";
            this.groupBoxOutputFormat.Size = new System.Drawing.Size(610, 128);
            this.groupBoxOutputFormat.TabIndex = 10;
            this.groupBoxOutputFormat.TabStop = false;
            this.groupBoxOutputFormat.Text = "Request LLM Output Format";
            // 
            // labelJsonSchema
            // 
            this.labelJsonSchema.AutoSize = true;
            this.labelJsonSchema.Location = new System.Drawing.Point(157, 94);
            this.labelJsonSchema.Name = "labelJsonSchema";
            this.labelJsonSchema.Size = new System.Drawing.Size(431, 15);
            this.labelJsonSchema.TabIndex = 16;
            this.labelJsonSchema.Text = "Guarantees both a JSON object and a valid JSON schema";
            // 
            // labelJsonObject
            // 
            this.labelJsonObject.AutoSize = true;
            this.labelJsonObject.Location = new System.Drawing.Point(157, 64);
            this.labelJsonObject.Name = "labelJsonObject";
            this.labelJsonObject.Size = new System.Drawing.Size(431, 15);
            this.labelJsonObject.TabIndex = 14;
            this.labelJsonObject.Text = "Guarantees a JSON object, but not a valid JSON schema";
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(157, 31);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(431, 15);
            this.labelText.TabIndex = 12;
            this.labelText.Text = "Does not guarantee a JSON object or valid JSON schema";
            // 
            // radioButtonJsonSchema
            // 
            this.radioButtonJsonSchema.AutoSize = true;
            this.radioButtonJsonSchema.Location = new System.Drawing.Point(6, 94);
            this.radioButtonJsonSchema.Name = "radioButtonJsonSchema";
            this.radioButtonJsonSchema.Size = new System.Drawing.Size(116, 19);
            this.radioButtonJsonSchema.TabIndex = 15;
            this.radioButtonJsonSchema.TabStop = true;
            this.radioButtonJsonSchema.Text = "JSON Schema";
            this.radioButtonJsonSchema.UseVisualStyleBackColor = true;
            // 
            // radioButtonJsonObject
            // 
            this.radioButtonJsonObject.AutoSize = true;
            this.radioButtonJsonObject.Location = new System.Drawing.Point(6, 62);
            this.radioButtonJsonObject.Name = "radioButtonJsonObject";
            this.radioButtonJsonObject.Size = new System.Drawing.Size(116, 19);
            this.radioButtonJsonObject.TabIndex = 13;
            this.radioButtonJsonObject.TabStop = true;
            this.radioButtonJsonObject.Text = "JSON Object";
            this.radioButtonJsonObject.UseVisualStyleBackColor = true;
            // 
            // radioButtonText
            // 
            this.radioButtonText.AutoSize = true;
            this.radioButtonText.Location = new System.Drawing.Point(6, 28);
            this.radioButtonText.Name = "radioButtonText";
            this.radioButtonText.Size = new System.Drawing.Size(60, 19);
            this.radioButtonText.TabIndex = 11;
            this.radioButtonText.TabStop = true;
            this.radioButtonText.Text = "Text";
            this.radioButtonText.UseVisualStyleBackColor = true;
            // 
            // groupBoxRequestSizeLimit
            // 
            this.groupBoxRequestSizeLimit.Controls.Add(this.labelMaxCharacters);
            this.groupBoxRequestSizeLimit.Controls.Add(this.labelMaxSegments);
            this.groupBoxRequestSizeLimit.Controls.Add(this.numericUpDownMaxCharacters);
            this.groupBoxRequestSizeLimit.Controls.Add(this.numericUpDownMaxSegments);
            this.groupBoxRequestSizeLimit.Location = new System.Drawing.Point(10, 12);
            this.groupBoxRequestSizeLimit.Name = "groupBoxRequestSizeLimit";
            this.groupBoxRequestSizeLimit.Size = new System.Drawing.Size(610, 97);
            this.groupBoxRequestSizeLimit.TabIndex = 0;
            this.groupBoxRequestSizeLimit.TabStop = false;
            this.groupBoxRequestSizeLimit.Text = "Request Size Limit";
            // 
            // labelMaxCharacters
            // 
            this.labelMaxCharacters.Location = new System.Drawing.Point(6, 65);
            this.labelMaxCharacters.Name = "labelMaxCharacters";
            this.labelMaxCharacters.Size = new System.Drawing.Size(232, 15);
            this.labelMaxCharacters.TabIndex = 3;
            this.labelMaxCharacters.Text = "Max Characters Per Request";
            // 
            // labelMaxSegments
            // 
            this.labelMaxSegments.Location = new System.Drawing.Point(6, 29);
            this.labelMaxSegments.Name = "labelMaxSegments";
            this.labelMaxSegments.Size = new System.Drawing.Size(232, 15);
            this.labelMaxSegments.TabIndex = 1;
            this.labelMaxSegments.Text = "Max Segments Per Request";
            // 
            // numericUpDownMaxCharacters
            // 
            this.numericUpDownMaxCharacters.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownMaxCharacters.Location = new System.Drawing.Point(297, 60);
            this.numericUpDownMaxCharacters.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownMaxCharacters.Name = "numericUpDownMaxCharacters";
            this.numericUpDownMaxCharacters.Size = new System.Drawing.Size(291, 25);
            this.numericUpDownMaxCharacters.TabIndex = 4;
            this.numericUpDownMaxCharacters.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // numericUpDownMaxSegments
            // 
            this.numericUpDownMaxSegments.Location = new System.Drawing.Point(297, 24);
            this.numericUpDownMaxSegments.Name = "numericUpDownMaxSegments";
            this.numericUpDownMaxSegments.Size = new System.Drawing.Size(291, 25);
            this.numericUpDownMaxSegments.TabIndex = 2;
            this.numericUpDownMaxSegments.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 100;
            // 
            // BathTranslate
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(629, 411);
            this.Controls.Add(this.groupBoxRequestSizeLimit);
            this.Controls.Add(this.groupBoxOutputFormat);
            this.Controls.Add(this.groupBoxOutputSchema);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BathTranslate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bath Translate (For use only by this provider)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BathTranslate_FormClosing);
            this.groupBoxOutputSchema.ResumeLayout(false);
            this.groupBoxOutputSchema.PerformLayout();
            this.groupBoxOutputFormat.ResumeLayout(false);
            this.groupBoxOutputFormat.PerformLayout();
            this.groupBoxRequestSizeLimit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxCharacters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSegments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.RadioButton radioButtonShorter;
        private System.Windows.Forms.GroupBox groupBoxOutputSchema;
        private System.Windows.Forms.RadioButton radioButtonLonger;
        private System.Windows.Forms.GroupBox groupBoxOutputFormat;
        private System.Windows.Forms.RadioButton radioButtonJsonSchema;
        private System.Windows.Forms.RadioButton radioButtonJsonObject;
        private System.Windows.Forms.RadioButton radioButtonText;
        private System.Windows.Forms.Label labelLonger;
        private System.Windows.Forms.Label labelShorter;
        private System.Windows.Forms.Label labelJsonSchema;
        private System.Windows.Forms.Label labelJsonObject;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.GroupBox groupBoxRequestSizeLimit;
        private System.Windows.Forms.Label labelMaxCharacters;
        private System.Windows.Forms.Label labelMaxSegments;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxCharacters;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxSegments;
        private System.Windows.Forms.ToolTip toolTip;
    }
}