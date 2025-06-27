using System.Collections.Generic;

namespace MultiSupplierMTPlugin.Providers.OpenAI
{
    class SupportLang
    {
        public static readonly Dictionary<string, string> Dic = new Dictionary<string, string>
        {
            {"zho-CN", "Chinese (Simplified)"},
            {"zho-TW", "Chinese (Traditional)"},
            {"eng", "English"},
            {"jpn", "Japanese"},
            {"kor", "Korean"},
            {"fre", "French"},
            {"spa", "Spanish"},
            {"rus", "Russian"},
            {"ger", "German"},
            {"ita", "Italian"},
            {"tur", "Turkish"},
            {"por-PT", "Portuguese (Portugal, Brazil)"},
            {"por", "Portuguese"},
            {"vie", "Vietnamese"},
            {"ind", "Indonesian"},
            {"tha", "Thai"},
            {"msa", "Malay"},
            {"ara", "Arabic"},
            {"hin", "Hindi"},
        };
    }
}
