namespace MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM
{
    partial class CustomModels
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelUserModelsTip1 = new System.Windows.Forms.Label();
            this.textBoxUserModels = new System.Windows.Forms.TextBox();
            this.tabControlModels = new System.Windows.Forms.TabControl();
            this.tabPageUserModels = new System.Windows.Forms.TabPage();
            this.labelUserModelsTip2 = new System.Windows.Forms.Label();
            this.tabPageNetworkModels = new System.Windows.Forms.TabPage();
            this.labelNetworkModelsTip2 = new System.Windows.Forms.Label();
            this.textBoxNetworkModels = new System.Windows.Forms.TextBox();
            this.labelNetworkModelsTip1 = new System.Windows.Forms.Label();
            this.tabPageBuiltinModels = new System.Windows.Forms.TabPage();
            this.checkedListBoxBuildinModels = new System.Windows.Forms.CheckedListBox();
            this.linkLabelAllDisable = new System.Windows.Forms.LinkLabel();
            this.linkLabelAllEnable = new System.Windows.Forms.LinkLabel();
            this.tabControlModels.SuspendLayout();
            this.tabPageUserModels.SuspendLayout();
            this.tabPageNetworkModels.SuspendLayout();
            this.tabPageBuiltinModels.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(307, 326);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(413, 326);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(103, 27);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelUserModelsTip1
            // 
            this.labelUserModelsTip1.AutoSize = true;
            this.labelUserModelsTip1.Location = new System.Drawing.Point(8, 225);
            this.labelUserModelsTip1.Name = "labelUserModelsTip1";
            this.labelUserModelsTip1.Size = new System.Drawing.Size(375, 15);
            this.labelUserModelsTip1.TabIndex = 1;
            this.labelUserModelsTip1.Text = "Separate models with commas, newlines optional";
            // 
            // textBoxUserModels
            // 
            this.textBoxUserModels.AcceptsReturn = true;
            this.textBoxUserModels.Location = new System.Drawing.Point(8, 9);
            this.textBoxUserModels.Multiline = true;
            this.textBoxUserModels.Name = "textBoxUserModels";
            this.textBoxUserModels.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxUserModels.Size = new System.Drawing.Size(481, 204);
            this.textBoxUserModels.TabIndex = 0;
            // 
            // tabControlModels
            // 
            this.tabControlModels.Controls.Add(this.tabPageUserModels);
            this.tabControlModels.Controls.Add(this.tabPageNetworkModels);
            this.tabControlModels.Controls.Add(this.tabPageBuiltinModels);
            this.tabControlModels.Location = new System.Drawing.Point(12, 12);
            this.tabControlModels.Name = "tabControlModels";
            this.tabControlModels.SelectedIndex = 0;
            this.tabControlModels.Size = new System.Drawing.Size(508, 305);
            this.tabControlModels.TabIndex = 12;
            // 
            // tabPageUserModels
            // 
            this.tabPageUserModels.Controls.Add(this.labelUserModelsTip2);
            this.tabPageUserModels.Controls.Add(this.textBoxUserModels);
            this.tabPageUserModels.Controls.Add(this.labelUserModelsTip1);
            this.tabPageUserModels.Location = new System.Drawing.Point(4, 25);
            this.tabPageUserModels.Name = "tabPageUserModels";
            this.tabPageUserModels.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUserModels.Size = new System.Drawing.Size(500, 276);
            this.tabPageUserModels.TabIndex = 0;
            this.tabPageUserModels.Text = "User Models";
            this.tabPageUserModels.UseVisualStyleBackColor = true;
            // 
            // labelUserModelsTip2
            // 
            this.labelUserModelsTip2.AutoSize = true;
            this.labelUserModelsTip2.Location = new System.Drawing.Point(8, 253);
            this.labelUserModelsTip2.Name = "labelUserModelsTip2";
            this.labelUserModelsTip2.Size = new System.Drawing.Size(367, 15);
            this.labelUserModelsTip2.TabIndex = 2;
            this.labelUserModelsTip2.Text = "Use \"=\" to set aliases, e.g., gpt-4o-mini=xxx";
            // 
            // tabPageNetworkModels
            // 
            this.tabPageNetworkModels.Controls.Add(this.labelNetworkModelsTip2);
            this.tabPageNetworkModels.Controls.Add(this.textBoxNetworkModels);
            this.tabPageNetworkModels.Controls.Add(this.labelNetworkModelsTip1);
            this.tabPageNetworkModels.Location = new System.Drawing.Point(4, 25);
            this.tabPageNetworkModels.Name = "tabPageNetworkModels";
            this.tabPageNetworkModels.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNetworkModels.Size = new System.Drawing.Size(500, 276);
            this.tabPageNetworkModels.TabIndex = 1;
            this.tabPageNetworkModels.Text = "Network Models";
            this.tabPageNetworkModels.UseVisualStyleBackColor = true;
            // 
            // labelNetworkModelsTip2
            // 
            this.labelNetworkModelsTip2.AutoSize = true;
            this.labelNetworkModelsTip2.Location = new System.Drawing.Point(8, 253);
            this.labelNetworkModelsTip2.Name = "labelNetworkModelsTip2";
            this.labelNetworkModelsTip2.Size = new System.Drawing.Size(463, 15);
            this.labelNetworkModelsTip2.TabIndex = 2;
            this.labelNetworkModelsTip2.Text = "This list won\'t be saved. Copy needed models to user list";
            // 
            // textBoxNetworkModels
            // 
            this.textBoxNetworkModels.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxNetworkModels.HideSelection = false;
            this.textBoxNetworkModels.Location = new System.Drawing.Point(8, 9);
            this.textBoxNetworkModels.Multiline = true;
            this.textBoxNetworkModels.Name = "textBoxNetworkModels";
            this.textBoxNetworkModels.ReadOnly = true;
            this.textBoxNetworkModels.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNetworkModels.Size = new System.Drawing.Size(481, 204);
            this.textBoxNetworkModels.TabIndex = 0;
            // 
            // labelNetworkModelsTip1
            // 
            this.labelNetworkModelsTip1.AutoSize = true;
            this.labelNetworkModelsTip1.Location = new System.Drawing.Point(8, 226);
            this.labelNetworkModelsTip1.MaximumSize = new System.Drawing.Size(500, 0);
            this.labelNetworkModelsTip1.Name = "labelNetworkModelsTip1";
            this.labelNetworkModelsTip1.Size = new System.Drawing.Size(423, 15);
            this.labelNetworkModelsTip1.TabIndex = 1;
            this.labelNetworkModelsTip1.Text = "Load models into Network Models from main form first";
            // 
            // tabPageBuiltinModels
            // 
            this.tabPageBuiltinModels.Controls.Add(this.checkedListBoxBuildinModels);
            this.tabPageBuiltinModels.Controls.Add(this.linkLabelAllDisable);
            this.tabPageBuiltinModels.Controls.Add(this.linkLabelAllEnable);
            this.tabPageBuiltinModels.Location = new System.Drawing.Point(4, 25);
            this.tabPageBuiltinModels.Name = "tabPageBuiltinModels";
            this.tabPageBuiltinModels.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBuiltinModels.Size = new System.Drawing.Size(500, 276);
            this.tabPageBuiltinModels.TabIndex = 2;
            this.tabPageBuiltinModels.Text = "Builtin Models";
            this.tabPageBuiltinModels.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxBuildinModels
            // 
            this.checkedListBoxBuildinModels.BackColor = System.Drawing.SystemColors.Window;
            this.checkedListBoxBuildinModels.CheckOnClick = true;
            this.checkedListBoxBuildinModels.FormattingEnabled = true;
            this.checkedListBoxBuildinModels.Location = new System.Drawing.Point(8, 9);
            this.checkedListBoxBuildinModels.Name = "checkedListBoxBuildinModels";
            this.checkedListBoxBuildinModels.ScrollAlwaysVisible = true;
            this.checkedListBoxBuildinModels.Size = new System.Drawing.Size(481, 204);
            this.checkedListBoxBuildinModels.TabIndex = 0;
            // 
            // linkLabelAllDisable
            // 
            this.linkLabelAllDisable.AutoSize = true;
            this.linkLabelAllDisable.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelAllDisable.Location = new System.Drawing.Point(351, 234);
            this.linkLabelAllDisable.Name = "linkLabelAllDisable";
            this.linkLabelAllDisable.Size = new System.Drawing.Size(95, 15);
            this.linkLabelAllDisable.TabIndex = 2;
            this.linkLabelAllDisable.TabStop = true;
            this.linkLabelAllDisable.Text = "All Disable";
            this.linkLabelAllDisable.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAllDisable_LinkClicked);
            // 
            // linkLabelAllEnable
            // 
            this.linkLabelAllEnable.AutoSize = true;
            this.linkLabelAllEnable.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelAllEnable.Location = new System.Drawing.Point(56, 234);
            this.linkLabelAllEnable.Name = "linkLabelAllEnable";
            this.linkLabelAllEnable.Size = new System.Drawing.Size(87, 15);
            this.linkLabelAllEnable.TabIndex = 1;
            this.linkLabelAllEnable.TabStop = true;
            this.linkLabelAllEnable.Text = "All Enable";
            this.linkLabelAllEnable.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAllEnable_LinkClicked);
            // 
            // CustomModels
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(532, 364);
            this.Controls.Add(this.tabControlModels);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomModels";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Model List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomModels_FormClosing);
            this.tabControlModels.ResumeLayout(false);
            this.tabPageUserModels.ResumeLayout(false);
            this.tabPageUserModels.PerformLayout();
            this.tabPageNetworkModels.ResumeLayout(false);
            this.tabPageNetworkModels.PerformLayout();
            this.tabPageBuiltinModels.ResumeLayout(false);
            this.tabPageBuiltinModels.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelUserModelsTip1;
        private System.Windows.Forms.TextBox textBoxUserModels;
        private System.Windows.Forms.TabControl tabControlModels;
        private System.Windows.Forms.TabPage tabPageUserModels;
        private System.Windows.Forms.TabPage tabPageNetworkModels;
        private System.Windows.Forms.TabPage tabPageBuiltinModels;
        private System.Windows.Forms.Label labelUserModelsTip2;
        private System.Windows.Forms.Label labelNetworkModelsTip2;
        private System.Windows.Forms.TextBox textBoxNetworkModels;
        private System.Windows.Forms.Label labelNetworkModelsTip1;
        private System.Windows.Forms.CheckedListBox checkedListBoxBuildinModels;
        private System.Windows.Forms.LinkLabel linkLabelAllDisable;
        private System.Windows.Forms.LinkLabel linkLabelAllEnable;
    }
}