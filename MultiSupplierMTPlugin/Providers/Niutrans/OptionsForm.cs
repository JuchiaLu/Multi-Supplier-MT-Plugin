using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Providers.Niutrans.LocalizedKey;

namespace MultiSupplierMTPlugin.Providers.Niutrans
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

            linkLabelApikey.Text = LLH.G(LLK.LinkLabelApikey);
        }

        private void LoadOptions()
        {
            textBoxApikey.Text = _secureSettings.Apikey;

            commonBottomControl.Init(this, _generalSettings.Checked, _service.ApiDocLink, linkLabelCheck_LinkClicked, Controls);
        }

        private void BindOptionsChangedEvent()
        {
            void onOptionsChanged(object sender, EventArgs e)
            {
                if (
                    _secureSettings.Apikey != textBoxApikey.Text
                )
                {
                    commonBottomControl.ButtonOkState = false;
                }
                else
                {
                    commonBottomControl.ButtonOkState = _generalSettings.Checked;
                }
            }

            textBoxApikey.TextChanged += onOptionsChanged;
        }

        private async Task linkLabelCheck_LinkClicked()
        {
            await _service.Check(new Options(new GeneralSettings(), new SecureSettings() {
                Apikey = textBoxApikey.Text
            }));
        }

        private void linkLabelApikey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                _secureSettings.Apikey = textBoxApikey.Text;
                _generalSettings.Checked = true;
            }
        }
    }
}
