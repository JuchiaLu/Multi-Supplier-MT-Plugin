using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.ProviderdsCommon;
using MultiSupplierMTPlugin.ProviderdsCommon.Forms;

namespace MultiSupplierMTPlugin.Providers.Baidu
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
            this.labelAppId = new System.Windows.Forms.Label();
            this.textBoxAppId = new System.Windows.Forms.TextBox();
            this.textBoxAppKey = new System.Windows.Forms.TextBox();
            this.commonBottomControl = new MultiSupplierMTPlugin.ProviderdsCommon.Forms.CommonBottomControl();
            this.linkLabelAppKey = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelAppId
            // 
            this.labelAppId.Location = new System.Drawing.Point(17, 22);
            this.labelAppId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppId.Name = "labelAppId";
            this.labelAppId.Size = new System.Drawing.Size(99, 18);
            this.labelAppId.TabIndex = 0;
            this.labelAppId.Text = "App Id";
            // 
            // textBoxAppId
            // 
            this.textBoxAppId.Location = new System.Drawing.Point(121, 19);
            this.textBoxAppId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAppId.Name = "textBoxAppId";
            this.textBoxAppId.Size = new System.Drawing.Size(380, 25);
            this.textBoxAppId.TabIndex = 1;
            // 
            // textBoxAppKey
            // 
            this.textBoxAppKey.Location = new System.Drawing.Point(121, 59);
            this.textBoxAppKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAppKey.Name = "textBoxAppKey";
            this.textBoxAppKey.PasswordChar = '*';
            this.textBoxAppKey.Size = new System.Drawing.Size(380, 25);
            this.textBoxAppKey.TabIndex = 3;
            // 
            // commonBottomControl
            // 
            this.commonBottomControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commonBottomControl.ButtonOkState = true;
            this.commonBottomControl.FailedDetailsMsg = null;
            this.commonBottomControl.Location = new System.Drawing.Point(20, 90);
            this.commonBottomControl.Name = "commonBottomControl";
            this.commonBottomControl.Size = new System.Drawing.Size(481, 74);
            this.commonBottomControl.TabIndex = 4;
            // 
            // linkLabelAppKey
            // 
            this.linkLabelAppKey.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelAppKey.Location = new System.Drawing.Point(17, 64);
            this.linkLabelAppKey.Name = "linkLabelAppKey";
            this.linkLabelAppKey.Size = new System.Drawing.Size(99, 18);
            this.linkLabelAppKey.TabIndex = 2;
            this.linkLabelAppKey.TabStop = true;
            this.linkLabelAppKey.Text = "App Key";
            this.linkLabelAppKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAppKey_LinkClicked);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 173);
            this.Controls.Add(this.linkLabelAppKey);
            this.Controls.Add(this.commonBottomControl);
            this.Controls.Add(this.textBoxAppKey);
            this.Controls.Add(this.textBoxAppId);
            this.Controls.Add(this.labelAppId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Baidu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAppId;
        private System.Windows.Forms.TextBox textBoxAppId;
        private System.Windows.Forms.TextBox textBoxAppKey;
        private CommonBottomControl commonBottomControl;
        private System.Windows.Forms.LinkLabel linkLabelAppKey;
    }
}