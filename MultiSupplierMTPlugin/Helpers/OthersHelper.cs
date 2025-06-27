using LiteDB;
using MultiSupplierMTPlugin.Localized;
using MultiSupplierMTPlugin.ProvidersCommon.Options.LLM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.Helpers
{
    class ServiceLocalizedNameHelper
    {
        private const string _LOCALIZED_KEY_PREFIX = "Provider_";

        public static string Get(string uniqueName)
        {
            var serviceInfo = OptionsHelper.MtOption.GeneralSettings.CustomOpenAICompatibleServiceInfos
                .FirstOrDefault(p => p.UniqueName == uniqueName);

            if (serviceInfo != null && !string.IsNullOrWhiteSpace(serviceInfo.DisplayName))
            {
                return serviceInfo.DisplayName;
            }

            if (LocalizedKeyBase.TryFromName<LLKC>(_LOCALIZED_KEY_PREFIX + uniqueName, out var keyEnum))
            {
                return LLH.G(keyEnum);
            }

            return uniqueName;
        }

        public static string GetWithSuffix(string uniqueName, bool? isLLM = null, bool? isBuiltIn = null)
        {
            var name = Get(uniqueName);
            var suffix = BuildSuffix(isLLM, isBuiltIn);
            return name + suffix;
        }

        private static string BuildSuffix(bool? isLLM, bool? isBuiltIn)
        {
            var parts = new List<string>();

            if (isLLM.HasValue)
                parts.Add(LLH.G(isLLM.Value ? LLKC.ProviderType_LLM : LLKC.ProviderType_NMT));

            if (isBuiltIn.HasValue)
                parts.Add(LLH.G(isBuiltIn.Value ? LLKC.ProviderType_BuiltIn : LLKC.ProviderType_NeedConfig));

            return parts.Count > 0 ? " " + string.Join("", parts) : string.Empty;
        }
    }

    class NaturalSortComparer : IComparer<string>
    {
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        private static extern int StrCmpLogicalW(string x, string y);

        public int Compare(string x, string y)
        {
            return StrCmpLogicalW(x, y);
        }
    }

    class PlaceholderTextBox
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private const int _EM_SETCUEBANNER = 0x1501;

        public static void SetCueBanner(TextBox textBox, string cue)
        {
            SendMessage(textBox.Handle, _EM_SETCUEBANNER, 0, cue);
        }
    }

    class RecycleBinHelper
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            public uint wFunc;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pFrom;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pTo;
            public ushort fFlags;
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszProgressTitle;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHFileOperation(ref SHFILEOPSTRUCT FileOp);

        private const int FO_DELETE = 3;
        private const int FOF_ALLOWUNDO = 0x0040;
        private const int FOF_NOCONFIRMATION = 0x0010;
        private const int FOF_SILENT = 0x0004;

        /// <summary>
        /// 将单个文件或目录移动到回收站。
        /// </summary>
        public static bool MoveToRecycleBin(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return false;

            var fs = new SHFILEOPSTRUCT
            {
                wFunc = FO_DELETE,
                pFrom = path + '\0' + '\0', // 双结尾是 Win32 API 的要求
                fFlags = FOF_ALLOWUNDO | FOF_NOCONFIRMATION | FOF_SILENT
            };

            return SHFileOperation(ref fs) == 0;
        }

        /// <summary>
        /// 将多个路径同时移至回收站。
        /// </summary>
        public static bool MoveMultipleToRecycleBin(string[] paths)
        {
            if (paths == null || paths.Length == 0) return false;

            // 路径用 null 字符隔开，并以两个 null 结尾
            var allPaths = string.Join("\0", paths) + "\0\0";

            var fs = new SHFILEOPSTRUCT
            {
                wFunc = FO_DELETE,
                pFrom = allPaths,
                fFlags = FOF_ALLOWUNDO | FOF_NOCONFIRMATION | FOF_SILENT
            };

            return SHFileOperation(ref fs) == 0;
        }
    }

    class ModelItemHelper
    {
        public static ModelItem[] ParseList(string text)
        {
            return (text ?? "")
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(Parse)
                .Where(m => m != null)
                .ToArray();
        }

        public static string ToTextList(ModelItem[] models, string separator)
        {
            return models == null
                ? ""
                : string.Join(separator, models.Select(ToText));
        }

        public static ModelItem Parse(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return null;

            var parts = s.Split('=');
            var uniqueName = parts[0].Trim();
            var displayName = parts.Length >= 2 ? parts[1].Trim() : uniqueName;

            if (string.IsNullOrEmpty(uniqueName) || string.IsNullOrEmpty(displayName))
                return null;

            return new ModelItem { UniqueName = uniqueName, DisplayName = displayName };
        }

        public static string ToText(ModelItem model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.UniqueName))
                return string.Empty;

            var uniqueName = model.UniqueName.Trim();
            var displayName = model.DisplayName.Trim();

            return uniqueName == displayName ? uniqueName : $"{uniqueName}={displayName}";
        }
    }

    class DatabaseHelper
    {
        private static readonly object _lock = new object();

        public static void Init(string dbDir, string prefix)
        {
            if (Initialized) return;

            lock (_lock)
            {
                if (Initialized) return;
                try
                {
                    Directory.CreateDirectory(dbDir);
                    var dbPath = Path.Combine(dbDir, prefix + ".db");
                    LiteDatebase = new LiteDatabase(dbPath);
                    Initialized = true;
                }
                catch (Exception ex)
                {
                    LoggingHelper.Warn("LiteDB initialization failed: " + ex.Message);
                }
            }
        }

        public static LiteDatabase LiteDatebase { get; private set; }

        public static bool Initialized { get; private set; }
    }
}
