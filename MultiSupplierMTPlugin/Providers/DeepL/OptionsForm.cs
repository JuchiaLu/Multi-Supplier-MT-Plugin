using MultiSupplierMTPlugin.Helpers;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Providers.DeepL.LocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.Providers.DeepL
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
            Text = LLH.G(LLK.DeepL);
            
            labelServer.Text = LLH.G(LLK.LabelServer);
            
            linkLabelAuthKey.Text = LLH.G(LLK.LinkLabelAuthKey);
            
            labelGlossaryId.Text = LLH.G(LLK.LabelGlossaryId);
            PlaceholderTextBox.SetCueBanner(textBoxGlossaryId, LLH.G(LLKC.Textbox_OptionalTip));
        }

        private void LoadOptions()
        {
            textBoxServer.Text = _generalSettings.Server;
            textBoxAuthKey.Text = _secureSettings.AuthKey;
            textBoxGlossaryId.Text = _generalSettings.GlossaryId;
            
            commonBottomControl.Init(this, _generalSettings.Checked, _service.ApiDocLink, linkLabelCheck_LinkClicked, Controls);
        }

        private void BindOptionsChangedEvent()
        {
            void onOptionsChanged(object sender, EventArgs e)
            {
                if (
                    _secureSettings.AuthKey != textBoxAuthKey.Text ||
                    _generalSettings.Server != textBoxServer.Text ||
                    _generalSettings.GlossaryId != textBoxGlossaryId.Text
                )
                {
                    commonBottomControl.ButtonOkState = false;
                }
                else
                {
                    commonBottomControl.ButtonOkState = _generalSettings.Checked;
                }
            }

            textBoxAuthKey.TextChanged += onOptionsChanged;
            textBoxServer.TextChanged += onOptionsChanged;
            textBoxGlossaryId.TextChanged += onOptionsChanged;
        }

        private async Task linkLabelCheck_LinkClicked()
        {
            await _service.Check(new Options(
                    new GeneralSettings() { Server = textBoxServer.Text, GlossaryId = textBoxGlossaryId.Text}, 
                    new SecureSettings() { AuthKey = textBoxAuthKey.Text}));
        }

        private void linkLabelAuthKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                _secureSettings.AuthKey = textBoxAuthKey.Text;

                _generalSettings.Server = textBoxServer.Text;
                _generalSettings.GlossaryId = textBoxGlossaryId.Text;
                _generalSettings.Checked = true;
            }
        }
    }
}
