using System;
using MemoQ.Addins.Common.DataStructures;
using MemoQ.MTInterfaces;

namespace MT_SDK
{
    /// <summary>
    /// Dummy environment to be able to initialize the plugins.
    /// 能够初始化插件的虚拟环境。
    /// </summary>
    public class DummyEnvironment : IEnvironment2
    {
        /// <summary>
        /// The two-letter UI language code of the application.
        /// 应用程序的两个字母的 UI 语言代码。
        /// </summary>
        public string UILang
        {
            get { return "eng"; }
        }

        /// <summary>
        /// Handles the plugin availability changed events
        /// 处理插件可用性更改事件。
        /// </summary>
        public void PluginAvailabilityChanged() { }

        /// <summary>
        /// Parse the string for a TMX segment, i.e.: "<seg>...</seg>"
        /// 解析 TMX 段的字符串，即: “ < seg > ... </seg >”
        /// </summary>
        public Segment ParseTMXSeg(string str)
        {
            return Segment.Empty;
        }

        /// <summary>
        /// Serialize the segment as a TMX segment, i.e.: "<seg>...</seg>"
        /// 将段序列化为 TMX 段，即: “ < seg > ... </seg >”
        /// </summary>
        public string WriteTMXSeg(Segment seg)
        {
            return string.Empty;
        }

        /// <summary>
        /// Returns the localized text which is belonging to the specified key.
        /// 返回属于指定键的本地化文本。
        /// If returns null the MT plugin should display its own default texts.
        /// 如果返回空的 MT 插件应该显示自己的默认文本。
        /// </summary>
        public string GetResourceString(string pluginName, string key)
        {
            return null;
        }

        /// <summary>
        /// Shows the localized web help otherwise the deployed (offline) English help.
        /// 显示本地化的 Web 帮助，否则部署(脱机)英语帮助。
        /// </summary>
        public void ShowHelp(string helpTopicId)
        {
            TestClient.TestClientHelpHelper.TestClientShowHelp(helpTopicId);
        }
    }
}
