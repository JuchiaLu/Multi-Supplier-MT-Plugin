using MultiSupplierMTPlugin.Localized;
using MultiSupplierMTPlugin.ProvidersCommon.Options.LLM;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM.PromptPlaceholdersLocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM
{
    partial class PromptPlaceholders : Form
    {
        private MultiSupplierMTGeneralSettings _mtGeneralSettings;

        private MultiSupplierMTSecureSettings _mtSecureSettings;

        private LLMCommonGeneralSettings _llmSettings;
        
        public PromptPlaceholders(MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings)
        {
            InitializeComponent();

            this._mtGeneralSettings = mtGeneralSettings;
            this._mtSecureSettings = mtSecureSettings;

            this._llmSettings = mtGeneralSettings.LLMCommon;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Localized();

            LoadOptions();
        }

        private void Localized()
        {
            string zeroIndicatesNoLimit = LLH.G(LLKC.ZeroIndicatesNoLimit) + LLH.G(LLK.BothZeroResultEmpty);

            Text = LLH.G(LLK.Form);

            groupBoxGlossaryText.Text = LLH.G(LLK.GroupBoxGlossaryText);
            labelGlossaryDelimiter.Text = LLH.G(LLK.LabelGlossaryDelimiter);
            labelGlossaryEncoding.Text = LLH.G(LLK.LabelGlossaryEncoding);
            labelGlossaryFilePath.Text = LLH.G(LLK.LabelGlossaryFilePath);
            buttonGlossarySelect.Text = LLH.G(LLK.ButtonGlossarySelect);
            toolTip.SetToolTip(textBoxGlossaryFilePath, LLH.G(LLKC.GlossaryFileFormatTip));

            groupBoxSummaryText.Text = LLH.G(LLK.GroupBoxSummaryText);
            labelSummaryType.Text = LLH.G(LLK.LabelSummaryType);
            radioButtonManualSelect.Text = LLH.G(LLK.RadioButtonManualSelect);
            radioButtonAutoGenerate.Text = LLH.G(LLK.RadioButtonAutoGenerate);
            labelSummaryFilePath.Text = LLH.G(LLK.LabelSummaryFilePath);
            buttonSummarySelect.Text = LLH.G(LLK.ButtonSummarySelect);
            labelSummaryPrompt.Text = LLH.G(LLK.LabelSummaryPrompt);
            linkLabelSummaryCacheDir.Text = LLH.G(LLK.LinkLabelSummaryCacheDir);

            groupBoxAboveText.Text = LLH.G(LLK.GroupBoxAboveText);
            labelAboveTextIncludeSource.Text = LLH.G(LLK.LabelAboveTextIncludeSource);
            labelAboveTextIncludeTarget.Text = LLH.G(LLK.LabelAboveTextIncludeTarget);
            labelAboveTextMaxSegments.Text = LLH.G(LLK.LabelAboveTextMaxSegments);
            labelAboveTextMaxCharacters.Text = LLH.G(LLK.LabelAboveTextMaxCharacters);
            toolTip.SetToolTip(numericUpDownAboveTextMaxSegments, zeroIndicatesNoLimit);
            toolTip.SetToolTip(numericUpDownAboveTextMaxCharacters, zeroIndicatesNoLimit);

            groupBoxBelowText.Text = LLH.G(LLK.GroupBoxBelowText);
            labelBelowTextIncludeSource.Text = LLH.G(LLK.LabelBelowTextIncludeSource);
            labelBelowTextIncludeTarget.Text = LLH.G(LLK.LabelBelowTextIncludeTarget);
            labelBelowTextMaxSegments.Text = LLH.G(LLK.LabelBelowTextMaxSegments);
            labelBelowTextMaxCharacters.Text = LLH.G(LLK.LabelBelowTextMaxCharacters);
            toolTip.SetToolTip(numericUpDownBelowTextMaxSegments, zeroIndicatesNoLimit);
            toolTip.SetToolTip(numericUpDownBelowTextMaxCharacters, zeroIndicatesNoLimit);

            buttonOK.Text = LLH.G(LLKC.ButtonOK);
            buttonCancel.Text = LLH.G(LLKC.ButtonCancel);
        }

        private void LoadOptions()
        {
            textBoxGlossaryDelimiter.Text = _llmSettings.GlossaryDelimiter;
            textBoxGlossaryEncoding.Text = "utf-8";
            textBoxGlossaryFilePath.Text = _llmSettings.GlossaryFilePath;

            radioButtonAutoGenerate.Checked = _llmSettings.SummaryAutoGenerate;
            radioButtonManualSelect.Checked = !_llmSettings.SummaryAutoGenerate;
            textBoxSummaryFilePath.Text = _llmSettings.SummaryFilePath;
            textBoxSummaryPrompt.Text = _llmSettings.SummaryGeneratePrompt
                .Replace(Environment.NewLine, "\n").Replace("\n", Environment.NewLine); // 解决 xml 反序列化后换行符总是变成 \n

            checkBoxAboveTextIncludeSource.Checked = _llmSettings.AboveTextIncludeSource;
            checkBoxAboveTextIncludeTarget.Checked = _llmSettings.AboveTextIncludeTarget;
            numericUpDownAboveTextMaxSegments.Value = _llmSettings.AboveTextMaxSegments;
            numericUpDownAboveTextMaxCharacters.Value = _llmSettings.AboveTextMaxCharacters;

            checkBoxBelowTextIncludeSource.Checked = _llmSettings.BelowTextIncludeSource;
            checkBoxBelowTextIncludeTarget.Checked = _llmSettings.BelowTextIncludeTarget;
            numericUpDownBelowTextMaxSegments.Value = _llmSettings.BelowTextMaxSegments;
            numericUpDownBelowTextMaxCharacters.Value = _llmSettings.BelowTextMaxCharacters;

            ChangeSummaryControlState();
        }

        private void ChangeSummaryControlState()
        {
            bool manual = radioButtonManualSelect.Checked;

            labelSummaryFilePath.Enabled = manual;
            textBoxSummaryFilePath.Enabled = manual;
            buttonSummarySelect.Enabled = manual;

            labelSummaryPrompt.Enabled = !manual;
            linkLabelSummaryCacheDir.Enabled = !manual;
            textBoxSummaryPrompt.Enabled = !manual;            
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

        private void radioButtonManualSelect_CheckedChanged(object sender, EventArgs e)
        {
            ChangeSummaryControlState();
        }

        private void buttonSummarySelect_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "All Supported Formats|*.txt;";

            openFileDialog.FileName = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxSummaryFilePath.Text = openFileDialog.FileName;
            }
        }

        private void textBoxSummaryPrompt_TextChanged(object sender, EventArgs e)
        {
            textBoxSummaryPrompt.ScrollBars = textBoxSummaryPrompt.Lines.Length > 7 ? ScrollBars.Vertical : ScrollBars.None;
        }

        private void linkLabelSummaryCacheDir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string cacheDir = Path.Combine(_mtGeneralSettings.DataDir, "Cache", "Summary");

                if (!Directory.Exists(cacheDir))
                {
                    Directory.CreateDirectory(cacheDir);
                }

                Process.Start(cacheDir);
            }
            catch
            {
                MessageBox.Show(LLH.G(LLK.OpenLogDirFailMsg), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void PromptPlaceholders_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _llmSettings.GlossaryDelimiter = textBoxGlossaryDelimiter.Text;
                _llmSettings.GlossaryFilePath = textBoxGlossaryFilePath.Text;

                _llmSettings.SummaryAutoGenerate = radioButtonAutoGenerate.Checked;
                _llmSettings.SummaryFilePath = textBoxSummaryFilePath.Text;
                _llmSettings.SummaryGeneratePrompt = textBoxSummaryPrompt.Text;

                _llmSettings.AboveTextIncludeSource = checkBoxAboveTextIncludeSource.Checked;
                _llmSettings.AboveTextIncludeTarget = checkBoxAboveTextIncludeTarget.Checked;
                _llmSettings.AboveTextMaxSegments = (int)numericUpDownAboveTextMaxSegments.Value;
                _llmSettings.AboveTextMaxCharacters = (int)numericUpDownAboveTextMaxCharacters.Value;

                _llmSettings.BelowTextIncludeSource = checkBoxBelowTextIncludeSource.Checked;
                _llmSettings.BelowTextIncludeTarget = checkBoxBelowTextIncludeTarget.Checked;
                _llmSettings.BelowTextMaxSegments = (int)numericUpDownBelowTextMaxSegments.Value;
                _llmSettings.BelowTextMaxCharacters = (int)numericUpDownBelowTextMaxCharacters.Value;
            }
        }
    }

    class PromptPlaceholdersLocalizedKey : LocalizedKeyBase
    {
        public PromptPlaceholdersLocalizedKey(string name) : base(name)
        {
        }

        static PromptPlaceholdersLocalizedKey()
        {
            AutoInit<PromptPlaceholdersLocalizedKey>();
        }

        [LocalizedValue("dc890482-dc4d-4b0e-9116-0fab38646663", "Prompt Placeholder (Shared by all LLM providers)", "提示词占位符（所有 LLM 提供商共用）")]
        public static PromptPlaceholdersLocalizedKey Form { get; private set; }

        [LocalizedValue("af774b33-337b-430b-be72-4c1371cde1db", "{{{{glossary-text}}}}", "术语：{{{{glossary-text}}}}")]
        public static PromptPlaceholdersLocalizedKey GroupBoxGlossaryText { get; private set; }

        [LocalizedValue("1714ce05-0aa7-4ade-bb5a-c0864fd36609", "File Path", "文件路径")]
        public static PromptPlaceholdersLocalizedKey LabelGlossaryFilePath { get; private set; }

        [LocalizedValue("af7c654d-f637-411b-8ca6-44716bbce5dc", "Select", "选择")]
        public static PromptPlaceholdersLocalizedKey ButtonGlossarySelect { get; private set; }

        [LocalizedValue("b03e7fc0-8820-4d4f-9cbf-28b3ac7c6077", "Delimiter", "分割符")]
        public static PromptPlaceholdersLocalizedKey LabelGlossaryDelimiter { get; private set; }

        [LocalizedValue("c9caf220-5b0a-4706-8501-b5df7387eca3", "Encoding", "文件编码")]
        public static PromptPlaceholdersLocalizedKey LabelGlossaryEncoding { get; private set; }

        [LocalizedValue("d3c0c4e6-8f79-48e5-8880-4fa057ff8f09", "{{{{summary-text}}}}", "摘要：{{{{summary-text}}}}")]
        public static PromptPlaceholdersLocalizedKey GroupBoxSummaryText { get; private set; }

        [LocalizedValue("a3836daa-4ec9-44a9-92af-284d8e1123bc", "Source Type", "来源方式")]
        public static PromptPlaceholdersLocalizedKey LabelSummaryType { get; private set; }

        [LocalizedValue("1ee04bd7-0d3a-4f02-badf-5788b3b875eb", "Manual select", "手动选择")]
        public static PromptPlaceholdersLocalizedKey RadioButtonManualSelect { get; private set; }

        [LocalizedValue("45223ec4-cb6d-4d51-a235-62c0f91988cc", "Auto generate", "自动生成")]
        public static PromptPlaceholdersLocalizedKey RadioButtonAutoGenerate { get; private set; }

        [LocalizedValue("5d35c198-fbae-4d50-8a36-97d47e865363", "File Path", "文件路径")]
        public static PromptPlaceholdersLocalizedKey LabelSummaryFilePath { get; private set; }

        [LocalizedValue("50e88bbf-dcec-4d81-ba2b-6aa8edb0f9fe", "Select", "选择")]
        public static PromptPlaceholdersLocalizedKey ButtonSummarySelect { get; private set; }

        [LocalizedValue("57c3e8b8-3800-404d-ad13-637a8b9c56d8", "Prompt", "生成提示词")]
        public static PromptPlaceholdersLocalizedKey LabelSummaryPrompt { get; private set; }

        [LocalizedValue("7d36b8c4-ee41-4d01-80d4-51b01d7eaa2c", "Cache Dir ?", "缓存目录？")]
        public static PromptPlaceholdersLocalizedKey LinkLabelSummaryCacheDir { get; private set; }

        [LocalizedValue("520f5894-cb1f-4ffc-b7ea-83be36ed7373", "{{{{above-text}}}}", "上文：{{{{above-text}}}}")]
        public static PromptPlaceholdersLocalizedKey GroupBoxAboveText { get; private set; }

        [LocalizedValue("e5a7c5c9-4772-4aaf-86b7-f6ae27375ff4", "Includ Source", "包括原文")]
        public static PromptPlaceholdersLocalizedKey LabelAboveTextIncludeSource { get; private set; }

        [LocalizedValue("ed594127-f2a5-4a22-88be-1638e8725dc2", "Include Target", "包括译文")]
        public static PromptPlaceholdersLocalizedKey LabelAboveTextIncludeTarget { get; private set; }

        [LocalizedValue("c47bf709-ba53-4f7a-8a25-0c77ad922dec", "Max Segments", "最大句段数")]
        public static PromptPlaceholdersLocalizedKey LabelAboveTextMaxSegments { get; private set; }

        [LocalizedValue("bd5c9add-e199-4a53-9c03-bd4b6736e7a4", "Max Characters", "最大字符数")]
        public static PromptPlaceholdersLocalizedKey LabelAboveTextMaxCharacters { get; private set; }

        [LocalizedValue("c29b5bee-c48a-482f-b2bc-9486afa36267", "{{{{below-text}}}}", "下文：{{{{below-text}}}}")]
        public static PromptPlaceholdersLocalizedKey GroupBoxBelowText { get; private set; }

        [LocalizedValue("88b2e066-c5cc-436d-8ec1-57b392fe85dd", "Includ Source", "包括原文")]
        public static PromptPlaceholdersLocalizedKey LabelBelowTextIncludeSource { get; private set; }

        [LocalizedValue("c0bf0d0b-05e5-430e-a326-701abc022381", "Include Target", "包括译文")]
        public static PromptPlaceholdersLocalizedKey LabelBelowTextIncludeTarget { get; private set; }

        [LocalizedValue("91fe8e98-6335-4f08-99b6-36275e0d8a6e", "Max Segments", "最大句段数")]
        public static PromptPlaceholdersLocalizedKey LabelBelowTextMaxSegments { get; private set; }

        [LocalizedValue("ef12b4d4-8c60-42ed-a805-6bab80fcc5f1", "Max Characters", "最大字符数")]
        public static PromptPlaceholdersLocalizedKey LabelBelowTextMaxCharacters { get; private set; }

        [LocalizedValue("8d801472-2544-4098-91cf-2b9e6fdffca4", "\r\nBut if both are zero, the result will be empty", "\r\n但两者同时为零会得到空")]
        public static PromptPlaceholdersLocalizedKey BothZeroResultEmpty { get; private set; }

        [LocalizedValue("3b3a66db-7043-4421-a878-4b105410bc25", "Dir cteate or open fail", "目录创建或打开失败")]
        public static PromptPlaceholdersLocalizedKey OpenLogDirFailMsg { get; private set; }
    }
}
