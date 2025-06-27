using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.Localized;
using MultiSupplierMTPlugin.ProvidersCommon.Options.LLM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM.OptionsFormLocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM
{
    partial class OptionsForm : Form
    {
        private LLMBaseService _service;

        private LLMBaseGeneralSettings _generalSettings;

        private LLMBaseSecureSettings _secureSettings;

        private MultiSupplierMTGeneralSettings _mtGeneralSettings;

        private MultiSupplierMTSecureSettings _mtSecureSettings;

        private BindingList<PromptTemplate> _promptTemplates;

        private BindingList<ModelItem> _models;

        private ModelItem[] _buildInModels; 

        private List<string> _networkModels;
       
        private int _previousModelIndex = -1;
        private bool _ignoreModelIndexChange = false;

        private ContextMenuStrip _textBoxPromptMenu;

        public OptionsForm(LLMBaseService service, 
            LLMBaseGeneralSettings generalSettings, LLMBaseSecureSettings secureSettings,
            MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings)
        {
            InitializeComponent();

            this._service = service;
            this._generalSettings = generalSettings;
            this._secureSettings = secureSettings;

            this._mtGeneralSettings = mtGeneralSettings;
            this._mtSecureSettings = mtSecureSettings;

            this._buildInModels = service.BuildInModels;
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
            Text = ServiceLocalizedNameHelper.Get(_service.UniqueName);

            labelBaseUrl.Text = LLH.G(LLK.LabelBaseUrl);
            labelPath.Text = LLH.G(LLK.LabelPath);

            labelMaxTokens.Text = LLH.G(LLK.LabelMaxTokens);
            labelTemperature.Text = LLH.G(LLK.LabelTemperature);

            labelOrganization.Text = LLH.G(LLK.LabelOrganization);
            linkLabelApiKey.Text = LLH.G(LLK.LinkLabelApiKey);
            
            PlaceholderTextBox.SetCueBanner(textBoxOrganization, LLH.G(LLKC.Textbox_OptionalTip));

            linkLabelModel.Text = LLH.G(LLK.LinkLabelModel);
            buttonListModels.Text = LLH.G(LLK.ButtonListModels);

            labelPromptTemplate.Text = LLH.G(LLK.LabelPromptTemplate);
            buttonManage.Text = LLH.G(LLK.ButtonManage);

            labelSystemPrompt.Text = LLH.G(LLK.LabelSystemPrompt);
            labelUserPrompt.Text = LLH.G(LLK.LabelUserPrompt);
            
            toolTip.SetToolTip(labelSystemPrompt, LLH.G(LLKC.ToolTip_LLMPromptTip));
            toolTip.SetToolTip(labelUserPrompt, LLH.G(LLKC.ToolTip_LLMPromptTip));

            labelOtherOptions.Text = LLH.G(LLK.LabelOtherOptions);
            linkLabelBathTranslate.Text = LLH.G(LLK.LinkLabelBathTranslate);
            linkLabelMoreSettings.Text = LLH.G(LLK.LabelMoreSettings);

            _textBoxPromptMenu = PromptHelper.CreateTextBoxContextMenu();
        }

        private void LoadOptions()
        {
            textBoxBaseUrl.Text = _generalSettings.BaseURL;
            textBoxPath.Text = _generalSettings.Path;

            numericUpDownMaxTokens.Value = _generalSettings.MaxTokens;
            numericUpDownTemperature.Value = (decimal)_generalSettings.Temperature;

            textBoxOrganization.Text = _secureSettings.Organization;
            textBoxApiKey.Text = _secureSettings.ApiKey;

            LoadModels(_generalSettings.Model, _generalSettings.Model, _generalSettings.UserModels, _buildInModels, _generalSettings.HidenBuildInModels.ToHashSet());
            LoadPromptTemplates(_generalSettings.PromptTemplateId, _mtGeneralSettings.LLMCommon.PromptTemplates);
            
            checkBoxBathTranslate.Checked = _generalSettings.EnableBathTranslate;

            buttonListModels.Enabled = !string.IsNullOrEmpty(textBoxApiKey.Text);

            commonBottomControl.Init(this, _generalSettings.Checked, _service.ApiDocLink, linkLabelCheck_LinkClicked, Controls);
        }


        private void LoadModels(string currentModel, string selectModel, ModelItem[] userModels, ModelItem[] buildInModels, HashSet<string> hidenBuildInModels)
        {
            var models = userModels.ToList();

            models.AddRange(buildInModels.Where(m => !hidenBuildInModels.Contains(m.UniqueName)).ToList());

            // 当前模型不是空白，且模型列表不包含当前模型，添加当前模型到列表
            if (!string.IsNullOrEmpty(currentModel) && !models.Any(m => m.UniqueName == currentModel)) 
                models.Insert(0, new ModelItem() { UniqueName = currentModel, DisplayName = currentModel });

            // 末尾添加一个占位项
            models.Add(new ModelItem() { UniqueName = "$custom-model-list$", DisplayName = LLH.G(LLK.CustomModelList) });

            _models = new BindingList<ModelItem>(models);
            comboBoxModels.DataSource = _models;
            comboBoxModels.ValueMember = "UniqueName";
            comboBoxModels.DisplayMember = "DisplayName";

            int index = models.FindIndex(m => m.UniqueName == selectModel);
            if (models.Count <= 1)
                comboBoxModels.SelectedIndex = -1; // 只有占位项，保持未选中
            else
                comboBoxModels.SelectedIndex = (index == -1) ? 0 : index;

            _previousModelIndex = comboBoxModels.SelectedIndex;

            comboBoxModels.SelectionChangeCommitted -= comboBoxModels_SelectionChangeCommitted;
            comboBoxModels.SelectionChangeCommitted += comboBoxModels_SelectionChangeCommitted;
        }

        private void LoadPromptTemplates(string currentTemplateId, PromptTemplate[] savedPromptTemplates)
        {
            var promptTemplates = savedPromptTemplates
                .Select(p => p.Clone())
                .OrderBy(p => p.Name, new NaturalSortComparer())
                .ToList();

            promptTemplates.Insert(0, new PromptTemplate()
            {
                ID = "",
                Name = LLH.G(LLK.PromptTemplateNoUse), 
                SystemPrompt = _generalSettings.SystemPrompt,
                UserPrompt = _generalSettings.UserPrompt,
                BathTranslateSystemPrompt = _generalSettings.BathTranslateSystemPrompt,
                BathTranslateUserPrompt = _generalSettings.BathTranslateUserPrompt,
            });
            promptTemplates.Insert(1,  PromptTemplate.GetDefault(LLH.G(LLK.DefaultPromptTemplateName)));

            _promptTemplates = new BindingList<PromptTemplate>(promptTemplates);
            comboBoxPromptTemplate.DataSource = _promptTemplates;
            comboBoxPromptTemplate.DisplayMember = "Name";            

            int index = promptTemplates.FindIndex(p => p.ID == currentTemplateId);

            comboBoxPromptTemplate.SelectedIndex = index == -1 ? 0 : index;            
        }

        private void BindOptionsChangedEvent()
        {
            void onOptionsChanged(object sender, EventArgs e)
            {
                if (
                    _generalSettings.BaseURL != textBoxBaseUrl.Text ||
                    _generalSettings.Path != textBoxPath.Text ||
                    _generalSettings.MaxTokens != (int)numericUpDownMaxTokens.Value ||
                    _generalSettings.Temperature != (double)numericUpDownTemperature.Value ||
                    _secureSettings.Organization != textBoxOrganization.Text ||
                    _secureSettings.ApiKey != textBoxApiKey.Text ||
                    _generalSettings.Model != ComboBoxModelsRealValue()
                   )
                {
                    commonBottomControl.ButtonOkState = false;
                }
                else
                {
                    commonBottomControl.ButtonOkState = _generalSettings.Checked;
                }
            }

            void onTextBoxApiKeyChanged(object sender, EventArgs e) 
            {
                if (string.IsNullOrEmpty(textBoxApiKey.Text))
                {
                    buttonListModels.Enabled = false;
                }
                else
                {
                    buttonListModels.Enabled = true;
                }
            }

            textBoxBaseUrl.TextChanged += onOptionsChanged;
            textBoxPath.TextChanged += onOptionsChanged;
            numericUpDownMaxTokens.ValueChanged += onOptionsChanged;
            numericUpDownTemperature.ValueChanged += onOptionsChanged;
            textBoxOrganization.TextChanged += onOptionsChanged;
            textBoxApiKey.TextChanged += onOptionsChanged;
            comboBoxModels.TextChanged += onOptionsChanged;

            textBoxApiKey.TextChanged += onTextBoxApiKeyChanged;
        }


        private string ComboBoxModelsRealValue()
        {
            var text = comboBoxModels.Text;
            var model = _models.FirstOrDefault(m => m.DisplayName == text);
            return model != null ? model.UniqueName : text;
        }

        private void ChangeTextBoxPrompt(bool batchTranslate, PromptTemplate promptTemplate)
        {
            string systemPrompt = batchTranslate ? promptTemplate.BathTranslateSystemPrompt : promptTemplate.SystemPrompt;
            string userPrompt = batchTranslate ? promptTemplate.BathTranslateUserPrompt : promptTemplate.UserPrompt;

            textBoxSystemPrompt.Text = systemPrompt
                 .Replace(Environment.NewLine, "\n").Replace("\n", Environment.NewLine); // 解决 xml 反序列化后换行符总是变成 \n
            textBoxUserPrompt.Text = userPrompt
                .Replace(Environment.NewLine, "\n").Replace("\n", Environment.NewLine); // 解决 xml 反序列化后换行符总是变成 \n;
        }

        
        private async Task linkLabelCheck_LinkClicked()
        {
            var option = _service.GetDefaultOptions();

            var bg = option.GeneralSettings as LLMBaseGeneralSettings;
            var bs = option.SecureSettings as LLMBaseSecureSettings;

            bg.BaseURL = textBoxBaseUrl.Text;
            bg.Path = textBoxPath.Text;

            bg.MaxTokens = (int)numericUpDownMaxTokens.Value;
            bg.Temperature = (double)numericUpDownTemperature.Value;

            bg.Model = ComboBoxModelsRealValue();

            bg.EnableBathTranslate = false;
            bg.PromptTemplateId = "";

            bg.SystemPrompt = "You are an AI."; // 测试无需真实值
            bg.UserPrompt = "This is a connection test, output 'yes' only."; // 测试无需真实值  

            bs.Organization = textBoxOrganization.Text;
            bs.ApiKey = textBoxApiKey.Text;

            await _service.Check(option);
        }


        private async void buttonListModels_Click(object sender, EventArgs e)
        {
            var originalControlStates = commonBottomControl.DisableControls();
            commonBottomControl.CleanLabelResult();
            commonBottomControl.ShowProgressBar();

            _networkModels = null;
            try
            {
                var option = _service.GetDefaultOptions();

                var bg = option.GeneralSettings as LLMBaseGeneralSettings;
                var bs = option.SecureSettings as LLMBaseSecureSettings;

                bg.BaseURL = textBoxBaseUrl.Text;

                bs.Organization = textBoxOrganization.Text;
                bs.ApiKey = textBoxApiKey.Text;

                _networkModels = await _service.ListModels(option);
            }
            catch (Exception ex)
            {
                commonBottomControl.FailedDetailsMsg = ex.Message;
            }

            if (!IsDisposed)
            {
                bool isLoadSuccess = _networkModels != null;

                if (isLoadSuccess)
                {
                    var preSelectModel = _previousModelIndex >= 0 && _previousModelIndex < _models.Count ? _models[_previousModelIndex].UniqueName : "";
                    var networkModels = _networkModels.Select(name => new ModelItem() { UniqueName = name, DisplayName = name }).ToArray();

                    LoadModels("", preSelectModel, networkModels, new ModelItem[0], new HashSet<string>());
                }

                var msg = isLoadSuccess ? LLH.G(LLK.LabelResult_LoadSuccees) : LLH.G(LLK.LabelResult_LoadFail);

                commonBottomControl.HideProgressBar();
                commonBottomControl.ShowLabelResult(isLoadSuccess, msg);
                commonBottomControl.RecoverControls(originalControlStates);
            }
        }

        private void comboBoxModels_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_ignoreModelIndexChange) return;

            int currentIndex = comboBoxModels.SelectedIndex;
            int specialIndex = comboBoxModels.Items.Count - 1;

            if (currentIndex == specialIndex)
            {               
                using (var form = new CustomModels(_mtGeneralSettings, _mtSecureSettings, _generalSettings, _buildInModels, _networkModels))
                {
                    form.ShowDialog();

                    if (form.DialogResult == DialogResult.OK)
                    {
                        var preSelectModel = _previousModelIndex >= 0 && _previousModelIndex < _models.Count ? _models[_previousModelIndex].UniqueName : "";
                        LoadModels(_generalSettings.Model, preSelectModel, _generalSettings.UserModels, _buildInModels, _generalSettings.HidenBuildInModels.ToHashSet());
                    }
                    else
                    {
                        _ignoreModelIndexChange = true;
                        comboBoxModels.SelectedIndex = _previousModelIndex;
                        _ignoreModelIndexChange = false;
                    }
                }
            }
            else
            {
                _previousModelIndex = currentIndex;
            }
        }

        private void comboBoxPromptTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {           
            if (comboBoxPromptTemplate.SelectedItem is PromptTemplate promptTemplate) 
            {
                bool noUse = string.IsNullOrEmpty(promptTemplate.ID);

                textBoxSystemPrompt.ReadOnly = !noUse;
                textBoxUserPrompt.ReadOnly = !noUse;

                textBoxSystemPrompt.ContextMenuStrip = noUse ? _textBoxPromptMenu : null;
                textBoxUserPrompt.ContextMenuStrip = noUse ? _textBoxPromptMenu : null;

                ChangeTextBoxPrompt(checkBoxBathTranslate.Checked, promptTemplate);
            }
        }

        private void textBoxSystemPrompt_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxPromptTemplate.SelectedItem is PromptTemplate promptTemplate) 
            {
                if (checkBoxBathTranslate.Checked)
                    promptTemplate.BathTranslateSystemPrompt = textBoxSystemPrompt.Text;
                else
                    promptTemplate.SystemPrompt = textBoxSystemPrompt.Text;

                textBoxSystemPrompt.ScrollBars = textBoxSystemPrompt.Lines.Length > 6 ? ScrollBars.Vertical : ScrollBars.None;
            }
        }

        private void textBoxUserPrompt_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxPromptTemplate.SelectedItem is PromptTemplate promptTemplate)
            {
                if (checkBoxBathTranslate.Checked)
                    promptTemplate.BathTranslateUserPrompt = textBoxUserPrompt.Text;
                else
                    promptTemplate.UserPrompt = textBoxUserPrompt.Text;

                textBoxUserPrompt.ScrollBars = textBoxUserPrompt.Lines.Length > 6 ? ScrollBars.Vertical : ScrollBars.None;
            }
        }

        private void checkBoxBathTranslate_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBoxPromptTemplate.SelectedItem is PromptTemplate promptTemplate)
            {
                ChangeTextBoxPrompt(checkBoxBathTranslate.Checked, promptTemplate);
            }
        }




        private void buttonManage_Click(object sender, EventArgs e)
        {
            var id = ((PromptTemplate)comboBoxPromptTemplate.SelectedItem)?.ID;

            using (var form = new PromptTemplateManage(_mtGeneralSettings, _mtSecureSettings, id))
            {
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    LoadPromptTemplates(id, _mtGeneralSettings.LLMCommon.PromptTemplates);
                }
            }
        }

        private void linkLabelMoreSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var form = new PromptPlaceholders(_mtGeneralSettings, _mtSecureSettings))
            {
                form.ShowDialog();
            }
        }

        private void linkLabelBathTranslate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var form = new BathTranslate(_mtGeneralSettings, _mtSecureSettings, _generalSettings))
            {
                form.ShowDialog();
            }
        }


        private void linkLabelApiKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void linkLabelModel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(_service.ModelsLink);
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
                _generalSettings.BaseURL = textBoxBaseUrl.Text;
                _generalSettings.Path = textBoxPath.Text;

                _generalSettings.MaxTokens = (int)numericUpDownMaxTokens.Value;
                _generalSettings.Temperature = (double)numericUpDownTemperature.Value;

                _secureSettings.Organization = textBoxOrganization.Text;
                _secureSettings.ApiKey = textBoxApiKey.Text;

                _generalSettings.Model = ComboBoxModelsRealValue();

                _generalSettings.PromptTemplateId = ((PromptTemplate)comboBoxPromptTemplate.SelectedItem)?.ID;

                _generalSettings.SystemPrompt = _promptTemplates[0].SystemPrompt;
                _generalSettings.UserPrompt = _promptTemplates[0].UserPrompt;
                _generalSettings.BathTranslateSystemPrompt = _promptTemplates[0].BathTranslateSystemPrompt;
                _generalSettings.BathTranslateUserPrompt = _promptTemplates[0].BathTranslateUserPrompt;
                
                _generalSettings.EnableBathTranslate = checkBoxBathTranslate.Checked;

                _generalSettings.Checked = true;
            }
        }
    }


    class OptionsFormLocalizedKey : LocalizedKeyBase
    {
        public OptionsFormLocalizedKey(string name) : base(name)
        {
        }

        static OptionsFormLocalizedKey()
        {
            AutoInit<OptionsFormLocalizedKey>();
        }


        [LocalizedValue("07a89e6b-7ae9-4dab-8c63-d78fc747ea82", "LLM", "LLM")]
        public static OptionsFormLocalizedKey Form { get; private set; }

        [LocalizedValue("300fc67c-0b73-42e1-8e5f-6594aaf0ab8f", "Base Url", "请求基址")]
        public static OptionsFormLocalizedKey LabelBaseUrl { get; private set; }

        [LocalizedValue("42bbc36b-7616-45cb-ae8b-fa2575d11849", "Path", "请求路径")]
        public static OptionsFormLocalizedKey LabelPath { get; private set; }

        [LocalizedValue("0e793242-acff-4e42-852e-076645f7dcfd", "Max Tokens", "最大词元数")]
        public static OptionsFormLocalizedKey LabelMaxTokens { get; private set; }

        [LocalizedValue("8793bde6-cdf1-4fca-a7db-2d42251c4097", "Temperature", "温度")]
        public static OptionsFormLocalizedKey LabelTemperature { get; private set; }

        [LocalizedValue("87136671-38b8-41d0-8e9b-5151282e2cc3", "Organization", "组织")]
        public static OptionsFormLocalizedKey LabelOrganization { get; private set; }

        [LocalizedValue("ab51f3ef-e791-48db-aba8-37c9435d7396", "Api Key", "密钥")]
        public static OptionsFormLocalizedKey LinkLabelApiKey { get; private set; }

        [LocalizedValue("f8289042-679e-4a55-aa7c-a0c00ee640a0", "Model", "模型")]
        public static OptionsFormLocalizedKey LinkLabelModel { get; private set; }

        [LocalizedValue("3c6256ad-3bf9-4b08-8a21-d2c8a94fab46", "List", "加载")]
        public static OptionsFormLocalizedKey ButtonListModels { get; private set; }

        [LocalizedValue("efc3547c-df38-4a99-8714-c1fd594f9933", "Prompt Template", "提示词模板")]
        public static OptionsFormLocalizedKey LabelPromptTemplate { get; private set; }

        [LocalizedValue("7426855e-98ab-4fc4-abf4-353675f36250", "No Use", "不使用")]
        public static OptionsFormLocalizedKey PromptTemplateNoUse { get; private set; }

        [LocalizedValue("cafcd548-dcd5-4604-bff0-ad04ea8c7946", "Manage", "管理")]
        public static OptionsFormLocalizedKey ButtonManage { get; private set; }

        [LocalizedValue("8b08223d-ff3a-4618-8f53-70d3abfe899e", "System Prompt^", "系统提示词^")]
        public static OptionsFormLocalizedKey LabelSystemPrompt { get; private set; }

        [LocalizedValue("57e1d8dd-b89e-4404-8aab-9c07f0d174e6", "User Prompt^", "用户提示词^")]
        public static OptionsFormLocalizedKey LabelUserPrompt { get; private set; }

        [LocalizedValue("b530929e-dca0-444c-9e8c-7d9f1dd3bac7", "Other Options", "其他选项")]
        public static OptionsFormLocalizedKey LabelOtherOptions { get; private set; }

        [LocalizedValue("6836599e-966f-45d9-8d5a-25285b05450e", "Bath Translate", "批量翻译")]
        public static OptionsFormLocalizedKey LinkLabelBathTranslate { get; private set; }

        [LocalizedValue("957c00f3-efef-420e-a129-719a141ff6f3", "More Settings", "更多设置")]
        public static OptionsFormLocalizedKey LabelMoreSettings { get; private set; }

        [LocalizedValue("44b68ad2-9c88-4b9c-b1ea-f5d581713f8c", "[Custom Model List]", "【自定义模型列表】")]
        public static OptionsFormLocalizedKey CustomModelList { get; private set; }

        [LocalizedValue("b77452d6-c194-4d1b-b13a-686c5656c638", "Default", "内置默认")]
        public static OptionsFormLocalizedKey DefaultPromptTemplateName { get; private set; }

        [LocalizedValue("0c661c70-25b3-452d-867a-126efd954a0d", "List succeess !", "加载成功！")]
        public static OptionsFormLocalizedKey LabelResult_LoadSuccees { get; private set; }

        [LocalizedValue("bfc392e3-0df1-4787-b2f2-5d2f1e349622", "List fail ! Click here for details", "加载失败！点此查看详情")]
        public static OptionsFormLocalizedKey LabelResult_LoadFail { get; private set; }
    }
}
