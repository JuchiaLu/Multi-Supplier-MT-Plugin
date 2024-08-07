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
    public partial class FormClaude : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;

        private bool checkSuccess = false;
        
        public FormClaude(MultiSupplierMTOptions options, IEnvironment environment)
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
            Text = LLH.G(LLK.FormClaude);

            labelBaseUrl.Text = LLH.G(LLK.FormClaude_LabelBaseUrl);
            labelPath.Text = LLH.G(LLK.FormClaude_LabelPath);
            labelModel.Text = LLH.G(LLK.FormClaude_LabelModel);
            labelMaxTokens.Text = LLH.G(LLK.FormClaude_LabelMaxTokens);
            labelTemperature.Text = LLH.G(LLK.FormClaude_LabelTemperature);

            labelXApiKey.Text = LLH.G(LLK.FormClaude_LabelXApiKey);

            labelPrompt.Text = LLH.G(LLK.FormClaude_LabelPrompt);

            linkLabelCheck.Text = LLH.G(LLK.Form_LinkLabelCheck);

            buttonOK.Text = LLH.G(LLK.Form_ButtonOK);
            buttonCancel.Text = LLH.G(LLK.Form_ButtonCancel);
            buttonHelp.Text = LLH.G(LLK.Form_ButtonHelp);
        }

        private void loadOptions()
        {
            textBoxBaseUrl.Text = options.GeneralSettings.ClaudeGeneralOptions.BaseURL;
            textBoxPath.Text = options.GeneralSettings.ClaudeGeneralOptions.Path;
            
            var model = options.GeneralSettings.ClaudeGeneralOptions.Model;
            var models = new string[]
            {
                "claude-3-opus-20240229",
                "claude-3-sonnet-20240229",
                "claude-3-haiku-20240307",
                "claude-3-5-sonnet-20240620",
            };
            comboBoxModels.Items.AddRange(models);
            if (!models.Contains(model)) comboBoxModels.Items.Add(model);
            comboBoxModels.SelectedItem = model;

            numericUpDownMaxTokens.Value = options.GeneralSettings.ClaudeGeneralOptions.MaxTokens;
            numericUpDownTemperature.Value = (decimal)options.GeneralSettings.ClaudeGeneralOptions.Temperature;

            textBoxXApiKey.Text = options.SecureSettings.ClaudeSecureOptions.XApiKey;

            textBoxPrompt.Text = options.GeneralSettings.ClaudeGeneralOptions.Prompt;

            buttonOK.Enabled = options.GeneralSettings.ClaudeGeneralOptions.Checked;
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

            checkSuccess = await Claude.Check(textBoxBaseUrl.Text, textBoxPath.Text, (string)comboBoxModels.Text, (int)numericUpDownMaxTokens.Value, (double)numericUpDownTemperature.Value, textBoxXApiKey.Text, textBoxPrompt.Text);

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
                Process.Start("https://docs.anthropic.com/en/docs/welcome");
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
                options.GeneralSettings.ClaudeGeneralOptions.BaseURL = textBoxBaseUrl.Text;
                options.GeneralSettings.ClaudeGeneralOptions.Path = textBoxPath.Text;

                options.GeneralSettings.ClaudeGeneralOptions.Model = (string)comboBoxModels.Text;
                
                options.GeneralSettings.ClaudeGeneralOptions.MaxTokens = (int)numericUpDownMaxTokens.Value;
                options.GeneralSettings.ClaudeGeneralOptions.Temperature = (double)numericUpDownTemperature.Value;

                options.SecureSettings.ClaudeSecureOptions.XApiKey = textBoxXApiKey.Text;

                options.GeneralSettings.ClaudeGeneralOptions.Prompt = textBoxPrompt.Text;

                options.GeneralSettings.ClaudeGeneralOptions.Checked = true;
            }
        }
    }
}
