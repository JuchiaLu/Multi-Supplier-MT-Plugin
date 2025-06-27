using MultiSupplierMTPlugin.ProvidersCommon.Options.LLM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiSupplierMTPlugin.Helpers
{
    class BathTranslateHelper
    {
        private static Dictionary<string, object> _jsonSchemaShorter = new Dictionary<string, object>
        {
            ["name"] = "translation_result_map",
            ["description"] = "Map of sentence IDs to their translations.",
            ["strict"] = true,
            ["schema"] = new Dictionary<string, object>
            {
                ["type"] = "object",
                ["properties"] = new Dictionary<string, object>(),
                ["additionalProperties"] = new Dictionary<string, object> { ["type"] = "string" },
            }
        };

        private static Dictionary<string, object> _jsonSchemaLonger = new Dictionary<string, object>
        {
            ["name"] = "translation_result_list",
            ["description"] = "List of original texts with IDs and their translations.",
            ["strict"] = true,
            ["schema"] = new Dictionary<string, object>
            {
                ["type"] = "object",
                ["properties"] = new Dictionary<string, object>
                {
                    ["texts"] = new Dictionary<string, object>
                    {
                        ["type"] = "array",
                        ["items"] = new Dictionary<string, object>
                        {
                            ["type"] = "object",
                            ["properties"] = new Dictionary<string, object>
                            {
                                ["id"] = new Dictionary<string, object> { ["type"] = "integer" },
                                ["text"] = new Dictionary<string, object> { ["type"] = "string" }
                            },
                            ["required"] = new[] { "id", "text" },
                            ["additionalProperties"] = false
                        }
                        //["minItems"] = 1
                        //["maxItems"] = 
                    }
                },
                ["required"] = new[] { "texts" },
                ["additionalProperties"] = false
            }
        };


        public static Dictionary<string, object> GetJsonScheme(BathTranslateSchema schema)
        {
            return schema == BathTranslateSchema.Longer ? _jsonSchemaLonger : _jsonSchemaShorter;
        }

        public static string Serialize(BathTranslateSchema schema, List<string> texts)
        {
            if (schema == BathTranslateSchema.Longer)
            {
                var textEntities = new SchemaLongerEntity
                {
                    Texts = texts.Select((text, index) => new SchemaLongerItem { Id = index + 1, Text = text })
                    .ToArray()
                };
                return JsonConvert.SerializeObject(textEntities);
            }

            var textMap = texts.Select((text, index) => new { Key = (index + 1).ToString(), Value = text })
                   .ToDictionary(pair => pair.Key, pair => pair.Value);
            return JsonConvert.SerializeObject(textMap);
        }

        public static List<string> Deserialize(BathTranslateSchema schema, int count, string content)
        {
            try
            {
                string[] results = new string[count];

                if (schema == BathTranslateSchema.Longer)
                {
                    var items = JsonConvert.DeserializeObject<SchemaLongerEntity>(content).Texts;

                    if (items.Length != count)
                        throw new Exception($"The number of batch translation items is incorrect. Expected {count} items.");

                    foreach (var item in items)
                    {
                        int index = item.Id - 1;

                        if (index < 0 || index >= count || results[index] != null)
                            throw new Exception($"Invalid item ID in batch translation response (must be 1 to {count} and unique).");

                        results[index] = item.Text;
                    }
                }
                else
                {
                    var map = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);

                    if (map.Count != count)
                        throw new Exception($"The number of batch translation items is incorrect. Expected {count} items.");

                    foreach (var kv in map)
                    {
                        int index = int.Parse(kv.Key) - 1;

                        if (index < 0 || index >= count || results[index] != null)
                            throw new Exception($"Invalid item ID in batch translation response (must be 1 to {count} and unique).");

                        results[index] = kv.Value;
                    }
                }

                return results.ToList();
            }
            catch
            {
                throw new Exception("Invalid JSON format in batch translation response. Please review your configuration or prompt.\"");
            }
        }


        private class SchemaLongerEntity
        {
            [JsonProperty("texts")]
            public SchemaLongerItem[] Texts { get; set; }
        }

        private class SchemaLongerItem
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }
        }
    }
}
