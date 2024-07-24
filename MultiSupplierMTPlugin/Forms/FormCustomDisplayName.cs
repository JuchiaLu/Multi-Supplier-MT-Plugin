using MemoQ.MTInterfaces;
using System;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyEnum;

namespace MultiSupplierMTPlugin.Forms
{
    public partial class FormCustomDisplayName : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;
        
        public FormCustomDisplayName(MultiSupplierMTOptions options, IEnvironment environment)
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
            Text = LLH.G(LLK.FormCustomDisplayName);

            labelDisplayName.Text = LLH.G(LLK.FormCustomDisplayName_LabelDisplayName);

            buttonOK.Text = LLH.G(LLK.Form_ButtonOK);
            buttonCancel.Text = LLH.G(LLK.Form_ButtonCancel);
        }

        private void loadOptions()
        {
            textBoxDisplayName.Text = options.GeneralSettings.CustomDisplayName;
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                options.GeneralSettings.CustomDisplayName = textBoxDisplayName.Text;
            }
        }
    }
}
