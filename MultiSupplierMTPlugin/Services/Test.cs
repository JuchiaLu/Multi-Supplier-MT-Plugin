using MemoQ.MTInterfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin.Services
{
    public class Test : MultiSupplierMTService
    {
        public override MultiSupplierMTOptions ShowConfig(MultiSupplierMTOptions options, IEnvironment environment, IWin32Window parentForm)
        {
            return options;
        }

        public override bool IsAvailable(MultiSupplierMTOptions options)
        {
            return true;
        }

        public override bool IsLanguagePairSupported(string srcLangCode, string trgLangCode)
        {
            return true;
        }

        public override bool IsBatchSupported()
        {
            return true;
        }

        public override bool IsXmlSupported()
        {
            return true;
        }

        public override bool IsHtmlSupported()
        {
            return true;
        }

        public override bool IsBuiltIn()
        {
            return true;
        }

        public override int MaxBatchSize()
        {
            return 10;
        }

        public override int MaxQueriesPerWindow()
        {
            return 50;
        }

        public override int WindowSizeMs()
        {
            return 1000;
        }

        public override double Smoothness()
        {
            return 1.0;
        }

        public override int MaxThreadHold()
        {
            return 50;
        }

        public override int FailedTimeoutMs()
        {
            return 0;
        }

        public override int RetryWaitingMs()
        {
            return 0;
        }

        public override int NumberOfRetries()
        {
            return 0;
        }

        public override string UniqueName()
        {
            return "TestBuiltIn";
        }

        public override async Task<List<string>> TranslateAsync(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken)
        {
            List<string> result = new List<string>();

            var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            int i = 1;
            foreach (var text in texts)
            {
                string translated = $"DateTime: {now}, order: {i}, srcLang: {srcLangCode}, trgLang: {trgLangCode}, text: {text}";

                result.Add(translated);

                i++;
            }
            return result;
        }
    }
}
