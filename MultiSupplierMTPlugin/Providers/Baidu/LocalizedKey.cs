using MultiSupplierMTPlugin.Localized;

namespace MultiSupplierMTPlugin.Providers.Baidu
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

        [LocalizedValue("02dbdf25-02a9-4cd3-8a8e-d54290fa2fe6", "Baidu", "百度")]
        public static LocalizedKey Form { get; private set; }

        [LocalizedValue("362f169d-dc50-42d4-bb28-e54ced53ea5b", "App Id", "App Id")]
        public static LocalizedKey LabelAppId { get; private set; }

        [LocalizedValue("865a1c4e-4701-47d3-9b26-f88a76c8bc02", "App Key", "App Key")]
        public static LocalizedKey LinkLabelAppKey { get; private set; }
    }
}
