namespace MultiSupplierMTPlugin.Forms
{
    partial class FormStatsAndLog
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
            this.labelRequestCount = new System.Windows.Forms.Label();
            this.labelRequestCountValue = new System.Windows.Forms.Label();
            this.linkLabelResetStats = new System.Windows.Forms.LinkLabel();
            this.labelExceptionCount = new System.Windows.Forms.Label();
            this.labelExceptionCountValue = new System.Windows.Forms.Label();
            this.buttonOpenLogDir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(397, 119);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // labelRequestCount
            // 
            this.labelRequestCount.AutoSize = true;
            this.labelRequestCount.Location = new System.Drawing.Point(14, 27);
            this.labelRequestCount.Name = "labelRequestCount";
            this.labelRequestCount.Size = new System.Drawing.Size(111, 15);
            this.labelRequestCount.TabIndex = 0;
            this.labelRequestCount.Text = "Request Count";
            // 
            // labelRequestCountValue
            // 
            this.labelRequestCountValue.AutoSize = true;
            this.labelRequestCountValue.Location = new System.Drawing.Point(169, 27);
            this.labelRequestCountValue.Name = "labelRequestCountValue";
            this.labelRequestCountValue.Size = new System.Drawing.Size(15, 15);
            this.labelRequestCountValue.TabIndex = 1;
            this.labelRequestCountValue.Text = "0";
            // 
            // linkLabelResetStats
            // 
            this.linkLabelResetStats.AutoSize = true;
            this.linkLabelResetStats.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelResetStats.Location = new System.Drawing.Point(261, 52);
            this.linkLabelResetStats.Name = "linkLabelResetStats";
            this.linkLabelResetStats.Size = new System.Drawing.Size(95, 15);
            this.linkLabelResetStats.TabIndex = 4;
            this.linkLabelResetStats.TabStop = true;
            this.linkLabelResetStats.Text = "Reset Stats";
            this.linkLabelResetStats.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelResetStats_LinkClicked);
            // 
            // labelExceptionCount
            // 
            this.labelExceptionCount.AutoSize = true;
            this.labelExceptionCount.Location = new System.Drawing.Point(14, 77);
            this.labelExceptionCount.Name = "labelExceptionCount";
            this.labelExceptionCount.Size = new System.Drawing.Size(127, 15);
            this.labelExceptionCount.TabIndex = 2;
            this.labelExceptionCount.Text = "Exception Count";
            // 
            // labelExceptionCountValue
            // 
            this.labelExceptionCountValue.AutoSize = true;
            this.labelExceptionCountValue.Location = new System.Drawing.Point(169, 77);
            this.labelExceptionCountValue.Name = "labelExceptionCountValue";
            this.labelExceptionCountValue.Size = new System.Drawing.Size(15, 15);
            this.labelExceptionCountValue.TabIndex = 3;
            this.labelExceptionCountValue.Text = "0";
            // 
            // buttonOpenLogDir
            // 
            this.buttonOpenLogDir.Location = new System.Drawing.Point(12, 119);
            this.buttonOpenLogDir.Name = "buttonOpenLogDir";
            this.buttonOpenLogDir.Size = new System.Drawing.Size(167, 27);
            this.buttonOpenLogDir.TabIndex = 5;
            this.buttonOpenLogDir.Text = "&Open Log Dir";
            this.buttonOpenLogDir.UseVisualStyleBackColor = true;
            this.buttonOpenLogDir.Click += new System.EventHandler(this.buttonOpenLogDir_Click);
            // 
            // FormStatsAndLog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 158);
            this.Controls.Add(this.buttonOpenLogDir);
            this.Controls.Add(this.labelExceptionCountValue);
            this.Controls.Add(this.labelExceptionCount);
            this.Controls.Add(this.linkLabelResetStats);
            this.Controls.Add(this.labelRequestCountValue);
            this.Controls.Add(this.labelRequestCount);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStatsAndLog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stats And Log";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelRequestCount;
        private System.Windows.Forms.Label labelRequestCountValue;
        private System.Windows.Forms.LinkLabel linkLabelResetStats;
        private System.Windows.Forms.Label labelExceptionCount;
        private System.Windows.Forms.Label labelExceptionCountValue;
        private System.Windows.Forms.Button buttonOpenLogDir;
    }
}