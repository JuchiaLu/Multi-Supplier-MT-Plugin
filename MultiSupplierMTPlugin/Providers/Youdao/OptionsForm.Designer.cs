using MultiSupplierMTPlugin.ProviderdsCommon;
using MultiSupplierMTPlugin.ProviderdsCommon.Forms;

namespace MultiSupplierMTPlugin.Providers.Youdao
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
            this.labelAppKey = new System.Windows.Forms.Label();
            this.textBoxAppKey = new System.Windows.Forms.TextBox();
            this.textBoxAppSecret = new System.Windows.Forms.TextBox();
            this.commonBottomControl = new MultiSupplierMTPlugin.ProviderdsCommon.Forms.CommonBottomControl();
            this.linkLabelAppSecret = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelAppKey
            // 
            this.labelAppKey.Location = new System.Drawing.Point(17, 17);
            this.labelAppKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppKey.Name = "labelAppKey";
            this.labelAppKey.Size = new System.Drawing.Size(99, 18);
            this.labelAppKey.TabIndex = 0;
            this.labelAppKey.Text = "App Key";
            // 
            // textBoxAppKey
            // 
            this.textBoxAppKey.Location = new System.Drawing.Point(121, 14);
            this.textBoxAppKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAppKey.Name = "textBoxAppKey";
            this.textBoxAppKey.Size = new System.Drawing.Size(380, 25);
            this.textBoxAppKey.TabIndex = 1;
            // 
            // textBoxAppSecret
            // 
            this.textBoxAppSecret.Location = new System.Drawing.Point(121, 51);
            this.textBoxAppSecret.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAppSecret.Name = "textBoxAppSecret";
            this.textBoxAppSecret.PasswordChar = '*';
            this.textBoxAppSecret.Size = new System.Drawing.Size(380, 25);
            this.textBoxAppSecret.TabIndex = 3;
            // 
            // commonBottomControl
            // 
            this.commonBottomControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commonBottomControl.ButtonOkState = true;
            this.commonBottomControl.FailedDetailsMsg = null;
            this.commonBottomControl.Location = new System.Drawing.Point(20, 85);
            this.commonBottomControl.Name = "commonBottomControl";
            this.commonBottomControl.Size = new System.Drawing.Size(481, 74);
            this.commonBottomControl.TabIndex = 4;
            // 
            // linkLabelAppSecret
            // 
            this.linkLabelAppSecret.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelAppSecret.Location = new System.Drawing.Point(17, 56);
            this.linkLabelAppSecret.Name = "linkLabelAppSecret";
            this.linkLabelAppSecret.Size = new System.Drawing.Size(99, 18);
            this.linkLabelAppSecret.TabIndex = 2;
            this.linkLabelAppSecret.TabStop = true;
            this.linkLabelAppSecret.Text = "App Secret";
            this.linkLabelAppSecret.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAppSecret_LinkClicked);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 163);
            this.Controls.Add(this.linkLabelAppSecret);
            this.Controls.Add(this.commonBottomControl);
            this.Controls.Add(this.textBoxAppSecret);
            this.Controls.Add(this.textBoxAppKey);
            this.Controls.Add(this.labelAppKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Youdao";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAppKey;
        private System.Windows.Forms.TextBox textBoxAppKey;
        private System.Windows.Forms.TextBox textBoxAppSecret;
        private CommonBottomControl commonBottomControl;
        private System.Windows.Forms.LinkLabel linkLabelAppSecret;
    }
}