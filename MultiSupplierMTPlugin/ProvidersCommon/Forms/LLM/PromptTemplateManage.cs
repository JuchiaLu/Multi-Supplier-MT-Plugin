using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.Localized;
using MultiSupplierMTPlugin.ProvidersCommon.Options.LLM;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM.PromptTemplateManageLocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM
{
    partial class PromptTemplateManage : Form
    {
        private MultiSupplierMTGeneralSettings _mtGeneralSettings;

        private MultiSupplierMTSecureSettings _mtSecureSettings;

        private BindingList<PromptTemplate> _promptTemplates;

        private string _currentPromptId;

        private bool _renaming = false;


        public PromptTemplateManage(MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings, string currentPromptId)
        {
            InitializeComponent();

            this._mtGeneralSettings = mtGeneralSettings;
            this._mtSecureSettings = mtSecureSettings;

            this._currentPromptId = currentPromptId;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Localized();

            LoadOptions();
        }


        private void Localized()
        {
            var textBoxPromptMenu = PromptHelper.CreateTextBoxContextMenu();

            Text = LLH.G(LLK.Form);

            labelAction.Text = LLH.G(LLK.LabelAction);
            buttonAdd.Text = LLH.G(LLK.ButtonAdd);
            buttonDelete.Text = LLH.G(LLK.ButtonDelete);
            buttonRename.Text = LLH.G(LLK.ButtonRename);

            labelTemplates.Text = LLH.G(LLK.LabelTemplates);

            groupBoxSingleTranslate.Text = LLH.G(LLK.GroupBoxSingleTranslate);
            labelSystemPrompt.Text = LLH.G(LLK.LabelSystemPrompt);
            labelUserPrompt.Text = LLH.G(LLK.LabelUserPrompt);
            
            toolTip.SetToolTip(labelSystemPrompt, LLH.G(LLKC.ToolTip_LLMPromptTip));
            toolTip.SetToolTip(labelUserPrompt, LLH.G(LLKC.ToolTip_LLMPromptTip));

            textBoxSystemPrompt.ContextMenuStrip = textBoxPromptMenu;
            textBoxUserPrompt.ContextMenuStrip = textBoxPromptMenu;

            groupBoxBathTranslate.Text = LLH.G(LLK.GroupBoxBathTranslate);
            labelBathTranslateSystemPrompt.Text = LLH.G(LLK.LabelBathTranslateSystemPrompt);
            labelBathTranslateUserPrompt.Text = LLH.G(LLK.LabelBathTranslateUserPrompt);
            
            toolTip.SetToolTip(labelBathTranslateSystemPrompt, LLH.G(LLKC.ToolTip_LLMPromptTip));
            toolTip.SetToolTip(labelBathTranslateUserPrompt, LLH.G(LLKC.ToolTip_LLMPromptTip));

            textBoxBathTranslateSystemPrompt.ContextMenuStrip = textBoxPromptMenu;
            textBoxBathTranslateUserPrompt.ContextMenuStrip = textBoxPromptMenu;

            buttonOK.Text = LLH.G(LLKC.ButtonOK);
            buttonCancel.Text = LLH.G(LLKC.ButtonCancel);
        }

        private void LoadOptions()
        {
            _promptTemplates = new BindingList<PromptTemplate>(
                _mtGeneralSettings.LLMCommon.PromptTemplates
                .Select(p => p.Clone())
                .OrderBy(p => p.Name, new NaturalSortComparer())
                .ToList());
            
            comboBoxTemplates.DataSource = _promptTemplates;
            comboBoxTemplates.DisplayMember = "Name";

            var promptTemplate = _promptTemplates.Where(p => p.ID == _currentPromptId).FirstOrDefault();
            if (promptTemplate != null)
            {
                comboBoxTemplates.SelectedItem = promptTemplate;
            }

            UpdateControlState();
        }

        private void UpdateControlState()
        {
            bool hasSel = comboBoxTemplates.SelectedIndex != -1;
            bool hasSelAndRenaming = hasSel & _renaming;
            bool hasSelNoRenaming = hasSel & !_renaming;
            bool noEmptyNoRenaming = _promptTemplates.Count > 0 & !_renaming;

            buttonAdd.Enabled = !_renaming;
            buttonDelete.Enabled = hasSelNoRenaming;
            buttonRename.Enabled = hasSel;

            textBoxTemplate.Enabled = hasSelAndRenaming;
            comboBoxTemplates.Enabled = noEmptyNoRenaming;            

            textBoxSystemPrompt.Enabled = hasSelNoRenaming;
            textBoxUserPrompt.Enabled = hasSelNoRenaming;

            textBoxBathTranslateSystemPrompt.Enabled = hasSelNoRenaming;
            textBoxBathTranslateUserPrompt.Enabled = hasSelNoRenaming;
        }

        private void comboBoxTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTemplates.SelectedItem is PromptTemplate prompt)
            {
                textBoxSystemPrompt.Text = prompt?.SystemPrompt
                  .Replace(Environment.NewLine, "\n").Replace("\n", Environment.NewLine) ?? ""; // 解决 xml 反序列化后换行符总是变成 \n
                textBoxUserPrompt.Text = prompt?.UserPrompt
                    .Replace(Environment.NewLine, "\n").Replace("\n", Environment.NewLine) ?? ""; // 解决 xml 反序列化后换行符总是变成 \n;

                textBoxBathTranslateSystemPrompt.Text = prompt?.BathTranslateSystemPrompt
                 .Replace(Environment.NewLine, "\n").Replace("\n", Environment.NewLine) ?? ""; // 解决 xml 反序列化后换行符总是变成 \n
                textBoxBathTranslateUserPrompt.Text = prompt?.BathTranslateUserPrompt
                    .Replace(Environment.NewLine, "\n").Replace("\n", Environment.NewLine) ?? ""; // 解决 xml 反序列化后换行符总是变成 \n;
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (_renaming) return;

            string newName = Enumerable.Range(1, int.MaxValue)
               .Select(i => $"New {i}")
               .First(name => !_promptTemplates.Any(p => p.Name == name));

            _promptTemplates.Add(new PromptTemplate() { ID = Guid.NewGuid().ToString(), Name = newName });
            UpdateControlState();

            if (comboBoxTemplates.Items.Count > 0)
                comboBoxTemplates.SelectedIndex = comboBoxTemplates.Items.Count - 1;

            comboBoxTemplates_SelectedIndexChanged(comboBoxTemplates, EventArgs.Empty);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_renaming) return;

            int index = comboBoxTemplates.SelectedIndex;
            if (index >= 0 && index < _promptTemplates.Count)
            { 
                _promptTemplates.RemoveAt(index);
                UpdateControlState();
                comboBoxTemplates_SelectedIndexChanged(comboBoxTemplates, EventArgs.Empty);
            }
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (comboBoxTemplates.SelectedItem is PromptTemplate prompt)
            {
                if (!_renaming)
                {
                    textBoxTemplate.Text = prompt.Name;
                }
                else
                {
                    var name = textBoxTemplate.Text;

                    if (_promptTemplates.Any(p => p.Name == name && prompt.Name != name))
                    {
                        MessageBox.Show(LLH.G(LLK.MessageAlreadyExists), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    prompt.Name = name;
                    ((CurrencyManager)BindingContext[comboBoxTemplates.DataSource]).Refresh();
                }

                _renaming = !_renaming;
                UpdateControlState();

                textBoxTemplate.Visible = _renaming;
                comboBoxTemplates.Visible = !_renaming;
                buttonRename.Text = LLH.G(_renaming ? LLK.ButtonApply : LLK.ButtonRename);
            }
        }

        private void textBoxSystemPrompt_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxTemplates.SelectedItem is PromptTemplate prompt)
            {
                prompt.SystemPrompt = textBoxSystemPrompt.Text;
                textBoxSystemPrompt.ScrollBars = textBoxSystemPrompt.Lines.Length > 6 ? ScrollBars.Vertical : ScrollBars.None;
            }
        }

        private void textBoxUserPrompt_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxTemplates.SelectedItem is PromptTemplate prompt)
            { 
                prompt.UserPrompt = textBoxUserPrompt.Text;
                textBoxUserPrompt.ScrollBars = textBoxUserPrompt.Lines.Length > 6 ? ScrollBars.Vertical : ScrollBars.None;
            }
        }


        private void textBoxBathTranslateSystemPrompt_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxTemplates.SelectedItem is PromptTemplate prompt)
            {
                prompt.BathTranslateSystemPrompt = textBoxBathTranslateSystemPrompt.Text;
                textBoxBathTranslateSystemPrompt.ScrollBars = textBoxBathTranslateSystemPrompt.Lines.Length > 6 ? ScrollBars.Vertical : ScrollBars.None;
            }
        }

        private void textBoxBathTranslateUserPrompt_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxTemplates.SelectedItem is PromptTemplate prompt)
            {
                prompt.BathTranslateUserPrompt = textBoxBathTranslateUserPrompt.Text;
                textBoxBathTranslateUserPrompt.ScrollBars = textBoxBathTranslateUserPrompt.Lines.Length > 6 ? ScrollBars.Vertical : ScrollBars.None;
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


        private void PromptTemplateManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _mtGeneralSettings.LLMCommon.PromptTemplates = _promptTemplates.ToArray();
            }
        }
    }

    class PromptTemplateManageLocalizedKey : LocalizedKeyBase
    {
        public PromptTemplateManageLocalizedKey(string name) : base(name)
        {
        }

        static PromptTemplateManageLocalizedKey()
        {
            AutoInit<PromptTemplateManageLocalizedKey>();
        }

        [LocalizedValue("ffbeb939-9b25-4b44-bd30-604ad2c0b2ba", "Prompt Templates (Shared by all LLM providers)", "提示词模板（所有 LLM 提供商共用）")]
        public static PromptTemplateManageLocalizedKey Form { get; private set; }

        [LocalizedValue("227804b2-297d-4c7c-9f16-bcb4306ca076", "Action", "动作")]
        public static PromptTemplateManageLocalizedKey LabelAction { get; private set; }

        [LocalizedValue("776f2388-a89a-4e10-a6ce-11d9f6ec82cf", "Add", "新添")]
        public static PromptTemplateManageLocalizedKey ButtonAdd { get; private set; }

        [LocalizedValue("7e313363-cc3d-47e7-bd78-3428ce73fd7e", "Delete", "删除")]
        public static PromptTemplateManageLocalizedKey ButtonDelete { get; private set; }

        [LocalizedValue("99c30c93-8b17-4a22-b1c7-e3e8650ddc25", "Rename", "修改")]
        public static PromptTemplateManageLocalizedKey ButtonRename { get; private set; }

        [LocalizedValue("d2b7d306-4d3a-44e7-b497-3a568870f6ca", "Apply", "应用")]
        public static PromptTemplateManageLocalizedKey ButtonApply { get; private set; }

        [LocalizedValue("c6be6ebf-5421-4640-84c6-e06f9f38a74e", "Templates", "模板")]
        public static PromptTemplateManageLocalizedKey LabelTemplates { get; private set; }

        [LocalizedValue("7261c57b-b57a-4c99-864a-d469e973cb28", "Use For Single Translate", "用于单段翻译")]
        public static PromptTemplateManageLocalizedKey GroupBoxSingleTranslate { get; private set; }

        [LocalizedValue("58afc667-1e31-407a-a0c0-6a47118ce089", "System Prompt^", "系统提示词^")]
        public static PromptTemplateManageLocalizedKey LabelSystemPrompt { get; private set; }

        [LocalizedValue("aa1943dd-abdc-4a13-b6f6-293144219aaf", "User Prompt^", "用户提示词^")]
        public static PromptTemplateManageLocalizedKey LabelUserPrompt { get; private set; }

        [LocalizedValue("86643d6d-60d7-4657-ade2-8a8929892dac", "Use For Bath Translate", "用于批量翻译")]
        public static PromptTemplateManageLocalizedKey GroupBoxBathTranslate { get; private set; }

        [LocalizedValue("87c5b641-ad6e-4e26-899b-9ef7317ac40d", "System Prompt^", "系统提示词^")]
        public static PromptTemplateManageLocalizedKey LabelBathTranslateSystemPrompt { get; private set; }

        [LocalizedValue("51da8b07-42b8-459e-adc7-853fe2ebb782", "User Prompt^", "用户提示词^")]
        public static PromptTemplateManageLocalizedKey LabelBathTranslateUserPrompt { get; private set; }

        [LocalizedValue("f7e49fcd-990c-4166-999d-c0dee50fd85e", "Already exists", "已存在")]
        public static PromptTemplateManageLocalizedKey MessageAlreadyExists { get; private set; }
    }
}
