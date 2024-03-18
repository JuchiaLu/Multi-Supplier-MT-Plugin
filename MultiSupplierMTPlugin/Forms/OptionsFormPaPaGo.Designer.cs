﻿namespace MultiSupplierMTPlugin.Forms
{
    partial class OptionsFormPapago
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
            this.labelClientID = new System.Windows.Forms.Label();
            this.labelClientSecret = new System.Windows.Forms.Label();
            this.textBoxClientID = new System.Windows.Forms.TextBox();
            this.textBoxClientSecret = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.linkLabelCheck = new System.Windows.Forms.LinkLabel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelCheckResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelClientID
            // 
            this.labelClientID.Location = new System.Drawing.Point(17, 22);
            this.labelClientID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelClientID.Name = "labelClientID";
            this.labelClientID.Size = new System.Drawing.Size(99, 18);
            this.labelClientID.TabIndex = 0;
            this.labelClientID.Text = "Client ID";
            // 
            // labelClientSecret
            // 
            this.labelClientSecret.AutoSize = true;
            this.labelClientSecret.Location = new System.Drawing.Point(17, 61);
            this.labelClientSecret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelClientSecret.Name = "labelClientSecret";
            this.labelClientSecret.Size = new System.Drawing.Size(111, 15);
            this.labelClientSecret.TabIndex = 2;
            this.labelClientSecret.Text = "Client Secret";
            // 
            // textBoxClientID
            // 
            this.textBoxClientID.Location = new System.Drawing.Point(136, 19);
            this.textBoxClientID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxClientID.Name = "textBoxClientID";
            this.textBoxClientID.Size = new System.Drawing.Size(365, 25);
            this.textBoxClientID.TabIndex = 1;
            // 
            // textBoxClientSecret
            // 
            this.textBoxClientSecret.Location = new System.Drawing.Point(136, 58);
            this.textBoxClientSecret.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxClientSecret.Name = "textBoxClientSecret";
            this.textBoxClientSecret.PasswordChar = '*';
            this.textBoxClientSecret.Size = new System.Drawing.Size(365, 25);
            this.textBoxClientSecret.TabIndex = 3;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(292, 129);
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
            this.buttonCancel.Location = new System.Drawing.Point(398, 129);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(103, 27);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // linkLabelCheck
            // 
            this.linkLabelCheck.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabelCheck.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelCheck.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linkLabelCheck.Location = new System.Drawing.Point(17, 95);
            this.linkLabelCheck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelCheck.Name = "linkLabelCheck";
            this.linkLabelCheck.Size = new System.Drawing.Size(100, 23);
            this.linkLabelCheck.TabIndex = 4;
            this.linkLabelCheck.TabStop = true;
            this.linkLabelCheck.Text = "Check";
            this.linkLabelCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCheck_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(17, 135);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(264, 14);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // labelCheckResult
            // 
            this.labelCheckResult.Location = new System.Drawing.Point(121, 94);
            this.labelCheckResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCheckResult.Name = "labelCheckResult";
            this.labelCheckResult.Size = new System.Drawing.Size(380, 25);
            this.labelCheckResult.TabIndex = 5;
            // 
            // OptionsFormPapago
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(510, 167);
            this.Controls.Add(this.labelCheckResult);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.linkLabelCheck);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxClientSecret);
            this.Controls.Add(this.textBoxClientID);
            this.Controls.Add(this.labelClientSecret);
            this.Controls.Add(this.labelClientID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsFormPapago";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Papago";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelClientID;
        private System.Windows.Forms.Label labelClientSecret;
        private System.Windows.Forms.TextBox textBoxClientID;
        private System.Windows.Forms.TextBox textBoxClientSecret;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.LinkLabel linkLabelCheck;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelCheckResult;
    }
}