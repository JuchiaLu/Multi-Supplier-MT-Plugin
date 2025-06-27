using Newtonsoft.Json;
using System.Collections.Generic;

namespace MultiSupplierMTPlugin.Providers.OpenAI
{
    class ChatCompletionRequest
    {
        [JsonProperty("messages")]
        public Message[] Messages { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        //[JsonProperty("frequency_penalty")]
        //public double FrequencyPenalty { get; set; }

        //[JsonProperty("logit_bias")]
        //public string LogitBias { get; set; }

        [JsonProperty("max_tokens")]
        public int MaxTokens { get; set; }

        //[JsonProperty("n")]
        //public int N { get; set; }

        //[JsonProperty("presence_penalty")]
        //public double PresencePenalty { get; set; }

        [JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
        public ResponseFormat ResponseFormat { get; set; }

        //[JsonProperty("seed")]
        //public int Seed { get; set; }

        //// string / array / null
        //[JsonProperty("stop")]
        //public string[] Stop { get; set; }

        //[JsonProperty("stream")]
        //public bool Stream { get; set; }

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        //[JsonProperty("top_p")]
        //public double TopP { get; set; }

        //[JsonProperty("tools")]
        //public Tool[] Tools { get; set; }

        //[JsonProperty("tool_choice")]
        //public Tool ToolChoice { get; set; }

        //[JsonProperty("user")]
        //public string User { get; set; }
    }


    class ResponseFormat
    {
        [JsonProperty("type")]
        public string Type { get; set; } // text、json_object、json_schema

        [JsonProperty("json_schema", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> JsonSchema { get; set; }
    }


    class Message
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        //[JsonProperty("name")]
        //public string Name { get; set; }
    }

    public enum Role
    {
        //system,
        //user,
        //assistant,
        //tool
    }

    public enum Model
    {
        //gpt-4
        //gpt-4-1106-preview
        //gpt-4-vision-preview
        //gpt-4-32k
        //gpt-3.5-turbo
        //gpt-3.5-turbo-16k
    }

    public enum FinishReason
    {

    }

    class ChatCompletionResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("choices")]
        public Choice[] Choices { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("system_fingerprint")]
        public string SystemFingerprint { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("usage")]
        public Usage Usage { get; set; }
    }

    class Choice
    {
        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("message")]
        public ChoiceMessage Message { get; set; }
    }

    class ChoiceMessage
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("refusal")]
        public string Refusal { get; set; }

        [JsonProperty("tool_calls")]
        public ToolCall[] ToolCalls { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }

    class ToolCall
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("function")]
        public Function Function { get; set; }
    }

    class Function
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("arguments")]
        public string Arguments { get; set; }
    }

    class Usage
    {
        [JsonProperty("completion_tokens")]
        public int CompletionTokens { get; set; }

        [JsonProperty("prompt_tokens")]
        public int PromptTokens { get; set; }

        [JsonProperty("total_tokens")]
        public int TotalTokens { get; set; }

        [JsonProperty("completion_tokens_details ")]
        public CompletionTokensDetails CompletionTokensDetails { get; set; }

        [JsonProperty("prompt_tokens_details")]
        public PromptTokensDetails PromptTokensDetails { get; set; }
    }

    class CompletionTokensDetails
    {
        [JsonProperty("audio_tokens")]
        public int AudioTokens { get; set; }

        [JsonProperty("reasoning_tokens")]
        public int TeasoningTokens { get; set; }
    }

    class PromptTokensDetails
    {
        [JsonProperty("audio_tokens")]
        public int AudioTokens { get; set; }

        [JsonProperty("cached_tokens")]
        public int CachedTokens { get; set; }
    }

    class ChatCompletionChunkResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("choices")]
        public Choice2[] Choices { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("system_fingerprint")]
        public string SystemFingerprint { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }
    }

    class Choice2
    {
        [JsonProperty("delta")]
        public Delta Delta { get; set; }

        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }
    }

    class Delta
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("tool_calls")]
        public ToolCall2[] ToolCalls { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }

    class ToolCall2
    {
        [JsonProperty("index")]
        public int Index { set; get; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("tool_calls")]
        public ToolCall2[] ToolCalls { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }


    class ModelResponse
    {
        [JsonProperty("data")]
        public ModelInfo[] Data { set; get; }
    }

    class ModelInfo
    {
        [JsonProperty("id")]
        public string Id { set; get; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("owned_by")]
        public string OwnedBy { get; set; }
    }
}