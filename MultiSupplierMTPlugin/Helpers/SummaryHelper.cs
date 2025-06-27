using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.ProvidersCommon.Options.LLM;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Helpers
{
    class SummaryHelper
    {
        private static readonly object _lockObj = new object();

        private static readonly ConcurrentDictionary <string, string> _summaryCache = new ConcurrentDictionary<string, string>();

        public static string ReadFromFile(string filePath)
        {
            string key = GetKey(filePath); // 文件不存在会抛异常

            if (_summaryCache.TryGetValue(key, out string cachedResult))
            {
                LoggingHelper.Info($"Summary load from memory");

                return cachedResult;
            }

            string summary;
            try
            {
                summary = File.ReadAllText(filePath); // 文件打不开会抛异常
            }
            catch
            {
                throw new Exception($"summary file read fail：{filePath}");
            }

            LoggingHelper.Info($"Summary load from disk");

            _summaryCache[key] = summary;

            return summary;
        }

        public static bool TryReadFromFile(string projectGuid, string documentGuid, string srcLang, string tgtLang, out string summary)
        {
            string filePath = GetCacheFilePath(projectGuid, documentGuid, srcLang, tgtLang);
            try
            {
                summary = ReadFromFile(filePath);
                return true;
            }
            catch
            { 
                summary = null;
                return false;
            }
        }

        public static string ReadFromCacheOrGenerate(string projectGuid, string documentGuid, string srcLang, string tgtLang,
            MultiSupplierMTOptions mtOptions, ProviderOptions providerCloneOptions, MultiSupplierMTService service,
            List<string> texts, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData)
        {
            if (TryReadFromFile(projectGuid, documentGuid, srcLang, tgtLang, out var summaryInCache))
            {
                return summaryInCache;
            }

            lock (_lockObj)
            {
                if (TryReadFromFile(projectGuid, documentGuid, srcLang, tgtLang, out var summaryInCache2))
                {
                    return summaryInCache2;
                }

                providerCloneOptions = providerCloneOptions.Clone();
                
                var bSettings = providerCloneOptions.GeneralSettings as LLMBaseGeneralSettings;

                var summaryGeneratePrompt = mtOptions.GeneralSettings.LLMCommon.SummaryGeneratePrompt;

                bSettings.EnableBathTranslate = false;
                bSettings.PromptTemplateId = "";

                bSettings.SystemPrompt = "You are a helpful AI designed for generating text summaries.";
                bSettings.UserPrompt = summaryGeneratePrompt.Replace("{{summary-text}}", "").Replace("{{summary-text!}}", "");                

                string summary = Task.Run(async () =>
                {
                    return await service.TranslateAsync(texts, srcLang, tgtLang, tmSources, tmTargets, metaData, new CancellationToken(), providerCloneOptions);
                }).GetAwaiter().GetResult()[0];

                string filePath = GetCacheFilePath(projectGuid, documentGuid, srcLang, tgtLang);

                string dir = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                LoggingHelper.Info($"Summary auto generate");

                File.WriteAllText(filePath, summary);

                _summaryCache[GetKey(filePath)] = summary;

                return summary;
            }
        }

        private static string GetKey(string filePath)
        {
            string modificationTime;

            try
            {
                modificationTime = File.GetLastWriteTimeUtc(filePath).ToString("o");
            }
            catch
            {
                throw new Exception($"summary file does not exist：{filePath}");
            }

            return $"{filePath}|{modificationTime}";
        }

        private static string GetCacheFilePath(string projectGuid, string documentGuid, string srcLang, string tgtLang)
        {
            string cacheDir = Path.Combine(OptionsHelper.MtOption.GeneralSettings.DataDir, "Cache", "Summary");
            string docName = ContextHelper.Instance.GetDocName(projectGuid, documentGuid, srcLang, tgtLang);
            string fileName = $"[summary]-[{docName}]-[{documentGuid}].txt"; // 暂时用不到 projectGuid, srcLang, tgtLang

            return Path.Combine(cacheDir, fileName);
        }
    }
}
