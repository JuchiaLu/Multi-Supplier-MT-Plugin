using MultiSupplierMTPlugin.Localized;

namespace MultiSupplierMTPlugin.Providers.Niutrans
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

        [LocalizedValue("8ca6b805-41fe-4830-8d5b-e16673d712b5", "Niutrans", "小牛")]
        public static LocalizedKey Form { get; private set; }

        [LocalizedValue("8cd43629-c5ba-4cba-8949-2c7824e246df", "Api Key", "Api Key")]
        public static LocalizedKey LinkLabelApikey { get; private set; }

    }
}
