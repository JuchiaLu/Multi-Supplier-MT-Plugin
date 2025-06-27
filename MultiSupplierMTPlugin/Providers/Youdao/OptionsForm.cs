using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Providers.Youdao.LocalizedKey;

namespace MultiSupplierMTPlugin.Providers.Youdao
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

            labelAppKey.Text = LLH.G(LLK.LabelAppKey);
            linkLabelAppSecret.Text = LLH.G(LLK.LinkLabelAppSecret);
        }

        private void LoadOptions()
        {
            textBoxAppKey.Text = _secureSettings.AppKey;
            textBoxAppSecret.Text = _secureSettings.AppSecret;
            
            commonBottomControl.Init(this, _generalSettings.Checked, _service.ApiDocLink, linkLabelCheck_LinkClicked, Controls);
        }

        private void BindOptionsChangedEvent()
        {
            void onOptionsChanged(object sender, EventArgs e)
            {
                if (
                    _secureSettings.AppKey != textBoxAppKey.Text ||
                    _secureSettings.AppSecret != textBoxAppSecret.Text
                )
                {
                    commonBottomControl.ButtonOkState = false;
                }
                else
                {
                    commonBottomControl.ButtonOkState = _generalSettings.Checked;
                }
            }

            textBoxAppKey.TextChanged += onOptionsChanged;
            textBoxAppSecret.TextChanged += onOptionsChanged;
        }

        private async Task linkLabelCheck_LinkClicked()
        {
            await _service.Check(new Options(new GeneralSettings(), new SecureSettings() {
                AppKey = textBoxAppKey.Text,
                AppSecret = textBoxAppSecret.Text
            }));
        }

        private void linkLabelAppSecret_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                _secureSettings.AppKey = textBoxAppKey.Text;
                _secureSettings.AppSecret = textBoxAppSecret.Text;
                _generalSettings.Checked = true;
            }
        }
    }
}
