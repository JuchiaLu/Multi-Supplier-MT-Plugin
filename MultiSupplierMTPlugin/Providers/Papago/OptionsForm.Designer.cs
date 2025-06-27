using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.ProviderdsCommon;
using MultiSupplierMTPlugin.ProviderdsCommon.Forms;

namespace MultiSupplierMTPlugin.Providers.Papago
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
            this.labelClientID = new System.Windows.Forms.Label();
            this.textBoxClientID = new System.Windows.Forms.TextBox();
            this.textBoxClientSecret = new System.Windows.Forms.TextBox();
            this.commonBottomControl = new MultiSupplierMTPlugin.ProviderdsCommon.Forms.CommonBottomControl();
            this.linkLabelClientSecret = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelClientID
            // 
            this.labelClientID.Location = new System.Drawing.Point(13, 19);
            this.labelClientID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelClientID.Name = "labelClientID";
            this.labelClientID.Size = new System.Drawing.Size(99, 18);
            this.labelClientID.TabIndex = 0;
            this.labelClientID.Text = "Client ID";
            // 
            // textBoxClientID
            // 
            this.textBoxClientID.Location = new System.Drawing.Point(132, 16);
            this.textBoxClientID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxClientID.Name = "textBoxClientID";
            this.textBoxClientID.Size = new System.Drawing.Size(383, 25);
            this.textBoxClientID.TabIndex = 1;
            // 
            // textBoxClientSecret
            // 
            this.textBoxClientSecret.Location = new System.Drawing.Point(132, 55);
            this.textBoxClientSecret.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxClientSecret.Name = "textBoxClientSecret";
            this.textBoxClientSecret.PasswordChar = '*';
            this.textBoxClientSecret.Size = new System.Drawing.Size(383, 25);
            this.textBoxClientSecret.TabIndex = 3;
            // 
            // commonBottomControl
            // 
            this.commonBottomControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commonBottomControl.ButtonOkState = true;
            this.commonBottomControl.FailedDetailsMsg = null;
            this.commonBottomControl.Location = new System.Drawing.Point(16, 85);
            this.commonBottomControl.Name = "commonBottomControl";
            this.commonBottomControl.Size = new System.Drawing.Size(499, 74);
            this.commonBottomControl.TabIndex = 4;
            // 
            // linkLabelClientSecret
            // 
            this.linkLabelClientSecret.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelClientSecret.Location = new System.Drawing.Point(13, 60);
            this.linkLabelClientSecret.Name = "linkLabelClientSecret";
            this.linkLabelClientSecret.Size = new System.Drawing.Size(111, 18);
            this.linkLabelClientSecret.TabIndex = 2;
            this.linkLabelClientSecret.TabStop = true;
            this.linkLabelClientSecret.Text = "Client Secret";
            this.linkLabelClientSecret.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelClientSecret_LinkClicked);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 167);
            this.Controls.Add(this.linkLabelClientSecret);
            this.Controls.Add(this.commonBottomControl);
            this.Controls.Add(this.textBoxClientSecret);
            this.Controls.Add(this.textBoxClientID);
            this.Controls.Add(this.labelClientID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Papago";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelClientID;
        private System.Windows.Forms.TextBox textBoxClientID;
        private System.Windows.Forms.TextBox textBoxClientSecret;
        private CommonBottomControl commonBottomControl;
        private System.Windows.Forms.LinkLabel linkLabelClientSecret;
    }
}