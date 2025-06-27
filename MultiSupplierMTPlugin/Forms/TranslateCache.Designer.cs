namespace MultiSupplierMTPlugin.Forms
{
    partial class TranslateCache
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
            this.labelCacheCount = new System.Windows.Forms.Label();
            this.labelCacheCountValue = new System.Windows.Forms.Label();
            this.linkLabelCleanCache = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(397, 61);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // labelCacheCount
            // 
            this.labelCacheCount.AutoSize = true;
            this.labelCacheCount.Location = new System.Drawing.Point(14, 27);
            this.labelCacheCount.Name = "labelCacheCount";
            this.labelCacheCount.Size = new System.Drawing.Size(111, 15);
            this.labelCacheCount.TabIndex = 0;
            this.labelCacheCount.Text = "Cache Count: ";
            // 
            // labelCacheCountValue
            // 
            this.labelCacheCountValue.AutoSize = true;
            this.labelCacheCountValue.Location = new System.Drawing.Point(131, 27);
            this.labelCacheCountValue.Name = "labelCacheCountValue";
            this.labelCacheCountValue.Size = new System.Drawing.Size(15, 15);
            this.labelCacheCountValue.TabIndex = 1;
            this.labelCacheCountValue.Text = "0";
            // 
            // linkLabelCleanCache
            // 
            this.linkLabelCleanCache.AutoSize = true;
            this.linkLabelCleanCache.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelCleanCache.Location = new System.Drawing.Point(260, 27);
            this.linkLabelCleanCache.Name = "linkLabelCleanCache";
            this.linkLabelCleanCache.Size = new System.Drawing.Size(95, 15);
            this.linkLabelCleanCache.TabIndex = 2;
            this.linkLabelCleanCache.TabStop = true;
            this.linkLabelCleanCache.Text = "Clean Cache";
            this.linkLabelCleanCache.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCleanCache_LinkClicked);
            // 
            // FormTranslateCache
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 100);
            this.Controls.Add(this.linkLabelCleanCache);
            this.Controls.Add(this.labelCacheCountValue);
            this.Controls.Add(this.labelCacheCount);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTranslateCache";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Translate Cache";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelCacheCount;
        private System.Windows.Forms.Label labelCacheCountValue;
        private System.Windows.Forms.LinkLabel linkLabelCleanCache;
    }
}