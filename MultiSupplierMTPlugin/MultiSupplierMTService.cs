using MemoQ.MTInterfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin.Services
{
    public abstract class MultiSupplierMTService
    {
        public abstract MultiSupplierMTOptions ShowConfig(MultiSupplierMTOptions options, IEnvironment environment, IWin32Window parentForm);

        public abstract bool IsAvailable(MultiSupplierMTOptions options);

        public abstract bool IsLanguagePairSupported(string srcLangCode, string trgLangCode);


        public abstract bool IsBatchSupported();

        public abstract bool IsXmlSupported();

        public abstract bool IsHtmlSupported();

        public abstract bool IsBuiltIn();


        public abstract int MaxBatchSize();


        public abstract int MaxQueriesPerWindow();

        public abstract int WindowSizeMs();

        public abstract double Smoothness();


        public abstract int MaxThreadHold();


        public abstract int FailedTimeoutMs();

        public abstract int RetryWaitingMs();

        public abstract int NumberOfRetries();


        public abstract string UniqueName();

        public abstract Task<List<string>> TranslateAsync(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken);
    }
}
