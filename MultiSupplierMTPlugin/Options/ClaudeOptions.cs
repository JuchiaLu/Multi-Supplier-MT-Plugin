
namespace MultiSupplierMTPlugin.Options
{
    public class ClaudeGeneralOptions
    {
        public bool Checked = false;

        public string BaseURL = "https://api.anthropic.com";

        public string Path = "/v1/messages";

        public string Model = "claude-3-5-sonnet-20240620";

        public int MaxTokens = 4096;

        public double Temperature = 1.0;

        public string Prompt = "You are a professional translator. Please translate the text from <srcLang> to <tgtLang>. The text may contain special formatting elements such as <inline_tag id=\"0\"> and <span data-mqitag=\"0\">, where the id and data-mqitag attribute values are variable. Do not translate these special formatting elements, and place them in the appropriate positions in the translated text.";
    }

    public class ClaudeSecureOptions
    {
        public string XApiKey = string.Empty;
    }
}
