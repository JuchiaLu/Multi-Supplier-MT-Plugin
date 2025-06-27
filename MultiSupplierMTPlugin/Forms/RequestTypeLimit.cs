using MultiSupplierMTPlugin.Localized;
using System;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Forms.RequestTypeLimitLocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.Forms
{
    partial class RequestTypeLimit : Form
    {
        private MultiSupplierMTGeneralSettings _mtGeneralSettings;

        private MultiSupplierMTSecureSettings _mtSecureSettings;

        public RequestTypeLimit(MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings)
        {
            InitializeComponent();

            this._mtGeneralSettings = mtGeneralSettings;
            this._mtSecureSettings = mtSecureSettings;
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

            labelShowSupportedOnly.Text = LLH.G(LLK.LabelShowSupportedOnly);
            radioButtonTrue.Text = LLH.G(LLK.RadioButtonTrue);
            radioButtonFalse.Text = LLH.G(LLK.RadioButtonFalse);

            buttonOK.Text = LLH.G(LLKC.ButtonOK);
            buttonCancel.Text = LLH.G(LLKC.ButtonCancel);
        }

        private void LoadOptions()
        {
            radioButtonTrue.Checked = _mtGeneralSettings.ShowSupportedRequestTypeOnly;
            radioButtonFalse.Checked = !_mtGeneralSettings.ShowSupportedRequestTypeOnly;
        }

        private void RequestTypeLimit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _mtGeneralSettings.ShowSupportedRequestTypeOnly = radioButtonTrue.Checked;
            }
        }
    }

    class RequestTypeLimitLocalizedKey : LocalizedKeyBase
    {
        public RequestTypeLimitLocalizedKey(string name) : base(name)
        {
        }

        static RequestTypeLimitLocalizedKey()
        {
            AutoInit<RequestTypeLimitLocalizedKey>();
        }

        [LocalizedValue("732e4217-0e1c-4575-b687-0795a49caf51", "Request Type", "请求类型")]
        public static RequestTypeLimitLocalizedKey Form { get; private set; }

        [LocalizedValue("ebd0cd7b-700a-4ceb-a14f-66889eabb66c", "Show Provider Supported Request Type Only: ", "仅显示提供商支持的请求类型：")]
        public static RequestTypeLimitLocalizedKey LabelShowSupportedOnly { get; private set; }

        [LocalizedValue("dee36c19-14b5-4052-9e44-43f1cd69692e", "True", "是")]
        public static RequestTypeLimitLocalizedKey RadioButtonTrue { get; private set; }

        [LocalizedValue("39d3a53e-caf0-4402-b3b5-b2ef88e35c9e", "False", "否")]
        public static RequestTypeLimitLocalizedKey RadioButtonFalse { get; private set; }
    }
}
