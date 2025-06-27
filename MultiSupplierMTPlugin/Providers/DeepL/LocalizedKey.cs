using MultiSupplierMTPlugin.Localized;

namespace MultiSupplierMTPlugin.Providers.DeepL
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

        [LocalizedValue("f576e989-e60d-4329-8cb6-b1e65c4805ed", "DeepL", "DeepL")]
        public static LocalizedKey DeepL { get; private set; }

        [LocalizedValue("e680baf5-c6b6-4836-a345-63b45d340194", "Server", "Server")]
        public static LocalizedKey LabelServer { get; private set; }

        [LocalizedValue("6c9bfb0c-79d1-495a-8a47-8530cc41059d", "Auth Key", "Auth Key")]
        public static LocalizedKey LinkLabelAuthKey { get; private set; }

        [LocalizedValue("b5cf37e3-0009-490a-80d4-5b0f227602f8", "Glossary Id", "Glossary Id")]
        public static LocalizedKey LabelGlossaryId { get; private set; }
    }
}
