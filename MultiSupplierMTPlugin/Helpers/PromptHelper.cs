using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.ProvidersCommon.Options.LLM;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.Helpers
{
    class PromptHelper 
    {
        private const string _GLOSSARY_TEXT_KEY = "glossary-text";

        private const string _SOURCE_LANGUAGE_KEY = "source-language";

        private const string _TARGET_LANGUAGE_KEY = "target-language";

        private const string _SOURCE_TEXT_KEY = "source-text";

        private const string _TARGET_TEXT_KEY = "target-text";

        private const string _TM_SOURCE_TEXT_KEY = "tm-source-text";

        private const string _TM_TARGET_TEXT_KEY = "tm-target-text";

        private const string _FULL_TEXT_KEY = "full-text";

        private const string _SUAMMARY_TEXT_KEY = "summary-text";

        private const string _ABOVE_TEXT_KEY = "above-text";

        private const string _BELOW_TEXT_KEY = "below-text";

        private static readonly HashSet<string> _KNOWN_PLACEHOLDER_NAMES = new HashSet<string>() 
        { 
            _GLOSSARY_TEXT_KEY, 
            _SOURCE_LANGUAGE_KEY, _TARGET_LANGUAGE_KEY,
            _SOURCE_TEXT_KEY, _TARGET_TEXT_KEY,
            _TM_SOURCE_TEXT_KEY, _TM_TARGET_TEXT_KEY,
            _FULL_TEXT_KEY, _SUAMMARY_TEXT_KEY,
            _ABOVE_TEXT_KEY, _BELOW_TEXT_KEY
        };

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        public static ContextMenuStrip CreateTextBoxContextMenu()
        {
            var menu = new ContextMenuStrip();

            void Add(string text, Action<TextBoxBase> action)
            {
                var item = new ToolStripMenuItem(text);
                item.Click += (s, e) =>
                {
                    if (menu.SourceControl is TextBoxBase tb)
                        action(tb);
                };
                menu.Items.Add(item);
            }

            void Insert(string label, string text) =>
                Add(label, tb =>
                {
                    if (!tb.Focused) tb.Focus();
                    int EM_REPLACESEL = 0x00C2;
                    SendMessage(tb.Handle, EM_REPLACESEL, (IntPtr)1, text);
                });

            void AddSeparator() => menu.Items.Add(new ToolStripSeparator());

            string Build(string name, bool noEmpty)
            {
                var no = noEmpty ? "!" : "";
                return "{{" + name + no + "}}";
            }

            Insert(LLH.G(LLKC.TextBoxPromptMenu_SourceLanguage), Build(_SOURCE_LANGUAGE_KEY, true));
            Insert(LLH.G(LLKC.TextBoxPromptMenu_TargetLanguage), Build(_TARGET_LANGUAGE_KEY, true));
            AddSeparator();
            Insert(LLH.G(LLKC.TextBoxPromptMenu_SourceText), Build(_SOURCE_TEXT_KEY, true));
            Insert(LLH.G(LLKC.TextBoxPromptMenu_TargetText), Build(_TARGET_TEXT_KEY, true));
            AddSeparator();
            Insert(LLH.G(LLKC.TextBoxPromptMenu_TmSourceText), Build(_TM_SOURCE_TEXT_KEY, false));
            Insert(LLH.G(LLKC.TextBoxPromptMenu_TmTargetText), Build(_TM_TARGET_TEXT_KEY, false));
            AddSeparator();
            Insert(LLH.G(LLKC.TextBoxPromptMenu_AboveText), Build(_ABOVE_TEXT_KEY, false));
            Insert(LLH.G(LLKC.TextBoxPromptMenu_BelowText), Build(_BELOW_TEXT_KEY, false));
            AddSeparator();
            Insert(LLH.G(LLKC.TextBoxPromptMenu_SuammaryText), Build(_SUAMMARY_TEXT_KEY, true));
            Insert(LLH.G(LLKC.TextBoxPromptMenu_FullText), Build(_FULL_TEXT_KEY, true));
            AddSeparator();
            Insert(LLH.G(LLKC.TextBoxPromptMenu_GlossaryText), Build(_GLOSSARY_TEXT_KEY, true));

            return menu;
        }

        


        public static (string, string)  Parse(
            string systemPrompt, string userPrompt,

            MultiSupplierMTOptions mtOptions,
            
            ProviderOptions providerOptions,           
            Dictionary<string, string> supportLanguages,
            MultiSupplierMTService service,

            List<string> texts, 
            string srcLang, string tgtLang,
            List<string> tmSources, List<string> tmTargets,
            MTRequestMetadata metaData
            )
        {
            // 解决 xml 反序列化后换行符总是变成 \n
            systemPrompt = systemPrompt.Replace(Environment.NewLine, "\n").Replace("\n", Environment.NewLine); 
            userPrompt = userPrompt.Replace(Environment.NewLine, "\n").Replace("\n", Environment.NewLine);

            var cSettings = mtOptions.GeneralSettings.LLMCommon;
            var bSettings = providerOptions.GeneralSettings as LLMBaseGeneralSettings;            

            var promptBuilder = new PromptBuilder(systemPrompt, userPrompt, _KNOWN_PLACEHOLDER_NAMES);

            // 术语表
            if (promptBuilder.HasPlaceholder(_GLOSSARY_TEXT_KEY))
            {
                var glsFilePath = cSettings.GlossaryFilePath;
                var glsDelimiter = cSettings.GlossaryDelimiter;

                string glossary = GlossaryHelper.ReadGlossary(glsFilePath, srcLang, tgtLang, glsDelimiter, "utf-8", true) ;
                
                promptBuilder.SetPlaceholder(_GLOSSARY_TEXT_KEY, glossary);
            }

            // 源语言
            if (promptBuilder.HasPlaceholder(_SOURCE_LANGUAGE_KEY))
            {
                if (!supportLanguages.ContainsKey(srcLang)) new Exception($"Source language code is not supported: {srcLang}");

                promptBuilder.SetPlaceholder(_SOURCE_LANGUAGE_KEY, supportLanguages[srcLang]);
            }

            // 目标语言
            if (promptBuilder.HasPlaceholder(_TARGET_LANGUAGE_KEY))
            {
                if (!supportLanguages.ContainsKey(tgtLang)) new Exception($"Target language code is not supported: {tgtLang}");

                promptBuilder.SetPlaceholder(_TARGET_LANGUAGE_KEY, supportLanguages[tgtLang]);
            }

            // 源文本
            if (promptBuilder.HasPlaceholder(_SOURCE_TEXT_KEY))
            {
                var sourceText = bSettings.EnableBathTranslate
                        ? BathTranslateHelper.Serialize(bSettings.BathTranslateSchema, texts)
                        : texts[0];

                promptBuilder.SetPlaceholder(_SOURCE_TEXT_KEY, sourceText);
            }

            // 目标文本（目前预览 SDK 获取获取目标文本不带有标签，且有的句段（比如图片名字）无法获取）
            //if (promptBuilder.HasPlaceholder(TARGET_TEXT_KEY))
            //{
            //
            //}

            // 源文本（翻译记忆中保存的）
            if (promptBuilder.HasPlaceholder(_TM_SOURCE_TEXT_KEY))
            {
                if (tmSources == null) throw new Exception($"{_TM_SOURCE_TEXT_KEY} Placeholders require memoQ min version 10.0, and enable \"Send best fuzzy TM\" in memoq settings");
                
                promptBuilder.SetPlaceholder(_TM_SOURCE_TEXT_KEY, tmSources[0]);
            }

            // 目标文本（翻译记忆中保存的）
            if (promptBuilder.HasPlaceholder(_TM_TARGET_TEXT_KEY))
            {
                if (tmTargets == null) throw new Exception($"{_TM_TARGET_TEXT_KEY} Placeholders require memoQ min version 10.0, and enable \"Send best fuzzy TM\" in memoq settings");
                
                promptBuilder.SetPlaceholder(_TM_TARGET_TEXT_KEY, tmTargets[0]);
            }

            if (promptBuilder.HasPlaceholder(_FULL_TEXT_KEY) || promptBuilder.HasPlaceholder(_SUAMMARY_TEXT_KEY) ||
                promptBuilder.HasPlaceholder(_ABOVE_TEXT_KEY) || promptBuilder.HasPlaceholder(_BELOW_TEXT_KEY) || 
                promptBuilder.HasPlaceholder(_TARGET_TEXT_KEY))
            {
                // 全文、摘要、上下文、目标文本需要 memoQ 版本大于 9.14 才能获取到 metaData
                if (metaData == null) throw new Exception($"{_FULL_TEXT_KEY}, {_SUAMMARY_TEXT_KEY}, {_ABOVE_TEXT_KEY}, {_BELOW_TEXT_KEY}, {_TARGET_TEXT_KEY} Placeholders require memoQ min version 9.14");

                var prjGuid = metaData.ProjectGuid.ToString();
                var docGuid = metaData.DocumentID.ToString();

                // 全文文本
                if (promptBuilder.HasPlaceholder(_FULL_TEXT_KEY))
                {
                    string fullText = ContextHelper.Instance.GetFullText(prjGuid, docGuid, srcLang, tgtLang);
                    promptBuilder.SetPlaceholder(_FULL_TEXT_KEY, fullText);
                }

                // 全文摘要
                if (promptBuilder.HasPlaceholder(_SUAMMARY_TEXT_KEY))
                {
                    string summary;

                    if (cSettings.SummaryAutoGenerate)
                    {
                        summary = SummaryHelper.ReadFromCacheOrGenerate(prjGuid, docGuid, srcLang, tgtLang,
                                mtOptions, providerOptions, service, texts, tmSources, tmTargets, metaData);
                    }
                    else
                    {
                        summary = SummaryHelper.ReadFromFile(cSettings.SummaryFilePath);
                    }

                    promptBuilder.SetPlaceholder(_SUAMMARY_TEXT_KEY, summary);
                }

                // 上文、下文、目标文本 需要界面交互
                if (promptBuilder.HasPlaceholder(_ABOVE_TEXT_KEY) || promptBuilder.HasPlaceholder(_BELOW_TEXT_KEY) || promptBuilder.HasPlaceholder(_TARGET_TEXT_KEY))
                {
                    if (texts.Count > 1) throw new Exception("Batch translation or Pre-translation does not support getting above-text, below-text or target-text");

                    var currentIndex = GetSegmIndex(prjGuid, docGuid, srcLang, tgtLang);
                    //LoggingHelper.Log($"Prompt segmIndex: {currentIndex.IndexStart}, {currentIndex.IndexEnd}");

                    if (promptBuilder.HasPlaceholder(_ABOVE_TEXT_KEY))
                    {
                        var aboveMaxSegm = cSettings.AboveTextMaxSegments;
                        var aboveMaxChar = cSettings.AboveTextMaxCharacters;
                        var aboveIncludeSrc = cSettings.AboveTextIncludeSource;
                        var aboveIncludeTgt = cSettings.AboveTextIncludeTarget;

                        string aboveText = ContextHelper.Instance.GetAboveContext(prjGuid, docGuid, srcLang, tgtLang,
                            currentIndex.IndexStart, aboveMaxSegm, aboveMaxChar, aboveIncludeSrc, aboveIncludeTgt);

                        promptBuilder.SetPlaceholder(_ABOVE_TEXT_KEY, aboveText);
                    }

                    if (promptBuilder.HasPlaceholder(_BELOW_TEXT_KEY))
                    {
                        var belowMaxSegm = cSettings.BelowTextMaxSegments;
                        var belowMaxChar = cSettings.BelowTextMaxCharacters;
                        var belowIncludeSrc = cSettings.BelowTextIncludeSource;
                        var belowIncludeTgt = cSettings.BelowTextIncludeTarget;

                        string belowText = ContextHelper.Instance.GetBelowContext(prjGuid, docGuid, srcLang, tgtLang,
                            currentIndex.IndexEnd, belowMaxSegm, belowMaxChar, belowIncludeSrc, belowIncludeTgt);

                        promptBuilder.SetPlaceholder(_BELOW_TEXT_KEY, belowText);
                    }

                    // 目标文本（目前预览 SDK 获取获取目标文本不带有标签，且有的句段（比如图片名字）无法获取）
                    if (promptBuilder.HasPlaceholder(_TARGET_TEXT_KEY))
                    {
                        string targetText = "";
                        for (int i = currentIndex.IndexStart; i <= currentIndex.IndexEnd; i++)
                        {
                            targetText += ContextHelper.Instance.GetTargetText(prjGuid, docGuid, srcLang, tgtLang, i);
                        }

                        promptBuilder.SetPlaceholder(_TARGET_TEXT_KEY, targetText);
                    }
                }
            }

            return promptBuilder.BuildPrompts();
        }


        private static CurrentIndex GetSegmIndex(string prjGuid, string docGuid, string srcLang, string tgtLang)
        {
            var startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            while (true)
            {
                var currentIndex = ContextHelper.Instance.GetCurrentIndex(prjGuid, docGuid, srcLang, tgtLang);
               
                var diff = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - currentIndex.UtcMs;
                if (currentIndex.IndexStart != -1 && currentIndex.IndexEnd != -1 && diff < 1000)
                {
                    ContextHelper.Instance.ResetCurrentIndex(prjGuid, docGuid, srcLang, tgtLang);
                    return currentIndex;
                }

                if (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - startTime > 3000)
                {
                    throw new Exception("Gets the current segment index timeout. Try reactivates the current segment");
                }

                Thread.Sleep(50);
            }
        }
    }

    class PromptBuilder
    {
        private string _systemPrompt;

        private string _userPrompt;

        private List<Placeholder> _systemPlaceholders;

        private List<Placeholder> _userPlaceholders;

        private HashSet<string> _knownPlaceholderNames;

        private Dictionary<string, string> _placeholderReplacementDic = new Dictionary<string, string>();

        private static readonly Regex _placeholderRegex = new Regex(@"(\[(?:.)*?\])?{{([\w\-]+)(!)?}}(\[(?:.)*?\])?", RegexOptions.Singleline);


        public PromptBuilder(string systemPrompt, string userPrompt, HashSet<string> knownPlaceholderNames)
        {
            this._systemPrompt = systemPrompt;
            this._userPrompt = userPrompt;

            this._knownPlaceholderNames = knownPlaceholderNames;

            this._systemPlaceholders = GetPlaceholders(systemPrompt, true);
            this._userPlaceholders = GetPlaceholders(userPrompt, false);
        }


        public bool HasPlaceholder(string name)
        {
            foreach (var plhd in _systemPlaceholders)
            {
                if(plhd.Name.Equals(name)) return true;
            }

            foreach (var plhd in _userPlaceholders)
            {
                if (plhd.Name.Equals(name)) return true;
            }

            return false;
        }

        public void SetPlaceholder(string name, string replacement)
        {
            if (string.IsNullOrWhiteSpace(replacement))
            {
                foreach (var plhd in _systemPlaceholders)
                {
                    if (plhd.Name.Equals(name) && plhd.NoWhiteSpace) throw new Exception($"placeholder '{{{name}!}}' has an white space value.");
                }

                foreach (var plhd in _userPlaceholders)
                {
                    if (plhd.Name.Equals(name) && plhd.NoWhiteSpace) throw new Exception($"placeholder '{{{name}!}}' has an white space value.");
                }
            }

            _placeholderReplacementDic[name] = replacement;
        }

        public (string, string) BuildPrompts()
        { 
            return (BuildSystemPrompt(), BuildUserPrompt());
        }

        public string BuildSystemPrompt()
        {
            return Build(_systemPrompt, _systemPlaceholders);
        }

        public string BuildUserPrompt()
        {
            return Build(_userPrompt, _userPlaceholders);
        }


        private List<Placeholder> GetPlaceholders(string prompt, bool isSystem)
        {
            var placeholders = new List<Placeholder>();

            var matches = _placeholderRegex.Matches(prompt);
            for (int i = 0; i < matches.Count; i++)
            {
                var match = matches[i];
                var plhd = new Placeholder()
                {
                    Leading = match.Groups[1].Success ? match.Groups[1].Value.Trim('[', ']') : string.Empty,
                    Name = match.Groups[2].Value,
                    NoWhiteSpace = match.Groups[3].Success,
                    Trailing = match.Groups[4].Success ? match.Groups[4].Value.Trim('[', ']') : string.Empty,
                    Position = match.Index,
                    Length = match.Length,
                    IsSystem = isSystem
                };

                if(_knownPlaceholderNames.Contains(plhd.Name)) placeholders.Add(plhd);
            }

            return placeholders;
        }

        private string Build(string prompt, List<Placeholder> placeholders)
        {
            var result = new StringBuilder(prompt);

            for (int i = placeholders.Count - 1; i >= 0; i--)
            {
                string leading = placeholders[i].Leading;
                string name = placeholders[i].Name;
                bool noWhiteSpace = placeholders[i].NoWhiteSpace;
                string trailing = placeholders[i].Trailing;
                int position = placeholders[i].Position;
                int length = placeholders[i].Length;

                if (_placeholderReplacementDic.TryGetValue(name, out string replacement))
                {
                    if (string.IsNullOrWhiteSpace(replacement))
                    {
                        result.Remove(position, length);
                    }
                    else
                    {
                        result.Remove(position, length);
                        result.Insert(position, leading + replacement + trailing);
                    }
                }
            }

            return result.ToString();
        }


        private class Placeholder
        {
            public string Leading { get; set; }

            public string Name { get; set; }

            public bool NoWhiteSpace { get; set; }

            public string Trailing { get; set; }

            public int Position { get; set; }

            public int Length { get; set; }

            public bool IsSystem { get; set; }
        }
    }   
}
