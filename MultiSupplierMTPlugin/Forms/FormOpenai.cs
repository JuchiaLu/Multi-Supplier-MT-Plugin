using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyEnum;

namespace MultiSupplierMTPlugin.Forms
{
    public partial class FormOpenai : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;

        private bool checkSuccess = false;
        
        public FormOpenai(MultiSupplierMTOptions options, IEnvironment environment)
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
            Text = LLH.G(LLK.FormOpenai);

            labelBaseUrl.Text = LLH.G(LLK.FormOpenai_LabelBaseUrl);
            labelPath.Text = LLH.G(LLK.FormOpenai_LabelPath);
            labelModel.Text = LLH.G(LLK.FormOpenai_LabelModel);
            labelTemperature.Text = LLH.G(LLK.FormOpenai_LabelTemperature);
            labelApiKey.Text = LLH.G(LLK.FormOpenai_LabelApiKey);
            labelOrganization.Text = LLH.G(LLK.FormOpenai_LabelOrganization);
            labelPrompt.Text = LLH.G(LLK.FormOpenai_LabelPrompt);

            linkLabelCheck.Text = LLH.G(LLK.Form_LinkLabelCheck);

            buttonOK.Text = LLH.G(LLK.Form_ButtonOK);
            buttonCancel.Text = LLH.G(LLK.Form_ButtonCancel);
            buttonHelp.Text = LLH.G(LLK.Form_ButtonHelp);
        }

        private void loadOptions()
        {
            textBoxBaseUrl.Text = options.GeneralSettings.OpenaiGeneralOptions.BaseURL;
            textBoxPath.Text = options.GeneralSettings.OpenaiGeneralOptions.Path;
            
            var model = options.GeneralSettings.OpenaiGeneralOptions.Model;
            var models = new string[]
            {
                "gpt-3.5-turbo",
                "gpt-3.5-turbo-16k",
                "gpt-4",
                "gpt-4-32k",
                "gpt-4-turbo",
                "gpt-4-turbo-preview",
                "gpt-4o",
                "gpt-4o-mini",
            };
            comboBoxModels.Items.AddRange(models);
            if (!models.Contains(model)) comboBoxModels.Items.Add(model);
            comboBoxModels.SelectedItem = model;
            numericUpDownTemperature.Value = (decimal)options.GeneralSettings.OpenaiGeneralOptions.temperature;

            textBoxApiKey.Text = options.SecureSettings.OpenaiSecureOptions.ApiKey;
            textBoxOrganization.Text = options.SecureSettings.OpenaiSecureOptions.Organization;

            textBoxPrompt.Text = options.GeneralSettings.OpenaiGeneralOptions.Prompt;

            buttonOK.Enabled = options.GeneralSettings.OpenaiGeneralOptions.Checked;
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
                else if (control is ComboBox comboBox)
                {
                    comboBox.TextChanged += onOptionsChanged;
                }
                else if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.ValueChanged += onOptionsChanged;
                }
            }
        }

        private async void linkLabelCheck_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            void setControlsEnabledState(bool enabled)
            {
                foreach (Control control in Controls)
                {
                    if (control is TextBox || control is ComboBox || control is LinkLabel || control is NumericUpDown)
                    {
                        control.Enabled = enabled;
                    }
                }

                progressBar.Visible = !enabled;
            }

            setControlsEnabledState(false);

            labelCheckResult.Text = "";
            buttonOK.Enabled = false;

            checkSuccess = await Openai.Check(textBoxBaseUrl.Text, textBoxPath.Text, (string)comboBoxModels.Text, (double)numericUpDownTemperature.Value, textBoxApiKey.Text, textBoxOrganization.Text, textBoxPrompt.Text);

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
                Process.Start("https://platform.openai.com/docs/overview");
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
                options.GeneralSettings.OpenaiGeneralOptions.BaseURL = textBoxBaseUrl.Text;
                options.GeneralSettings.OpenaiGeneralOptions.Path = textBoxPath.Text;

                options.GeneralSettings.OpenaiGeneralOptions.Model = (string)comboBoxModels.Text;
                options.GeneralSettings.OpenaiGeneralOptions.temperature = (double)numericUpDownTemperature.Value;

                options.SecureSettings.OpenaiSecureOptions.ApiKey = textBoxApiKey.Text;
                options.SecureSettings.OpenaiSecureOptions.Organization = textBoxOrganization.Text;

                options.GeneralSettings.OpenaiGeneralOptions.Prompt = textBoxPrompt.Text;

                options.GeneralSettings.OpenaiGeneralOptions.Checked = true;
            }
        }
    }
}
