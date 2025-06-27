namespace MultiSupplierMTPlugin.Forms
{
    partial class StatsAndLog
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelSuccessRequests = new System.Windows.Forms.Label();
            this.labelSuccessCountValue = new System.Windows.Forms.Label();
            this.linkLabelResetStats = new System.Windows.Forms.LinkLabel();
            this.labelFailedRequest = new System.Windows.Forms.Label();
            this.labelFailedCountValue = new System.Windows.Forms.Label();
            this.radioButtonDebug = new System.Windows.Forms.RadioButton();
            this.labelLoggingLevel = new System.Windows.Forms.Label();
            this.radioButtonInfo = new System.Windows.Forms.RadioButton();
            this.radioButtonWarn = new System.Windows.Forms.RadioButton();
            this.radioButtonError = new System.Windows.Forms.RadioButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.linkLabelOpenLogFile = new System.Windows.Forms.LinkLabel();
            this.linkLabelOpenLogDir = new System.Windows.Forms.LinkLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageStatistics = new System.Windows.Forms.TabPage();
            this.tabPageLogging = new System.Windows.Forms.TabPage();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl.SuspendLayout();
            this.tabPageStatistics.SuspendLayout();
            this.tabPageLogging.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(290, 158);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 12;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // labelSuccessRequests
            // 
            this.labelSuccessRequests.AutoSize = true;
            this.labelSuccessRequests.Location = new System.Drawing.Point(12, 27);
            this.labelSuccessRequests.Name = "labelSuccessRequests";
            this.labelSuccessRequests.Size = new System.Drawing.Size(135, 15);
            this.labelSuccessRequests.TabIndex = 0;
            this.labelSuccessRequests.Text = "Success Requests";
            // 
            // labelSuccessCountValue
            // 
            this.labelSuccessCountValue.AutoSize = true;
            this.labelSuccessCountValue.Location = new System.Drawing.Point(167, 27);
            this.labelSuccessCountValue.Name = "labelSuccessCountValue";
            this.labelSuccessCountValue.Size = new System.Drawing.Size(15, 15);
            this.labelSuccessCountValue.TabIndex = 1;
            this.labelSuccessCountValue.Text = "0";
            // 
            // linkLabelResetStats
            // 
            this.linkLabelResetStats.AutoSize = true;
            this.linkLabelResetStats.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelResetStats.Location = new System.Drawing.Point(282, 56);
            this.linkLabelResetStats.Name = "linkLabelResetStats";
            this.linkLabelResetStats.Size = new System.Drawing.Size(95, 15);
            this.linkLabelResetStats.TabIndex = 4;
            this.linkLabelResetStats.TabStop = true;
            this.linkLabelResetStats.Text = "Reset Stats";
            this.linkLabelResetStats.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelResetStats_LinkClicked);
            // 
            // labelFailedRequest
            // 
            this.labelFailedRequest.AutoSize = true;
            this.labelFailedRequest.Location = new System.Drawing.Point(12, 77);
            this.labelFailedRequest.Name = "labelFailedRequest";
            this.labelFailedRequest.Size = new System.Drawing.Size(127, 15);
            this.labelFailedRequest.TabIndex = 2;
            this.labelFailedRequest.Text = "Failed Requests";
            // 
            // labelFailedCountValue
            // 
            this.labelFailedCountValue.AutoSize = true;
            this.labelFailedCountValue.Location = new System.Drawing.Point(167, 77);
            this.labelFailedCountValue.Name = "labelFailedCountValue";
            this.labelFailedCountValue.Size = new System.Drawing.Size(15, 15);
            this.labelFailedCountValue.TabIndex = 3;
            this.labelFailedCountValue.Text = "0";
            // 
            // radioButtonDebug
            // 
            this.radioButtonDebug.AutoSize = true;
            this.radioButtonDebug.Location = new System.Drawing.Point(140, 76);
            this.radioButtonDebug.Name = "radioButtonDebug";
            this.radioButtonDebug.Size = new System.Drawing.Size(68, 19);
            this.radioButtonDebug.TabIndex = 8;
            this.radioButtonDebug.TabStop = true;
            this.radioButtonDebug.Text = "Debug";
            this.radioButtonDebug.UseVisualStyleBackColor = true;
            // 
            // labelLoggingLevel
            // 
            this.labelLoggingLevel.AutoSize = true;
            this.labelLoggingLevel.Location = new System.Drawing.Point(15, 78);
            this.labelLoggingLevel.Name = "labelLoggingLevel";
            this.labelLoggingLevel.Size = new System.Drawing.Size(111, 15);
            this.labelLoggingLevel.TabIndex = 7;
            this.labelLoggingLevel.Text = "Logging Level";
            // 
            // radioButtonInfo
            // 
            this.radioButtonInfo.AutoSize = true;
            this.radioButtonInfo.Location = new System.Drawing.Point(234, 76);
            this.radioButtonInfo.Name = "radioButtonInfo";
            this.radioButtonInfo.Size = new System.Drawing.Size(60, 19);
            this.radioButtonInfo.TabIndex = 9;
            this.radioButtonInfo.TabStop = true;
            this.radioButtonInfo.Text = "Info";
            this.radioButtonInfo.UseVisualStyleBackColor = true;
            // 
            // radioButtonWarn
            // 
            this.radioButtonWarn.AutoSize = true;
            this.radioButtonWarn.Location = new System.Drawing.Point(320, 76);
            this.radioButtonWarn.Name = "radioButtonWarn";
            this.radioButtonWarn.Size = new System.Drawing.Size(60, 19);
            this.radioButtonWarn.TabIndex = 10;
            this.radioButtonWarn.TabStop = true;
            this.radioButtonWarn.Text = "Warn";
            this.radioButtonWarn.UseVisualStyleBackColor = true;
            // 
            // radioButtonError
            // 
            this.radioButtonError.AutoSize = true;
            this.radioButtonError.Location = new System.Drawing.Point(406, 76);
            this.radioButtonError.Name = "radioButtonError";
            this.radioButtonError.Size = new System.Drawing.Size(68, 19);
            this.radioButtonError.TabIndex = 11;
            this.radioButtonError.TabStop = true;
            this.radioButtonError.Text = "Error";
            this.radioButtonError.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(402, 158);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 27);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "&Cancel";
            // 
            // linkLabelOpenLogFile
            // 
            this.linkLabelOpenLogFile.AutoSize = true;
            this.linkLabelOpenLogFile.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelOpenLogFile.Location = new System.Drawing.Point(15, 28);
            this.linkLabelOpenLogFile.Name = "linkLabelOpenLogFile";
            this.linkLabelOpenLogFile.Size = new System.Drawing.Size(111, 15);
            this.linkLabelOpenLogFile.TabIndex = 5;
            this.linkLabelOpenLogFile.TabStop = true;
            this.linkLabelOpenLogFile.Text = "Open Log File";
            this.linkLabelOpenLogFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOpenLogFile_LinkClicked);
            // 
            // linkLabelOpenLogDir
            // 
            this.linkLabelOpenLogDir.AutoSize = true;
            this.linkLabelOpenLogDir.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelOpenLogDir.Location = new System.Drawing.Point(371, 28);
            this.linkLabelOpenLogDir.Name = "linkLabelOpenLogDir";
            this.linkLabelOpenLogDir.Size = new System.Drawing.Size(103, 15);
            this.linkLabelOpenLogDir.TabIndex = 6;
            this.linkLabelOpenLogDir.TabStop = true;
            this.linkLabelOpenLogDir.Text = "Open Log Dir";
            this.linkLabelOpenLogDir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOpenLogDir_LinkClicked);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageStatistics);
            this.tabControl.Controls.Add(this.tabPageLogging);
            this.tabControl.Location = new System.Drawing.Point(4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(502, 150);
            this.tabControl.TabIndex = 14;
            // 
            // tabPageStatistics
            // 
            this.tabPageStatistics.Controls.Add(this.linkLabelResetStats);
            this.tabPageStatistics.Controls.Add(this.labelFailedRequest);
            this.tabPageStatistics.Controls.Add(this.labelSuccessCountValue);
            this.tabPageStatistics.Controls.Add(this.labelFailedCountValue);
            this.tabPageStatistics.Controls.Add(this.labelSuccessRequests);
            this.tabPageStatistics.Location = new System.Drawing.Point(4, 25);
            this.tabPageStatistics.Name = "tabPageStatistics";
            this.tabPageStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatistics.Size = new System.Drawing.Size(494, 121);
            this.tabPageStatistics.TabIndex = 0;
            this.tabPageStatistics.Text = "Statistics";
            this.tabPageStatistics.UseVisualStyleBackColor = true;
            // 
            // tabPageLogging
            // 
            this.tabPageLogging.Controls.Add(this.linkLabelOpenLogFile);
            this.tabPageLogging.Controls.Add(this.linkLabelOpenLogDir);
            this.tabPageLogging.Controls.Add(this.labelLoggingLevel);
            this.tabPageLogging.Controls.Add(this.radioButtonDebug);
            this.tabPageLogging.Controls.Add(this.radioButtonInfo);
            this.tabPageLogging.Controls.Add(this.radioButtonError);
            this.tabPageLogging.Controls.Add(this.radioButtonWarn);
            this.tabPageLogging.Location = new System.Drawing.Point(4, 25);
            this.tabPageLogging.Name = "tabPageLogging";
            this.tabPageLogging.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogging.Size = new System.Drawing.Size(494, 121);
            this.tabPageLogging.TabIndex = 1;
            this.tabPageLogging.Text = "Logging";
            this.tabPageLogging.UseVisualStyleBackColor = true;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 100;
            // 
            // StatsAndLog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(510, 192);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatsAndLog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stats And Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatsAndLog_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPageStatistics.ResumeLayout(false);
            this.tabPageStatistics.PerformLayout();
            this.tabPageLogging.ResumeLayout(false);
            this.tabPageLogging.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelSuccessRequests;
        private System.Windows.Forms.Label labelSuccessCountValue;
        private System.Windows.Forms.LinkLabel linkLabelResetStats;
        private System.Windows.Forms.Label labelFailedRequest;
        private System.Windows.Forms.Label labelFailedCountValue;
        private System.Windows.Forms.RadioButton radioButtonDebug;
        private System.Windows.Forms.Label labelLoggingLevel;
        private System.Windows.Forms.RadioButton radioButtonInfo;
        private System.Windows.Forms.RadioButton radioButtonWarn;
        private System.Windows.Forms.RadioButton radioButtonError;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.LinkLabel linkLabelOpenLogFile;
        private System.Windows.Forms.LinkLabel linkLabelOpenLogDir;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageStatistics;
        private System.Windows.Forms.TabPage tabPageLogging;
        private System.Windows.Forms.ToolTip toolTip;
    }
}