## 一、pdf 转 docx

memoQ 也支持导入 pdf，但本质上还是先将其转换成 docx 格式，转换的效果不是很理想，个人认为转换效果最好的还是 ABBYY FineReader PDF，一是因为它支持 OCR 且快速准确，二是它支持手动框选某区域是文本还是表格或是图片，三是它可以导出与原 pdf 文件排版高度一致的 docx 文件。

1.  打开 pdf 文件并分析所有页面

   ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_0.png)

2. 对于不想翻译的公式、表格、图片等手动将其框选成图片区域

   ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_1.png)

3. 识别所有页面

   ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_2.png)

4. 另存为 Word 精确副本

   ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_3.png)

5. 在弹出的保存窗口中，点击选项，有两种选择

   - 保留换行符和连字符

     ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_4.png)

   - 去除换行符和连字符

     ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_5.png)

   保留换行符的好处是格式几乎和原文完全一致，坏处是要求翻译引擎支持携带标签，翻译时需将换行符标签放置到正确译文处，由于携带大量的标签可能会对翻译效果产生一定的影响。所以，非必要情况下，更推荐去除换行符和连字符。

## 二、使用 memoQ 翻译 docx

1. 新建项目

   ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_6.png)

2. 选择源语言和目标语言，之后的步骤（导入文件、建立翻译记忆库、建立术语库）先跳过，直接点完成。

   ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_7.png)

3. 修改默认的断句规则

   - 先复制一份默认断句规则，双击点开后选择高级视图，然后将所有自带规则删除

     ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_9.png)

   - 接着添加以下三个新的断句规则：`(\r){2,}#!#`、`(\n){2,}#!#`、`(\r\n){2,}#!#`

     ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_10.png)

   默认的断句规则是为人工翻译准备的，它根据问号、句号等句子结束符将其拆分为句段，这不利于机器翻译，一是句段太短缺少上下文，二是句段的数量太多，机器翻译时需要发送大量的请求，新添加的断句规则是把间隔至少两个换行符的部分才拆分为一个句段。

4. 选择性导入待翻译文件

   ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_11.png)

5. 导入时更改过滤器配置，根据之前 PDF 导出 Word 时是保留还是去除换行符，有两种选择

   - 保留换行符时：要将软回车选为“以行内标签显示”

     ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_12.png)

   - 去除换行符时：要将软回车选为“开始新句段”

     ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_13.png)

   

6. 新建机器翻译配置

   ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_14.png)

7. 选择机器翻译插件

   ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_15.png)

8. 打开待翻译文档

   ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_16.png)

9. 点击“预翻译”按钮

   ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_17.png)

10. 确定执行预翻译

    ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_18.png)

11. 预翻译报错不要紧，一是再次执行预翻译只会翻译没有翻译过的句段，二是翻译插件带有缓存功能

    ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_19.png)

12. 导出翻译后的译文

    ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_20.png)

13. 有可能会导出失败，原因是有些句段未翻译，或者一些必须标签翻译后缺失，或翻译后标签没有放置到正确的位置，需要手动处理

    ![](https://raw.githubusercontent.com/JuchiaLu/Multi-Supplier-MT-Plugin/master/images/BestPractice_21.png)

