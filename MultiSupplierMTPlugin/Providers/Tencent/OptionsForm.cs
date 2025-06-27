using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Providers.Tencent.LocalizedKey;

namespace MultiSupplierMTPlugin.Providers.Tencent
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

            labelSecretId.Text = LLH.G(LLK.LabelSecretId);
            linkLabelSecretKey.Text = LLH.G(LLK.LinkLabelSecretKey);
        }

        private void LoadOptions()
        {
            textBoxSecretId.Text = _secureSettings.SecretId;
            textBoxSecretKey.Text = _secureSettings.SecretKey;

            commonBottomControl.Init(this, _generalSettings.Checked, _service.ApiDocLink, linkLabelCheck_LinkClicked, Controls);
        }

        private void BindOptionsChangedEvent()
        {
            void onOptionsChanged(object sender, EventArgs e)
            {
                if (
                    _secureSettings.SecretId != textBoxSecretId.Text ||
                    _secureSettings.SecretKey != textBoxSecretKey.Text
                )
                {
                    commonBottomControl.ButtonOkState = false;
                }
                else
                {
                    commonBottomControl.ButtonOkState = _generalSettings.Checked;
                }
            }

            textBoxSecretId.TextChanged += onOptionsChanged;
            textBoxSecretKey.TextChanged += onOptionsChanged;
        }

        private async Task linkLabelCheck_LinkClicked()
        {
            await _service.Check(new Options(new GeneralSettings(), new SecureSettings() 
            {
                SecretId = textBoxSecretId.Text,
                SecretKey = textBoxSecretKey.Text
            }));
        }

        private void linkLabelSecretKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                _secureSettings.SecretId = textBoxSecretId.Text;
                _secureSettings.SecretKey = textBoxSecretKey.Text;
                _generalSettings.Checked = true;
            }
        }
    }
}
