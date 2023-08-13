using MultiSupplierMTPlugin.Service;
using MemoQ.MTInterfaces;
using System;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin
{
    public partial class OptionsFormXunfei : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;

        private bool checkSuccess = false;
        
        public OptionsFormXunfei(MultiSupplierMTOptions options, IEnvironment environment)
        {
            InitializeComponent();

            this.options = options;
            this.environment = environment;

            localizeContent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            textBoxAppId.Text = options.SecureSettings.XunfeiSecureOptions.AppId;
            textBoxApiKey.Text = options.SecureSettings.XunfeiSecureOptions.ApiKey;
            textApiSecret.Text = options.SecureSettings.XunfeiSecureOptions.ApiSecret;

            buttonOK.Enabled = options.GeneralSettings.XunfeiGeneralOptions.Checked;
        }

        private void localizeContent()
        {
            this.Text = LocalizationHelper.Instance.GetResourceString("XunfeiOptionForm");

            this.labelAppId.Text = LocalizationHelper.Instance.GetResourceString("XunfeiOptionForm.labelAppId");
            this.labelApiKey.Text = LocalizationHelper.Instance.GetResourceString("XunfeiOptionForm.labelApiKey");
            this.labelApiSecret.Text = LocalizationHelper.Instance.GetResourceString("XunfeiOptionForm.labelApiSecret");

            this.linkLabelCheck.Text = LocalizationHelper.Instance.GetResourceString("XunfeiOptionForm.linkLabelCheck");

            this.buttonOK.Text = LocalizationHelper.Instance.GetResourceString("XunfeiOptionForm.buttonOK");
            this.buttonCancel.Text = LocalizationHelper.Instance.GetResourceString("XunfeiOptionForm.buttonCancel");
        }

        private void textBoxAppIdOrAppKey_TextChanged(object sender, EventArgs e)
        {
            linkLabelCheck.Enabled = !string.IsNullOrEmpty(textBoxAppId.Text) 
                && !string.IsNullOrEmpty(textBoxApiKey.Text)
                && !string.IsNullOrEmpty(textApiSecret.Text);
            
            buttonOK.Enabled = false;
        }

        private async void linkLabelCheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setControlsEnabledState(false);
            buttonOK.Enabled = false;

            checkSuccess = await ServiceXunfei.Check(textBoxAppId.Text, textBoxApiKey.Text, textApiSecret.Text);

            if (!IsDisposed) 
            {
                if (checkSuccess)
                {
                    buttonOK.Enabled = true;
                    labelCheckResult.Text = LocalizationHelper.Instance.GetResourceString("XunfeiOptionForm.labelCheckResult.CheckedSuccees");
                }
                else
                {
                    labelCheckResult.Text = LocalizationHelper.Instance.GetResourceString("XunfeiOptionForm.labelCheckResult.CheckedFail");
                }

                setControlsEnabledState(true);
            }
        }

        private void setControlsEnabledState(bool enabled)
        {
            textBoxAppId.Enabled = enabled;
            textBoxApiKey.Enabled = enabled;
            textApiSecret.Enabled = enabled;
            linkLabelCheck.Enabled = enabled;
            progressBar.Visible = !enabled;
        }

        private void DummyMTOptionsFormXunfei_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK && checkSuccess)
            {
                options.SecureSettings.XunfeiSecureOptions.AppId = textBoxAppId.Text;
                options.SecureSettings.XunfeiSecureOptions.ApiKey = textBoxApiKey.Text;
                options.SecureSettings.XunfeiSecureOptions.ApiSecret = textApiSecret.Text;
                options.GeneralSettings.XunfeiGeneralOptions.Checked = true;
            }
        }
    }
}
