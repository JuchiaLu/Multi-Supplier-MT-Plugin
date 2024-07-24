using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Services;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyEnum;

namespace MultiSupplierMTPlugin.Forms
{
    public partial class FormXunfei : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;

        private bool checkSuccess = false;
        
        public FormXunfei(MultiSupplierMTOptions options, IEnvironment environment)
        {
            InitializeComponent();

            this.options = options;
            this.environment = environment;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            localized();

            loadOptions();

            bindOptionsgChangedEvent();
        }

        private void localized()
        {
            Text = LLH.G(LLK.FormXunfei);

            labelApiId.Text = LLH.G(LLK.FormXunfei_LabelApiId);
            labelApiKey.Text = LLH.G(LLK.FormXunfei_LabelApiKey);
            labelApiSecret.Text = LLH.G(LLK.FormXunfei_LabelApiSecret);

            linkLabelCheck.Text = LLH.G(LLK.Form_LinkLabelCheck);

            buttonOK.Text = LLH.G(LLK.Form_ButtonOK);
            buttonCancel.Text = LLH.G(LLK.Form_ButtonCancel);
            buttonHelp.Text = LLH.G(LLK.Form_ButtonHelp);
        }

        private void loadOptions()
        {
            textBoxApiId.Text = options.SecureSettings.XunfeiSecureOptions.AppId;
            textBoxApiKey.Text = options.SecureSettings.XunfeiSecureOptions.ApiKey;
            textApiSecret.Text = options.SecureSettings.XunfeiSecureOptions.ApiSecret;

            buttonOK.Enabled = options.GeneralSettings.XunfeiGeneralOptions.Checked;
        }

        private void bindOptionsgChangedEvent()
        {
            void onOptionsChanged(object sender, EventArgs e)
            {
                buttonOK.Enabled = false;
            }

            foreach (Control control in Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.TextChanged += onOptionsChanged;
                }
            }
        }

        private async void linkLabelCheck_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            void setControlsEnabledState(bool enabled)
            {
                foreach (Control control in Controls)
                {
                    if (control is TextBox || control is LinkLabel)
                    {
                        control.Enabled = enabled;
                    }
                }

                progressBar.Visible = !enabled;
            }

            setControlsEnabledState(false);

            labelCheckResult.Text = "";
            buttonOK.Enabled = false;

            checkSuccess = await Xunfei.Check(textBoxApiId.Text, textBoxApiKey.Text, textApiSecret.Text);

            if (!IsDisposed) 
            {
                if (checkSuccess)
                {
                    buttonOK.Enabled = true;
                    labelCheckResult.Text = LLH.G(LLK.Form_LabelCheckResult_CheckedSuccees);
                }
                else
                {
                    labelCheckResult.Text = LLH.G(LLK.Form_LabelCheckResult_CheckedFail);
                }

                setControlsEnabledState(true);
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://www.xfyun.cn/services/xftrans");
            }
            catch
            {
                // do nothing
            }
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK && checkSuccess)
            {
                options.SecureSettings.XunfeiSecureOptions.AppId = textBoxApiId.Text;
                options.SecureSettings.XunfeiSecureOptions.ApiKey = textBoxApiKey.Text;
                options.SecureSettings.XunfeiSecureOptions.ApiSecret = textApiSecret.Text;
                options.GeneralSettings.XunfeiGeneralOptions.Checked = true;
            }
        }
    }
}
