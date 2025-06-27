using Newtonsoft.Json;
using System;

namespace MultiSupplierMTPlugin.Providers.Anthropic
{
    // TODO：JSON 序列化时忽略 null 字段
    class AnthropicRequest
    {
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("messages")]
        public Message[] Messages { get; set; }

        [JsonProperty("max_tokens")]
        public int MaxTokens { get; set; }

        //[JsonProperty("metadata")]
        //public Metadata Metadata { get; set; }

        //[JsonProperty("stop_sequences")]
        //public string[] StopSequences { get; set; }

        //[JsonProperty("stream")]
        //public bool? Stream { get; set; }

        [JsonProperty("system")]
        public SystemItem[] System { get; set; }

        [JsonProperty("temperature")]
        public double? Temperature { get; set; }

        //[JsonProperty("top_k")]
        //public int? TopK { get; set; }

        //[JsonProperty("top_p")]
        //public double? TopP { get; set; }
    }

    class SystemItem
    {
        [JsonProperty("cache_control", NullValueHandling = NullValueHandling.Ignore)]
        public CacheControl CacheControl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    class CacheControl
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    class Message
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    class Metadata
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }

    class AnthropicResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("content")]
        public ContentBlock[] Content { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("stop_reason")]
        public string StopReason { get; set; }

        [JsonProperty("stop_sequence")]
        public string StopSequence { get; set; }

        [JsonProperty("usage")]
        public Usage Usage { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    class ContentBlock
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    class Usage
    {
        [JsonProperty("input_tokens")]
        public int InputTokens { get; set; }

        [JsonProperty("output_tokens")]
        public int OutputTokens { get; set; }

        [JsonProperty("cache_creation_input_tokens")]
        public int CacheCreationInputTokens { get; set; }

        [JsonProperty("cache_read_input_tokens")]
        public int CacheReadInputTokens { get; set; }
    }

    class Error
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    class ModelResponse
    {
        [JsonProperty("data")]
        public ModelResponseItem[] Data { get; set; }

        [JsonProperty("first_id")]
        public string FirstId { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("last_id")]
        public string LastId { get; set; }
    }


    class ModelResponseItem
    {

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}