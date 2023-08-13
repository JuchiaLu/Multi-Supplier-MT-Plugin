using MultiSupplierMTPlugin.Service;
using MemoQ.MTInterfaces;
using System;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin
{
    public partial class OptionsFormHuoshan : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;

        private bool checkSuccess = false;
        
        public OptionsFormHuoshan(MultiSupplierMTOptions options, IEnvironment environment)
        {
            InitializeComponent();

            this.options = options;
            this.environment = environment;

            localizeContent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            textBoxAppId.Text = options.SecureSettings.HuoshanSecureOptions.AccessKey;
            textBoxAppKey.Text = options.SecureSettings.HuoshanSecureOptions.SecretKey;

            buttonOK.Enabled = options.GeneralSettings.HuoshanGeneralOptions.Checked;
        }

        private void localizeContent()
        {
            this.Text = LocalizationHelper.Instance.GetResourceString("HuoshanOptionForm");

            this.labelAppId.Text = LocalizationHelper.Instance.GetResourceString("HuoshanOptionForm.labelAppId");
            this.labelAppKey.Text = LocalizationHelper.Instance.GetResourceString("HuoshanOptionForm.labelAppKey");

            this.linkLabelCheck.Text = LocalizationHelper.Instance.GetResourceString("HuoshanOptionForm.linkLabelCheck");

            this.buttonOK.Text = LocalizationHelper.Instance.GetResourceString("HuoshanOptionForm.buttonOK");
            this.buttonCancel.Text = LocalizationHelper.Instance.GetResourceString("HuoshanOptionForm.buttonCancel");
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

            checkSuccess = await ServiceHuoshan.Check(textBoxAppId.Text, textBoxAppKey.Text);

            if (!IsDisposed) 
            {
                if (checkSuccess)
                {
                    buttonOK.Enabled = true;
                    labelCheckResult.Text = LocalizationHelper.Instance.GetResourceString("HuoshanOptionForm.labelCheckResult.CheckedSuccees");
                }
                else
                {
                    labelCheckResult.Text = LocalizationHelper.Instance.GetResourceString("HuoshanOptionForm.labelCheckResult.CheckedFail");
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
                options.SecureSettings.HuoshanSecureOptions.AccessKey = textBoxAppId.Text;
                options.SecureSettings.HuoshanSecureOptions.SecretKey = textBoxAppKey.Text;
                options.GeneralSettings.HuoshanGeneralOptions.Checked = true;
            }
        }
    }
}
