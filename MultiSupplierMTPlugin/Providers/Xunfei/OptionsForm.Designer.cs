using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.ProviderdsCommon;
using MultiSupplierMTPlugin.ProviderdsCommon.Forms;

namespace MultiSupplierMTPlugin.Providers.Xunfei
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
            this.labelApiId = new System.Windows.Forms.Label();
            this.labelApiKey = new System.Windows.Forms.Label();
            this.textBoxApiId = new System.Windows.Forms.TextBox();
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.textApiSecret = new System.Windows.Forms.TextBox();
            this.commonBottomControl = new MultiSupplierMTPlugin.ProviderdsCommon.Forms.CommonBottomControl();
            this.linkLabelApiSecret = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelApiId
            // 
            this.labelApiId.Location = new System.Drawing.Point(17, 17);
            this.labelApiId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApiId.Name = "labelApiId";
            this.labelApiId.Size = new System.Drawing.Size(99, 18);
            this.labelApiId.TabIndex = 0;
            this.labelApiId.Text = "Api Id";
            // 
            // labelApiKey
            // 
            this.labelApiKey.Location = new System.Drawing.Point(17, 55);
            this.labelApiKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApiKey.Name = "labelApiKey";
            this.labelApiKey.Size = new System.Drawing.Size(99, 18);
            this.labelApiKey.TabIndex = 2;
            this.labelApiKey.Text = "Api Key";
            // 
            // textBoxApiId
            // 
            this.textBoxApiId.Location = new System.Drawing.Point(121, 14);
            this.textBoxApiId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxApiId.Name = "textBoxApiId";
            this.textBoxApiId.Size = new System.Drawing.Size(380, 25);
            this.textBoxApiId.TabIndex = 1;
            // 
            // textBoxApiKey
            // 
            this.textBoxApiKey.Location = new System.Drawing.Point(121, 52);
            this.textBoxApiKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.Size = new System.Drawing.Size(380, 25);
            this.textBoxApiKey.TabIndex = 3;
            // 
            // textApiSecret
            // 
            this.textApiSecret.Location = new System.Drawing.Point(121, 89);
            this.textApiSecret.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textApiSecret.Name = "textApiSecret";
            this.textApiSecret.PasswordChar = '*';
            this.textApiSecret.Size = new System.Drawing.Size(380, 25);
            this.textApiSecret.TabIndex = 5;
            // 
            // commonBottomControl
            // 
            this.commonBottomControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commonBottomControl.ButtonOkState = true;
            this.commonBottomControl.FailedDetailsMsg = null;
            this.commonBottomControl.Location = new System.Drawing.Point(20, 119);
            this.commonBottomControl.Name = "commonBottomControl";
            this.commonBottomControl.Size = new System.Drawing.Size(481, 74);
            this.commonBottomControl.TabIndex = 6;
            // 
            // linkLabelApiSecret
            // 
            this.linkLabelApiSecret.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelApiSecret.Location = new System.Drawing.Point(17, 94);
            this.linkLabelApiSecret.Name = "linkLabelApiSecret";
            this.linkLabelApiSecret.Size = new System.Drawing.Size(99, 18);
            this.linkLabelApiSecret.TabIndex = 4;
            this.linkLabelApiSecret.TabStop = true;
            this.linkLabelApiSecret.Text = "Api Secret";
            this.linkLabelApiSecret.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelApiSecret_LinkClicked);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 198);
            this.Controls.Add(this.linkLabelApiSecret);
            this.Controls.Add(this.commonBottomControl);
            this.Controls.Add(this.textApiSecret);
            this.Controls.Add(this.textBoxApiKey);
            this.Controls.Add(this.textBoxApiId);
            this.Controls.Add(this.labelApiKey);
            this.Controls.Add(this.labelApiId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xunfei";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelApiId;
        private System.Windows.Forms.Label labelApiKey;
        private System.Windows.Forms.TextBox textBoxApiId;
        private System.Windows.Forms.TextBox textBoxApiKey;
        private System.Windows.Forms.TextBox textApiSecret;
        private CommonBottomControl commonBottomControl;
        private System.Windows.Forms.LinkLabel linkLabelApiSecret;
    }
}