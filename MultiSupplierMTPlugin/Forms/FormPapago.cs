using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Services;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyEnum;

namespace MultiSupplierMTPlugin.Forms
{
    public partial class FormPapago : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;

        private bool checkSuccess = false;
        
        public FormPapago(MultiSupplierMTOptions options, IEnvironment environment)
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

            bindOptionsChangedEvent();
        }

        private void localized()
        {
            Text = LLH.G(LLK.FormPapago);

            labelClientID.Text = LLH.G(LLK.FormPapago_LabelClientID);
            labelClientSecret.Text = LLH.G(LLK.FormPapago_LabelClientSecret);

            linkLabelCheck.Text = LLH.G(LLK.Form_LinkLabelCheck);

            buttonOK.Text = LLH.G(LLK.Form_ButtonOK);
            buttonCancel.Text = LLH.G(LLK.Form_ButtonCancel);
            buttonHelp.Text = LLH.G(LLK.Form_ButtonHelp);
        }

        private void loadOptions()
        {
            textBoxClientID.Text = options.SecureSettings.PapagoSecureOptions.ClientID;
            textBoxClientSecret.Text = options.SecureSettings.PapagoSecureOptions.ClientSecret;

            buttonOK.Enabled = options.GeneralSettings.PapagoGeneralOptions.Checked;
        }

        private void bindOptionsChangedEvent()
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

            checkSuccess = await Papago.Check(textBoxClientID.Text, textBoxClientSecret.Text);

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
                Process.Start("https://guide.ncloud-docs.com/docs/en/papagotranslation-api");
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
                options.SecureSettings.PapagoSecureOptions.ClientID = textBoxClientID.Text;
                options.SecureSettings.PapagoSecureOptions.ClientSecret = textBoxClientSecret.Text;
                options.GeneralSettings.PapagoGeneralOptions.Checked = true;
            }
        }
    }
}
