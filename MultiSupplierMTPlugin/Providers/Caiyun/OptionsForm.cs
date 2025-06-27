using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Providers.Caiyun.LocalizedKey;

namespace MultiSupplierMTPlugin.Providers.Caiyun
{
    partial class OptionsForm : Form
    {
        private Service _service;

        private GeneralSettings _generalOptions;

        private SecureSettings _secureOptions;

        private MultiSupplierMTGeneralSettings _mtGeneralOptions;

        private MultiSupplierMTSecureSettings _mtSecureOptions;

        public OptionsForm(Service service, GeneralSettings generalSettings, SecureSettings secureSettings,
            MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings)
        {
            InitializeComponent();

            this._service = service;                    
            this._generalOptions = generalSettings;
            this._secureOptions = secureSettings;

            this._mtGeneralOptions = mtGeneralSettings;
            this._mtSecureOptions = mtSecureSettings;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Localized();

            LoadOptions();

            BindOptionsChangedEvent();
        }

        private void Localized()
        {
            Text = LLH.G(LLK.Form);

            linkLabelToken.Text = LLH.G(LLK.LinkLabelToken);
        }

        private void LoadOptions()
        {
            textBoxToken.Text = _secureOptions.Token;

            commonBottomControl.Init(this, _generalOptions.Checked, _service.ApiDocLink, linkLabelCheck_LinkClicked, Controls);
        }

        private void BindOptionsChangedEvent()
        {
            void onOptionsChanged(object sender, EventArgs e)
            {
                if (
                    _secureOptions.Token != textBoxToken.Text
                )
                {
                    commonBottomControl.ButtonOkState = false;
                }
                else
                {
                    commonBottomControl.ButtonOkState = _generalOptions.Checked;
                }
            }

            textBoxToken.TextChanged += onOptionsChanged;
        }

        private async Task linkLabelCheck_LinkClicked()
        {
            await _service.Check(new Options(
                new GeneralSettings(),
                new SecureSettings() { Token = textBoxToken.Text }
                ));
        }

        private void linkLabelToken_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(_service.ApiKeyLink);
            }
            catch
            {
                // do nothing
            }
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _secureOptions.Token = textBoxToken.Text;
                _generalOptions.Checked = true;
            }
        }
    }
}
