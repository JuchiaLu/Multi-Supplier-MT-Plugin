using MultiSupplierMTPlugin.Service;
using MemoQ.MTInterfaces;
using System;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin
{
    public partial class OptionsFormYoudao : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;

        private bool checkSuccess = false;
        
        public OptionsFormYoudao(MultiSupplierMTOptions options, IEnvironment environment)
        {
            InitializeComponent();

            this.options = options;
            this.environment = environment;

            localizeContent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            textBoxAppId.Text = options.SecureSettings.YoudaoSecureOptions.AppKey;
            textBoxAppKey.Text = options.SecureSettings.YoudaoSecureOptions.AppSecret;

            buttonOK.Enabled = options.GeneralSettings.YoudaoGeneralOptions.Checked;
        }

        private void localizeContent()
        {
            this.Text = LocalizationHelper.Instance.GetResourceString("YoudaoOptionForm");

            this.labelAppId.Text = LocalizationHelper.Instance.GetResourceString("YoudaoOptionForm.labelAppId");
            this.labelAppKey.Text = LocalizationHelper.Instance.GetResourceString("YoudaoOptionForm.labelAppKey");

            this.linkLabelCheck.Text = LocalizationHelper.Instance.GetResourceString("YoudaoOptionForm.linkLabelCheck");

            this.buttonOK.Text = LocalizationHelper.Instance.GetResourceString("YoudaoOptionForm.buttonOK");
            this.buttonCancel.Text = LocalizationHelper.Instance.GetResourceString("YoudaoOptionForm.buttonCancel");
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

            checkSuccess = await ServiceYoudao.Check(textBoxAppId.Text, textBoxAppKey.Text);

            if (!IsDisposed) 
            {
                if (checkSuccess)
                {
                    buttonOK.Enabled = true;
                    labelCheckResult.Text = LocalizationHelper.Instance.GetResourceString("YoudaoOptionForm.labelCheckResult.CheckedSuccees");
                }
                else
                {
                    labelCheckResult.Text = LocalizationHelper.Instance.GetResourceString("YoudaoOptionForm.labelCheckResult.CheckedFail");
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

        private void DummyMTOptionsFormYoudao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK && checkSuccess)
            {
                options.SecureSettings.YoudaoSecureOptions.AppKey = textBoxAppId.Text;
                options.SecureSettings.YoudaoSecureOptions.AppSecret = textBoxAppKey.Text;
                options.GeneralSettings.YoudaoGeneralOptions.Checked = true;
            }
        }
    }
}
