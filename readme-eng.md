[中文](https://github.com/JuchiaLu/Multi-Supplier-MT-Plugin/blob/main/readme.md) [English (MT)](https://github.com/JuchiaLu/Multi-Supplier-MT-Plugin/blob/main/readme-eng.md)

##  Why write this plugin

Recently, I wanted to translate some technical documents. Due to the need for consistency in some professional terms, I came across CAT (Computer-Assisted Translation) software and eventually chose memoQ. ~~It has a PDF external preview plugin that can preview the position of the segment to be translated in the original PDF in real time, which was an important reason for my choice~~ (After using it for a while, I found that it did not fully meet my needs, so I developed [a Word external preview plugin for memoQ)](https://github.com/JuchiaLu/Memoq-Word-Preview).

Since memoQ is a foreign software, domestic translation service providers are hardly integrated. Although the existing Tmxmall and Intento plugins integrate dozens of providers at home and abroad on the server side, they cannot fill in the provider's own Key. Each provider offers a certain amount of free quota every month, which cannot be enjoyed by using Tmxmall or Intento. Moreover, these two plugins do not have a translation caching feature, hence this plugin.

The plugin has only been tested in memoQ versions 9.14 and 11.4. If problems occur in other versions, please provide feedback. Since memoQ is somewhat difficult to get started with, I have specially written a [graphic tutorial](https://github.com/JuchiaLu/Multi-Supplier-MT-Plugin/blob/main/doc/BestPractice.md) on best practices.

##  Translation plugin feature preview

![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/preview.png)

---

✔ Multiple service providers (hundreds), multiple installations, multilingual interface

✔ Service provider management: Custom add OpenAI compatible providers, enable or disable providers

✔ Large language model support: Batch translation, glossary, context, translation memory, full-text summary

---

✔ Request type: Plain text only, including formatting, including formatting and tags

✔ Formatting or tag representation: Xml, Html

✔ Request without tags: Append tags from the original text to the translation (optional to enable)

✔ Request with tags: Normalize spaces around tags in the translation (optional to enable)

---

✔ Batch translation: Multiple segments only need to send one request

✔ Parallel requests: Multiple requests can be sent simultaneously in parallel

✔ Request size limit: A request can only contain a certain number of segments or characters at most

✔ Request rate limit: Only a certain number of requests can be sent within a certain period of time

✔ Request concurrency limit: At any time, only a certain number of requests are being executed at most

✔ Request failure retry: Timeout failure time, retry wait time, failure retry count

---

✔ Translation cache: Enabled by default, the cache is retained in the database and is permanently valid

✔ Other features: Request log, request count statistics, custom display name

---

<details>
<summary>Expand to view</summary>
<pre>
Store (manual) translation results: (Director.StoringTranslationSupported), (When confirming a segment in memoQ, the source and target text are sent to the plugin, which can be used for self-learning or stored as a translation cache), (Supported, currently only used for storing as cache)<br/>
Use "MT (Machine Translation)" to correct "TM (Translation Memory)": (Engine.SupportsFuzzyCorrection), (If the source segment has a TM match but is not perfect, memoQ will attempt to improve the suggestion by sending the differences to MT for translation), (Supported, not currently used)<br/>
Use "MetaData" to assist "MT (Machine Translation)": (ISessionWithMetadata interface), (Metadata set by the user for the translation project, such as ProjectID, Client, Domain, Subject, etc., can be used to assist translation, provided starting from memoQ version 9.14), (Supported, used to assist in obtaining translations, context, summary, full text)<br/>
Use "TM (Translation Memory)" to assist "MT (Machine Translation)": (Director.SupportFuzzyForwarding), (In addition to the source segment to be translated, memoQ also sends the best available TM match's source and target text to MT, provided starting from memoQ version 10.0), (Supported, users can use it in large model prompts)<br/>
</pre>
</details>

---

## How to install the translation plugin

![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/installed.png)

Put the `MultiSupplierMTPlugin.dll` in the Release into the memoQ plugin directory (such as `C:\Program Files\memoQ\memoQ-9\Addins`).

`en-US`, `zh-CN` and other folders are multilingual resource folders. Copy them to the memoQ plugin directory as needed (Chinese-English bilingual, the new version of the plugin has built-in, no need to copy anymore).

The plugin is unsigned, and memoQ will ask whether to load it every time it starts. If you don't want to be asked every time, you need to put `ClientDevConfig.xml` into the `%programdata%\MemoQ` directory.

## How to multiple installations

![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/multi%20install%202.png)

Use the `Dll Generator.exe` in the Release to generate the required number of dll files, and put them together with `MultiSupplierMTPlugin.dll` into the plugin directory.

Make sure one dll file is named `MultiSupplierMTPlugin.dll`, because other dlls will share the multilingual resource files of `MultiSupplierMTPlugin.dll`.

Although you can rename the dll to any name, it is not recommended to do so, because when the next version is released, you will have to manually rename it back to the original name to associate with the saved configuration.

Be sure to use `Dll Generator.exe` to generate the dll, not directly copy and rename, otherwise multiple installations will cause errors, unless [this](https://github.com/dotnet/aspnetcore/issues/47465) issue is resolved.

## Tag request type explanation

![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/formattings%20and%20tags.png)

In the original text, "Hello" is bold, "World! " is red font, the difference in the original text request when machine translating is as follows:

- Plain text: `Hello World!`
- Including formatting: `<b>Hello<\b> World!`
- Including formatting and tags: `<b>Hello<\b> <inline_tag id="0">World!<inline_tag id="0"/>`

To ensure the layout effect of the translation remains consistent with the original, it is required to place format (such as bold, italic, underline, superscript, subscript, etc.) and tags (such as font color, background color, links, etc.) in appropriate positions during translation. Formatting or tags can be represented in two forms: one is using the Xml standard, and the other is using the Html standard. For the support situation of each, please refer to the 'Support Xml or Html' in the provider table.

## Custom request limit settings

- If the service provider does not support batch translation, the plugin forces it to translate only 1 segment per request, and then does not limit the number of characters per request.
- If the service provider can support batch translation, the plugin defaults to limiting each request to a maximum of 10 segments, and defaults to limiting each request to a maximum of 3000 characters.
- If QPS is unknown, the plugin's default rate limit is set to 5 requests per second, and the default concurrency limit is also set to a maximum of 5 requests being executed simultaneously.
- If QPS is known, the plugin's default rate limit is set to 90% of the known QPS, and the plugin's default concurrency limit is set equal to the known QPS value.
- The default timeout failure time, retry wait time, and maximum number of retries for all service providers are set to 0, which means no retry operation is performed by default.
- When customizing request limits: Setting size limit, rate limit, and concurrency limit to 0 means no limit, and setting retry limit to 0 means no retry.



Note:

When performing pre-translation (batch translation), the maximum number of segments is also limited by memoQ, with a default value of up to 10 segments,

You can change it by modifying the `BatchSize` value in `C:\Program Files\memoQ\memoQ-9\MemoQ.exe.config`.

## Large language model prompt cache

Mainstream large language model providers have supported the [prompt cache](https://api-docs.deepseek.com/zh-cn/news/news0802) feature, using this feature will reduce service latency and costs.



Each provider has requirements for the input Token length of the prompt cache, and the price for writing or reading the cache, as well as the expiration time, also vary:

|Provider                                                                        |Minimum input Token length|Write price multiplier|Read price multiplier|Cache expiration time           |
|--------------------------------------------------------------------------------|--------------------------|----------------------|---------------------|--------------------------------|
|[DeepSeek](https://api-docs.deepseek.com/zh-cn/guides/kv_cache)                 |64 (same for all models)  |1.0                   |0.1                  |From a few hours to several days|
|[OpenAI](https://platform.openai.com/docs/guides/prompt-caching)                |1024 (same for all models)|1.0                   |0.5                  |5~10 minutes                    |
|[Google](https://ai.google.dev/gemini-api/docs/caching#implicit-caching)        |1024 (varies by model)    |1.0                   |0.25                 |3-5 minutes                     |
|[Anthropic](https://docs.anthropic.com/en/docs/build-with-claude/prompt-caching)|1024 (varies by model)    |1.25                  |0.1                  |5 minutes                       |



Taking Anthropic Claude as an example, assuming the prompt length is 10,000 Tokens:

- The first request performs a cache write operation, consuming 1 * 1.25 = 12.5 thousand input Tokens
- Each subsequent request performs a cache read operation, consuming 1 * 0.1 = 1 thousand input Tokens
- If there are no cache read operations for 5 consecutive minutes, the next request will consume the same amount as the first request



Each time a request is made, only the **unchanged prefix** of the prompt (from the first character of the system prompt to the character before the first changing character of the user prompt) can be read from the cache.

Therefore, placeholders whose values do not change dynamically (such as `{{glossary-text}}`, `{{summary-text}}`, etc.) should be placed at the front of the prompt.

Placeholders whose values change dynamically with each request (such as `{{source-text}}`, `{{target-text}}`, etc.) should be placed towards the end of the prompt.



For DeepSeek and OpenAI, they do not charge extra for writing to the prompt cache (price multiplier 1.0), so the prompt caching feature is enabled by default and cannot be turned off.

For Anthropic, writing will incur an additional 25% charge (price multiplier 1.25). If the prompt is not written as described above, enabling caching may lead to higher costs.

You can enable the plugin log to view the Token usage (including write and read information of the prompt cache) and adjust the prompt in time to prevent the prompt cache from becoming invalid.

## Large language model prompt placeholders

The following placeholders can be used in "System Prompt" or "User Prompt" (right-click menu for quick insertion), and they will eventually be replaced by actual content:

---

- `{{source-language}}`: Source language (restriction: None)

- `{{target-language}}`: Target language (restriction: None)

---

- `{{source-text}}`: Source text (text to be translated) (restriction: None)
- `{{target-text}}`: Target text (translated text) (restriction: Requires memoQ 9.14+, must agree to enable the preview helper, cannot be used in pre-translation)

---

- `{{tm-source-text}}`: The best matching translation memory source text for the text to be translated (restriction: Requires memoQ 10.0+, must enable the "Send best fuzzy TM" option)
- `{{tm-target-text}}`: The best matching translation memory target text for the text to be translated (restriction: Requires memoQ 10.0+, must enable the "Send best fuzzy TM" option)

---

- `{{above-text}}`: The context above the text to be translated (can include translations) (restriction: Requires memoQ 9.14+, must agree to enable the preview helper, cannot be used in pre-translation)
- `{{below-text}}`: The context below the text to be translated (can include translations) (restriction: Requires memoQ 9.14+, must agree to enable the preview helper, cannot be used in pre-translation)

---

- `{{summary-text}}`: Full text summary (excluding translations) (restriction: Requires memoQ 9.14+, must agree to enable the preview helper)

- `{{full-text}}`: Full text (excluding translations) (restriction: Requires memoQ 9.14+, must agree to enable the preview helper)

---

- `{{glossary-text}}`: Glossary (restriction: The glossary file must be encoded in UTF-8)

---

### {{source-language}}, {{target-language}}

(No special instructions, omitted)

### {{source-text}}, {{target-text}}

The obtained target-text does not include tag information, so you cannot use only target-text in the prompt to have AI polish the translation, otherwise the result will lack the original tags.

A workaround is to include both the tagged source-text and the untagged target-text in the prompt, allowing the AI to polish the translation while placing the tags from the source-text into the appropriate positions in the translation.

### {{tm-source-text}}, {{tm-target-text}}

Translation memory refers to the translation memory in memoQ, not the plugin's translation cache. These two placeholders require memoQ version 10.0 at minimum, and the following option must be enabled in the memoQ machine translation settings:

![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/SendBestFuzzyTM.png)

### {{above-text}}, {{below-text}}

Options:

- If neither `Include Source` nor `Include Target` is selected, blank content will always be obtained.
- If both `Max Segments` and `Max Characters` are 0, blank content will always be obtained.
- If either `Max Segments` or `Max Characters` is 0, zero means no limit on its quantity.
- If `Max Segments` or `Max Characters` is not 0, both quantities will be limited simultaneously.

Recommendation:

- For regular users, priority should be given to adjusting memoQ segmentation rules to produce longer segments, which inherently provide context, thereby eliminating the need to carry context and saving Tokens.

- For translation professionals who must use shorter segmentation rules, adjust the number of contextual segments or characters carried based on actual conditions to balance between translation quality and Token consumption.

### {{summary-text}}, {{full-text}}

Use the `{{full-text}}` placeholder with caution, as it includes the full text in the request, consuming a large number of your Tokens.

 

The actual content of `{{summary-text}}` can be manually specified, applying to all documents, or automatically generated by a large language model, where each document has its own summary.

The summary is automatically generated only once and then saved to the file cache, from which it is read each time thereafter. It will not be regenerated unless the document is deleted from memoQ and re-imported or the cache file is manually deleted.

Summary cache files are saved in the `%appdata%/MemoQ/Plugins/MultiSupplierMTPlugin/Cache/Summary` directory, named with `[summary]-[original document filename]-[document GUID].txt`, for example, `[summary]-[MyDocument.doc]-[1ee7154a-47b7-4e82-bc48-f99b3728f233].txt`. You can check and correct the automatically generated summary content.

### {{glossary-text}}

Store terms as CSV or TXT files encoded in UTF-8, with the default column names and order as follows:

```csv
SourceTerm, TargetTerm, SourceLanguage, TargetLanguage
Hello     , 你好       , eng           , zho-CN
World     , 世界       , eng           , zho-CN
```

The default delimiter is an "English half-width comma", and the language codes use the 3-letter codes specified by memoQ. For details, please refer to: [memoQ 3-letter code](https://docs.memoq.com/current/en/Concepts/concepts-supported-languages.html).



The term file parsing algorithm is flexible enough. If it differs from the default structure, as long as the following conventions are met, it should parse correctly:

- Header: If the column order matches the default order, the first row header is optional. Otherwise, it must include a header to indicate the correct column order.
- Column count: Must include at least `SourceTerm` and `TargetTerm` columns, optionally including `SourceLanguage` and `TargetLanguage` columns.
- Conflict: If the header is included and does not list language columns, but the data rows do, the language columns in the data rows will be ignored.
- Spaces: Adding spaces to align delimiters is not necessary. They are added in the example for aesthetics only and do not affect parsing whether present or not.



The purpose of language columns is to limit the retrieval of term entries. For example, if a term file contains term pairs in multiple languages without language columns, the final result will include term pairs in all languages.

If the term file fails to read or any row of data fails to parse, the plugin will terminate the translation to prevent unexpected translation results. You can check the error messages in the log and correct the errors.



Note: In a Chinese environment, memoQ automatically sets the input method to full-width mode. If you need to modify the delimiter and the term file uses a non-full-width delimiter, first manually switch back to half-width mode.

### Special syntax explanation for placeholders

- To terminate the current translation request when the actual content of a placeholder is desired to be empty, append `!` after the placeholder name, for example, `{{glossary-text!}}`, `{{summary-text!}}`.

- To replace the guiding words related to the placeholder with empty when the actual content of the placeholder is desired to be empty, add `[]` before or after the placeholder, then write the guiding words within `[]`.

### Placeholder and special syntax examples

System prompt:

````
This is the glossary for translation reference:
Glossary start
{{glossary-text!}}
Glossary end

This is the full-text summary for translation reference:
Summary start
{{summary-text!}}
Summary end

This is the full-text for translation reference:
Full text start
{{full-text!}}
Full text end
````



User prompt:

````
[This is the preceding text for translation reference located before the text to be translated:
Preceding text start
]{{above-text}}[
Preceding text end]

[This is the following text for translation reference located after the text to be translated:
Following text start
]{{below-text}}[
Following text end]

[This is the original and translated text from the translation memory for reference:
Translation memory start
]{{tm-source-text}}
{{tm-target-text}}[
Translation memory end]

Please translate the following text from {{source-language!}} to {{target-language!}}:
{{source-text!}}
````



When we want the content of glossary-text, summary-text, full-text, source-text, etc., to be empty, terminate the translation request, so we append `!` after them, indicating that empty content is prohibited.

When we want the content of above-text, below-text, tm-source-text, tm-target-text to be empty, replace the related "guiding words" with empty as well, so we use the `[]` syntax.

For example, when the content of `{{below-text}}` is empty, the guiding words before it `[This is the following text for translation reference located before the text to be translated: Following text start]` and after it `[Following text end]` will also be replaced with empty.

### Why enable the preview helper

The official "Machine Translation SDK" does not provide the ability to obtain translations, context, or full text. When clicking on a segment in the memoQ interface, only the single segment's original text can be obtained. When performing batch translation using pre-translation, by default, only the original text of 10 segments can be obtained at a time.



This plugin uses the official "Preview Tool SDK" to indirectly obtain translations, context, and full text. Upon first use of the plugin, a pop-up will request your approval to enable `Multi Supplier MT Plugin Helper` (a virtual preview tool).

![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/EnableHelper.png)



Since the plugin needs to know the index of a segment to retrieve its translation and context, unfortunately, even with the 'Preview Tool SDK', the index can only be obtained when a segment is clicked in the memoQ interface. During batch translation using pre-translation, there is no interface click interaction, making it impossible to obtain the index of the segment being translated, and thus unable to retrieve the segment's translation and context.

## Supported traditional translation providers

| Provider                                                     | Free quota                                                   | QPS rate limit                                    | Batch translation support | Xml or Html support |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------- | ------------------------- | ------------------- |
| [Ali](https://help.aliyun.com/zh/machine-translation/developer-reference/api-alimt-2018-10-12-translategeneral) | Standard version: 1 million characters per month<br />Professional version: 1 million characters per month | Standard version: 50<br/>Professional version: 50 | ✔                         | ✔ (Html)            |
| [Tencent](https://cloud.tencent.com/document/product/551/40566) | 5 million characters per month                               | 5                                                 | ✔                         | ×                   |
| [Baidu](https://fanyi-api.baidu.com/product/113)             | Standard version: 50,000 characters per month<br/>Advanced version: 1 million characters per month | Standard version: 1<br />Advanced version: 10     | ?                         | ×                   |
| [Volcano](https://www.volcengine.com/docs/4640/65067)        | 2 million characters per month                               | 10                                                | ✔                         | ×                   |
| [Niutrans](https://niutrans.com/documents/contents/transapi_batch_v2) | 200,000 characters per day                                   | 5                                                 | ×                         | ✔ (Xml)             |
| [Youdao](https://fanyi.youdao.com/openapi/)                  | New users receive 50 yuan trial fund (permanently valid)     | 50                                                | ✔                         | ×                   |
| [iFlytek](https://www.xfyun.cn/doc/nlp/xftrans/API.html)     | New users receive 2 million characters (valid for 90 days)   | ?                                                 | ×                         | ✔ (Xml)             |
| [Caiyun](https://open.caiyunapp.com/%E4%BA%94%E5%88%86%E9%92%9F%E5%AD%A6%E4%BC%9A%E5%BD%A9%E4%BA%91%E5%B0%8F%E8%AF%91_API) | New users receive 1 million characters (valid for 30 days)   | 10                                                | ✔                         | ×                   |
|                                                              |                                                              |                                                   |                           |                     |
| [Papago](https://guide.ncloud-docs.com/docs/en/papagotranslation-api) | 10,000 characters per day                                    | ?                                                 | ×                         | ×                   |
| [DeepL](https://developers.deepl.com/docs/api-reference/translate/openapi-spec-for-text-translation) | 500,000 characters per month                                 | ?                                                 | ✔                         | ✔ (Xml or Html)     |
| [DeepLX](https://deeplx.owo.network/endpoints/free.html)     | Self-deployment or developer provides 500,000 characters per day | ?                                                 | ×                         | ✔ (Xml or Html)     |
| [Yandex](https://yandex.cloud/en/docs/translate/api-ref/Translation/translate) | ?                                                            | 20                                                | ✔                         | ✔ (Html)            |
|                                                              |                                                              |                                                   |                           |                     |
| Microsoft (built-in)                                         | Use it while you can                                         | ?                                                 | ✔                         | ×                   |
| Google (built-in)                                            | Use it while you can                                         | ?                                                 | ×                         | ✔ (Xml or Html)     |
| DeepL (built-in)                                             | Use it while you can                                         | ?                                                 | ×                         | ✔(Xml or Html)      |
| Yandex (built-in)                                            | Use it while you can                                         | ?                                                 | ×                         | ✔(Xml or Html)      |
| Lingvanex (built-in)                                         | Use it while you can                                         | ?                                                 | ×                         | ✔(Xml or Html)      |
| Modernmt (built-in)                                          | Use it while you can                                         | ?                                                 | ×                         | ✔(Xml or Html)      |

Note: Baidu Translate claims to support batch translation, but it uses line breaks to distinguish between individual segments. However, a segment provided by memoQ may contain line breaks, so it is considered not to support batch translation.

## Supported large language model providers

| Provider                                                     | Free quota | QPS rate limit | Batch translation support | Xml or Html support |
| ------------------------------------------------------------ | ---------- | -------------- | ------------------------- | ------------------- |
| [Ali Bailian](https://help.aliyun.com/zh/model-studio/compatibility-of-openai-with-dashscope) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Tencent Hunyuan](https://cloud.tencent.com/document/product/1729/111007) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Baidu Qianfan](https://cloud.baidu.com/doc/qianfan-docs/s/1m9l6eex1) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [ByteDance Volcano](https://www.volcengine.com/docs/82379/1330626) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [iFlytek Spark](https://www.xfyun.cn/doc/spark/HTTP%E8%B0%83%E7%94%A8%E6%96%87%E6%A1%A3.html#_7-%E4%BD%BF%E7%94%A8openai-sdk%E8%AF%B7%E6%B1%82%E7%A4%BA%E4%BE%8B) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [DeepSeek](https://api-docs.deepseek.com/zh-cn/)             | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Zhipu Qingyan](https://bigmodel.cn/dev/api/thirdparty-frame/openai-sdk) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Step Fun](https://platform.stepfun.com/docs/guide/openai)   | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Moonshot](https://platform.moonshot.cn/docs/guide/migrating-from-openai-to-kimi) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Baichuan AI](https://platform.baichuan-ai.com/docs/api#python-client) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [MiniMax](https://platform.minimaxi.com/document/ChatCompletion) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [SenseTime](https://www.sensecore.cn/help/docs/model-as-a-service/nova/overview/compatible-mode) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Lingyi Wanwu](https://platform.lingyiwanwu.com/docs)        | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [InternAI](https://internlm.intern-ai.org.cn/doc/docs/Chat/) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Infly](https://platform.infly.cn/docs/open-api/api)         | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [InfiniAI](https://docs.infini-ai.com/gen-studio/api/maas.html) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Silicon Flow](https://docs.siliconflow.cn/cn/userguide/quickstart#4-3-openai) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [360 Zhinao](https://ai.360.com/open)                        | ?          | ?              | ✔                         | ✔(Xml or Html)      |
|                                                              |            |                |                           |                     |
| [OpenAI](https://platform.openai.com/docs/api-reference/chat) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Anthropic](https://docs.anthropic.com/en/api/openai-sdk)    | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Google](https://ai.google.dev/gemini-api/docs/openai)       | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [xAI](https://docs.x.ai/docs/api-reference#chat-completions) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Mistral](https://docs.mistral.ai/api/)                      | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Cohere](https://docs.cohere.com/docs/compatibility-api)     | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Upstage](https://console.upstage.ai/docs/getting-started)   | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Azure](https://learn.microsoft.com/en-us/azure/ai-services/openai/reference) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Cloudflare](https://developers.cloudflare.com/workers-ai/configuration/open-ai-compatibility/) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Nvidia](https://docs.api.nvidia.com/nim/reference/nvidia-llama-3_1-nemotron-ultra-253b-v1-infer) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Open Router](https://openrouter.ai/docs/quickstart)         | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [One API](https://github.com/songquanpeng/one-api)           | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [New API](https://docs.newapi.pro/api/openai-chat/)          | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Lite LLM](https://docs.litellm.ai/docs/)                    | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [Ollama](https://github.com/ollama/ollama/blob/main/docs/openai.md) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [vLLM](https://docs.vllm.ai/en/latest/serving/openai_compatible_server.html) | ?          | ?              | ✔                         | ✔(Xml or Html)      |
| [LM Studio](https://lmstudio.ai/docs/app/api/endpoints/openai) | ?          | ?              | ✔                         | ✔(Xml or Html)      |

Note: The above only lists some commonly used service providers. The plugin also supports nearly all mainstream large language model providers, including self-developed manufacturers, online aggregation gateways, self-built aggregation gateways, and local large models.
