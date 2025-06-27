using MultiSupplierMTPlugin.Localized;

namespace MultiSupplierMTPlugin.Providers.Xunfei
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

        [LocalizedValue("a89e15a0-c08f-47a0-a517-be32d5200068", "Xunfei", "讯飞")]
        public static LocalizedKey Form { get; private set; }

        [LocalizedValue("099c2f58-da48-48b4-af32-91e172fc0709", "Api Id", "Api Id")]
        public static LocalizedKey LabelApiId { get; private set; }

        [LocalizedValue("9a1ae0fa-1be3-4cf9-95d2-7d4f1337d2d4", "Api Key", "Api Key")]
        public static LocalizedKey LabelApiKey { get; private set; }

        [LocalizedValue("ff38c851-5663-4b7d-8c85-4bea0ce0b058", "Api Secret", "Api Secret")]
        public static LocalizedKey LinkLabelApiSecret { get; private set; }
    }
}
