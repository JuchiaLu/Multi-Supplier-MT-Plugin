### 为什么写这个插件

最近想要翻译一些技术文档，由于一些专业术语翻译时需要确保一致性，所以接触到了 CAT（计算机辅助翻译）软件，最终选择了memoQ，它有一个 PDF 预览插件，可以完美的预览待翻译段落在原文中的位置，这是我选择它的一个重要理由。

由于 memoQ 是一款国外软件，国内的翻译服务提供商几乎都没有接入，虽然 Tmxmall 和 Intento 插件可以连接国内外几十家不同的服务提供商，但国内各家翻译服务提供商每月赠送有一定量的免费额度，使用 Tmxmall 或 Intento 无法享受到这种优惠，且这两款插件都没有提供翻译缓存功能（可能是为了让你消耗更多的字符？），所以有了本插件。

### 如何使用翻译插件

将 Release 中的 `MultiSupplierMTPlugin.dll` 放入到软件安装目录（比如 `C:\Program Files\memoQ\memoQ-9\Addins`） 下。

由于插件未经过签名，每次启动 memoQ 都会询问是否加载，如果不想每次询问，需要将 `ClientDevConfig.xml` 放入到 `%programdata%/MemoQ` 目录下。

插件只在 memoQ 9.14 版本中进行过测试，其他版本如出现任何问题，欢迎进行反馈。

### 翻译插件需求分析

标签类型：XML ✔、HTML ✔

是否在译文末尾插入所需标签 ✔

是否开启译文标签空格规范化 ✔

是否开启翻译缓存（默认开启）✔

是否使用网络代理（自带设置）✔

批量翻译：多个段落只需发送一个请求 ✔

并发请求：多个请求可以同时并行发送 ✔

限速（QPS）：每秒最多只能发送 n 个请求 ✔

限量（MTH）：同时最多只能 m 个请求在执行 ✔

失败重试：（超时时间、重试次数、重试等待时间）

语言代码规范化：各个提供商支持的语言不同 ，语言代码也不同 ，需要规范化 ✔

请求类型： 仅纯文本 ✔、包括格式标记 ✔、包括格式标记和标签（memoQ 标签、内联标签）✔

是否支持储存翻译结果：（Director.StoringTranslationSupported），（当在 memoQ 中确认某段翻译时，会将原文和译文发送给插件，插件可以用来自学习，或储存为翻译缓存）（自带设置）✔

是否使用 “MT（机器翻译）” 来修正 “TM（翻译记忆）”：（Engine.SupportsFuzzyCorrection），（如果源片段有 TM 匹配，但并不完美，memoQ 将尝试通过将差异发送给 MT 进行翻译来改进建议）（自带设置）✔

是否使用 “TM（翻译记忆）” 来辅助 “MT（机器翻译）”：（Director.SupportFuzzyForwarding），（除了要翻译的源片段之外，memoQ 还会将最佳可用 TM 匹配的源文本和目标文本发送给 MT）（memoQ 10.0 版本后提供）✔

### 翻译服务提供商接入

计划接入的服务提供商（memoQ 已自带的将不再重复接入）：

国内：阿里✔、腾讯✔、百度✔、彩云✔、火山✔、小牛✔、有道✔、讯飞✔、搜狗（下架）

国外：谷歌（自带）、微软（自带）、亚马逊 （自带）、DeepL（自带）、Yandex、Bing

逆向：谷歌✔、微软✔

其他：LingVA、PaPaGo、PALM2、OpenAI

| 提供商       | 免费额度                                             | 官方声称 QPS              | 支持批量翻译 | 支持 Html 或 XML | 插件批量大小 | 插件 QPS | 插件最大线程数 |
| ------------ | ---------------------------------------------------- | ------------------------- | ------------ | ---------------- | ------------ | -------- | -------------- |
| 阿里         | 普通版：每月 100 万字符<br />专业版：每月 100 万字符 | 普通版：50<br/>专业版：50 | ✔            | ✔ (html)         | 10           | 10       | 50             |
| 腾讯         | 每月 500 万字符                                      | 5                         | ✔            | ×                | 10           | 4        | 5              |
| 百度         | 标准版：每月 5 万字符<br/>高级版：每月 100 万字符    | 标准版：1<br />高级版：10 | ?            | ×                | 1            | 1        | 1              |
| 火山         | 每月 200 万字符                                      | 10                        | ✔            | ×                | 10           | 5        | 10             |
| 彩云         | 每月 100 万字符                                      | 10                        | ✔            | ×                | 10           | 8        | 10             |
| 小牛         | 每日 20 万字符                                       | 50                        | ×            | ✔  (xml)         | 1            | 10       | 50             |
| 有道         | 新用户赠送 50 元体验金                               | 50                        | ✔            | ×                | 10           | 1        | 50             |
| 讯飞         | 新用户赠送 200 万字符                                | 不详                      | ×            | ✔ (xml)          | 1            | 3        | 10             |
|              |                                                      |                           |              |                  |              |          |                |
| 谷歌（逆向） | 无                                                   | 不详                      | ×            | ✔ (xml 或 html)  | 1            | 5        | 10             |
| 微软（逆向） | 无                                                   | 不详                      | ✔            | ×                | 10           | 5        | 10             |

注：

1. 由于 memoQ 在一次批量翻译时最多只提供 10 个段落，所以在提供商支持批量翻译的情况下，插件一次请求默认的批量翻译大小为 10 个段落。
2. 百度翻译声称支持批量翻译，但他使用换行符来区分各个独立段落，但 memoQ  提供的一个段落是可能包含换行符的，所以插件设置百度翻译默认的批量翻译大小为 1 个段落，即把它当作不支持批量翻译处理。
3. 国内多数厂商声称的 QPS 与我实测得到的结果不太符合，比如 QPS 为 10，我的理解是，只要在 1 秒窗口内，保证总的请求小于 10 个就行，比如：可以在 0.1 秒时刻发送 10 个请求，之后的 0.9 秒不发送任何请求；也可以每隔开 0.1 秒发送一个请求，依次发送 10 个请求。本插件使用的限流策略属于第一种情况，如果按照国内厂商声称的 QPS 进行设置，大多数报错。

### 如何添加其他提供商

如果你想快速的添加其他翻译服务提供商，你无需了解 memoQ 插件的工作流程（当然，我已把官方文档翻译成中文，不妨也看看），你也无需关心批量、缓存、并发、限流，你只需要实现 `MultiSupplierMTServiceInterface.cs` 接口：

```C#
public abstract class MultiSupplierMTServiceInterface
    {
        public abstract string UniqueName();
    
        public abstract MultiSupplierMTOptions ShowConfig(MultiSupplierMTOptions options, IEnvironment environment, IWin32Window parentForm);

        public abstract bool IsAvailable(MultiSupplierMTOptions options);

        public abstract bool IsLanguagePairSupported(string srcLangCode, string trgLangCode);

        public abstract int MaxQueriesPerSecond();

        public abstract int MaxThreadHold();
    
        public abstract int MaxBatchSize();

        public abstract Task<List<string>> BatchTranslate(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode,  List<string> tmSources,  List<string> tmTargets, MTRequestMetadata metaData);
}
```

- UniqueName 方法

  返回一个唯一的服务提供商名字，这将会显示在服务提供商选择界面的下拉列表中。

- ShowConfig 方法

  当用户在下拉列表中选中此服务提供商时，会调用此方法来显示 GUI 配置界面。

  如果该服务需要收集用户配置（比如 appKey、appSecret）后才能使用，你需要建一个 Form 类来收集。

  参数：

  - options：配置类实例，你可能需要在 MultiSupplierMTOptions 类中添加你的配置子类和字段
  - environment：memoQ 的环境，比如你能获取到 memoQ 用户界面的语言代码 `UILang` 等。
  - parentForm：父窗口的实例，比如用在你的 Form 实例的 ShowDialog(parentForm) 方法中。

  返回：MultiSupplierMTOptions 类型的配置实例，该实例将被 XML 序列化后持久保存。

- IsAvailable 方法

  返回一个 bool 值，说明此服务是否已可用，也就是用户配置（比如 appKey、appSecret）是否已收集且经过验证。

  参数：

  - options：配置类实例

- IsLanguagePairSupported 方法

  返回一个 bool 值，说明此服务是否支持从 srcLangCode 翻译成 trgLangCode，语言代码请参考 [memoQ](https://docs.memoq.com/current/en/Things/things-supported-languages.html) 官网。

  参数：

  - srcLangCode：源语言代码
  - trgLangCode：目标语言代码

- MaxQueriesPerSecond 方法

  返回一个数值，说明此服务的最大 QPS 限制大小，0 代表无限制。

  上层会并发调用此服务，调用时需要进行限流，确保 QPS 不会超过此值。

- MaxThreadHold 方法

  返回一个数值，说明允许的最大请求线程数，0 代表无限制。

  比如设置为 5，发出 5 个请求后都没有响应，第 6 个线程将会等待，直到某个线程完成。

- MaxBatchSize 方法

  返回一个数值，说明每次请求时批量翻译的最大段落数。

  比如翻译服务提供商不支持批量翻译则返回 1 即可。

- BatchTranslate 方法

  这是翻译服务逻辑实现的地方，也就是真正发送 Http 请求的地方。

  请不要在该方法内实现批量、缓存、并发、限流功能，因为上层已经实现。

  上层会根据此类返回的 MaxBatchSize  、MaxQueriesPerSecond 、MaxThreadHold 值，并发的调用此方法。

  主要参数：

  - MultiSupplierMTOptions options

    配置类，比如你可以从中获取收集到的用户配置（比如 appKey、appSecret）

  - List\<string\> texts

    待翻译的段落列表，该列表的大小不会超过 MaxBatchSize  的值

  - string srcLangCode

    源语言代码

  - string trgLangCode

    目标语言代码

  次要参数：

  - List\<string\> tmSources 和 List\<string\> tmTargets

    如果待翻译的段落在 memoQ 中有部分匹配的 TM（翻译记忆），则可以获取到匹配的原文和译文，用于辅助翻译。

    tmSource 代表原文段落，tmTargets 代表译文段落，它与参数 texts 中的段落是一一对关系。

    该参数的值不一定存在，也就可能为 null，且只有 memoQ 10.0 版本后该参数才可能有值。

  - MTRequestMetadata metaData

    这可以获取到用户翻译项目设置的元信息，比如 PorjectID、Client、Domain、Subject 等，用于辅助翻译。

    该参数的值不一定存在，也就可能为 null，且只有 memoQ 9.14 版本后该参数才可能有值。

  返回值：和 texts 顺序一致的翻译后的 List\<string\>