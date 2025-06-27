using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.ProviderdsCommon;
using MultiSupplierMTPlugin.ProviderdsCommon.Forms;

namespace MultiSupplierMTPlugin.Providers.Huoshan
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
            this.labelAccessKey = new System.Windows.Forms.Label();
            this.textBoxAccessKey = new System.Windows.Forms.TextBox();
            this.textBoxSecretKey = new System.Windows.Forms.TextBox();
            this.commonBottomControl = new MultiSupplierMTPlugin.ProviderdsCommon.Forms.CommonBottomControl();
            this.linkLabelSecretKey = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelAccessKey
            // 
            this.labelAccessKey.Location = new System.Drawing.Point(17, 22);
            this.labelAccessKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAccessKey.Name = "labelAccessKey";
            this.labelAccessKey.Size = new System.Drawing.Size(99, 18);
            this.labelAccessKey.TabIndex = 0;
            this.labelAccessKey.Text = "Access Key";
            // 
            // textBoxAccessKey
            // 
            this.textBoxAccessKey.Location = new System.Drawing.Point(121, 19);
            this.textBoxAccessKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAccessKey.Name = "textBoxAccessKey";
            this.textBoxAccessKey.Size = new System.Drawing.Size(380, 25);
            this.textBoxAccessKey.TabIndex = 1;
            // 
            // textBoxSecretKey
            // 
            this.textBoxSecretKey.Location = new System.Drawing.Point(121, 58);
            this.textBoxSecretKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxSecretKey.Name = "textBoxSecretKey";
            this.textBoxSecretKey.PasswordChar = '*';
            this.textBoxSecretKey.Size = new System.Drawing.Size(380, 25);
            this.textBoxSecretKey.TabIndex = 3;
            // 
            // commonBottomControl
            // 
            this.commonBottomControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commonBottomControl.ButtonOkState = true;
            this.commonBottomControl.FailedDetailsMsg = null;
            this.commonBottomControl.Location = new System.Drawing.Point(20, 88);
            this.commonBottomControl.Name = "commonBottomControl";
            this.commonBottomControl.Size = new System.Drawing.Size(481, 74);
            this.commonBottomControl.TabIndex = 4;
            // 
            // linkLabelSecretKey
            // 
            this.linkLabelSecretKey.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelSecretKey.Location = new System.Drawing.Point(17, 63);
            this.linkLabelSecretKey.Name = "linkLabelSecretKey";
            this.linkLabelSecretKey.Size = new System.Drawing.Size(99, 18);
            this.linkLabelSecretKey.TabIndex = 2;
            this.linkLabelSecretKey.TabStop = true;
            this.linkLabelSecretKey.Text = "Secret Key";
            this.linkLabelSecretKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSecretKey_LinkClicked);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 167);
            this.Controls.Add(this.linkLabelSecretKey);
            this.Controls.Add(this.commonBottomControl);
            this.Controls.Add(this.textBoxSecretKey);
            this.Controls.Add(this.textBoxAccessKey);
            this.Controls.Add(this.labelAccessKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Huoshan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAccessKey;
        private System.Windows.Forms.TextBox textBoxAccessKey;
        private System.Windows.Forms.TextBox textBoxSecretKey;
        private CommonBottomControl commonBottomControl;
        private System.Windows.Forms.LinkLabel linkLabelSecretKey;
    }
}