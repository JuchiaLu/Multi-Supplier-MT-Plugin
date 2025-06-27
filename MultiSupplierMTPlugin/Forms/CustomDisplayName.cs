using MultiSupplierMTPlugin.Localized;
using System;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Forms.CustomDisplayNameLocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.Forms
{
    partial class CustomDisplayName : Form
    {
        private MultiSupplierMTGeneralSettings _mtGeneralSettings;

        private MultiSupplierMTSecureSettings _mtSecureSettings;

        public CustomDisplayName(MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings)
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

            labelDisplayName.Text = LLH.G(LLK.LabelDisplayName);

            buttonOK.Text = LLH.G(LLKC.ButtonOK);
            buttonCancel.Text = LLH.G(LLKC.ButtonCancel);
        }

        private void LoadOptions()
        {
            textBoxDisplayName.Text = _mtGeneralSettings.CustomDisplayName;
        }

        private void CustomDisplayName_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _mtGeneralSettings.CustomDisplayName = textBoxDisplayName.Text;
            }
        }
    }

    class CustomDisplayNameLocalizedKey : LocalizedKeyBase
    {
        public CustomDisplayNameLocalizedKey(string name) : base(name)
        {
        }

        static CustomDisplayNameLocalizedKey()
        {
            AutoInit<CustomDisplayNameLocalizedKey>();
        }

        [LocalizedValue("f3f35751-a53b-4933-b04d-9ae07a45ac48", "Custom Display Name", "自定义显示名称")]
        public static CustomDisplayNameLocalizedKey Form { get; private set; }

        [LocalizedValue("f98f704f-cdab-4049-9236-065df3dbcb8b", "Display Name", "显示名称")]
        public static CustomDisplayNameLocalizedKey LabelDisplayName { get; private set; }
    }
}
