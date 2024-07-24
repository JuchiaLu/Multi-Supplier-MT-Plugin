namespace MultiSupplierMTPlugin.Forms
{
    partial class FormCustomLimit
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
            this.labelMaxSegmentsPerRequest = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.numericUpDownMaxSegmentsPerRequest = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxRequestsPerWindow = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxRequestsHold = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWindowSizeMs = new System.Windows.Forms.NumericUpDown();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSegmentLimit = new System.Windows.Forms.TabPage();
            this.labelNoBathTip = new System.Windows.Forms.Label();
            this.tabPageRateLimit = new System.Windows.Forms.TabPage();
            this.labelWindowSizeMs = new System.Windows.Forms.Label();
            this.labelMaxRequestsPerWindow = new System.Windows.Forms.Label();
            this.labelRequestSmoothness = new System.Windows.Forms.Label();
            this.numericUpDownRequestSmoothness = new System.Windows.Forms.NumericUpDown();
            this.tabPageConcurrencyLimit = new System.Windows.Forms.TabPage();
            this.labelMaxRequestsHold = new System.Windows.Forms.Label();
            this.tabPageRetryLimit = new System.Windows.Forms.TabPage();
            this.numericUpDownNumberOfRetries = new System.Windows.Forms.NumericUpDown();
            this.labelFailedTimeoutMs = new System.Windows.Forms.Label();
            this.labelNumberOfRetries = new System.Windows.Forms.Label();
            this.numericUpDownFailedTimeoutMs = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRetryWaitingMs = new System.Windows.Forms.NumericUpDown();
            this.labelRetryWaitingMs = new System.Windows.Forms.Label();
            this.buttonLoadProviderDefault = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSegmentsPerRequest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxRequestsPerWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxRequestsHold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowSizeMs)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageSegmentLimit.SuspendLayout();
            this.tabPageRateLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRequestSmoothness)).BeginInit();
            this.tabPageConcurrencyLimit.SuspendLayout();
            this.tabPageRetryLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRetries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFailedTimeoutMs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRetryWaitingMs)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMaxSegmentsPerRequest
            // 
            this.labelMaxSegmentsPerRequest.AutoSize = true;
            this.labelMaxSegmentsPerRequest.Location = new System.Drawing.Point(7, 17);
            this.labelMaxSegmentsPerRequest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaxSegmentsPerRequest.Name = "labelMaxSegmentsPerRequest";
            this.labelMaxSegmentsPerRequest.Size = new System.Drawing.Size(199, 15);
            this.labelMaxSegmentsPerRequest.TabIndex = 1;
            this.labelMaxSegmentsPerRequest.Text = "Max Segments Per Request";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(267, 166);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 27);
            this.buttonOK.TabIndex = 19;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(373, 166);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(103, 27);
            this.buttonCancel.TabIndex = 20;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // numericUpDownMaxSegmentsPerRequest
            // 
            this.numericUpDownMaxSegmentsPerRequest.Location = new System.Drawing.Point(305, 12);
            this.numericUpDownMaxSegmentsPerRequest.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownMaxSegmentsPerRequest.Name = "numericUpDownMaxSegmentsPerRequest";
            this.numericUpDownMaxSegmentsPerRequest.Size = new System.Drawing.Size(147, 25);
            this.numericUpDownMaxSegmentsPerRequest.TabIndex = 2;
            // 
            // numericUpDownMaxRequestsPerWindow
            // 
            this.numericUpDownMaxRequestsPerWindow.Location = new System.Drawing.Point(304, 12);
            this.numericUpDownMaxRequestsPerWindow.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownMaxRequestsPerWindow.Name = "numericUpDownMaxRequestsPerWindow";
            this.numericUpDownMaxRequestsPerWindow.Size = new System.Drawing.Size(147, 25);
            this.numericUpDownMaxRequestsPerWindow.TabIndex = 5;
            // 
            // numericUpDownMaxRequestsHold
            // 
            this.numericUpDownMaxRequestsHold.Location = new System.Drawing.Point(305, 13);
            this.numericUpDownMaxRequestsHold.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownMaxRequestsHold.Name = "numericUpDownMaxRequestsHold";
            this.numericUpDownMaxRequestsHold.Size = new System.Drawing.Size(147, 25);
            this.numericUpDownMaxRequestsHold.TabIndex = 11;
            // 
            // numericUpDownWindowSizeMs
            // 
            this.numericUpDownWindowSizeMs.Location = new System.Drawing.Point(304, 47);
            this.numericUpDownWindowSizeMs.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownWindowSizeMs.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWindowSizeMs.Name = "numericUpDownWindowSizeMs";
            this.numericUpDownWindowSizeMs.Size = new System.Drawing.Size(147, 25);
            this.numericUpDownWindowSizeMs.TabIndex = 7;
            this.numericUpDownWindowSizeMs.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageSegmentLimit);
            this.tabControl.Controls.Add(this.tabPageRateLimit);
            this.tabControl.Controls.Add(this.tabPageConcurrencyLimit);
            this.tabControl.Controls.Add(this.tabPageRetryLimit);
            this.tabControl.Location = new System.Drawing.Point(8, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(471, 146);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageSegmentLimit
            // 
            this.tabPageSegmentLimit.Controls.Add(this.labelNoBathTip);
            this.tabPageSegmentLimit.Controls.Add(this.labelMaxSegmentsPerRequest);
            this.tabPageSegmentLimit.Controls.Add(this.numericUpDownMaxSegmentsPerRequest);
            this.tabPageSegmentLimit.Location = new System.Drawing.Point(4, 25);
            this.tabPageSegmentLimit.Name = "tabPageSegmentLimit";
            this.tabPageSegmentLimit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSegmentLimit.Size = new System.Drawing.Size(463, 117);
            this.tabPageSegmentLimit.TabIndex = 0;
            this.tabPageSegmentLimit.Text = "Segment Limit";
            this.tabPageSegmentLimit.UseVisualStyleBackColor = true;
            // 
            // labelNoBathTip
            // 
            this.labelNoBathTip.AutoSize = true;
            this.labelNoBathTip.ForeColor = System.Drawing.Color.Red;
            this.labelNoBathTip.Location = new System.Drawing.Point(7, 67);
            this.labelNoBathTip.Name = "labelNoBathTip";
            this.labelNoBathTip.Size = new System.Drawing.Size(407, 15);
            this.labelNoBathTip.TabIndex = 3;
            this.labelNoBathTip.Text = "Selected provider no supported  batch translation!";
            this.labelNoBathTip.Visible = false;
            // 
            // tabPageRateLimit
            // 
            this.tabPageRateLimit.Controls.Add(this.labelWindowSizeMs);
            this.tabPageRateLimit.Controls.Add(this.labelMaxRequestsPerWindow);
            this.tabPageRateLimit.Controls.Add(this.labelRequestSmoothness);
            this.tabPageRateLimit.Controls.Add(this.numericUpDownWindowSizeMs);
            this.tabPageRateLimit.Controls.Add(this.numericUpDownMaxRequestsPerWindow);
            this.tabPageRateLimit.Controls.Add(this.numericUpDownRequestSmoothness);
            this.tabPageRateLimit.Location = new System.Drawing.Point(4, 25);
            this.tabPageRateLimit.Name = "tabPageRateLimit";
            this.tabPageRateLimit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRateLimit.Size = new System.Drawing.Size(463, 117);
            this.tabPageRateLimit.TabIndex = 1;
            this.tabPageRateLimit.Text = "Rate Limit";
            this.tabPageRateLimit.UseVisualStyleBackColor = true;
            // 
            // labelWindowSizeMs
            // 
            this.labelWindowSizeMs.AutoSize = true;
            this.labelWindowSizeMs.Location = new System.Drawing.Point(6, 52);
            this.labelWindowSizeMs.Name = "labelWindowSizeMs";
            this.labelWindowSizeMs.Size = new System.Drawing.Size(119, 15);
            this.labelWindowSizeMs.TabIndex = 6;
            this.labelWindowSizeMs.Text = "Window Size Ms";
            // 
            // labelMaxRequestsPerWindow
            // 
            this.labelMaxRequestsPerWindow.AutoSize = true;
            this.labelMaxRequestsPerWindow.Location = new System.Drawing.Point(6, 17);
            this.labelMaxRequestsPerWindow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaxRequestsPerWindow.Name = "labelMaxRequestsPerWindow";
            this.labelMaxRequestsPerWindow.Size = new System.Drawing.Size(191, 15);
            this.labelMaxRequestsPerWindow.TabIndex = 4;
            this.labelMaxRequestsPerWindow.Text = "Max Requests Per Window";
            // 
            // labelRequestSmoothness
            // 
            this.labelRequestSmoothness.AutoSize = true;
            this.labelRequestSmoothness.Location = new System.Drawing.Point(6, 87);
            this.labelRequestSmoothness.Name = "labelRequestSmoothness";
            this.labelRequestSmoothness.Size = new System.Drawing.Size(151, 15);
            this.labelRequestSmoothness.TabIndex = 8;
            this.labelRequestSmoothness.Text = "Request Smoothness";
            // 
            // numericUpDownRequestSmoothness
            // 
            this.numericUpDownRequestSmoothness.DecimalPlaces = 2;
            this.numericUpDownRequestSmoothness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownRequestSmoothness.Location = new System.Drawing.Point(304, 82);
            this.numericUpDownRequestSmoothness.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRequestSmoothness.Name = "numericUpDownRequestSmoothness";
            this.numericUpDownRequestSmoothness.Size = new System.Drawing.Size(147, 25);
            this.numericUpDownRequestSmoothness.TabIndex = 9;
            this.numericUpDownRequestSmoothness.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            // 
            // tabPageConcurrencyLimit
            // 
            this.tabPageConcurrencyLimit.Controls.Add(this.labelMaxRequestsHold);
            this.tabPageConcurrencyLimit.Controls.Add(this.numericUpDownMaxRequestsHold);
            this.tabPageConcurrencyLimit.Location = new System.Drawing.Point(4, 25);
            this.tabPageConcurrencyLimit.Name = "tabPageConcurrencyLimit";
            this.tabPageConcurrencyLimit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConcurrencyLimit.Size = new System.Drawing.Size(463, 117);
            this.tabPageConcurrencyLimit.TabIndex = 2;
            this.tabPageConcurrencyLimit.Text = "Concurrency Limit";
            this.tabPageConcurrencyLimit.UseVisualStyleBackColor = true;
            // 
            // labelMaxRequestsHold
            // 
            this.labelMaxRequestsHold.AutoSize = true;
            this.labelMaxRequestsHold.Location = new System.Drawing.Point(7, 18);
            this.labelMaxRequestsHold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaxRequestsHold.Name = "labelMaxRequestsHold";
            this.labelMaxRequestsHold.Size = new System.Drawing.Size(143, 15);
            this.labelMaxRequestsHold.TabIndex = 10;
            this.labelMaxRequestsHold.Text = "Max Requests Hold";
            // 
            // tabPageRetryLimit
            // 
            this.tabPageRetryLimit.Controls.Add(this.numericUpDownNumberOfRetries);
            this.tabPageRetryLimit.Controls.Add(this.labelFailedTimeoutMs);
            this.tabPageRetryLimit.Controls.Add(this.labelNumberOfRetries);
            this.tabPageRetryLimit.Controls.Add(this.numericUpDownFailedTimeoutMs);
            this.tabPageRetryLimit.Controls.Add(this.numericUpDownRetryWaitingMs);
            this.tabPageRetryLimit.Controls.Add(this.labelRetryWaitingMs);
            this.tabPageRetryLimit.Location = new System.Drawing.Point(4, 25);
            this.tabPageRetryLimit.Name = "tabPageRetryLimit";
            this.tabPageRetryLimit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRetryLimit.Size = new System.Drawing.Size(463, 117);
            this.tabPageRetryLimit.TabIndex = 3;
            this.tabPageRetryLimit.Text = "Retry Limit";
            this.tabPageRetryLimit.UseVisualStyleBackColor = true;
            // 
            // numericUpDownNumberOfRetries
            // 
            this.numericUpDownNumberOfRetries.Location = new System.Drawing.Point(304, 11);
            this.numericUpDownNumberOfRetries.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownNumberOfRetries.Name = "numericUpDownNumberOfRetries";
            this.numericUpDownNumberOfRetries.Size = new System.Drawing.Size(147, 25);
            this.numericUpDownNumberOfRetries.TabIndex = 13;
            // 
            // labelFailedTimeoutMs
            // 
            this.labelFailedTimeoutMs.AutoSize = true;
            this.labelFailedTimeoutMs.Location = new System.Drawing.Point(6, 52);
            this.labelFailedTimeoutMs.Name = "labelFailedTimeoutMs";
            this.labelFailedTimeoutMs.Size = new System.Drawing.Size(143, 15);
            this.labelFailedTimeoutMs.TabIndex = 14;
            this.labelFailedTimeoutMs.Text = "Failed Timeout Ms";
            // 
            // labelNumberOfRetries
            // 
            this.labelNumberOfRetries.AutoSize = true;
            this.labelNumberOfRetries.Location = new System.Drawing.Point(6, 16);
            this.labelNumberOfRetries.Name = "labelNumberOfRetries";
            this.labelNumberOfRetries.Size = new System.Drawing.Size(143, 15);
            this.labelNumberOfRetries.TabIndex = 12;
            this.labelNumberOfRetries.Text = "Number Of Retries";
            // 
            // numericUpDownFailedTimeoutMs
            // 
            this.numericUpDownFailedTimeoutMs.Location = new System.Drawing.Point(304, 47);
            this.numericUpDownFailedTimeoutMs.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownFailedTimeoutMs.Name = "numericUpDownFailedTimeoutMs";
            this.numericUpDownFailedTimeoutMs.Size = new System.Drawing.Size(147, 25);
            this.numericUpDownFailedTimeoutMs.TabIndex = 15;
            // 
            // numericUpDownRetryWaitingMs
            // 
            this.numericUpDownRetryWaitingMs.Location = new System.Drawing.Point(304, 83);
            this.numericUpDownRetryWaitingMs.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownRetryWaitingMs.Name = "numericUpDownRetryWaitingMs";
            this.numericUpDownRetryWaitingMs.Size = new System.Drawing.Size(147, 25);
            this.numericUpDownRetryWaitingMs.TabIndex = 17;
            // 
            // labelRetryWaitingMs
            // 
            this.labelRetryWaitingMs.AutoSize = true;
            this.labelRetryWaitingMs.Location = new System.Drawing.Point(6, 88);
            this.labelRetryWaitingMs.Name = "labelRetryWaitingMs";
            this.labelRetryWaitingMs.Size = new System.Drawing.Size(135, 15);
            this.labelRetryWaitingMs.TabIndex = 16;
            this.labelRetryWaitingMs.Text = "Retry Waiting Ms";
            // 
            // buttonLoadProviderDefault
            // 
            this.buttonLoadProviderDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoadProviderDefault.Location = new System.Drawing.Point(12, 166);
            this.buttonLoadProviderDefault.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonLoadProviderDefault.Name = "buttonLoadProviderDefault";
            this.buttonLoadProviderDefault.Size = new System.Drawing.Size(247, 27);
            this.buttonLoadProviderDefault.TabIndex = 18;
            this.buttonLoadProviderDefault.Text = "&Load provider default";
            this.buttonLoadProviderDefault.UseVisualStyleBackColor = true;
            this.buttonLoadProviderDefault.Click += new System.EventHandler(this.buttonLoadProviderDefault_Click);
            // 
            // FormCustomLimit
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(483, 204);
            this.Controls.Add(this.buttonLoadProviderDefault);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCustomLimit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Limit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxSegmentsPerRequest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxRequestsPerWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxRequestsHold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowSizeMs)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageSegmentLimit.ResumeLayout(false);
            this.tabPageSegmentLimit.PerformLayout();
            this.tabPageRateLimit.ResumeLayout(false);
            this.tabPageRateLimit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRequestSmoothness)).EndInit();
            this.tabPageConcurrencyLimit.ResumeLayout(false);
            this.tabPageConcurrencyLimit.PerformLayout();
            this.tabPageRetryLimit.ResumeLayout(false);
            this.tabPageRetryLimit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRetries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFailedTimeoutMs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRetryWaitingMs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelMaxSegmentsPerRequest;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxSegmentsPerRequest;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxRequestsPerWindow;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxRequestsHold;
        private System.Windows.Forms.NumericUpDown numericUpDownWindowSizeMs;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSegmentLimit;
        private System.Windows.Forms.TabPage tabPageRateLimit;
        private System.Windows.Forms.TabPage tabPageConcurrencyLimit;
        private System.Windows.Forms.TabPage tabPageRetryLimit;
        private System.Windows.Forms.NumericUpDown numericUpDownRequestSmoothness;
        private System.Windows.Forms.Label labelRequestSmoothness;
        private System.Windows.Forms.Label labelWindowSizeMs;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfRetries;
        private System.Windows.Forms.NumericUpDown numericUpDownRetryWaitingMs;
        private System.Windows.Forms.NumericUpDown numericUpDownFailedTimeoutMs;
        private System.Windows.Forms.Label labelNumberOfRetries;
        private System.Windows.Forms.Label labelRetryWaitingMs;
        private System.Windows.Forms.Label labelFailedTimeoutMs;
        private System.Windows.Forms.Label labelMaxRequestsPerWindow;
        private System.Windows.Forms.Label labelMaxRequestsHold;
        private System.Windows.Forms.Button buttonLoadProviderDefault;
        private System.Windows.Forms.Label labelNoBathTip;
    }
}