using MultiSupplierMTPlugin.Service;
using MemoQ.MTInterfaces;
using System;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin
{
    public partial class OptionsFormTencent : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;

        private bool checkSuccess = false;
        
        public OptionsFormTencent(MultiSupplierMTOptions options, IEnvironment environment)
        {
            InitializeComponent();

            this.options = options;
            this.environment = environment;

            localizeContent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            textBoxAppId.Text = options.SecureSettings.TencentSecureOptions.SecretId;
            textBoxAppKey.Text = options.SecureSettings.TencentSecureOptions.SecretKey;

            buttonOK.Enabled = options.GeneralSettings.TencentGeneralOptions.Checked;
        }

        private void localizeContent()
        {
            this.Text = LocalizationHelper.Instance.GetResourceString("TencentOptionForm");

            this.labelAppId.Text = LocalizationHelper.Instance.GetResourceString("TencentOptionForm.labelAppId");
            this.labelAppKey.Text = LocalizationHelper.Instance.GetResourceString("TencentOptionForm.labelAppKey");

            this.linkLabelCheck.Text = LocalizationHelper.Instance.GetResourceString("TencentOptionForm.linkLabelCheck");

            this.buttonOK.Text = LocalizationHelper.Instance.GetResourceString("TencentOptionForm.buttonOK");
            this.buttonCancel.Text = LocalizationHelper.Instance.GetResourceString("TencentOptionForm.buttonCancel");
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

            checkSuccess = await ServiceTencent.Check(textBoxAppId.Text, textBoxAppKey.Text);

            if (!IsDisposed) 
            {
                if (checkSuccess)
                {
                    buttonOK.Enabled = true;
                    labelCheckResult.Text = LocalizationHelper.Instance.GetResourceString("TencentOptionForm.labelCheckResult.CheckedSuccees");
                }
                else
                {
                    labelCheckResult.Text = LocalizationHelper.Instance.GetResourceString("TencentOptionForm.labelCheckResult.CheckedFail");
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
                options.SecureSettings.TencentSecureOptions.SecretId = textBoxAppId.Text;
                options.SecureSettings.TencentSecureOptions.SecretKey = textBoxAppKey.Text;
                options.GeneralSettings.TencentGeneralOptions.Checked = true;
            }
        }
    }
}
