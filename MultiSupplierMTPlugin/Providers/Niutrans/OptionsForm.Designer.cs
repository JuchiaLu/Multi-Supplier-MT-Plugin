using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.ProviderdsCommon;
using MultiSupplierMTPlugin.ProviderdsCommon.Forms;

namespace MultiSupplierMTPlugin.Providers.Niutrans
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
            this.textBoxApikey = new System.Windows.Forms.TextBox();
            this.commonBottomControl = new MultiSupplierMTPlugin.ProviderdsCommon.Forms.CommonBottomControl();
            this.linkLabelApikey = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // textBoxApikey
            // 
            this.textBoxApikey.Location = new System.Drawing.Point(121, 21);
            this.textBoxApikey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxApikey.Name = "textBoxApikey";
            this.textBoxApikey.PasswordChar = '*';
            this.textBoxApikey.Size = new System.Drawing.Size(380, 25);
            this.textBoxApikey.TabIndex = 1;
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
            // linkLabelApikey
            // 
            this.linkLabelApikey.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelApikey.Location = new System.Drawing.Point(17, 26);
            this.linkLabelApikey.Name = "linkLabelApikey";
            this.linkLabelApikey.Size = new System.Drawing.Size(99, 18);
            this.linkLabelApikey.TabIndex = 0;
            this.linkLabelApikey.TabStop = true;
            this.linkLabelApikey.Text = "Api Key";
            this.linkLabelApikey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelApikey_LinkClicked);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 132);
            this.Controls.Add(this.linkLabelApikey);
            this.Controls.Add(this.commonBottomControl);
            this.Controls.Add(this.textBoxApikey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Niutrans";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxApikey;
        private CommonBottomControl commonBottomControl;
        private System.Windows.Forms.LinkLabel linkLabelApikey;
    }
}