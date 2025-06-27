using MultiSupplierMTPlugin.Localized;

namespace MultiSupplierMTPlugin.Providers.Caiyun
{
    class LocalizedKey : LocalizedKeyBase
    {
        public LocalizedKey(string name) : base(name)
        {
        }

        static LocalizedKey()
        {
            AutoInit<LocalizedKey>();
        }


        [LocalizedValue("9141043a-d8df-4ca0-95aa-a941c7fcff03", "Caiyun", "彩云")]
        public static LocalizedKey Form { get; private set; }

        [LocalizedValue("3907107c-22eb-4572-b41f-1ace9ce191b4", "Token", "Token")]
        public static LocalizedKey LinkLabelToken { get; private set; }
    }
}
