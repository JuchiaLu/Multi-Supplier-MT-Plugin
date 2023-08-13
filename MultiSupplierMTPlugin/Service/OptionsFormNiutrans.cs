using MultiSupplierMTPlugin.Service;
using MemoQ.MTInterfaces;
using System;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin
{
    public partial class OptionsFormNiutrans : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;

        private bool checkSuccess = false;
        
        public OptionsFormNiutrans(MultiSupplierMTOptions options, IEnvironment environment)
        {
            InitializeComponent();

            this.options = options;
            this.environment = environment;

            localizeContent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            textBoxApikey.Text = options.SecureSettings.NiutransSecureOptions.Apikey;

            buttonOK.Enabled = options.GeneralSettings.NiutransGeneralOptions.Checked;
        }

        private void localizeContent()
        {
            this.Text = LocalizationHelper.Instance.GetResourceString("NiutransOptionForm");

            this.labelApikey.Text = LocalizationHelper.Instance.GetResourceString("NiutransOptionForm.labelApikey");            

            this.linkLabelCheck.Text = LocalizationHelper.Instance.GetResourceString("NiutransOptionForm.linkLabelCheck");

            this.buttonOK.Text = LocalizationHelper.Instance.GetResourceString("NiutransOptionForm.buttonOK");
            this.buttonCancel.Text = LocalizationHelper.Instance.GetResourceString("NiutransOptionForm.buttonCancel");
        }

        private void textBoxAppIdOrAppKey_TextChanged(object sender, EventArgs e)
        {
            linkLabelCheck.Enabled = !string.IsNullOrEmpty(textBoxApikey.Text);
            
            buttonOK.Enabled = false;
        }

        private async void linkLabelCheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setControlsEnabledState(false);
            buttonOK.Enabled = false;

            checkSuccess = await ServiceNiutrans.Check(textBoxApikey.Text);

            if (!IsDisposed) 
            {
                if (checkSuccess)
                {
                    buttonOK.Enabled = true;
                    labelCheckResult.Text = LocalizationHelper.Instance.GetResourceString("NiutransOptionForm.labelCheckResult.CheckedSuccees");
                }
                else
                {
                    labelCheckResult.Text = LocalizationHelper.Instance.GetResourceString("NiutransOptionForm.labelCheckResult.CheckedFail");
                }

                setControlsEnabledState(true);
            }
        }

        private void setControlsEnabledState(bool enabled)
        {
            textBoxApikey.Enabled = enabled;
            linkLabelCheck.Enabled = enabled;
            progressBar.Visible = !enabled;
        }

        private void DummyMTOptionsFormNiutrans_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK && checkSuccess)
            {
                options.SecureSettings.NiutransSecureOptions.Apikey = textBoxApikey.Text;
                options.GeneralSettings.NiutransGeneralOptions.Checked = true;
            }
        }
    }
}
