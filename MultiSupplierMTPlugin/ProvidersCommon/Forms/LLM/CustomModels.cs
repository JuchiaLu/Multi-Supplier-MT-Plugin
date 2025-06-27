using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.Localized;
using MultiSupplierMTPlugin.ProvidersCommon.Options.LLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM.CustomModelsLocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM
{
    partial class CustomModels : Form
    {
        private MultiSupplierMTGeneralSettings _mtGeneralSettings;

        private MultiSupplierMTSecureSettings _mtSecureSettings;

        private LLMBaseGeneralSettings _llmBaseGeneralSettings;

        private ModelItem[] _buildinModels;
        private List<string> _networkModels;

        public CustomModels(MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings,
            LLMBaseGeneralSettings llmBaseGeneralSettings, ModelItem[] buildInModels, List<string> networkModels)
        {
            InitializeComponent();

            this._mtGeneralSettings = mtGeneralSettings;
            this._mtSecureSettings = mtSecureSettings;

            this._llmBaseGeneralSettings = llmBaseGeneralSettings;
            this._buildinModels = buildInModels;
            this._networkModels = networkModels;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Localized();

            LoadOptions();
        }

        private void Localized()
        {
            Text = LLH.G(LLK.Form);

            tabPageUserModels.Text = LLH.G(LLK.TabPageUserModels);
            labelUserModelsTip1.Text = LLH.G(LLK.LabelUserModelsTip1);
            labelUserModelsTip2.Text = LLH.G(LLK.LabelUserModelsTip2);

            tabPageNetworkModels.Text = LLH.G(LLK.TabPageNetworkModels);
            labelNetworkModelsTip1.Text = LLH.G(LLK.LabelNetworkModelsTip1);
            labelNetworkModelsTip2.Text = LLH.G(LLK.LabelNetworkModelsTip2);

            tabPageBuiltinModels.Text = LLH.G(LLK.TabPageBuiltinModels);
            linkLabelAllEnable.Text = LLH.G(LLK.LinkLabelAllEnable);
            linkLabelAllDisable.Text = LLH.G(LLK.LinkLabelAllDisable);

            buttonOK.Text = LLH.G(LLKC.ButtonOK);
            buttonCancel.Text = LLH.G(LLKC.ButtonCancel);
        }

        private void LoadOptions()
        {
            textBoxUserModels.Text = ModelItemHelper.ToTextList(_llmBaseGeneralSettings.UserModels, ",\r\n");

            var _hidenModels = _llmBaseGeneralSettings.HidenBuildInModels.ToHashSet();            
            foreach (var model in _buildinModels)
            {
                var modelText = ModelItemHelper.ToText(model);
                int index = checkedListBoxBuildinModels.Items.Add(modelText);

                if (!_hidenModels.Contains(model.UniqueName))
                {
                    checkedListBoxBuildinModels.SetItemChecked(index, true);
                }
            }

            if (_networkModels != null)
                textBoxNetworkModels.Text = string.Join(",\r\n", _networkModels);
        }

        private void linkLabelAllEnable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < checkedListBoxBuildinModels.Items.Count; i++)
                checkedListBoxBuildinModels.SetItemChecked(i, true);
        }

        private void linkLabelAllDisable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < checkedListBoxBuildinModels.Items.Count; i++)
                checkedListBoxBuildinModels.SetItemChecked(i, false);
        }

        private void CustomModels_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _llmBaseGeneralSettings.UserModels = ModelItemHelper.ParseList(textBoxUserModels.Text);

                var uncheckedItems = new List<string>();
                for (int i = 0; i < checkedListBoxBuildinModels.Items.Count; i++)
                {
                    if (!checkedListBoxBuildinModels.GetItemChecked(i))
                    {
                        uncheckedItems.Add((string)checkedListBoxBuildinModels.Items[i]);
                    }
                }
                _llmBaseGeneralSettings.HidenBuildInModels = uncheckedItems.ToArray();
            }
        }
    }

    class CustomModelsLocalizedKey : LocalizedKeyBase
    {
        public CustomModelsLocalizedKey(string name) : base(name)
        {
        }

        static CustomModelsLocalizedKey()
        {
            AutoInit<CustomModelsLocalizedKey>();
        }


        [LocalizedValue("c83f7d93-c08e-4cb2-ba72-887be5cd9314", "Custom Model List", "自定义模型列表")]
        public static CustomModelsLocalizedKey Form { get; private set; }

        [LocalizedValue("62b0540f-5246-4a2c-ab9b-2eea4926f9ca", "User Models", "用户模型")]
        public static CustomModelsLocalizedKey TabPageUserModels { get; private set; }

        [LocalizedValue("5c31ab4a-2008-43f6-9642-c4ad20578c7a", "Separate models with commas, newlines optional", "使用“英文逗号”分割模型，逗号后可选换行")]
        public static CustomModelsLocalizedKey LabelUserModelsTip1 { get; private set; }

        [LocalizedValue("35de8b83-ec56-4703-9123-3f84c613be26", "Use \"=\" to set aliases, e.g., gpt-4o-mini=xxx", "使用“等号”给模型设置别名，比如 gpt-4o-mini=xxx")]
        public static CustomModelsLocalizedKey LabelUserModelsTip2 { get; private set; }

        [LocalizedValue("4fbce202-5d5f-4b09-84dd-d184b0bfebd9", "Network Models", "网络模型")]
        public static CustomModelsLocalizedKey TabPageNetworkModels { get; private set; }

        [LocalizedValue("9614d031-4d1e-4d97-ade5-75f9f181fb74", "Load models into Network Models from main form first", "先从主界面加载模型到网络模型列表")]
        public static CustomModelsLocalizedKey LabelNetworkModelsTip1 { get; private set; }

        [LocalizedValue("523c4aa4-cd38-44b9-ab40-94fac425c304", "This list won't be saved. Copy needed models to user list", "此列表不会被保存，复制所需模型到用户模型列表")]
        public static CustomModelsLocalizedKey LabelNetworkModelsTip2 { get; private set; }

        [LocalizedValue("040d1697-3cb7-488f-993d-2b7e36c432e0", "Builtin Models", "内置模型")]
        public static CustomModelsLocalizedKey TabPageBuiltinModels { get; private set; }

        [LocalizedValue("904e1a67-cf48-453e-945c-ffb9a9370d76", "All Enable", "全部启用")]
        public static CustomModelsLocalizedKey LinkLabelAllEnable { get; private set; }

        [LocalizedValue("58e39fdd-5199-44c9-a9d3-a4ead4625042", "All Disable", "全部禁用")]
        public static CustomModelsLocalizedKey LinkLabelAllDisable { get; private set; }
    }
}
