namespace MultiSupplierMTPlugin.Helpers
{
    class OptionsHelper
    {
        public static void Init(MultiSupplierMTOptions option)
        {
            MtOption = option;
        }

        public static MultiSupplierMTOptions MtOption { get; private set; }

        public static void SetProviderOptions(string name, ProviderOptions option)
        { 
            MtOption.SetProviderOptions(name, option);
        }

        public static ProviderOptions GetProviderOptionsOrNull(string name) 
        {
            return MtOption.GetProviderOptionsOrNull(name);
        }
    }
}
