using System.Drawing;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin.Forms
{
    partial class ProvidersManage
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridViewEnable = new System.Windows.Forms.DataGridView();
            this.buttonEnable = new System.Windows.Forms.Button();
            this.buttonDisable = new System.Windows.Forms.Button();
            this.dataGridViewDisable = new System.Windows.Forms.DataGridView();
            this.labelNoDisableTip = new System.Windows.Forms.Label();
            this.textBoxDisableSearch = new System.Windows.Forms.TextBox();
            this.labelDisableSrarch = new System.Windows.Forms.Label();
            this.labelEnableSearch = new System.Windows.Forms.Label();
            this.textBoxEnableSearch = new System.Windows.Forms.TextBox();
            this.linkLabelMore = new System.Windows.Forms.LinkLabel();
            this.groupBoxEnableList = new System.Windows.Forms.GroupBox();
            this.groupBoxDisableList = new System.Windows.Forms.GroupBox();
            this.labelDisabledList = new System.Windows.Forms.Label();
            this.labelEnabledList = new System.Windows.Forms.Label();
            this.linkLabelReset = new System.Windows.Forms.LinkLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEnable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisable)).BeginInit();
            this.groupBoxEnableList.SuspendLayout();
            this.groupBoxDisableList.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.AutoSize = true;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(600, 545);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 14;
            this.buttonOK.Text = "&OK";
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(705, 545);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 27);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "&Cancel";
            // 
            // dataGridViewEnable
            // 
            this.dataGridViewEnable.AllowUserToAddRows = false;
            this.dataGridViewEnable.AllowUserToDeleteRows = false;
            this.dataGridViewEnable.AllowUserToOrderColumns = true;
            this.dataGridViewEnable.AllowUserToResizeRows = false;
            this.dataGridViewEnable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEnable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewEnable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewEnable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewEnable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridViewEnable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEnable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEnable.ColumnHeadersVisible = false;
            this.dataGridViewEnable.EnableHeadersVisualStyles = false;
            this.dataGridViewEnable.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewEnable.Location = new System.Drawing.Point(2, 50);
            this.dataGridViewEnable.Name = "dataGridViewEnable";
            this.dataGridViewEnable.ReadOnly = true;
            this.dataGridViewEnable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewEnable.RowHeadersVisible = false;
            this.dataGridViewEnable.RowHeadersWidth = 51;
            this.dataGridViewEnable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEnable.Size = new System.Drawing.Size(360, 446);
            this.dataGridViewEnable.TabIndex = 9;
            this.dataGridViewEnable.TabStop = false;
            // 
            // buttonEnable
            // 
            this.buttonEnable.Location = new System.Drawing.Point(383, 217);
            this.buttonEnable.Name = "buttonEnable";
            this.buttonEnable.Size = new System.Drawing.Size(51, 23);
            this.buttonEnable.TabIndex = 7;
            this.buttonEnable.Text = "->";
            this.buttonEnable.UseVisualStyleBackColor = true;
            this.buttonEnable.Click += new System.EventHandler(this.buttonEnable_Click);
            // 
            // buttonDisable
            // 
            this.buttonDisable.Location = new System.Drawing.Point(383, 282);
            this.buttonDisable.Name = "buttonDisable";
            this.buttonDisable.Size = new System.Drawing.Size(51, 23);
            this.buttonDisable.TabIndex = 8;
            this.buttonDisable.Text = "<-";
            this.buttonDisable.UseVisualStyleBackColor = true;
            this.buttonDisable.Click += new System.EventHandler(this.buttonDisable_Click);
            // 
            // dataGridViewDisable
            // 
            this.dataGridViewDisable.AllowUserToAddRows = false;
            this.dataGridViewDisable.AllowUserToDeleteRows = false;
            this.dataGridViewDisable.AllowUserToOrderColumns = true;
            this.dataGridViewDisable.AllowUserToResizeRows = false;
            this.dataGridViewDisable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDisable.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewDisable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDisable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewDisable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridViewDisable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDisable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDisable.ColumnHeadersVisible = false;
            this.dataGridViewDisable.EnableHeadersVisualStyles = false;
            this.dataGridViewDisable.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewDisable.Location = new System.Drawing.Point(2, 49);
            this.dataGridViewDisable.Name = "dataGridViewDisable";
            this.dataGridViewDisable.ReadOnly = true;
            this.dataGridViewDisable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewDisable.RowHeadersVisible = false;
            this.dataGridViewDisable.RowHeadersWidth = 51;
            this.dataGridViewDisable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDisable.Size = new System.Drawing.Size(360, 447);
            this.dataGridViewDisable.TabIndex = 5;
            this.dataGridViewDisable.TabStop = false;
            // 
            // labelNoDisableTip
            // 
            this.labelNoDisableTip.ForeColor = System.Drawing.Color.Red;
            this.labelNoDisableTip.Location = new System.Drawing.Point(249, 551);
            this.labelNoDisableTip.Name = "labelNoDisableTip";
            this.labelNoDisableTip.Size = new System.Drawing.Size(318, 15);
            this.labelNoDisableTip.TabIndex = 13;
            this.labelNoDisableTip.Text = "Can not disable the provider in used !";
            this.labelNoDisableTip.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelNoDisableTip.Visible = false;
            // 
            // textBoxDisableSearch
            // 
            this.textBoxDisableSearch.Location = new System.Drawing.Point(79, 16);
            this.textBoxDisableSearch.Name = "textBoxDisableSearch";
            this.textBoxDisableSearch.Size = new System.Drawing.Size(283, 25);
            this.textBoxDisableSearch.TabIndex = 2;
            this.textBoxDisableSearch.TextChanged += new System.EventHandler(this.textBoxSearchDisabled_TextChanged);
            // 
            // labelDisableSrarch
            // 
            this.labelDisableSrarch.AutoSize = true;
            this.labelDisableSrarch.Location = new System.Drawing.Point(2, 20);
            this.labelDisableSrarch.Name = "labelDisableSrarch";
            this.labelDisableSrarch.Size = new System.Drawing.Size(71, 15);
            this.labelDisableSrarch.TabIndex = 1;
            this.labelDisableSrarch.Text = "Search: ";
            // 
            // labelEnableSearch
            // 
            this.labelEnableSearch.AutoSize = true;
            this.labelEnableSearch.Location = new System.Drawing.Point(2, 21);
            this.labelEnableSearch.Name = "labelEnableSearch";
            this.labelEnableSearch.Size = new System.Drawing.Size(71, 15);
            this.labelEnableSearch.TabIndex = 3;
            this.labelEnableSearch.Text = "Search: ";
            // 
            // textBoxEnableSearch
            // 
            this.textBoxEnableSearch.Location = new System.Drawing.Point(79, 15);
            this.textBoxEnableSearch.Name = "textBoxEnableSearch";
            this.textBoxEnableSearch.Size = new System.Drawing.Size(283, 25);
            this.textBoxEnableSearch.TabIndex = 4;
            this.textBoxEnableSearch.TextChanged += new System.EventHandler(this.textBoxSearchEnabled_TextChanged);
            // 
            // linkLabelMore
            // 
            this.linkLabelMore.AutoSize = true;
            this.linkLabelMore.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelMore.Location = new System.Drawing.Point(12, 551);
            this.linkLabelMore.Name = "linkLabelMore";
            this.linkLabelMore.Size = new System.Drawing.Size(55, 15);
            this.linkLabelMore.TabIndex = 12;
            this.linkLabelMore.TabStop = true;
            this.linkLabelMore.Text = "More ?";
            this.linkLabelMore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMore_LinkClicked);
            // 
            // groupBoxEnableList
            // 
            this.groupBoxEnableList.Controls.Add(this.dataGridViewEnable);
            this.groupBoxEnableList.Controls.Add(this.labelEnableSearch);
            this.groupBoxEnableList.Controls.Add(this.textBoxEnableSearch);
            this.groupBoxEnableList.Location = new System.Drawing.Point(442, 3);
            this.groupBoxEnableList.Name = "groupBoxEnableList";
            this.groupBoxEnableList.Size = new System.Drawing.Size(364, 500);
            this.groupBoxEnableList.TabIndex = 0;
            this.groupBoxEnableList.TabStop = false;
            // 
            // groupBoxDisableList
            // 
            this.groupBoxDisableList.Controls.Add(this.dataGridViewDisable);
            this.groupBoxDisableList.Controls.Add(this.textBoxDisableSearch);
            this.groupBoxDisableList.Controls.Add(this.labelDisableSrarch);
            this.groupBoxDisableList.Location = new System.Drawing.Point(12, 4);
            this.groupBoxDisableList.Name = "groupBoxDisableList";
            this.groupBoxDisableList.Size = new System.Drawing.Size(364, 500);
            this.groupBoxDisableList.TabIndex = 0;
            this.groupBoxDisableList.TabStop = false;
            // 
            // labelDisabledList
            // 
            this.labelDisabledList.AutoSize = true;
            this.labelDisabledList.Location = new System.Drawing.Point(127, 512);
            this.labelDisabledList.Name = "labelDisabledList";
            this.labelDisabledList.Size = new System.Drawing.Size(111, 15);
            this.labelDisabledList.TabIndex = 10;
            this.labelDisabledList.Text = "Disabled List";
            // 
            // labelEnabledList
            // 
            this.labelEnabledList.AutoSize = true;
            this.labelEnabledList.Location = new System.Drawing.Point(588, 512);
            this.labelEnabledList.Name = "labelEnabledList";
            this.labelEnabledList.Size = new System.Drawing.Size(103, 15);
            this.labelEnabledList.TabIndex = 11;
            this.labelEnabledList.Text = "Enabled List";
            // 
            // linkLabelReset
            // 
            this.linkLabelReset.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelReset.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelReset.Location = new System.Drawing.Point(383, 56);
            this.linkLabelReset.Name = "linkLabelReset";
            this.linkLabelReset.Size = new System.Drawing.Size(51, 23);
            this.linkLabelReset.TabIndex = 6;
            this.linkLabelReset.TabStop = true;
            this.linkLabelReset.Text = "↻";
            this.linkLabelReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabelReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelResort_LinkClicked);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 100;
            // 
            // ProvidersManage
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(819, 584);
            this.Controls.Add(this.linkLabelReset);
            this.Controls.Add(this.labelEnabledList);
            this.Controls.Add(this.labelDisabledList);
            this.Controls.Add(this.groupBoxDisableList);
            this.Controls.Add(this.groupBoxEnableList);
            this.Controls.Add(this.linkLabelMore);
            this.Controls.Add(this.labelNoDisableTip);
            this.Controls.Add(this.buttonDisable);
            this.Controls.Add(this.buttonEnable);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProvidersManage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Providers Manage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProvidersManage_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEnable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisable)).EndInit();
            this.groupBoxEnableList.ResumeLayout(false);
            this.groupBoxEnableList.PerformLayout();
            this.groupBoxDisableList.ResumeLayout(false);
            this.groupBoxDisableList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private DataGridView dataGridViewEnable;
        private Button buttonEnable;
        private Button buttonDisable;
        private DataGridView dataGridViewDisable;
        private Label labelNoDisableTip;
        private TextBox textBoxDisableSearch;
        private Label labelDisableSrarch;
        private Label labelEnableSearch;
        private TextBox textBoxEnableSearch;
        private LinkLabel linkLabelMore;
        private GroupBox groupBoxEnableList;
        private GroupBox groupBoxDisableList;
        private Label labelDisabledList;
        private Label labelEnabledList;
        private LinkLabel linkLabelReset;
        private ToolTip toolTip;
    }
}