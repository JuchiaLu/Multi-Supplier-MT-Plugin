using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using System;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyEnum;

namespace MultiSupplierMTPlugin.Forms
{
    public partial class FormTranslateCache : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;
        
        public FormTranslateCache(MultiSupplierMTOptions options, IEnvironment environment)
        {
            InitializeComponent();

            this.options = options;
            this.environment = environment;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            localized();

            loadOptions();
        }

        private void localized()
        {
            Text = LLH.G(LLK.FormTranslateCache);

            labelCacheCount.Text = LLH.G(LLK.FormTranslateCache_LabelCacheCount);
            linkLabelClean.Text = LLH.G(LLK.FormTranslateCache_LinkLabelClean);

            buttonOK.Text = LLH.G(LLK.Form_ButtonOK);
        }

        private void loadOptions()
        {
            labelCacheCountValue.Text = CacheHelper.Count().ToString();
        }
        

        private void linkLabelCleanCache_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show(LLH.G(LLK.FormTranslateCache_MessageBoxConfirmCleanTip), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
            {
                CacheHelper.Clear();
                labelCacheCountValue.Text = "0";
            }
        }
    }
}
