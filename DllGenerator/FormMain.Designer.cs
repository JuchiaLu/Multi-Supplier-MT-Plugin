namespace DllGenerator
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.numericUpDownStartNumber = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEndNumber = new System.Windows.Forms.NumericUpDown();
            this.labelStartNumber = new System.Windows.Forms.Label();
            this.labelEndNumber = new System.Windows.Forms.Label();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.labelSourceDll = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelOutputDir = new System.Windows.Forms.Label();
            this.textBoxSourceDll = new System.Windows.Forms.TextBox();
            this.textBoxOutputDir = new System.Windows.Forms.TextBox();
            this.buttonSourceDllSelect = new System.Windows.Forms.Button();
            this.buttonOutputPathSelect = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonOpen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownStartNumber
            // 
            this.numericUpDownStartNumber.Location = new System.Drawing.Point(129, 116);
            this.numericUpDownStartNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownStartNumber.Name = "numericUpDownStartNumber";
            this.numericUpDownStartNumber.Size = new System.Drawing.Size(492, 25);
            this.numericUpDownStartNumber.TabIndex = 0;
            this.numericUpDownStartNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownEndNumber
            // 
            this.numericUpDownEndNumber.Location = new System.Drawing.Point(129, 162);
            this.numericUpDownEndNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownEndNumber.Name = "numericUpDownEndNumber";
            this.numericUpDownEndNumber.Size = new System.Drawing.Size(492, 25);
            this.numericUpDownEndNumber.TabIndex = 1;
            this.numericUpDownEndNumber.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // labelStartNumber
            // 
            this.labelStartNumber.AutoSize = true;
            this.labelStartNumber.Location = new System.Drawing.Point(11, 121);
            this.labelStartNumber.Name = "labelStartNumber";
            this.labelStartNumber.Size = new System.Drawing.Size(103, 15);
            this.labelStartNumber.TabIndex = 3;
            this.labelStartNumber.Text = "Start Number";
            // 
            // labelEndNumber
            // 
            this.labelEndNumber.AutoSize = true;
            this.labelEndNumber.Location = new System.Drawing.Point(12, 167);
            this.labelEndNumber.Name = "labelEndNumber";
            this.labelEndNumber.Size = new System.Drawing.Size(87, 15);
            this.labelEndNumber.TabIndex = 4;
            this.labelEndNumber.Text = "End Number";
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGenerate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGenerate.Location = new System.Drawing.Point(15, 206);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(100, 27);
            this.buttonGenerate.TabIndex = 13;
            this.buttonGenerate.Text = "&Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // labelSourceDll
            // 
            this.labelSourceDll.AutoSize = true;
            this.labelSourceDll.Location = new System.Drawing.Point(11, 29);
            this.labelSourceDll.Name = "labelSourceDll";
            this.labelSourceDll.Size = new System.Drawing.Size(87, 15);
            this.labelSourceDll.TabIndex = 14;
            this.labelSourceDll.Text = "Source Dll";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // labelOutputDir
            // 
            this.labelOutputDir.AutoSize = true;
            this.labelOutputDir.Location = new System.Drawing.Point(11, 75);
            this.labelOutputDir.Name = "labelOutputDir";
            this.labelOutputDir.Size = new System.Drawing.Size(87, 15);
            this.labelOutputDir.TabIndex = 15;
            this.labelOutputDir.Text = "Output Dir";
            // 
            // textBoxSourceDll
            // 
            this.textBoxSourceDll.Location = new System.Drawing.Point(129, 24);
            this.textBoxSourceDll.Name = "textBoxSourceDll";
            this.textBoxSourceDll.ReadOnly = true;
            this.textBoxSourceDll.Size = new System.Drawing.Size(399, 25);
            this.textBoxSourceDll.TabIndex = 16;
            this.textBoxSourceDll.Tag = "";
            this.textBoxSourceDll.Text = "./MultiSupplierMTPlugin.dll";
            // 
            // textBoxOutputDir
            // 
            this.textBoxOutputDir.Location = new System.Drawing.Point(129, 70);
            this.textBoxOutputDir.Name = "textBoxOutputDir";
            this.textBoxOutputDir.ReadOnly = true;
            this.textBoxOutputDir.Size = new System.Drawing.Size(399, 25);
            this.textBoxOutputDir.TabIndex = 17;
            this.textBoxOutputDir.Text = "./";
            // 
            // buttonSourceDllSelect
            // 
            this.buttonSourceDllSelect.Location = new System.Drawing.Point(534, 24);
            this.buttonSourceDllSelect.Name = "buttonSourceDllSelect";
            this.buttonSourceDllSelect.Size = new System.Drawing.Size(85, 25);
            this.buttonSourceDllSelect.TabIndex = 18;
            this.buttonSourceDllSelect.Text = "select";
            this.buttonSourceDllSelect.UseVisualStyleBackColor = true;
            this.buttonSourceDllSelect.Click += new System.EventHandler(this.buttonSourceDllSelect_Click);
            // 
            // buttonOutputPathSelect
            // 
            this.buttonOutputPathSelect.Location = new System.Drawing.Point(534, 70);
            this.buttonOutputPathSelect.Name = "buttonOutputPathSelect";
            this.buttonOutputPathSelect.Size = new System.Drawing.Size(87, 25);
            this.buttonOutputPathSelect.TabIndex = 19;
            this.buttonOutputPathSelect.Text = "select";
            this.buttonOutputPathSelect.UseVisualStyleBackColor = true;
            this.buttonOutputPathSelect.Click += new System.EventHandler(this.buttonOutputPathSelect_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpen.Location = new System.Drawing.Point(519, 206);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(100, 27);
            this.buttonOpen.TabIndex = 20;
            this.buttonOpen.Text = "&Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 245);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonOutputPathSelect);
            this.Controls.Add(this.buttonSourceDllSelect);
            this.Controls.Add(this.textBoxOutputDir);
            this.Controls.Add(this.textBoxSourceDll);
            this.Controls.Add(this.labelOutputDir);
            this.Controls.Add(this.labelSourceDll);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.labelEndNumber);
            this.Controls.Add(this.labelStartNumber);
            this.Controls.Add(this.numericUpDownEndNumber);
            this.Controls.Add(this.numericUpDownStartNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dll Generator";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownStartNumber;
        private System.Windows.Forms.NumericUpDown numericUpDownEndNumber;
        private System.Windows.Forms.Label labelStartNumber;
        private System.Windows.Forms.Label labelEndNumber;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Label labelSourceDll;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelOutputDir;
        private System.Windows.Forms.TextBox textBoxSourceDll;
        private System.Windows.Forms.TextBox textBoxOutputDir;
        private System.Windows.Forms.Button buttonSourceDllSelect;
        private System.Windows.Forms.Button buttonOutputPathSelect;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonOpen;
    }
}

