using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.ProviderdsCommon;
using MultiSupplierMTPlugin.ProviderdsCommon.Forms;

namespace MultiSupplierMTPlugin.Providers.DeepL
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
            this.labelGlossaryId = new System.Windows.Forms.Label();
            this.textBoxAuthKey = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxGlossaryId = new System.Windows.Forms.TextBox();
            this.commonBottomControl = new MultiSupplierMTPlugin.ProviderdsCommon.Forms.CommonBottomControl();
            this.linkLabelAuthKey = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelGlossaryId
            // 
            this.labelGlossaryId.Location = new System.Drawing.Point(17, 93);
            this.labelGlossaryId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGlossaryId.Name = "labelGlossaryId";
            this.labelGlossaryId.Size = new System.Drawing.Size(99, 18);
            this.labelGlossaryId.TabIndex = 4;
            this.labelGlossaryId.Text = "Glossary Id";
            // 
            // textBoxAuthKey
            // 
            this.textBoxAuthKey.Location = new System.Drawing.Point(121, 52);
            this.textBoxAuthKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAuthKey.Name = "textBoxAuthKey";
            this.textBoxAuthKey.PasswordChar = '*';
            this.textBoxAuthKey.Size = new System.Drawing.Size(380, 25);
            this.textBoxAuthKey.TabIndex = 3;
            // 
            // labelServer
            // 
            this.labelServer.Location = new System.Drawing.Point(18, 17);
            this.labelServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(99, 18);
            this.labelServer.TabIndex = 0;
            this.labelServer.Text = "Server";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(121, 14);
            this.textBoxServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(380, 25);
            this.textBoxServer.TabIndex = 1;
            // 
            // textBoxGlossaryId
            // 
            this.textBoxGlossaryId.Location = new System.Drawing.Point(121, 90);
            this.textBoxGlossaryId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxGlossaryId.Name = "textBoxGlossaryId";
            this.textBoxGlossaryId.Size = new System.Drawing.Size(380, 25);
            this.textBoxGlossaryId.TabIndex = 5;
            // 
            // commonBottomControl
            // 
            this.commonBottomControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commonBottomControl.ButtonOkState = true;
            this.commonBottomControl.FailedDetailsMsg = null;
            this.commonBottomControl.Location = new System.Drawing.Point(20, 120);
            this.commonBottomControl.Name = "commonBottomControl";
            this.commonBottomControl.Size = new System.Drawing.Size(481, 74);
            this.commonBottomControl.TabIndex = 6;
            // 
            // linkLabelAuthKey
            // 
            this.linkLabelAuthKey.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelAuthKey.Location = new System.Drawing.Point(17, 57);
            this.linkLabelAuthKey.Name = "linkLabelAuthKey";
            this.linkLabelAuthKey.Size = new System.Drawing.Size(99, 18);
            this.linkLabelAuthKey.TabIndex = 2;
            this.linkLabelAuthKey.TabStop = true;
            this.linkLabelAuthKey.Text = "Auth Key";
            this.linkLabelAuthKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAuthKey_LinkClicked);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 202);
            this.Controls.Add(this.linkLabelAuthKey);
            this.Controls.Add(this.commonBottomControl);
            this.Controls.Add(this.textBoxGlossaryId);
            this.Controls.Add(this.textBoxServer);
            this.Controls.Add(this.labelServer);
            this.Controls.Add(this.textBoxAuthKey);
            this.Controls.Add(this.labelGlossaryId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DeepL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGlossaryId;
        private System.Windows.Forms.TextBox textBoxAuthKey;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxGlossaryId;
        private CommonBottomControl commonBottomControl;
        private System.Windows.Forms.LinkLabel linkLabelAuthKey;
    }
}