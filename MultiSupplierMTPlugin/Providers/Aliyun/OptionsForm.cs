using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Providers.Aliyun.LocalizedKey;

namespace MultiSupplierMTPlugin.Providers.Aliyun
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
            base.Text = LLH.G(LLK.Form);

            labelKeyId.Text = LLH.G(LLK.LabelKeyId);
            linkLabelKeySecret.Text = LLH.G(LLK.LinkLabelKeySecret);

            labelServiceType.Text = LLH.G(LLK.LabelServiceType);
            radioButtonGeneral.Text = LLH.G(LLK.RadioButtonGeneral);
            radioButtonProfessional.Text = LLH.G(LLK.RadioButtonProfessional);
        }

        private void LoadOptions()
        {
            textBoxKeyId.Text = _secureSettings.AccessKeyId;
            textBoxKeySecret.Text = _secureSettings.AccessKeySecret;

            if ("general".Equals(_generalSettings.ServiceType))
            {
                radioButtonGeneral.Checked = true;
            }
            else
            {
                radioButtonProfessional.Checked = true;
            }
            
            commonBottomControl.Init(this, _generalSettings.Checked, _service.ApiDocLink, linkLabelCheck_LinkClicked, Controls);
        }

        private void BindOptionsChangedEvent()
        {
            void onOptionsChanged(object sender, EventArgs e)
            {
                if (
                    _secureSettings.AccessKeyId != textBoxKeyId.Text ||
                    _secureSettings.AccessKeySecret != textBoxKeySecret.Text ||
                    _generalSettings.ServiceType != (radioButtonGeneral.Checked ? "general" : "ecommerce")
                )
                {
                    commonBottomControl.ButtonOkState = false;
                }
                else
                {
                    commonBottomControl.ButtonOkState = _generalSettings.Checked;
                }
            }

            textBoxKeyId.TextChanged += onOptionsChanged;
            textBoxKeySecret.TextChanged += onOptionsChanged;
            radioButtonGeneral.CheckedChanged += onOptionsChanged;
        }

        private async Task linkLabelCheck_LinkClicked()
        {
            string serviceType = radioButtonGeneral.Checked ? "general" : "ecommerce";

            await _service.Check( new Options(
                    new GeneralSettings() { ServiceType = serviceType}, 
                    new SecureSettings() { AccessKeyId = textBoxKeyId.Text, AccessKeySecret = textBoxKeySecret.Text}
                    ));
        }

        private void linkLabelKeySecret_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                _secureSettings.AccessKeyId = textBoxKeyId.Text;
                _secureSettings.AccessKeySecret = textBoxKeySecret.Text;
                _generalSettings.ServiceType = radioButtonGeneral.Checked ? "general" : "ecommerce";
                _generalSettings.Checked = true;
            }
        }
    }
}
