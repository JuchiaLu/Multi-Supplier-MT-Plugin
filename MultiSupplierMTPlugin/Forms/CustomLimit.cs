using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.Localized;
using System;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Forms.CustomLimitLocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.Forms
{
    partial class CustomLimit : Form
    {
        private MultiSupplierMTGeneralSettings _mtGeneralSettings;

        private MultiSupplierMTSecureSettings _mtSecureSettings;

        private string selectedService;

        public CustomLimit(MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings, string selectedService)
        {
            InitializeComponent();

            this._mtGeneralSettings = mtGeneralSettings;
            this._mtSecureSettings = mtSecureSettings;

            this.selectedService = selectedService;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Localized();

            LoadOptions();
        }

        private void Localized()
        {
            Text = LLH.G(LLK.Form);

            tabPageSizeLimit.Text = LLH.G(LLK.TabPageSizeLimit);
            labelMaxSegmentsPerRequest.Text = LLH.G(LLK.LabelMaxSegmentsPerRequest);
            labelMaxCharactersPerRequest.Text = LLH.G(LLK.LabelMaxCharactersPerRequest);
            labelNoBathTip.Text = LLH.G(LLK.LabelNoBathTip);
            
            toolTip.SetToolTip(numericUpDownMaxSegmentsPerRequest, LLH.G(LLKC.ZeroIndicatesNoLimit));
            toolTip.SetToolTip(numericUpDownMaxCharactersPerRequest, LLH.G(LLKC.ZeroIndicatesNoLimit));

            tabPageRateLimit.Text = LLH.G(LLK.TabPageRateLimit);
            labelMaxRequestsPerWindow.Text = LLH.G(LLK.LabelMaxRequestsPerWindow);
            labelWindowSizeMs.Text = LLH.G(LLK.LabelWindowSizeMs);
            labelRequestSmoothness.Text = LLH.G(LLK.LabelRequestSmoothness);
            
            toolTip.SetToolTip(numericUpDownMaxRequestsPerWindow, LLH.G(LLKC.ZeroIndicatesNoLimit));
            toolTip.SetToolTip(numericUpDownWindowSizeMs, LLH.G(LLK.WindowSizeMsTip));
            toolTip.SetToolTip(numericUpDownRequestSmoothness, LLH.G(LLK.RequestSmoothnessTip));

            tabPageConcurrencyLimit.Text = LLH.G(LLK.TabPageConcurrencyLimit);
            labelMaxRequestsHold.Text = LLH.G(LLK.LabelMaxRequestsHold);
            
            toolTip.SetToolTip(numericUpDownMaxRequestsHold, LLH.G(LLKC.ZeroIndicatesNoLimit));

            tabPageRetryLimit.Text = LLH.G(LLK.TabPageRetryLimit);
            labelNumberOfRetries.Text = LLH.G(LLK.LabelNumberOfRetries);
            labelFailedTimeoutMs.Text = LLH.G(LLK.LabelFailedTimeoutMs);
            labelRetryWaitingMs.Text = LLH.G(LLK.LabelRetryWaitingMs);

            toolTip.SetToolTip(numericUpDownNumberOfRetries, LLH.G(LLK.NumberOfRetriesTip));
            toolTip.SetToolTip(numericUpDownFailedTimeoutMs, LLH.G(LLK.FailedTimeoutMsTip));
            toolTip.SetToolTip(numericUpDownRetryWaitingMs, LLH.G(LLK.RetryWaitingMsTip));

            buttonLoadProviderDefault.Text = LLH.G(LLK.ButtonLoadProviderDefault);

            buttonOK.Text = LLH.G(LLKC.ButtonOK);
            buttonCancel.Text = LLH.G(LLKC.ButtonCancel);
        }

        private void LoadOptions()
        {
            var service = ServiceHelper.GetServiceOrFallback(selectedService);

            if (service.IsBatchSupported)
            {
                numericUpDownMaxSegmentsPerRequest.Value = _mtGeneralSettings.MaxSegmentsPerRequest;
                numericUpDownMaxCharactersPerRequest.Value = _mtGeneralSettings.MaxCharactersPerRequest;
                numericUpDownMaxSegmentsPerRequest.Enabled = true;
                numericUpDownMaxCharactersPerRequest.Enabled = true;
                labelNoBathTip.Visible = false;
            }
            else
            {
                numericUpDownMaxSegmentsPerRequest.Value = 1;
                numericUpDownMaxCharactersPerRequest.Value = 0;
                numericUpDownMaxSegmentsPerRequest.Enabled = false;
                numericUpDownMaxCharactersPerRequest.Enabled = false;
                labelNoBathTip.Visible = true;
            }

            numericUpDownMaxRequestsPerWindow.Value = _mtGeneralSettings.MaxRequestsPerWindow;
            numericUpDownWindowSizeMs.Value = _mtGeneralSettings.WindowSizeMs;
            numericUpDownRequestSmoothness.Value = (decimal)_mtGeneralSettings.RequestSmoothness;

            numericUpDownMaxRequestsHold.Value = _mtGeneralSettings.MaxRequestsHold;

            numericUpDownNumberOfRetries.Value = _mtGeneralSettings.NumberOfRetries;
            numericUpDownFailedTimeoutMs.Value = _mtGeneralSettings.FailedTimeoutMs;
            numericUpDownRetryWaitingMs.Value = _mtGeneralSettings.RetryWaitingMs;
        }

        private void buttonLoadProviderDefault_Click(object sender, EventArgs e)
        {
            var currentService = ServiceHelper.GetServiceOrFallback(selectedService);

            numericUpDownMaxSegmentsPerRequest.Value = currentService.MaxSegments;
            numericUpDownMaxCharactersPerRequest.Value = currentService.MaxCharacters;

            numericUpDownMaxRequestsPerWindow.Value = currentService.MaxQueriesPerWindow;
            numericUpDownWindowSizeMs.Value = currentService.WindowSizeMs;
            numericUpDownRequestSmoothness.Value = (decimal)currentService.Smoothness;

            numericUpDownMaxRequestsHold.Value = currentService.MaxThreadHold;

            numericUpDownNumberOfRetries.Value = currentService.NumberOfRetries;
            numericUpDownFailedTimeoutMs.Value = currentService.FailedTimeoutMs;
            numericUpDownRetryWaitingMs.Value = currentService.RetryWaitingMs;
        }

        private void CustomLimit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _mtGeneralSettings.MaxSegmentsPerRequest = (int)numericUpDownMaxSegmentsPerRequest.Value;
                _mtGeneralSettings.MaxCharactersPerRequest = (int)numericUpDownMaxCharactersPerRequest.Value;

                _mtGeneralSettings.MaxRequestsPerWindow = (int)numericUpDownMaxRequestsPerWindow.Value;
                _mtGeneralSettings.WindowSizeMs = (int)numericUpDownWindowSizeMs.Value;
                _mtGeneralSettings.RequestSmoothness = (double)numericUpDownRequestSmoothness.Value;

                _mtGeneralSettings.MaxRequestsHold = (int)numericUpDownMaxRequestsHold.Value;

                _mtGeneralSettings.NumberOfRetries = (int)numericUpDownNumberOfRetries.Value;
                _mtGeneralSettings.FailedTimeoutMs = (int)numericUpDownFailedTimeoutMs.Value;
                _mtGeneralSettings.RetryWaitingMs = (int)numericUpDownRetryWaitingMs.Value;
            }
        }
    }

    class CustomLimitLocalizedKey : LocalizedKeyBase
    {
        public CustomLimitLocalizedKey(string name) : base(name)
        {
        }

        static CustomLimitLocalizedKey()
        {
            AutoInit<CustomLimitLocalizedKey>();
        }

        [LocalizedValue("22031b6b-eeb0-4599-b0d9-1e3641668875", "Custom Request Limit", "自定义请求限制")]
        public static CustomLimitLocalizedKey Form { get; private set; }

        [LocalizedValue("0c2743fc-8e3b-45b1-8ffa-0bd6f2971397", "Size Limit", "大小限制")]
        public static CustomLimitLocalizedKey TabPageSizeLimit { get; private set; }

        [LocalizedValue("c72a9c7b-dceb-4c54-b62c-64738f86033f", "Max Segments Per Request", "每请求最大句段数")]
        public static CustomLimitLocalizedKey LabelMaxSegmentsPerRequest { get; private set; }

        [LocalizedValue("c72a9c7b-dceb-4c54-b62c-64738f86033f", "Max Characters Per Request", "每请求最大字符数")]
        public static CustomLimitLocalizedKey LabelMaxCharactersPerRequest { get; private set; }

        [LocalizedValue("6cbdf74a-8412-4c20-9d5b-f3eda4fc7f26", "Selected provider no supported batch translation!", "选择的提供商不支持批量翻译！")]
        public static CustomLimitLocalizedKey LabelNoBathTip { get; private set; }

        [LocalizedValue("8d3c7ac2-b063-4de9-9d17-233d4a4f46ae", "Rate Limit", "速率限制")]
        public static CustomLimitLocalizedKey TabPageRateLimit { get; private set; }

        [LocalizedValue("849ae12e-3897-4247-afb0-e3419ec9bbd9", "Max Requests Per Window", "每窗口最大请求数")]
        public static CustomLimitLocalizedKey LabelMaxRequestsPerWindow { get; private set; }

        [LocalizedValue("d1cb71bd-5def-4dae-99d1-697cfe21aaf7", "Window Size Ms", "窗口大小（毫秒）")]
        public static CustomLimitLocalizedKey LabelWindowSizeMs { get; private set; }

        [LocalizedValue("9314b2e9-8bbb-43cb-96c9-205da152ee77", "Request Smoothness", "请求平滑度")]
        public static CustomLimitLocalizedKey LabelRequestSmoothness { get; private set; }

        [LocalizedValue("fbfb46fd-f5f3-41f9-ac20-8d182feeeec0", "Concurrency Limit", "并发限制")]
        public static CustomLimitLocalizedKey TabPageConcurrencyLimit { get; private set; }

        [LocalizedValue("b12804ea-fc85-4a47-a2ea-a19c1bb69474", "Max Requests Hold", "请求最大保持数")]
        public static CustomLimitLocalizedKey LabelMaxRequestsHold { get; private set; }

        [LocalizedValue("0c339fcb-14b1-44a5-81b7-74c57492d7ac", "Retry Limit", "重试限制")]
        public static CustomLimitLocalizedKey TabPageRetryLimit { get; private set; }

        [LocalizedValue("fcc7de38-9e72-4994-b329-0314c318fd82", "Number Of Retries", "重试最大次数")]
        public static CustomLimitLocalizedKey LabelNumberOfRetries { get; private set; }

        [LocalizedValue("33beee65-d86f-4943-ab77-6b83d2a6e480", "Failed Timeout Ms", "超时失败（毫秒）")]
        public static CustomLimitLocalizedKey LabelFailedTimeoutMs { get; private set; }

        [LocalizedValue("98d13160-5171-43ee-9d99-606f9c349985", "Retry Waiting Ms", "重试等待（毫秒）")]
        public static CustomLimitLocalizedKey LabelRetryWaitingMs { get; private set; }

        [LocalizedValue("16aba4ce-e67e-46c2-82f0-fd4edd64ca1a", "Load Provider Default", "加载提供商默认值")]
        public static CustomLimitLocalizedKey ButtonLoadProviderDefault { get; private set; }

        [LocalizedValue("bf5b7c53-32ce-4dd2-b735-efb04ef49ef4", "The value must be greater than zero", "值必需大于零")]
        public static CustomLimitLocalizedKey WindowSizeMsTip { get; private set; }

        [LocalizedValue("84dc7869-305f-4d84-b180-17fee65546f9", "The larger the value, the smoother the request", "值越大越平滑")]
        public static CustomLimitLocalizedKey RequestSmoothnessTip { get; private set; }

        [LocalizedValue("24177281-20be-4233-9ec0-9d9e7f9eba23", "Zero means no retry", "零代表不重试")]
        public static CustomLimitLocalizedKey NumberOfRetriesTip { get; private set; }

        [LocalizedValue("8c03604e-5df7-4e9c-9eac-fa10397f38e5", "Zero means no timeout", "零代表不超时")]
        public static CustomLimitLocalizedKey FailedTimeoutMsTip { get; private set; }

        [LocalizedValue("f8386f74-5805-4462-936c-8cdcb8e0fd51", "Zero means no waiting", "零代表不等待")]
        public static CustomLimitLocalizedKey RetryWaitingMsTip { get; private set; }
    }
}
