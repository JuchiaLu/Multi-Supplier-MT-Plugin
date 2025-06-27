using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.ProviderdsCommon;
using MultiSupplierMTPlugin.ProviderdsCommon.Forms;

namespace MultiSupplierMTPlugin.Providers.Aliyun
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
            this.labelKeyId = new System.Windows.Forms.Label();
            this.textBoxKeyId = new System.Windows.Forms.TextBox();
            this.textBoxKeySecret = new System.Windows.Forms.TextBox();
            this.labelServiceType = new System.Windows.Forms.Label();
            this.radioButtonGeneral = new System.Windows.Forms.RadioButton();
            this.radioButtonProfessional = new System.Windows.Forms.RadioButton();
            this.linkLabelKeySecret = new System.Windows.Forms.LinkLabel();
            this.commonBottomControl = new MultiSupplierMTPlugin.ProviderdsCommon.Forms.CommonBottomControl();
            this.SuspendLayout();
            // 
            // labelKeyId
            // 
            this.labelKeyId.Location = new System.Drawing.Point(17, 25);
            this.labelKeyId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelKeyId.Name = "labelKeyId";
            this.labelKeyId.Size = new System.Drawing.Size(99, 18);
            this.labelKeyId.TabIndex = 0;
            this.labelKeyId.Text = "Key Id";
            // 
            // textBoxKeyId
            // 
            this.textBoxKeyId.Location = new System.Drawing.Point(118, 22);
            this.textBoxKeyId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxKeyId.Name = "textBoxKeyId";
            this.textBoxKeyId.Size = new System.Drawing.Size(383, 25);
            this.textBoxKeyId.TabIndex = 1;
            // 
            // textBoxKeySecret
            // 
            this.textBoxKeySecret.Location = new System.Drawing.Point(118, 63);
            this.textBoxKeySecret.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxKeySecret.Name = "textBoxKeySecret";
            this.textBoxKeySecret.PasswordChar = '*';
            this.textBoxKeySecret.Size = new System.Drawing.Size(383, 25);
            this.textBoxKeySecret.TabIndex = 3;
            // 
            // labelServiceType
            // 
            this.labelServiceType.Location = new System.Drawing.Point(17, 104);
            this.labelServiceType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelServiceType.Name = "labelServiceType";
            this.labelServiceType.Size = new System.Drawing.Size(99, 18);
            this.labelServiceType.TabIndex = 4;
            this.labelServiceType.Text = "Type";
            // 
            // radioButtonGeneral
            // 
            this.radioButtonGeneral.AutoSize = true;
            this.radioButtonGeneral.Location = new System.Drawing.Point(118, 104);
            this.radioButtonGeneral.Name = "radioButtonGeneral";
            this.radioButtonGeneral.Size = new System.Drawing.Size(84, 19);
            this.radioButtonGeneral.TabIndex = 5;
            this.radioButtonGeneral.TabStop = true;
            this.radioButtonGeneral.Text = "General";
            this.radioButtonGeneral.UseVisualStyleBackColor = true;
            // 
            // radioButtonProfessional
            // 
            this.radioButtonProfessional.AutoSize = true;
            this.radioButtonProfessional.Location = new System.Drawing.Point(374, 104);
            this.radioButtonProfessional.Name = "radioButtonProfessional";
            this.radioButtonProfessional.Size = new System.Drawing.Size(124, 19);
            this.radioButtonProfessional.TabIndex = 6;
            this.radioButtonProfessional.TabStop = true;
            this.radioButtonProfessional.Text = "Professional";
            this.radioButtonProfessional.UseVisualStyleBackColor = true;
            // 
            // linkLabelKeySecret
            // 
            this.linkLabelKeySecret.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelKeySecret.Location = new System.Drawing.Point(17, 68);
            this.linkLabelKeySecret.Name = "linkLabelKeySecret";
            this.linkLabelKeySecret.Size = new System.Drawing.Size(99, 18);
            this.linkLabelKeySecret.TabIndex = 2;
            this.linkLabelKeySecret.TabStop = true;
            this.linkLabelKeySecret.Text = "Key Secret";
            this.linkLabelKeySecret.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelKeySecret_LinkClicked);
            // 
            // commonBottomControl
            // 
            this.commonBottomControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commonBottomControl.ButtonOkState = true;
            this.commonBottomControl.FailedDetailsMsg = null;
            this.commonBottomControl.Location = new System.Drawing.Point(20, 129);
            this.commonBottomControl.Name = "commonBottomControl";
            this.commonBottomControl.Size = new System.Drawing.Size(481, 75);
            this.commonBottomControl.TabIndex = 7;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 216);
            this.Controls.Add(this.commonBottomControl);
            this.Controls.Add(this.radioButtonProfessional);
            this.Controls.Add(this.radioButtonGeneral);
            this.Controls.Add(this.labelServiceType);
            this.Controls.Add(this.textBoxKeySecret);
            this.Controls.Add(this.textBoxKeyId);
            this.Controls.Add(this.labelKeyId);
            this.Controls.Add(this.linkLabelKeySecret);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aliyun";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelKeyId;
        private System.Windows.Forms.TextBox textBoxKeyId;
        private System.Windows.Forms.TextBox textBoxKeySecret;
        private System.Windows.Forms.Label labelServiceType;
        private System.Windows.Forms.RadioButton radioButtonGeneral;
        private System.Windows.Forms.RadioButton radioButtonProfessional;
        private CommonBottomControl commonBottomControl;
        private System.Windows.Forms.LinkLabel linkLabelKeySecret;
    }
}