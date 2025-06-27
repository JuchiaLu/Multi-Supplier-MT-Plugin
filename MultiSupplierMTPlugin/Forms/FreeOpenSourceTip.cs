using MultiSupplierMTPlugin.Localized;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Forms.FreeOpenSourceTipLocalizedKey;

namespace MultiSupplierMTPlugin.Forms
{
    partial class FreeOpenSourceTip : Form
    {
        private MultiSupplierMTGeneralSettings _mtGeneralSettings;

        private MultiSupplierMTSecureSettings _mtSecureSettings;

        public FreeOpenSourceTip(MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings)
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

            labelFreeOpenSourceTip.Text = LLH.G(LLK.LabelFreeOpenSourceTip);
            linkLabelViweOnGithub.Text = LLH.G(LLK.LinkLabelViweOnGithub);

            buttonGotIt.Text = LLH.G(LLK.ButtonGotIt);
            buttonNeverShow.Text = LLH.G(LLK.ButtonNeverShow);
        }

        private void LoadOptions()
        {
            
        }

        private void linkLabelViweOnGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://github.com/JuchiaLu/Multi-Supplier-MT-Plugin");
            }
            catch
            {
                // do nothing
            }
        }

        private void FreeOpenSourceTip_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Ignore)
            {
                _mtGeneralSettings.NeverShowTip = true;
            }
        }
    }

    class FreeOpenSourceTipLocalizedKey : LocalizedKeyBase
    {
        public FreeOpenSourceTipLocalizedKey(string name) : base(name)
        {
        }

        static FreeOpenSourceTipLocalizedKey()
        {
            AutoInit<FreeOpenSourceTipLocalizedKey>();
        }

        [LocalizedValue("cee377e1-514c-4f8b-8235-344727417446", "Tip", "提示")]
        public static FreeOpenSourceTipLocalizedKey Form { get; private set; }

        [LocalizedValue("fbe9ae4f-d443-47dd-9de9-9f7cdcae4ab3", "This plugin is open-source and free of charge.\r\n\r\nYou can download and upgrade the plugin for free on GitHub.\r\n\r\nIf someone tries to sell it to you, you may have been scammed.", "本插件是开源免费软件，\r\n\r\n你可以在 Github 免费下载与升级该插件，\r\n\r\n如果有人向你售卖它，那你可能已经上当受骗。")]
        public static FreeOpenSourceTipLocalizedKey LabelFreeOpenSourceTip { get; private set; }

        [LocalizedValue("8aa9d673-8b88-489b-9387-d579217ffddf", "View on Github ?", "去 Github 查看")]
        public static FreeOpenSourceTipLocalizedKey LinkLabelViweOnGithub { get; private set; }

        [LocalizedValue("f985b2fc-ba6f-4b62-ba76-c5069d76a451", "Got it", "我明白了")]
        public static FreeOpenSourceTipLocalizedKey ButtonGotIt { get; private set; }

        [LocalizedValue("23f42b2a-05b2-436b-b467-1d8770187a2b", "Never show", "不再显示")]
        public static FreeOpenSourceTipLocalizedKey ButtonNeverShow { get; private set; }
    }
}
