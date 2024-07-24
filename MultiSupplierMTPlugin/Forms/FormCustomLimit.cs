using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using System;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyEnum;

namespace MultiSupplierMTPlugin.Forms
{
    public partial class FormCustomLimit : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;
        
        private string selectedServices;

        public FormCustomLimit(MultiSupplierMTOptions options, IEnvironment environment, string selectedServices)
        {
            InitializeComponent();

            this.options = options;
            this.environment = environment;
            this.selectedServices = selectedServices;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            localized();

            loadOptions();
        }

        private void localized()
        {
            Text = LLH.G(LLK.FormCustomLimit);

            tabPageSegmentLimit.Text = LLH.G(LLK.FormCustomLimit_TabPageSegmentLimit);
            labelMaxSegmentsPerRequest.Text = LLH.G(LLK.FormCustomLimit_LabelMaxSegmentsPerRequest);
            labelNoBathTip.Text = LLH.G(LLK.FormCustomLimit_LabelNoBathTip);

            tabPageRateLimit.Text = LLH.G(LLK.FormCustomLimit_TabPageRateLimit);
            labelMaxRequestsPerWindow.Text = LLH.G(LLK.FormCustomLimit_LabelMaxRequestsPerWindow);
            labelWindowSizeMs.Text = LLH.G(LLK.FormCustomLimit_LabelWindowSizeMs);
            labelRequestSmoothness.Text = LLH.G(LLK.FormCustomLimit_LabelRequestSmoothness);

            tabPageConcurrencyLimit.Text = LLH.G(LLK.FormCustomLimit_TabPageConcurrencyLimit);
            labelMaxRequestsHold.Text = LLH.G(LLK.FormCustomLimit_LabelMaxRequestsHold);

            tabPageRetryLimit.Text = LLH.G(LLK.FormCustomLimit_TabPageRetryLimit);
            labelNumberOfRetries.Text = LLH.G(LLK.FormCustomLimit_LabelNumberOfRetries);
            labelFailedTimeoutMs.Text = LLH.G(LLK.FormCustomLimit_LabelFailedTimeoutMs);
            labelRetryWaitingMs.Text = LLH.G(LLK.FormCustomLimit_LabelRetryWaitingMs);

            buttonLoadProviderDefault.Text = LLH.G(LLK.FormCustomLimit_ButtonLoadProviderDefault);

            buttonOK.Text = LLH.G(LLK.Form_ButtonOK);
            buttonCancel.Text = LLH.G(LLK.Form_ButtonCancel);
        }

        private void loadOptions()
        {
            if (ServiceHelper.GetService(selectedServices).IsBatchSupported())
            {
                numericUpDownMaxSegmentsPerRequest.Value = options.GeneralSettings.MaxSegmentsPerRequest;
                numericUpDownMaxSegmentsPerRequest.Enabled = true;
                labelNoBathTip.Visible = false;
            }
            else
            {
                numericUpDownMaxSegmentsPerRequest.Value = 1;
                numericUpDownMaxSegmentsPerRequest.Enabled = false;
                labelNoBathTip.Visible = true;
            }

            numericUpDownMaxRequestsPerWindow.Value = options.GeneralSettings.MaxRequestsPerWindow;
            numericUpDownWindowSizeMs.Value = options.GeneralSettings.WindowSizeMs;
            numericUpDownRequestSmoothness.Value = (decimal)options.GeneralSettings.RequestSmoothness;

            numericUpDownMaxRequestsHold.Value = options.GeneralSettings.MaxRequestsHold;

            numericUpDownNumberOfRetries.Value = options.GeneralSettings.NumberOfRetries;
            numericUpDownFailedTimeoutMs.Value = options.GeneralSettings.FailedTimeoutMs;
            numericUpDownRetryWaitingMs.Value = options.GeneralSettings.RetryWaitingMs;
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                options.GeneralSettings.MaxSegmentsPerRequest = (int)numericUpDownMaxSegmentsPerRequest.Value;

                options.GeneralSettings.MaxRequestsPerWindow = (int)numericUpDownMaxRequestsPerWindow.Value;
                options.GeneralSettings.WindowSizeMs = (int)numericUpDownWindowSizeMs.Value;
                numericUpDownRequestSmoothness.Value = (decimal)options.GeneralSettings.RequestSmoothness;

                options.GeneralSettings.MaxRequestsHold = (int)numericUpDownMaxRequestsHold.Value;

                options.GeneralSettings.NumberOfRetries = (int)numericUpDownNumberOfRetries.Value;
                options.GeneralSettings.FailedTimeoutMs = (int)numericUpDownFailedTimeoutMs.Value;
                options.GeneralSettings.RetryWaitingMs = (int)numericUpDownRetryWaitingMs.Value;
            }
        }

        private void buttonLoadProviderDefault_Click(object sender, EventArgs e)
        {
            var currentService = ServiceHelper.GetService(selectedServices);

            numericUpDownMaxSegmentsPerRequest.Value = currentService.MaxBatchSize();

            numericUpDownMaxRequestsPerWindow.Value = currentService.MaxQueriesPerWindow();
            numericUpDownWindowSizeMs.Value = currentService.WindowSizeMs();
            numericUpDownRequestSmoothness.Value = (decimal)currentService.Smoothness();

            numericUpDownMaxRequestsHold.Value = currentService.MaxThreadHold();

            numericUpDownNumberOfRetries.Value = currentService.NumberOfRetries();
            numericUpDownFailedTimeoutMs.Value = currentService.FailedTimeoutMs();
            numericUpDownRetryWaitingMs.Value = currentService.RetryWaitingMs();
        }
    }
}
