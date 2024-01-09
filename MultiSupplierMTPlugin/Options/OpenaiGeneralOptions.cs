
namespace MultiSupplierMTPlugin.Options
{
    public class OpenaiGeneralOptions
    {
        public bool Checked = false;

        public string Model = "gpt-3.5-turbo";

        // https://opeanai-resource.openai.azure.com/openai/deployments/deployedEngine/{1}?api-version={0}
        // https://opeanai-resource.openai.azure.com/openai/deployments/gpt-35-turbo/chat/completions?api-version=2023-05-15
        public string BaseURL = "https://api.openai.com";

        public string Path = "/v1/chat/completions";

        public string Prompt = "Please translate the given text from <srcLang> to <tgtLang>. The \"<inline_tag id=\"0\">\" and \"<span data-mqitag=\"0\">\" in the text are special tags, please do not translate them, and place them in the correct positions during translation.";

        public double temperature = 1.0;
    }
}
