using MemoQ.MTInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin
{
    public abstract class MultiSupplierMTServiceInterface
    {
        public abstract MultiSupplierMTOptions ShowConfig(MultiSupplierMTOptions options, IEnvironment environment, IWin32Window parentForm);

        public abstract bool IsAvailable(MultiSupplierMTOptions options);

        public abstract bool IsLanguagePairSupported(string srcLangCode, string trgLangCode);

        public abstract int MaxBatchSize();

        public abstract int MaxQueriesPerSecond();

        public abstract int MaxThreadHold();

        public abstract string UniqueName();

        public abstract Task<List<string>> BatchTranslate(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData);
    }
}
