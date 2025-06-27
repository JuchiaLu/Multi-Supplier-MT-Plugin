using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Providers.DeepLX.LocalizedKey;

namespace MultiSupplierMTPlugin.Providers.DeepLX
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
            Text = LLH.G(LLK.DeepLX);
            
            labelServer.Text = LLH.G(LLK.LabelServer);

            linkLabelAuthKey.Text = LLH.G(LLK.LinkLabelAuthKey);

            labelEndpoint.Text = LLH.G(LLK.LabelEndpoint);
            radioFree.Text = LLH.G(LLK.RadioFree);
            radioPro.Text = LLH.G(LLK.RadioPro);
            radioOfficial.Text = LLH.G(LLK.RadioOfficial);
        }

        private void LoadOptions()
        {
            textBoxServer.Text = _generalSettings.Server;

            if (_generalSettings.Endpoint == "Free")
            {
                radioFree.Checked = true;
            }
            else if (_generalSettings.Endpoint == "Pro")
            {
                radioPro.Checked = true;
            }
            //else if (generalOptions.Endpoint == "Official")
            //{
            //    radioOfficial.Checked = true;
            //}


            textBoxAuthKey.Text = _secureSettings.AuthKey;

            commonBottomControl.Init(this, _generalSettings.Checked, _service.ApiDocLink, linkLabelCheck_LinkClicked, Controls);
        }

        private void BindOptionsChangedEvent()
        {
            void onOptionsChanged(object sender, EventArgs e)
            {
                string endpoint = "Free";
                if (radioPro.Checked)
                {
                    endpoint = "Pro";
                }
                //else if (radioOfficial.Checked)
                //{
                //    endpoint = "Official";
                //}

                if (
                    _secureSettings.AuthKey != textBoxAuthKey.Text ||
                    _generalSettings.Server != textBoxServer.Text ||
                    _generalSettings.Endpoint != endpoint
                )
                {
                    commonBottomControl.ButtonOkState = false;
                }
                else
                {
                    commonBottomControl.ButtonOkState = _generalSettings.Checked;
                }
            }

            textBoxAuthKey.TextChanged += onOptionsChanged;
            textBoxServer.TextChanged += onOptionsChanged;
            radioFree.CheckedChanged += onOptionsChanged;
            radioPro.CheckedChanged += onOptionsChanged;
            //radioOfficial.CheckedChanged += onOptionsChanged;
        }

        private async Task linkLabelCheck_LinkClicked()
        {
            string endpoint = "Free";
            if (radioPro.Checked)
            {
                endpoint = "Pro";
            }
            //else if(radioOfficial.Checked)
            //{
            //    endpoint = "Official";
            //}

            await _service.Check( new Options(
                    new GeneralSettings() { Server = textBoxServer.Text, Endpoint = endpoint}, 
                    new SecureSettings() { AuthKey = textBoxAuthKey.Text}));
        }

        private void linkLabelAuthKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                string endpoint = "Free";
                if (radioPro.Checked)
                {
                    endpoint = "Pro";
                }
                //else if (radioOfficial.Checked)
                //{
                //    endpoint = "Official";
                //}

                _secureSettings.AuthKey = textBoxAuthKey.Text;

                _generalSettings.Server = textBoxServer.Text;
                _generalSettings.Endpoint = endpoint;
                _generalSettings.Checked = true;
            }
        }
    }
}
