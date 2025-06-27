using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Providers.Papago.LocalizedKey;

namespace MultiSupplierMTPlugin.Providers.Papago
{
    partial class OptionsForm : Form
    {
        private Service _service;

        private GeneralSettings _generalSettings;

        private SecureSettings _secureSettings;

        private MultiSupplierMTGeneralSettings _mtGeneralSettings;

        private MultiSupplierMTSecureSettings _mtSecureSettings;

        public OptionsForm(Service service, GeneralSettings generalSettings, SecureSettings secureSettings,
            MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings)
        {
            InitializeComponent();

            this._service = service;
            this._generalSettings = generalSettings;
            this._secureSettings = secureSettings;

            this._mtGeneralSettings = mtGeneralSettings;
            this._mtSecureSettings = mtSecureSettings;
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

            labelClientID.Text = LLH.G(LLK.LabelClientID);
            linkLabelClientSecret.Text = LLH.G(LLK.LinkLabelClientSecret);
        }

        private void LoadOptions()
        {
            textBoxClientID.Text = _secureSettings.ClientID;
            textBoxClientSecret.Text = _secureSettings.ClientSecret;

            commonBottomControl.Init(this, _generalSettings.Checked, _service.ApiDocLink, linkLabelCheck_LinkClicked, Controls);
        }

        private void BindOptionsChangedEvent()
        {
            void onOptionsChanged(object sender, EventArgs e)
            {
                if (
                    _secureSettings.ClientID != textBoxClientID.Text ||
                    _secureSettings.ClientSecret != textBoxClientSecret.Text
                )
                {
                    commonBottomControl.ButtonOkState = false;
                }
                else
                {
                    commonBottomControl.ButtonOkState = _generalSettings.Checked;
                }
            }

            textBoxClientID.TextChanged += onOptionsChanged;
            textBoxClientSecret.TextChanged += onOptionsChanged;
        }

        private async Task linkLabelCheck_LinkClicked()
        {
            await _service.Check(
                new Options(new GeneralSettings(), new SecureSettings() {
                    ClientID = textBoxClientID.Text,
                    ClientSecret = textBoxClientSecret.Text
                }));
        }

        private void linkLabelClientSecret_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                _secureSettings.ClientID = textBoxClientID.Text;
                _secureSettings.ClientSecret = textBoxClientSecret.Text;
                _generalSettings.Checked = true;
            }
        }
    }
}
