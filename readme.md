

### 为什么写这款插件

最近想要翻译一些技术文档，由于一些专业术语翻译时需要确保一致性，所以接触到了 CAT（计算机辅助翻译）软件，最终选择了 memoQ，~~它有一款 pdf 外部预览插件，可以较为完美的预览待翻译句段在原文中的位置，这是我选择它的一个重要理由~~（使用一段时间后，发现它并不能完全满足我的需求，我又为 memoQ 开发了[ Word 外部预览插件）](https://github.com/JuchiaLu/Memoq-Word-Preview)。

由于 memoQ 是一款国外软件，国内的翻译服务提供商几乎没有接入，虽然 Tmxmall 和 Intento 插件可以连接国内外几十家不同的服务提供商，但各家服务提供商每月赠送有一定量的免费额度，使用 Tmxmall 或 Intento 无法享受到这种优惠，且这两款插件都没有提供翻译缓存功能（可能是为了让你消耗更多的字符？），所以有了本插件。

### 翻译插件功能预览

![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/preview.png)

多提供商 ✔



请求类型： 仅纯文本 、包括格式标记 、包括格式标记和标签 ✔

标记或标签表示：Xml 、Html ✔

译文末尾插入所需标签：针对不包括标签的请求 ✔

译文标签旁边的空格归一化：针对包括标签的请求 ✔



批量翻译：多个句段只需发送一个请求 ✔

并行请求：多个请求可以同时并行发送 ✔

请求限速：某时间段内最多只能发送一定数量的请求 ✔

请求限并发：任意时刻最多只有一定数量的请求正在执行 ✔

失败重试：失败超时时间 、重试等待时间 、失败重试次数 ✔

翻译缓存：默认开启，缓存数据保存在内存中，重启 memoQ 失效 ✔



其他：自定义显示名称 ✔、请求数以及请求异常数统计 ✔、异常日志 ✔、多重安装 ✔、多语言界面 ✔



储存（人工）翻译结果：（Director.StoringTranslationSupported），（当在 memoQ 中确认某段翻译时，会将原文和译文发送给插件，插件可以用来自学习，或储存为翻译缓存），（已支持，暂时只用来储存为缓存）✔

使用 “MT（机器翻译）” 来修正 “TM（翻译记忆）”：（Engine.SupportsFuzzyCorrection），（如果源句段有 TM 匹配，但并不完美，memoQ 将尝试通过将差异发送给 MT 进行翻译来改进建议），（已支持，暂时未用到）✔

使用 “Metadata（元数据）” 来辅助 “MT（机器翻译）”：（ISessionWithMetadata 接口），（用户翻译项目设置的元信息，比如 PorjectID、Client、Domain、Subject 等，可用于辅助翻译，memoQ 9.14 版本开始提供），（已支持，暂时未用到）✔

使用 “TM（翻译记忆）” 来辅助 “MT（机器翻译）”：（Director.SupportFuzzyForwarding），（除了要翻译的源句段之外，memoQ 还会将最佳可用 TM 匹配的源文本和目标文本发送给 MT，memoQ 10.0 版本开始提供），（已支持，暂时未用到）✔

### 如何安装翻译插件

![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/installed.png)

将 Release 中的 `MultiSupplierMTPlugin.dll` 放入到 memoQ 插件目录下（比如 `C:\Program Files\memoQ\memoQ-9\Addins`） 。

`en-US`、`zh-CN` 等文件夹为多语言资源文件夹，如果你要显示英语以外的其他语言，需要将对应的文件夹一并复制到 memoQ 插件目录下。

插件未经过签名，每次启动 memoQ 都会询问是否加载，如果不想每次询问，需要将 `ClientDevConfig.xml` 放入到 `%programdata%/MemoQ` 目录下。

插件仅在 memoQ 9.14 版本中进行过测试，其他版本如出现任何问题，请进行反馈。 由于 memoQ 上手有一定的难度，因此特别写了一篇最佳实践的[图文教程](https://github.com/JuchiaLu/Multi-Supplier-MT-Plugin/blob/main/doc/BestPractice.md)。

### 如何进行多重安装

![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/multi%20install.png)

使用 Release 中的 `Dll Generator.exe` 生成所需数量的 dll 文件，将其一同和 `MultiSupplierMTPlugin.dll`  放入到插件目录下。

确保有一个 dll 的文件名为 `MultiSupplierMTPlugin.dll`，因为其他 dll 要共用 `MultiSupplierMTPlugin.dll` 的多语言资源文件。

虽然可以重命名 dll 为任何名字，但不建议这么做，因为下一个版本发布时，又得手动重命名为原来的名字才能关联到已保存的配置。

请一定要使用 `Dll Generator.exe` 生成 dll，而不是直接复制后重命名，否则多重安装将会产生错误，除非等到 [这个](https://github.com/dotnet/aspnetcore/issues/47465) 问题得到解决。

### 如何使用大语言模型

![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/connect%20to%20OneAPI.png)

插件目前只对接了 Open AI 的大语言模型接口，但你可以使用 `OpenAI GPT` 配置界面连接到任何兼容 Open AI 接口的 “聚合大语言模型接口程序（比如 [One API](https://github.com/songquanpeng/one-api) 等）” ，这样你便可以使用国内外绝大多数提供商的大语言模型，以及本地大语言模型。

### 标签请求类型解释

![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/formattings%20and%20tags.png)

原文中“Hello”是加粗的，“World!”是红色字体，机器翻译时的原文请求区别如下：

- 纯文本：`Hello, World!`
- 包括格式标记：`<b>Hello<\b>, World!`
- 包括格式标记和标签：`<b>Hello<\b>, <inline_tag id="0">World!<inline_tag id="0"/>`

为了保证翻译后的排版格式和原文保持一致，要求翻译时将格式标记（比如加粗、斜体、下划线，上标、下标等）和标签（比如字体颜色、背景颜色、链接等）放置到正确的位置。

大多数的机器翻译引擎支持将格式标记保留不翻译，并放置到正确的位置，但标签就不一定，它们可能错误的将标签当作普通文本进行翻译，或没有把标签保留在译文中。格式标记或标签有两种形式表示，一是使用 Xml 标准表示，二是使用 Html 标准表示，各家支持的情况请看下文表格中的“支持 Xml 或 Html”。

想要直观的查看标签，可以使用插件提供的 `测试翻译（内建）` 服务提供商，从它的翻译结果中的 text 字段内容能看到未经转换的原始形式的标签表示。

### 翻译服务提供商接入

| 提供商                                                       | 免费额度                                             | QPS 限速                  | 批量翻译支持 | Xml 或 Html 支持 |
| ------------------------------------------------------------ | ---------------------------------------------------- | ------------------------- | ------------ | ---------------- |
| [阿里](https://www.aliyun.com/product/ai/base_alimt)         | 普通版：每月 100 万字符<br />专业版：每月 100 万字符 | 普通版：50<br/>专业版：50 | ✔            | ✔ (Html)         |
| [腾讯](https://cloud.tencent.com/product/tmt)                | 每月 500 万字符                                      | 5                         | ✔            | ×                |
| [百度](https://fanyi-api.baidu.com/product/11)               | 标准版：每月 5 万字符<br/>高级版：每月 100 万字符    | 标准版：1<br />高级版：10 | ?            | ×                |
| [火山](https://translate.volcengine.com/api)                 | 每月 200 万字符                                      | 10                        | ✔            | ×                |
| [小牛](https://niutrans.com/dev-page)                        | 每日 20 万字符                                       | 50                        | ×            | ✔  (Xml)         |
| [有道](https://fanyi.youdao.com/openapi/)                    | 新用户赠送 50 元体验金                               | 50                        | ✔            | ×                |
| [讯飞](https://www.xfyun.cn/services/xftrans)                | 新用户赠送 200 万字符（90 天内有效）                 | 不详                      | ×            | ✔ (Xml)          |
| [彩云](https://open.caiyunapp.com/%E4%BA%94%E5%88%86%E9%92%9F%E5%AD%A6%E4%BC%9A%E5%BD%A9%E4%BA%91%E5%B0%8F%E8%AF%91_API) | 新用户赠送 100 万字符（30 天内有效）                 | 10                        | ✔            | ×                |
|                                                              |                                                      |                           |              |                  |
| [Papago](https://guide.ncloud-docs.com/docs/en/papagotranslation-api) | 每天 1 万字符                                        | 不详                      | ×            | x                |
|                                                              |                                                      |                           |              |                  |
| [OpenAI GPT](https://platform.openai.com/docs/overview)      | 无                                                   | 由用户等级决定            | ×            | ✔ (Xml 或 Html)  |
|                                                              |                                                      |                           |              |                  |
| 微软（内置）                                                 | 且用且珍惜                                           | 不详                      | ✔            | ×                |
| 谷歌（内置）                                                 | 且用且珍惜                                           | 不详                      | ×            | ✔ (Xml 或 Html)  |
| DeepL（内置）                                                | 且用且珍惜                                           | 不详                      | ×            | ✔(Xml 或 Html)   |
| Yandex（内置）                                               | 且用且珍惜                                           | 不详                      | ×            | ✔(Xml 或 Html)   |
| Lingvanex（内置）                                            | 且用且珍惜                                           | 不详                      | ×            | ✔(Xml 或 Html)   |

注：百度翻译声称支持批量翻译，但他使用换行符来区分各个独立句段，但 memoQ  提供的一个句段是可能包含换行符的，所以把它当作不支持批量翻译处理。

### 自定义请求限制设置

1. 如果服务提供商不支持批量翻译，插件强制每个请求只翻译 1 个句段，否则默认每个请求翻译 10 个句段。
2. 如果 QPS 不详，插件的默认速率限制设置为每秒 5 个请求，默认并发限制也设置为最多 5 个请求正在同时执行。
3. 如果 QPS 已知，插件的默认速率限制设置为已知 QPS 的 90%，插件的默认并发限制设置为等于已知的 QPS 值。
4. 所有服务提供商的默认超时失败时间、重试等待时间、重试最大次数的值都为零，也就是默认不会进行重试操作。
5. 你可以进行自定义限制，句段限制、速率限制、并发限制设置为 0 代表不限制，重试限制设置为 0 则代表不重试。
6. 目前 memoQ 在一次翻译时最多只提供 10 个句段，所以即使设置超过 10 个句段，实际的句段数也不会超过 10 个。