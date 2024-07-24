
namespace MultiSupplierMTPlugin.Options
{
    public class OpenaiGeneralOptions
    {
        public bool Checked = false;

        public string BaseURL = "https://api.openai.com";

        public string Path = "/v1/chat/completions";

        public string Model = "gpt-3.5-turbo";

        public double temperature = 1.0;

        public string Prompt = "You are a professional translator. Please translate the text from <srcLang> to <tgtLang>. The text may contain special formatting elements such as <inline_tag id=\"0\"> and <span data-mqitag=\"0\">, where the id and data-mqitag attribute values are variable. Do not translate these special formatting elements, and place them in the appropriate positions in the translated text.";
    }

    public class OpenaiSecureOptions
    {
        public string ApiKey = string.Empty;

        public string Organization = string.Empty;
    }
}
