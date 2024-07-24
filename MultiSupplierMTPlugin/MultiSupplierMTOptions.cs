using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Options;
using System;
using System.IO;

namespace MultiSupplierMTPlugin
{
    public class MultiSupplierMTOptions : PluginSettingsObject<MultiSupplierMTGeneralOptions, MultiSupplierMTSecureOptions>
    {
        public MultiSupplierMTOptions(PluginSettings serializedSettings) : base(serializedSettings)
        {

        }

        public MultiSupplierMTOptions(MultiSupplierMTGeneralOptions generalOptions, MultiSupplierMTSecureOptions secureOptions) : base(generalOptions, secureOptions)
        {

        }
    }

    public enum RequestType
    {
        Plaintext = 0,
        OnlyFormattingWithXml = 1,
        OnlyFormattingWithHtml = 2,
        BothFormattingAndTagsWithXml = 3,
        BothFormattingAndTagsWithHtml = 4,
    }

    public class MultiSupplierMTGeneralOptions
    {
        public string DataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MemoQ", "Plugins", "MultiSupplierMTPlugin");

        public string CurrentServiceProvider = "MicrosoftBuiltIn";
        public RequestType RequestType = RequestType.Plaintext;

        public bool InsertRequiredTagsToEnd = false;
        public bool NormalizeWhitespaceAroundTags = false;

        public bool EnableCustomRequestLimit = false;
        public int MaxSegmentsPerRequest = 1;
        public int WindowSizeMs = 1000;
        public int MaxRequestsPerWindow = 1;
        public double RequestSmoothness = 1.0;
        public int MaxRequestsHold = 1;
        public int FailedTimeoutMs = 0;
        public int RetryWaitingMs = 0;
        public int NumberOfRetries = 0;

        public bool EnableCustomDisplayName = false;
        public string CustomDisplayName = string.Empty;

        public bool EnableCache = true;

        public bool EnableStatsAndLog = true;

        public BaiduGeneralOptions BaiduGeneralOptions = new BaiduGeneralOptions();

        public TencentGeneralOptions TencentGeneralOptions = new TencentGeneralOptions();

        public AliyunGeneralOptions AliyunGeneralOptions = new AliyunGeneralOptions();

        public HuoshanGeneralOptions HuoshanGeneralOptions = new HuoshanGeneralOptions();

        public CaiyunGeneralOptions CaiyunGeneralOptions = new CaiyunGeneralOptions();

        public NiutransGeneralOptions NiutransGeneralOptions = new NiutransGeneralOptions();

        public YoudaoGeneralOptions YoudaoGeneralOptions = new YoudaoGeneralOptions();

        public XunfeiGeneralOptions XunfeiGeneralOptions = new XunfeiGeneralOptions();

        public OpenaiGeneralOptions OpenaiGeneralOptions = new OpenaiGeneralOptions();

        public PapagoGeneralOptions PapagoGeneralOptions = new PapagoGeneralOptions();
    }

    public class MultiSupplierMTSecureOptions
    {
        public BaiduSecureOptions BaiduSecureOptions = new BaiduSecureOptions();

        public TencentSecureOptions TencentSecureOptions = new TencentSecureOptions();

        public AliyunSecureOptions AliyunSecureOptions = new AliyunSecureOptions();

        public HuoshanSecureOptions HuoshanSecureOptions = new HuoshanSecureOptions();

        public CaiyunSecureOptions CaiyunSecureOptions = new CaiyunSecureOptions();

        public NiutransSecureOptions NiutransSecureOptions = new NiutransSecureOptions();

        public YoudaoSecureOptions YoudaoSecureOptions = new YoudaoSecureOptions();

        public XunfeiSecureOptions XunfeiSecureOptions = new XunfeiSecureOptions();

        public OpenaiSecureOptions OpenaiSecureOptions = new OpenaiSecureOptions();

        public PapagoSecureOptions PapagoSecureOptions = new PapagoSecureOptions();
    }
}
