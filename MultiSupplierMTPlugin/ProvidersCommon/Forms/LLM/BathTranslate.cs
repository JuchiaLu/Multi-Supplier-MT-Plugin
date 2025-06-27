using MultiSupplierMTPlugin.Localized;
using MultiSupplierMTPlugin.ProvidersCommon.Options.LLM;
using System;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM.BathTranslateLocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM
{
    partial class BathTranslate : Form
    {
        private MultiSupplierMTGeneralSettings _mtGeneralSettings;

        private MultiSupplierMTSecureSettings _mtSecureSettings;

        protected LLMBaseGeneralSettings _llmBaseSettings;

        public BathTranslate(MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings, LLMBaseGeneralSettings llmBaseSettings)
        {
            InitializeComponent();

            this._mtGeneralSettings = mtGeneralSettings;
            this._mtSecureSettings = mtSecureSettings;
            this._llmBaseSettings = llmBaseSettings;
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

            groupBoxRequestSizeLimit.Text = LLH.G(LLK.GroupBoxRequestSizeLimit);
            labelMaxSegments.Text = LLH.G(LLK.LabelMaxSegments);
            labelMaxCharacters.Text = LLH.G(LLK.labelMaxCharacters);
            toolTip.SetToolTip(numericUpDownMaxSegments, LLH.G(LLKC.ZeroIndicatesNoLimit));
            toolTip.SetToolTip(numericUpDownMaxCharacters, LLH.G(LLKC.ZeroIndicatesNoLimit));

            groupBoxOutputSchema.Text = LLH.G(LLK.GroupBoxOutputSchema);
            radioButtonShorter.Text = LLH.G(LLK.RadioButtonShorter);
            labelShorter.Text = LLH.G(LLK.LabelShorter);
            radioButtonLonger.Text = LLH.G(LLK.RadioButtonLonger);
            labelLonger.Text = LLH.G(LLK.LabelLonger);

            groupBoxOutputFormat.Text = LLH.G(LLK.GroupBoxOutputFormat);
            radioButtonText.Text = LLH.G(LLK.RadioButtonText);
            labelText.Text = LLH.G(LLK.LabelText);
            radioButtonJsonObject.Text = LLH.G(LLK.RadioButtonJsonObject);
            labelJsonObject.Text = LLH.G(LLK.LabelJsonObject);
            radioButtonJsonSchema.Text = LLH.G(LLK.RadioButtonJsonSchema);
            labelJsonSchema.Text = LLH.G(LLK.LabelJsonSchema);

            buttonOK.Text = LLH.G(LLKC.ButtonOK);
            buttonCancel.Text = LLH.G(LLKC.ButtonCancel);
        }

        private void LoadOptions()
        {
            numericUpDownMaxSegments.Value = _llmBaseSettings.BathTranslateMaxSegments;
            numericUpDownMaxCharacters.Value = _llmBaseSettings.BathTranslateMaxCharacters;

            if(_llmBaseSettings.BathTranslateSchema == BathTranslateSchema.Longer)
                radioButtonLonger.Checked = true;
            else
                radioButtonShorter.Checked = true;

            if (_llmBaseSettings.BathTranslateResponseFormat == BathTranslateResponseFormat.JSON_Schema)
                radioButtonJsonSchema.Checked = true;
            else if (_llmBaseSettings.BathTranslateResponseFormat == BathTranslateResponseFormat.JSON_Object)
                radioButtonJsonObject.Checked = true;
            else
                radioButtonText.Checked = true;
        }

        private void BathTranslate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _llmBaseSettings.BathTranslateMaxSegments = (int)numericUpDownMaxSegments.Value;
                _llmBaseSettings.BathTranslateMaxCharacters = (int)numericUpDownMaxCharacters.Value;

                if (radioButtonLonger.Checked)
                    _llmBaseSettings.BathTranslateSchema = BathTranslateSchema.Longer;
                else
                    _llmBaseSettings.BathTranslateSchema = BathTranslateSchema.Shorter;

                if (radioButtonJsonSchema.Checked)
                    _llmBaseSettings.BathTranslateResponseFormat = BathTranslateResponseFormat.JSON_Schema;
                else if (radioButtonJsonObject.Checked)
                    _llmBaseSettings.BathTranslateResponseFormat = BathTranslateResponseFormat.JSON_Object;
                else
                    _llmBaseSettings.BathTranslateResponseFormat = BathTranslateResponseFormat.Text;
            }
        }
    }

    class BathTranslateLocalizedKey : LocalizedKeyBase
    {
        public BathTranslateLocalizedKey(string name) : base(name)
        {
        }

        static BathTranslateLocalizedKey()
        {
            AutoInit<BathTranslateLocalizedKey>();
        }

        [LocalizedValue("bfadc0e0-e72a-4131-8d60-f97217c890de", "Bath Translate (For use only by this provider)", "批量翻译（仅作用于本提供商）")]
        public static BathTranslateLocalizedKey Form { get; private set; }

        [LocalizedValue("7d22a2db-9c51-4207-8e23-0dbe96fae26b", "Request Size Limit", "请求大小限制")]
        public static BathTranslateLocalizedKey GroupBoxRequestSizeLimit { get; private set; }

        [LocalizedValue("e2362057-8631-48c5-90aa-2149e8f826d8", "Max Segments Per Request", "每请求最大句段数")]
        public static BathTranslateLocalizedKey LabelMaxSegments { get; private set; }

        [LocalizedValue("0b2a8a1d-40d7-422d-a264-7f935589a580", "Max Characters Per Request", "每请求最大字符数")]
        public static BathTranslateLocalizedKey labelMaxCharacters { get; private set; }

        [LocalizedValue("63ac2e82-638a-48ab-a118-66a58be724e6", "Expect Output JSON Schema", "预期输出 JSON 定义")]
        public static BathTranslateLocalizedKey GroupBoxOutputSchema { get; private set; }

        [LocalizedValue("09030313-4a12-42d9-9123-1893f1c88488", "Shorter", "较短")]
        public static BathTranslateLocalizedKey RadioButtonShorter { get; private set; }

        [LocalizedValue("7f615021-780c-4bd0-bc86-f32e609eb51d", "{{\"1\":\"t1\",\"2\":\"t2\"}}", "{{\"1\":\"t1\",\"2\":\"t2\"}}")]
        public static BathTranslateLocalizedKey LabelShorter { get; private set; }

        [LocalizedValue("5fb17689-1160-4c58-893c-45301900ae07", "Longer ", "较长")]
        public static BathTranslateLocalizedKey RadioButtonLonger { get; private set; }

        [LocalizedValue("dbbd9929-feaf-4815-be4d-5d3ecda565dc", "{{\"texts\":[{{\"id\":1,\"text\":\"t1\"}},{{\"id\":2,\"text\":\"t2\"}}]}}", "{{\"texts\":[{{\"id\":1,\"text\":\"t1\"}},{{\"id\":2,\"text\":\"t2\"}}]}}")]
        public static BathTranslateLocalizedKey LabelLonger { get; private set; }

        [LocalizedValue("eff40338-851f-4a8d-9c82-b195f073336d", "Request LLM Output Format", "要求大模型输出格式")]
        public static BathTranslateLocalizedKey GroupBoxOutputFormat { get; private set; }

        [LocalizedValue("d0c9544c-a428-45a6-a398-0c2b1c8ef891", "Text", "Text")]
        public static BathTranslateLocalizedKey RadioButtonText { get; private set; }

        [LocalizedValue("9c17463a-d2ad-4a4c-b6a1-782c573faee8", "Does not guarantee a JSON object or valid JSON schema", "不保证输出是合法 JSON 对象，不保证输出和 JSON 定义一致")]
        public static BathTranslateLocalizedKey LabelText { get; private set; }

        [LocalizedValue("5d09c280-afff-4861-96ce-d7ed0dbddd2f", "JSON Object", "JSON Object")]
        public static BathTranslateLocalizedKey RadioButtonJsonObject { get; private set; }

        [LocalizedValue("e1da972a-5adf-4c75-8eba-855c667c1de9", "Guarantees a JSON object, but not a valid JSON schema", "只保证输出是合法 JSON 对象，不保证输出和 JSON 定义一致")]
        public static BathTranslateLocalizedKey LabelJsonObject { get; private set; }

        [LocalizedValue("4dfcd0c2-82a3-4a5f-bf94-7404beb46278", "JSON Schema", "JSON Schema")]
        public static BathTranslateLocalizedKey RadioButtonJsonSchema { get; private set; }

        [LocalizedValue("1f17eb0d-7011-4140-86ed-e76403e6be0c", "Guarantees both a JSON object and a valid JSON schema", "既保证输出是合法 JSON 对象，又保证输出和 JSON 定义一致")]
        public static BathTranslateLocalizedKey LabelJsonSchema { get; private set; }
    }
}
