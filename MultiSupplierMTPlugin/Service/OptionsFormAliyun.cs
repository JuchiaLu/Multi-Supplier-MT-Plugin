using MultiSupplierMTPlugin.Service;
using MemoQ.MTInterfaces;
using System;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin
{
    public partial class OptionsFormAliyun : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;

        private bool checkSuccess = false;
        
        public OptionsFormAliyun(MultiSupplierMTOptions options, IEnvironment environment)
        {
            InitializeComponent();

            this.options = options;
            this.environment = environment;

            localizeContent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            textBoxAppId.Text = options.SecureSettings.AliyunSecureOptions.AccessKeyId;
            textBoxAppKey.Text = options.SecureSettings.AliyunSecureOptions.AccessKeySecret;
            
            if ("general".Equals(options.GeneralSettings.AliyunGeneralOptions.ServiceType))
                radioButtonGeneral.Checked = true;
            else
                radioButtonProfessional.Checked = true;

            buttonOK.Enabled = options.GeneralSettings.AliyunGeneralOptions.Checked;
        }

        private void localizeContent()
        {
            this.Text = LocalizationHelper.Instance.GetResourceString("AliyunOptionForm");

            this.labelAppId.Text = LocalizationHelper.Instance.GetResourceString("AliyunOptionForm.labelAppId");
            this.labelAppKey.Text = LocalizationHelper.Instance.GetResourceString("AliyunOptionForm.labelAppKey");

            this.labelServiceType.Text = LocalizationHelper.Instance.GetResourceString("AliyunOptionForm.labelServiceType");
            this.radioButtonGeneral.Text = LocalizationHelper.Instance.GetResourceString("AliyunOptionForm.radioButtonGeneral");
            this.radioButtonProfessional.Text = LocalizationHelper.Instance.GetResourceString("AliyunOptionForm.radioButtonProfessional");

            this.linkLabelCheck.Text = LocalizationHelper.Instance.GetResourceString("AliyunOptionForm.linkLabelCheck");

            this.buttonOK.Text = LocalizationHelper.Instance.GetResourceString("AliyunOptionForm.buttonOK");
            this.buttonCancel.Text = LocalizationHelper.Instance.GetResourceString("AliyunOptionForm.buttonCancel");
        }

        private void textBoxAppIdOrAppKey_TextChanged(object sender, EventArgs e)
        {
            linkLabelCheck.Enabled = !string.IsNullOrEmpty(textBoxAppId.Text) && !string.IsNullOrEmpty(textBoxAppKey.Text);
            
            buttonOK.Enabled = false;
        }

        private async void linkLabelCheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setControlsEnabledState(false);
            buttonOK.Enabled = false;

            string serviceType = radioButtonGeneral.Checked ? "general" : "ecommerce";
            checkSuccess = await ServiceAliyun.Check(serviceType, textBoxAppId.Text, textBoxAppKey.Text);

            if (!IsDisposed) 
            {
                if (checkSuccess)
                {
                    buttonOK.Enabled = true;
                    labelCheckResult.Text = LocalizationHelper.Instance.GetResourceString("AliyunOptionForm.labelCheckResult.CheckedSuccees");
                }
                else
                {
                    labelCheckResult.Text = LocalizationHelper.Instance.GetResourceString("AliyunOptionForm.labelCheckResult.CheckedFail");
                }

                setControlsEnabledState(true);
            }
        }

        private void setControlsEnabledState(bool enabled)
        {
            textBoxAppId.Enabled = enabled;
            textBoxAppKey.Enabled = enabled;
            linkLabelCheck.Enabled = enabled;
            progressBar.Visible = !enabled;
        }

        private void DummyMTOptionsFormBaidu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK && checkSuccess)
            {
                options.SecureSettings.AliyunSecureOptions.AccessKeyId = textBoxAppId.Text;
                options.SecureSettings.AliyunSecureOptions.AccessKeySecret = textBoxAppKey.Text;
                options.GeneralSettings.AliyunGeneralOptions.ServiceType = radioButtonGeneral.Checked ? "general" : "ecommerce";
                options.GeneralSettings.AliyunGeneralOptions.Checked = true;
            }
        }
    }
}
