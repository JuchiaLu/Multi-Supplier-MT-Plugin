using MultiSupplierMTPlugin.Service;
using MemoQ.MTInterfaces;
using System;
using System.Windows.Forms;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyEnum;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;

namespace MultiSupplierMTPlugin.Forms
{
    public partial class OptionsFormOpenai : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;

        private bool checkSuccess = false;
        
        public OptionsFormOpenai(MultiSupplierMTOptions options, IEnvironment environment)
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
            Text = LLH.G(LLK.OptionFormOpenai);

            labelBaseUrl.Text = LLH.G(LLK.OptionFormOpenai_LabelBaseUrl);
            labelPath.Text = LLH.G(LLK.OptionFormOpenai_LabelPath);
            labelModel.Text = LLH.G(LLK.OptionFormOpenai_LabelModel);
            labelTemperature.Text = LLH.G(LLK.OptionFormOpenai_LabelTemperature);
            labelApiKey.Text = LLH.G(LLK.OptionFormOpenai_LabelApiKey);
            labelOrganization.Text = LLH.G(LLK.OptionFormOpenai_LabelOrganization);
            labelPrompt.Text = LLH.G(LLK.OptionFormOpenai_LabelPrompt);

            linkLabelCheck.Text = LLH.G(LLK.OptionForm_LinkLabelCheck);

            buttonOK.Text = LLH.G(LLK.OptionForm_ButtonOK);
            buttonCancel.Text = LLH.G(LLK.OptionForm_ButtonCancel);
        }

        private void loadOptions()
        {
            textBoxBaseUrl.Text = options.GeneralSettings.OpenaiGeneralOptions.BaseURL;
            textBoxPath.Text = options.GeneralSettings.OpenaiGeneralOptions.Path;

            var models = new string[]
            {
                "gpt-3.5-turbo",
                "gpt-3.5-turbo-16k",
                "gpt-4",
                "gpt-4-1106-preview",
                "gpt-4-vision-preview",
                "gpt-4-32k",
            };
            comboBoxModels.Items.AddRange(models);
            comboBoxModels.SelectedItem = options.GeneralSettings.OpenaiGeneralOptions.Model;
            textBoxTemperature.Text = options.GeneralSettings.OpenaiGeneralOptions.temperature.ToString();

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
                    comboBox.SelectedIndexChanged += onOptionsChanged;
                }
            }
        }

        private async void linkLabelCheck_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            void setControlsEnabledState(bool enabled)
            {
                foreach (Control control in Controls)
                {
                    if (control is TextBox || control is ComboBox || control is LinkLabel)
                    {
                        control.Enabled = enabled;
                    }
                }

                progressBar.Visible = !enabled;
            }

            setControlsEnabledState(false);

            labelCheckResult.Text = "";
            buttonOK.Enabled = false;

            if (!double.TryParse(textBoxTemperature.Text, out var temperature))
            {
                temperature = 1.0;
                textBoxTemperature.Text = "1.0";
            }

            checkSuccess = await ServiceOpenai.Check(textBoxBaseUrl.Text, textBoxPath.Text, (string)comboBoxModels.SelectedItem, temperature, textBoxApiKey.Text, textBoxOrganization.Text, textBoxPrompt.Text);

            if (!IsDisposed) 
            {
                if (checkSuccess)
                {
                    buttonOK.Enabled = true;
                    labelCheckResult.Text = LLH.G(LLK.OptionForm_LabelCheckResult_CheckedSuccees);
                }
                else
                {
                    labelCheckResult.Text = LLH.G(LLK.OptionForm_LabelCheckResult_CheckedFail);
                }

                setControlsEnabledState(true);
            }
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK && checkSuccess)
            {
                options.GeneralSettings.OpenaiGeneralOptions.BaseURL = textBoxBaseUrl.Text;
                options.GeneralSettings.OpenaiGeneralOptions.Path = textBoxPath.Text;

                options.GeneralSettings.OpenaiGeneralOptions.Model = (string)comboBoxModels.SelectedItem;
                if (!double.TryParse(textBoxTemperature.Text, out var temperature))
                {
                    temperature = 1.0;
                }
                options.GeneralSettings.OpenaiGeneralOptions.temperature = temperature;

                options.SecureSettings.OpenaiSecureOptions.ApiKey = textBoxApiKey.Text;
                options.SecureSettings.OpenaiSecureOptions.Organization = textBoxOrganization.Text;

                options.GeneralSettings.OpenaiGeneralOptions.Prompt = textBoxPrompt.Text;

                options.GeneralSettings.OpenaiGeneralOptions.Checked = true;
            }
        }
    }
}
