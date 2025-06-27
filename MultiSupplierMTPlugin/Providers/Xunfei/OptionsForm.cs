using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Providers.Xunfei.LocalizedKey;

namespace MultiSupplierMTPlugin.Providers.Xunfei
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

            BindOptionsgChangedEvent();
        }

        private void Localized()
        {
            Text = LLH.G(LLK.Form);

            labelApiId.Text = LLH.G(LLK.LabelApiId);
            labelApiKey.Text = LLH.G(LLK.LabelApiKey);
            linkLabelApiSecret.Text = LLH.G(LLK.LinkLabelApiSecret);
        }

        private void LoadOptions()
        {
            textBoxApiId.Text = _secureSettings.AppId;
            textBoxApiKey.Text = _secureSettings.ApiKey;
            textApiSecret.Text = _secureSettings.ApiSecret;
            
            commonBottomControl.Init(this, _generalSettings.Checked, _service.ApiDocLink, linkLabelCheck_LinkClicked, Controls);
        }

        private void BindOptionsgChangedEvent()
        {
            void onOptionsChanged(object sender, EventArgs e)
            {
                if (
                    _secureSettings.AppId != textBoxApiId.Text ||
                    _secureSettings.ApiKey != textBoxApiKey.Text ||
                    _secureSettings.ApiSecret != textApiSecret.Text
                )
                {
                    commonBottomControl.ButtonOkState = false;
                }
                else
                {
                    commonBottomControl.ButtonOkState = _generalSettings.Checked;
                }
            }

            textBoxApiId.TextChanged += onOptionsChanged;
            textBoxApiKey.TextChanged += onOptionsChanged;
            textApiSecret.TextChanged += onOptionsChanged;
        }

        private async Task linkLabelCheck_LinkClicked()
        {
            await _service.Check(new Options(new GeneralSettings(), new SecureSettings() {
                AppId = textBoxApiId.Text,
                ApiKey = textBoxApiKey.Text,
                ApiSecret = textApiSecret.Text
            }));
        }

        private void linkLabelApiSecret_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                _secureSettings.AppId = textBoxApiId.Text;
                _secureSettings.ApiKey = textBoxApiKey.Text;
                _secureSettings.ApiSecret = textApiSecret.Text;
                _generalSettings.Checked = true;
            }
        }
    }
}
