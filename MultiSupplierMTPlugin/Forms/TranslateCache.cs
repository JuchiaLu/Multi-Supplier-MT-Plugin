using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.Localized;
using System;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Forms.TranslateCacheLocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.Forms
{
    partial class TranslateCache : Form
    {
        private MultiSupplierMTGeneralSettings _mtGeneralSettings;

        private MultiSupplierMTSecureSettings _mtSecureSettings;

        public TranslateCache(MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings)
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

            labelCacheCount.Text = LLH.G(LLK.LabelCacheCount);
            linkLabelCleanCache.Text = LLH.G(LLK.LinkLabelCleanCache);

            buttonOK.Text = LLH.G(LLKC.ButtonOK);
        }

        private void LoadOptions()
        {
            labelCacheCountValue.Text = CacheHelper.Count().ToString();
        }


        private void linkLabelCleanCache_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dialogResult = MessageBox.Show(LLH.G(LLK.MessageBoxConfirmCleanTip), "",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (DialogResult.OK == dialogResult)
            {
                CacheHelper.Clear();
                labelCacheCountValue.Text = "0";
            }
        }
    }

    class TranslateCacheLocalizedKey : LocalizedKeyBase
    {
        public TranslateCacheLocalizedKey(string name) : base(name)
        {
        }

        static TranslateCacheLocalizedKey()
        {
            AutoInit<TranslateCacheLocalizedKey>();
        }

        [LocalizedValue("e4886123-c46d-46ad-94c0-9c1dcfa63f99", "Translate Cache", "翻译缓存")]
        public static TranslateCacheLocalizedKey Form { get; private set; }

        [LocalizedValue("2522fd4f-4ec8-496c-bc2f-f8b1a706b8ec", "Cache Count", "缓存条数")]
        public static TranslateCacheLocalizedKey LabelCacheCount { get; private set; }

        [LocalizedValue("b725027c-9b93-40e8-b315-c4cf2771a7c2", "Clean Cache", "清空缓存")]
        public static TranslateCacheLocalizedKey LinkLabelCleanCache { get; private set; }

        [LocalizedValue("8aeecb5e-36f9-4546-b516-a5a620c1e412", "It cannot be restored after clearing", "清空后将无法恢复")]
        public static TranslateCacheLocalizedKey MessageBoxConfirmCleanTip { get; private set; }
    }
}
