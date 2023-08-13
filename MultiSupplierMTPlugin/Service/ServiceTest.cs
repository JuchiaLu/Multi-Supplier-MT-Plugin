//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using MemoQ.MTInterfaces;

//namespace MultiSupplierMTPlugin.Service
//{
//    public class ServiceTest : MultiSupplierMTServiceInterface
//    {
//        public override MultiSupplierMTOptions ShowConfig(MultiSupplierMTOptions options, IEnvironment environment, IWin32Window parentForm)
//        {
//            return options;
//        }

//        public override bool IsAvailable(MultiSupplierMTOptions options)
//        {
//            return true;
//        }

//        public override bool IsLanguagePairSupported(string srcLangCode, string trgLangCode)
//        {
//            return true;
//        }

//        public override int MaxBatchSize()
//        {
//            return 10;
//        }

//        public override int MaxQueriesPerSecond()
//        {
//            return 10;
//        }

//        public override int MaxThreadHold()
//        {
//            return 10;
//        }

//        public override string UniqueName()
//        {
//            return "Test";
//        }

//        public override async Task<List<string>> BatchTranslate(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode,  List<string> tmSources,  List<string> tmTargets, MTRequestMetadata metaData)
//        {
//            List<string> result = new List<string>();

//            int i = 1;
//            foreach (var text in texts)
//            {
//                string translation = string.Format("{0} {1}->{2}: {3}", i.ToString(), srcLangCode, trgLangCode, text);

//                result.Add(translation);

//                i++;
//            }
//            return result;
//        }
//    }
//}
