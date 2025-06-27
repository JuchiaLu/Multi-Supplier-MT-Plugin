using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.Localized;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Forms.OpenAICompatibleProviderLocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.Forms
{
    partial class OpenAICompatibleProvider : Form
    {
        private MultiSupplierMTGeneralSettings _mtGeneralSettings;

        private MultiSupplierMTSecureSettings _mtSecureSettings;

        private BindingList<OpenAICompatibleServiceInfo> _providers;

        private bool _renaming = false;

        public OpenAICompatibleProvider(MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings)
        {
            InitializeComponent();

            this._mtGeneralSettings = mtGeneralSettings;
            this._mtSecureSettings = mtSecureSettings;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Localized();

            LoadOptions();
        }

        private void Localized()
        {
            var textExample = LLH.G(LLK.TextExample);

            Text = LLH.G(LLK.Form);

            labelAction.Text = LLH.G(LLK.LabelAction);
            buttonAdd.Text = LLH.G(LLK.ButtonAdd);
            buttonDelete.Text = LLH.G(LLK.ButtonDelete);
            buttonRename.Text = LLH.G(LLK.ButtonRename);

            labelProviders.Text = LLH.G(LLK.LabelProviders);

            groupBoxRequest.Text = LLH.G(LLK.GroupBoxRequest);
            labelBaseURL.Text = LLH.G(LLK.LabelBaseURL);
            labelPath.Text = LLH.G(LLK.LabelPath);
            toolTip.SetToolTip(textBoxBaseURL, $"{textExample} https://api.openai.com/v1");
            toolTip.SetToolTip(textBoxPath, $"{textExample} /chat/completions");

            groupBoxModel.Text = LLH.G(LLK.GroupBoxModel);
            labelDefaultModel.Text = LLH.G(LLK.LabelDefaultModel);
            labelModelList.Text = LLH.G(LLK.LabelModelList);
            toolTip.SetToolTip(textBoxDefaultModel, $"{textExample} gpt-4o-mini");
            toolTip.SetToolTip(textBoxModelList, $"{textExample} gpt-4o, gpt-4o-mini, gpt-4.1, gpt-4.1-mini");

            groupBoxLink.Text = LLH.G(LLK.GroupBoxLink);
            labelApiKeyLink.Text = LLH.G(LLK.LabelApiKeyLink);
            labelModelsLink.Text = LLH.G(LLK.LabelModelsLink);
            labelDocLink.Text = LLH.G(LLK.LabelDocLink);
            toolTip.SetToolTip(textBoxApiKeyLink, $"{textExample} https://platform.openai.com/api-keys");
            toolTip.SetToolTip(textBoxModelsLink, $"{textExample} https://platform.openai.com/docs/models");
            toolTip.SetToolTip(textBoxDocLink, $"{textExample} https://platform.openai.com/docs/api-reference/chat");

            buttonOK.Text = LLH.G(LLKC.ButtonOK);
            buttonCancel.Text = LLH.G(LLKC.ButtonCancel);
        }

        private void LoadOptions()
        {
            _providers = new BindingList<OpenAICompatibleServiceInfo>(
                _mtGeneralSettings.CustomOpenAICompatibleServiceInfos
                .Select(p => p.Clone())
                .OrderBy(p => p.DisplayName, new NaturalSortComparer())
                .ToList());

            comboBoxProviders.DataSource = _providers;
            comboBoxProviders.DisplayMember = "DisplayName";

            UpdateControlState();
        }

        private void UpdateControlState()
        {            
            bool hasSel = comboBoxProviders.SelectedIndex != -1;
            bool hasSelAndRenaming = hasSel & _renaming;
            bool hasSelNoRenaming = hasSel & !_renaming;
            bool noEmptyNoRenaming = _providers.Count > 0 & !_renaming;

            buttonAdd.Enabled = !_renaming;            
            buttonDelete.Enabled = hasSelNoRenaming;
            buttonRename.Enabled = hasSel;

            textBoxProvider.Enabled = hasSelAndRenaming;
            comboBoxProviders.Enabled = noEmptyNoRenaming;

            textBoxBaseURL.Enabled = hasSelNoRenaming;
            textBoxPath.Enabled = hasSelNoRenaming;

            textBoxDefaultModel.Enabled = hasSelNoRenaming;
            textBoxModelList.Enabled = hasSelNoRenaming;

            textBoxApiKeyLink.Enabled = hasSelNoRenaming;
            textBoxModelsLink.Enabled = hasSelNoRenaming;
            textBoxDocLink.Enabled = hasSelNoRenaming;
        }

        private void comboBoxProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = comboBoxProviders.SelectedItem as OpenAICompatibleServiceInfo;

            textBoxBaseURL.Text = selected?.BaseURL ?? "";
            textBoxPath.Text = selected?.Path ?? "";

            textBoxDefaultModel.Text = selected?.Model ?? "";
            textBoxModelList.Text = selected?.BuildInModels != null ? ModelItemHelper.ToTextList(selected.BuildInModels, ",") : "";

            textBoxApiKeyLink.Text = selected?.ApiKeyLink ?? "";
            textBoxModelsLink.Text = selected?.ModelsLink ?? "";
            textBoxDocLink.Text = selected?.ApiDocLink ?? "";
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (_renaming) return;

            string displayName = Enumerable.Range(1, int.MaxValue)
                .Select(i => $"Custom LLM {i}")
                .First(name => !_providers.Any(p => p.DisplayName == name));

            _providers.Add(new OpenAICompatibleServiceInfo()
            {
                UniqueName = $"Custom_LLM_{Guid.NewGuid().ToString()}",
                DisplayName = displayName,
                BaseURL = "https://",
                Path = "/chat/completions",
                ApiKeyLink = "https://",
                ModelsLink = "https://",
                ApiDocLink = "https://"
            });

            UpdateControlState();

            if (comboBoxProviders.Items.Count > 0)
                comboBoxProviders.SelectedIndex = comboBoxProviders.Items.Count - 1;

            comboBoxProviders_SelectedIndexChanged(comboBoxProviders, EventArgs.Empty);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_renaming) return;

            int index = comboBoxProviders.SelectedIndex;
            if (index >= 0 && index < _providers.Count)
            {
                if (_providers[index].UniqueName == _mtGeneralSettings.CurrentServiceProvider)
                {
                    MessageBox.Show(LLH.G(LLK.MsgNoDeleteTip));
                    return;
                }

                _providers.RemoveAt(index);

                UpdateControlState();

                comboBoxProviders_SelectedIndexChanged(comboBoxProviders, EventArgs.Empty);                
            }
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (comboBoxProviders.SelectedItem is OpenAICompatibleServiceInfo provider)
            {
                if (!_renaming)
                {
                    textBoxProvider.Text = provider.DisplayName;
                }
                else
                {
                    var displayName = textBoxProvider.Text;

                    if (_providers.Any(p => p.DisplayName == displayName && provider.DisplayName != displayName))
                    {
                        MessageBox.Show(LLH.G(LLK.MessageAlreadyExists), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    provider.DisplayName = displayName;
                    ((CurrencyManager)BindingContext[comboBoxProviders.DataSource]).Refresh();
                }

                _renaming = !_renaming;

                UpdateControlState();

                textBoxProvider.Visible = _renaming;
                comboBoxProviders.Visible = !_renaming;
                buttonRename.Text = LLH.G(_renaming ? LLK.ButtonApply : LLK.ButtonRename);                
            }
        }

        private void textBoxBaseURL_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxProviders.SelectedItem is OpenAICompatibleServiceInfo provider)
            {
                provider.BaseURL = textBoxBaseURL.Text;
            }
        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxProviders.SelectedItem is OpenAICompatibleServiceInfo provider)
            {
                provider.Path = textBoxPath.Text;
            }
        }


        private void textBoxModel_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxProviders.SelectedItem is OpenAICompatibleServiceInfo provider)
            {
                provider.Model = textBoxDefaultModel.Text;
            }
        }

        private void textBoxModels_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxProviders.SelectedItem is OpenAICompatibleServiceInfo provider)
            {
                provider.BuildInModels = ModelItemHelper.ParseList(textBoxModelList.Text);
            }
        }


        private void textBoxApiKeyURL_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxProviders.SelectedItem is OpenAICompatibleServiceInfo provider)
            {
                provider.ApiKeyLink = textBoxApiKeyLink.Text;
            }
        }

        private void textBoxModelsURL_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxProviders.SelectedItem is OpenAICompatibleServiceInfo provider)
            {
                provider.ModelsLink = textBoxModelsLink.Text;
            }
        }

        private void textBoxHelpURL_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxProviders.SelectedItem is OpenAICompatibleServiceInfo provider)
            {
                provider.ApiDocLink = textBoxDocLink.Text;
            }
        }


        private void buttonHelp_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://github.com/JuchiaLu/Multi-Supplier-MT-Plugin");
            }
            catch
            {
                // do nothing
            }
        }


        private void OpenAICompatibleProvider_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _mtGeneralSettings.CustomOpenAICompatibleServiceInfos = _providers.ToArray();
            }
        }
    }

    class OpenAICompatibleProviderLocalizedKey : LocalizedKeyBase
    {
        public OpenAICompatibleProviderLocalizedKey(string name) : base(name)
        {
        }

        static OpenAICompatibleProviderLocalizedKey()
        {
            AutoInit<OpenAICompatibleProviderLocalizedKey>();
        }

        [LocalizedValue("c54d549b-b953-49c9-b101-eb7a9db69334", "Custom OpenAI Compatible Providers Manage", "自定义 OpenAI 兼容提供商管理")]
        public static OpenAICompatibleProviderLocalizedKey Form { get; private set; }

        [LocalizedValue("8ec20737-394d-4b53-9241-3e30b084290d", "Action", "动作")]
        public static OpenAICompatibleProviderLocalizedKey LabelAction { get; private set; }

        [LocalizedValue("7a71ce99-a9b5-476b-adff-5db0f57da777", "Add", "新增")]
        public static OpenAICompatibleProviderLocalizedKey ButtonAdd { get; private set; }

        [LocalizedValue("e25af8c6-d6c8-4a5a-b5d6-b9ed2d4de11c", "Delete", "删除")]
        public static OpenAICompatibleProviderLocalizedKey ButtonDelete { get; private set; }

        [LocalizedValue("9ac7d334-593b-467b-aa26-d1ff2742df7d", "Rename", "修改")]
        public static OpenAICompatibleProviderLocalizedKey ButtonRename { get; private set; }

        [LocalizedValue("56c4a8b9-9767-41d7-b881-369fddd2c9f1", "Apply", "应用")]
        public static OpenAICompatibleProviderLocalizedKey ButtonApply { get; private set; }

        [LocalizedValue("c951715b-5798-45f6-bcf0-6b43e11c911e", "Already exists", "已存在")]
        public static OpenAICompatibleProviderLocalizedKey MessageAlreadyExists { get; private set; }

        [LocalizedValue("31ea05e3-1ddf-459c-a70e-482314262334", "Providers", "提供商")]
        public static OpenAICompatibleProviderLocalizedKey LabelProviders { get; private set; }

        [LocalizedValue("9fcfa7ff-0715-45c8-a408-d136a163d6da", "", "")]
        public static OpenAICompatibleProviderLocalizedKey GroupBoxRequest { get; private set; }

        [LocalizedValue("8006d48d-e451-43b9-8d2c-19c207de9778", "Base URL", "请求基址")]
        public static OpenAICompatibleProviderLocalizedKey LabelBaseURL { get; private set; }

        [LocalizedValue("f9711834-13d5-4889-9af7-0f570d7e764e", "Path", "请求路径")]
        public static OpenAICompatibleProviderLocalizedKey LabelPath { get; private set; }

        [LocalizedValue("f20cd21b-512a-44b7-8183-311bd13211f4", "", "")]
        public static OpenAICompatibleProviderLocalizedKey GroupBoxModel { get; private set; }

        [LocalizedValue("7b40d8ed-7d70-4a3b-b507-17f268bd0934", "Default Model", "默认模型")]
        public static OpenAICompatibleProviderLocalizedKey LabelDefaultModel { get; private set; }

        [LocalizedValue("83074b6f-41b5-44f9-a9a3-9df5ca322548", "Model List", "模型列表")]
        public static OpenAICompatibleProviderLocalizedKey LabelModelList { get; private set; }

        [LocalizedValue("4ad4f443-afca-4c13-a475-5cf183d37230", "", "")]
        public static OpenAICompatibleProviderLocalizedKey GroupBoxLink { get; private set; }

        [LocalizedValue("a5d4735a-0ba4-4a0d-a725-088d9793c840", "Api Key Link", "密钥链接")]
        public static OpenAICompatibleProviderLocalizedKey LabelApiKeyLink { get; private set; }

        [LocalizedValue("fef58e20-9779-4bf9-9f54-36df97946a73", "Models Link", "模型链接")]
        public static OpenAICompatibleProviderLocalizedKey LabelModelsLink { get; private set; }

        [LocalizedValue("8ec7c1c2-a3cc-4061-8eaf-b04bb5efddec", "Doc Link", "文档链接")]
        public static OpenAICompatibleProviderLocalizedKey LabelDocLink { get; private set; }

        [LocalizedValue("aa65b878-5130-470b-8ef3-ae02fcf5031a", "Can not delete the provider in used !", "无法删除正在使用的提供商！")]
        public static OpenAICompatibleProviderLocalizedKey MsgNoDeleteTip { get; private set; }

        [LocalizedValue("e34d286f-5566-48b6-830a-6dd14ac9e975", "Example: ", "例如：")]
        public static OpenAICompatibleProviderLocalizedKey TextExample { get; private set; }
    }
}
