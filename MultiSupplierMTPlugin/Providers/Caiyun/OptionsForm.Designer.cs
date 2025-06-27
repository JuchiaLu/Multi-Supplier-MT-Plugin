using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.ProviderdsCommon;
using MultiSupplierMTPlugin.ProviderdsCommon.Forms;

namespace MultiSupplierMTPlugin.Providers.Caiyun
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
            this.textBoxToken = new System.Windows.Forms.TextBox();
            this.commonBottomControl = new MultiSupplierMTPlugin.ProviderdsCommon.Forms.CommonBottomControl();
            this.linkLabelToken = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // textBoxToken
            // 
            this.textBoxToken.Location = new System.Drawing.Point(121, 20);
            this.textBoxToken.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxToken.Name = "textBoxToken";
            this.textBoxToken.PasswordChar = '*';
            this.textBoxToken.Size = new System.Drawing.Size(380, 25);
            this.textBoxToken.TabIndex = 1;
            // 
            // commonBottomControl
            // 
            this.commonBottomControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commonBottomControl.ButtonOkState = true;
            this.commonBottomControl.FailedDetailsMsg = null;
            this.commonBottomControl.Location = new System.Drawing.Point(20, 54);
            this.commonBottomControl.Name = "commonBottomControl";
            this.commonBottomControl.Size = new System.Drawing.Size(481, 74);
            this.commonBottomControl.TabIndex = 2;
            // 
            // linkLabelToken
            // 
            this.linkLabelToken.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelToken.Location = new System.Drawing.Point(17, 25);
            this.linkLabelToken.Name = "linkLabelToken";
            this.linkLabelToken.Size = new System.Drawing.Size(99, 18);
            this.linkLabelToken.TabIndex = 0;
            this.linkLabelToken.TabStop = true;
            this.linkLabelToken.Text = "Token";
            this.linkLabelToken.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelToken_LinkClicked);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 140);
            this.Controls.Add(this.commonBottomControl);
            this.Controls.Add(this.textBoxToken);
            this.Controls.Add(this.linkLabelToken);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Caiyun";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxToken;
        private CommonBottomControl commonBottomControl;
        private System.Windows.Forms.LinkLabel linkLabelToken;
    }
}