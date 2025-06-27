using MultiSupplierMTPlugin.Localized;

namespace MultiSupplierMTPlugin.Providers.Youdao
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

        [LocalizedValue("65cfa610-5c9e-4fc0-acc9-e67e271adbcb", "Youdao", "有道")]
        public static LocalizedKey Form { get; private set; }

        [LocalizedValue("4dcdcb0b-f653-4349-b9af-7314712da29c", "App Key", "App Key")]
        public static LocalizedKey LabelAppKey { get; private set; }

        [LocalizedValue("ae384aee-4b30-4544-a587-c3669e8dddae", "App Secret", "App Secret")]
        public static LocalizedKey LinkLabelAppSecret { get; private set; }
    }
}
