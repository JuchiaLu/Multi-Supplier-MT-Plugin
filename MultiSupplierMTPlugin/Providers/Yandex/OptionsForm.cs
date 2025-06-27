using MultiSupplierMTPlugin.Helpers;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Providers.Yandex.LocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.Providers.Yandex
{
    partial class OptionsForm : Form
    {
        private Service _service;

        private GeneralSettings _generalSettings;

        private SecureSettings _secureSettings;

        private MultiSupplierMTGeneralSettings _mtGeneralSettings;

        private MultiSupplierMTSecureSettings _mtSecureSettings;

        public OptionsForm(Service service, GeneralSettings generalSettings, SecureSettings secureSettings,
            MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings)
        {
            InitializeComponent();

            this._service = service;
            this._generalSettings = generalSettings;
            this._secureSettings = secureSettings;

            this._mtGeneralSettings = mtGeneralSettings;
            this._mtSecureSettings = mtSecureSettings;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Localized();

            LoadOptions();

            BindOptionsChangedEvent();
        }

        private void Localized()
        {
            Text = LLH.G(LLK.Form);

            groupBoxAuthorization.Text = LLH.G(LLK.GroupBoxAuthorization);
            labelTyep.Text = LLH.G(LLK.LabelTyep);
            radioButtonApiKey.Text = LLH.G(LLK.RadioButtonApiKey);
            radioButtonIamToken.Text = LLH.G(LLK.RadioButtonIamToken);
            linkLabelKeyOrToken.Text = LLH.G(LLK.LinkLabelKeyOrToken);
            labelFolderId.Text = LLH.G(LLK.LabelFolderId);

            PlaceholderTextBox.SetCueBanner(textBoxFolderId, LLH.G(LLKC.Textbox_OptionalTip));

            groupBoxGlossary.Text = LLH.G(LLK.GroupBoxGlossary);
            labelGlossaryExact.Text = LLH.G(LLK.LabelGlossaryExact);
            radioButtonExactEnable.Text = LLH.G(LLK.RadioButtonExactEnable);
            radioButtonExactDisable.Text = LLH.G(LLK.RadioButtonExactDisable);
            labelGlossaryDelimiter.Text = LLH.G(LLK.LabelGlossaryDelimiter);
            labelGlossaryFilePath.Text = LLH.G(LLK.LabelGlossaryFilePath);
            buttonGlossarySelect.Text = LLH.G(LLK.ButtonGlossarySelect);

            PlaceholderTextBox.SetCueBanner(textBoxGlossaryFilePath, LLH.G(LLKC.Textbox_OptionalTip));
            toolTip.SetToolTip(textBoxGlossaryFilePath, LLH.G(LLKC.GlossaryFileFormatTip));

            groupBoxOther.Text = LLH.G(LLK.GroupBoxOther);
            labelSpeller.Text = LLH.G(LLK.LabelSpeller);
            radioButtonSpellerEnable.Text = LLH.G(LLK.RadioButtonSpellerEnable);
            radioButtonSpellerDisable.Text = LLH.G(LLK.RadioButtonSpellerDisable);
            labelModel.Text = LLH.G(LLK.LabelModel);

            PlaceholderTextBox.SetCueBanner(textBoxModel, LLH.G(LLKC.Textbox_OptionalTip));
        }

        private void LoadOptions()
        {
            radioButtonApiKey.Checked = _generalSettings.AuthorizationType == AuthorizationType.ApiKey;
            radioButtonIamToken.Checked = _generalSettings.AuthorizationType == AuthorizationType.IamToken;
            textBoxKeyOrToken.Text = _secureSettings.KeyOrToken;
            textBoxFolderId.Text = _generalSettings.FolderId;
            
            radioButtonExactEnable.Checked = _generalSettings.GlossaryExact;
            radioButtonExactDisable.Checked = !_generalSettings.GlossaryExact;
            textBoxGlossaryDelimiter.Text = _generalSettings.GlossaryDelimiter;
            textBoxGlossaryFilePath.Text = _generalSettings.GlossaryFilePath;

            radioButtonSpellerEnable.Checked = _generalSettings.Speller;
            radioButtonSpellerDisable.Checked = !_generalSettings.Speller;
            textBoxModel.Text = _generalSettings.Model;
            
            commonBottomControl.Init(this, _generalSettings.Checked, _service.ApiDocLink, linkLabelCheck_LinkClicked, Controls);
        }

        private void BindOptionsChangedEvent()
        {
            void onOptionsChanged(object sender, EventArgs e)
            {
                if (
                    _generalSettings.AuthorizationType != (radioButtonApiKey.Checked ? AuthorizationType.ApiKey : AuthorizationType.IamToken) ||
                    _secureSettings.KeyOrToken != textBoxKeyOrToken.Text ||
                    _generalSettings.FolderId != textBoxFolderId.Text ||
                    
                    _generalSettings.GlossaryExact != radioButtonExactEnable.Checked ||
                    _generalSettings.GlossaryDelimiter != textBoxGlossaryDelimiter.Text ||
                    _generalSettings.GlossaryFilePath != textBoxGlossaryFilePath.Text ||

                    _generalSettings.Speller != radioButtonSpellerEnable.Checked ||
                    _generalSettings.Model != textBoxModel.Text
                )
                {
                    commonBottomControl.ButtonOkState = false;
                }
                else
                {
                    commonBottomControl.ButtonOkState = _generalSettings.Checked;
                }
            }

            radioButtonApiKey.CheckedChanged += onOptionsChanged;
            textBoxKeyOrToken.TextChanged += onOptionsChanged;
            textBoxFolderId.TextChanged += onOptionsChanged;
            
            radioButtonExactEnable.CheckedChanged += onOptionsChanged;
            textBoxGlossaryDelimiter.TextChanged += onOptionsChanged;
            textBoxGlossaryFilePath.TextChanged += onOptionsChanged;
            
            radioButtonSpellerEnable.CheckedChanged += onOptionsChanged;
            textBoxModel.TextChanged += onOptionsChanged;
        }

        private void buttonGlossarySelect_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "All Supported Formats|*.txt;*.cvs;";

            openFileDialog.FileName = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxGlossaryFilePath.Text = openFileDialog.FileName;
            }
        }

        private async Task linkLabelCheck_LinkClicked()
        {
            await _service.Check(
                new Options(
                    new GeneralSettings() 
                    {
                        AuthorizationType = radioButtonApiKey.Checked ? AuthorizationType.ApiKey : AuthorizationType.IamToken,
                        FolderId = textBoxFolderId.Text,
                        
                        GlossaryExact = radioButtonExactEnable.Checked,
                        GlossaryDelimiter = textBoxGlossaryDelimiter.Text,
                        GlossaryFilePath = textBoxGlossaryFilePath.Text,

                        Speller = radioButtonSpellerEnable.Checked,
                        Model = textBoxModel.Text,
                    },
                    new SecureSettings() {   KeyOrToken = textBoxKeyOrToken.Text }));
        }

        private void linkLabelKeyOrToken_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(_service.ApiKeyLink);
            }
            catch
            {
                // do nothing
            }
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _generalSettings.AuthorizationType = radioButtonApiKey.Checked ? AuthorizationType.ApiKey : AuthorizationType.IamToken;
                _secureSettings.KeyOrToken = textBoxKeyOrToken.Text;
                _generalSettings.FolderId = textBoxFolderId.Text;

                _generalSettings.GlossaryExact = radioButtonExactEnable.Checked;
                _generalSettings.GlossaryDelimiter = textBoxGlossaryDelimiter.Text;
                _generalSettings.GlossaryFilePath = textBoxGlossaryFilePath.Text;

                _generalSettings.Speller = radioButtonSpellerEnable.Checked;                
                _generalSettings.Model = textBoxModel.Text;

                _generalSettings.Checked = true;
            }
        }
    }
}
