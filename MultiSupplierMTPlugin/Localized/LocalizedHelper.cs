using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace MultiSupplierMTPlugin.Localized
{
    /**
     * 需求：
     * 1. 代码中可追溯到哪里引用了该 key：使用属性，而不是字符串
     * 2. 可修改属性名称而不影响已有翻译：使用 GUID，而不是属性名
     * 3. 可以动态从属性名逆推得到属性值：
     * 4. 可以分模块将本地化键放到不同类：
     * 5. 可以运行时动态切换当前语言文化：
     * 6. 可以追踪各个版本的翻译变化情况：
     **/
    class LocalizedHelper
    {
        private static string _mainAssemblyName = "MultiSupplierMTPlugin";

        private static readonly ResourceManager _resourceManager;

        private static readonly Dictionary<string, string> _resourceCache;

        private static readonly Dictionary<LocalizedKeyBase, LocalizedValueAttribute> _attributeCache;


        static LocalizedHelper()
        {
            _resourceCache = new Dictionary<string, string>();
            _attributeCache = new Dictionary<LocalizedKeyBase, LocalizedValueAttribute>();

            Assembly assembly;
            try
            {
                // 优先加载共用的主 dll
                var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var file = $"{_mainAssemblyName}.dll";
                var mianAssemblyPath = Path.Combine(dir, file);                
                assembly = Assembly.LoadFrom(mianAssemblyPath);
            }
            catch (FileNotFoundException)
            {
                // 不存在再加载自身 dll
                assembly = Assembly.GetExecutingAssembly();
            }

            // resourceManager.GetString 当 key 不存在时抛出异常，导致在 debug 下性能非常缓慢，所以将其一次性缓存起来
            _resourceManager = new ResourceManager($"{_mainAssemblyName}.Languages.Lang", assembly);
        }


        public static string UILanguage { get; private set; }

        public static void Init(string cultureName)
        {
            CultureInfo culture;
            try
            {
                culture = new CultureInfo(cultureName);
                Thread.CurrentThread.CurrentUICulture = culture;
            }
            catch
            {
                culture = Thread.CurrentThread.CurrentUICulture;
            }

            UILanguage = culture.Name;

            LoadResourcesForCulture(culture);
        }

        private static void LoadResourcesForCulture(CultureInfo culture)
        {
            _resourceCache.Clear();

            try
            {
                var resourceSet = _resourceManager.GetResourceSet(culture, true, true);
                foreach (DictionaryEntry entry in resourceSet)
                {
                    var key = entry.Key?.ToString();
                    var value = entry.Value?.ToString();
                    if (key != null && value != null)
                        _resourceCache[key] = value;
                }
            }
            catch
            {
                // ignore errors
            }
        }

        public static string[] GetAvailableLanguages()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            var directories = Directory.GetDirectories(baseDir);

            var availableLanguages = new HashSet<string>() { "en-US", "zh-CN"};

            foreach (var dir in directories)
            {
                var cultureName = Path.GetFileName(dir);
                var expectedDll = Path.Combine(dir, $"{_mainAssemblyName}.resources.dll");

                if (File.Exists(expectedDll))
                {
                    try
                    {
                        // 验证是合法 CultureInfo
                        var _ = new CultureInfo(cultureName);
                        availableLanguages.Add(cultureName);
                    }
                    catch
                    {
                        // 忽略非法文化目录
                    }
                }
            }

            return availableLanguages.ToArray();
        }

        public static string G(LocalizedKeyBase key, params object[] slots)
        {
            var propertyName = key.ToString();
            try
            {
                if (!_attributeCache.TryGetValue(key, out var localizedValueAttribute))
                {
                    var propertyInfo = key.GetType().GetProperty(propertyName);
                    localizedValueAttribute = (LocalizedValueAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(LocalizedValueAttribute));

                    _attributeCache[key] = localizedValueAttribute;
                }

                if (!_resourceCache.TryGetValue(localizedValueAttribute.GUID, out var localizedValue))
                {
                    localizedValue = (localizedValueAttribute.ZH_CN != null && UILanguage == "zh-CN")
                        ? localizedValueAttribute.ZH_CN
                        : localizedValueAttribute.EN_US;
                }

                return string.Format(localizedValue, slots);
            }
            catch
            {
                return propertyName;
            }
        }


        #region 用于未来
        static void Diagnostics()
        {
            string newVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string jsonOutputPath = $"localized_output_{newVersion}.json";
            
            var (oldVersion, jsonInputPath) = FindClosestVersionOutput(newVersion);
            
            string diagnosticsPath = $"localized_diagnostics_{oldVersion}_vs_{newVersion}.txt";

            string txtOutputPath = $"localized_output_{newVersion}.txt";

            var duplicateGuidMap = new Dictionary<string, List<string>>();
            var duplicateEnMap = new Dictionary<string, List<string>>();
            var missingAttrList = new List<string>();
            var mismatchedPropertyTypeList = new List<string>();
            var nullPropertyList = new List<string>();

            var localizedFile = new LocalizedFile()
            {
                LocalizedClasses = new List<LocalizedClass>(),
                Version = newVersion
            };

            Assembly assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(LocalizedKeyBase).IsAssignableFrom(t));

            using (StreamWriter writer = new StreamWriter(txtOutputPath, false))
            {
                foreach (var type in types)
                {
                    var calssFile = new LocalizedClass()
                    {
                        ClassFullName = type.FullName,
                        LocalizedItem = new List<LocalizedItem>()
                    };

                    writer.WriteLine("//" + type.FullName);

                    var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

                    foreach (var prop in properties)
                    {
                        if (prop.PropertyType != type)
                        {
                            mismatchedPropertyTypeList.Add($"{type.FullName}.{prop.Name} => {prop.PropertyType.FullName}");
                        }

                        object value = prop.GetValue(null); // 读取静态属性值
                        if (value == null)
                        {
                            nullPropertyList.Add($"{type.FullName}.{prop.Name}");
                        }

                        var attr = prop.GetCustomAttributes(typeof(LocalizedValueAttribute), false)
                                       .FirstOrDefault() as LocalizedValueAttribute;

                        if (attr != null)
                        {
                            calssFile.LocalizedItem.Add( new LocalizedItem()
                            {
                                GUID = attr.GUID,
                                EN_US = attr.EN_US,
                                ZH_CN = attr.ZH_CN,
                                PropertyName = prop.Name,
                            });
                            writer.WriteLine($"{attr.GUID}\t{attr.EN_US}\t{attr.ZH_CN}\t{prop.Name}");

                            // 记录 GUID
                            if (!duplicateGuidMap.ContainsKey(attr.GUID))
                                duplicateGuidMap[attr.GUID] = new List<string>();
                            duplicateGuidMap[attr.GUID].Add($"{type.FullName}.{prop.Name}");

                            // 记录 EN_US
                            if (!duplicateEnMap.ContainsKey(attr.EN_US))
                                duplicateEnMap[attr.EN_US] = new List<string>();
                            duplicateEnMap[attr.EN_US].Add($"{type.FullName}.{prop.Name}");
                        }
                        else
                        {
                            missingAttrList.Add($"{type.FullName}.{prop.Name}");
                        }
                    }

                    localizedFile.LocalizedClasses.Add(calssFile);

                    writer.WriteLine();
                }
            }

            using (StreamWriter JsonWriter = new StreamWriter(jsonOutputPath, false))
            {
                JsonWriter.Write(JsonConvert.SerializeObject(localizedFile));
            }

            
            using (StreamWriter diagWriter = new StreamWriter(diagnosticsPath, false))
            {
                // Mismatched Property Type
                diagWriter.WriteLine("=== Properties with Type Mismatch ===");
                foreach (var line in mismatchedPropertyTypeList)
                {
                    diagWriter.WriteLine(line);
                }

                //Null Value
                diagWriter.WriteLine();
                diagWriter.WriteLine("=== Static Properties with Null Value ===");
                foreach (var line in nullPropertyList)
                {
                    diagWriter.WriteLine(line);
                }

                // Missing attributes
                diagWriter.WriteLine();
                diagWriter.WriteLine("=== Properties Without [LocalizedValueAttribute] ===");
                foreach (var missing in missingAttrList)
                {
                    diagWriter.WriteLine(missing);
                }

                // Duplicate GUIDs
                diagWriter.WriteLine();
                diagWriter.WriteLine("=== Duplicate GUIDs Detected ===");
                foreach (var kvp in duplicateGuidMap.Where(kvp => kvp.Value.Count > 1))
                {
                    diagWriter.WriteLine($"GUID: {kvp.Key}");
                    foreach (var propFullName in kvp.Value)
                    {
                        diagWriter.WriteLine(" - " + propFullName);
                    }
                }

                // Duplicate EN_US
                diagWriter.WriteLine();
                diagWriter.WriteLine("=== Duplicate EN_US Texts Detected ===");
                foreach (var kvp in duplicateEnMap.Where(kvp => kvp.Value.Count > 1))
                {
                    diagWriter.WriteLine($"EN_US: {kvp.Key}");
                    foreach (var propFullName in kvp.Value)
                    {
                        diagWriter.WriteLine(" - " + propFullName);
                    }
                }
            }


            if (File.Exists(jsonInputPath))
            {
                var oldJson = File.ReadAllText(jsonInputPath);
                var newJson = File.ReadAllText(jsonOutputPath);

                var oldData = JsonConvert.DeserializeObject<LocalizedFile>(oldJson);
                var newData = JsonConvert.DeserializeObject<LocalizedFile>(newJson);

                //var oldDict = oldData.ClassFiles
                //    .SelectMany(cls => cls.LocalizedItem.Select(item => new { item, cls.ClassFullName }))
                //    .ToDictionary(x => x.item.GUID, x => new { x.item.EN_US, x.item.ZH_CN, x.item.PropertyName, x.ClassFullName });
                //
                //var newDict = newData.ClassFiles
                //    .SelectMany(cls => cls.LocalizedItem.Select(item => new { item, cls.ClassFullName }))
                //    .ToDictionary(x => x.item.GUID, x => new { x.item.EN_US, x.item.ZH_CN, x.item.PropertyName, x.ClassFullName });

                var oldDict = oldData.LocalizedClasses
                    .SelectMany(cls => cls.LocalizedItem.Select(item => new { item, cls.ClassFullName }))
                    .GroupBy(x => x.item.GUID)
                    .ToDictionary(g => g.Key, g => new
                    {
                        g.First().item.EN_US,
                        g.First().item.ZH_CN,
                        g.First().item.PropertyName,
                        g.First().ClassFullName
                    });

                var newDict = newData.LocalizedClasses
                    .SelectMany(cls => cls.LocalizedItem.Select(item => new { item, cls.ClassFullName }))
                    .GroupBy(x => x.item.GUID)
                    .ToDictionary(g => g.Key, g => new
                    {
                        g.First().item.EN_US,
                        g.First().item.ZH_CN,
                        g.First().item.PropertyName,
                        g.First().ClassFullName
                    });

                var added = newDict.Keys.Except(oldDict.Keys).ToList();
                var removed = oldDict.Keys.Except(newDict.Keys).ToList();
                var modified = new List<string>();

                foreach (var guid in oldDict.Keys.Intersect(newDict.Keys))
                {
                    var oldItem = oldDict[guid];
                    var newItem = newDict[guid];

                    if (oldItem.EN_US != newItem.EN_US ||
                        oldItem.ZH_CN != newItem.ZH_CN ||
                        oldItem.PropertyName != newItem.PropertyName)
                    {
                        modified.Add(guid);
                    }
                }

                using (StreamWriter diagWriter = File.AppendText(diagnosticsPath))
                {
                    
                    //string oldVersion = oldData.Version ?? "Unknown";
                    //string newVersion = newData.Version ?? "Unknown";

                    diagWriter.WriteLine();
                    diagWriter.WriteLine("=== Version Comparison ===");
                    diagWriter.WriteLine($"Old Version: {oldVersion}");
                    diagWriter.WriteLine($"New Version: {newVersion}");

                    diagWriter.WriteLine();
                    diagWriter.WriteLine("=== Added Localized Items ===");
                    foreach (var guid in added)
                    {
                        var item = newDict[guid];
                        diagWriter.WriteLine($"{guid}\t{item.EN_US}\t{item.ZH_CN}\t{item.PropertyName}\t{item.ClassFullName}");
                    }

                    diagWriter.WriteLine();
                    diagWriter.WriteLine("=== Removed Localized Items ===");
                    foreach (var guid in removed)
                    {
                        var item = oldDict[guid];
                        diagWriter.WriteLine($"{guid}\t{item.EN_US}\t{item.ZH_CN}\t{item.PropertyName}\t{item.ClassFullName}");
                    }

                    diagWriter.WriteLine();
                    diagWriter.WriteLine("=== Modified Localized Items ===");
                    foreach (var guid in modified)
                    {
                        var oldItem = oldDict[guid];
                        var newItem = newDict[guid];
                        diagWriter.WriteLine($"GUID: {guid}");
                        diagWriter.WriteLine($"  OLD: {oldItem.EN_US}\t{oldItem.ZH_CN}\t{oldItem.PropertyName}\t{oldItem.ClassFullName}");
                        diagWriter.WriteLine($"  NEW: {newItem.EN_US}\t{newItem.ZH_CN}\t{newItem.PropertyName}\t{newItem.ClassFullName}");
                    }
                }
            }
        }

        static (string version, string path) FindClosestVersionOutput(string currentVersion)
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "localized_output_*.json");
            Version curVer = Version.Parse(currentVersion);

            string closestPath = null;
            Version closestVersion = null;

            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var versionPart = fileName.Replace("localized_output_", "");

                if (Version.TryParse(versionPart, out Version fileVersion))
                {
                    if (fileVersion < curVer)
                    {
                        if (closestVersion == null || fileVersion > closestVersion)
                        {
                            closestVersion = fileVersion;
                            closestPath = file;
                        }
                    }
                }
            }

            return (closestVersion?.ToString() ?? "none", closestPath);
        }

        class LocalizedFile
        { 
            public List<LocalizedClass> LocalizedClasses { get; set; }

            public string Version { get; set; }
        }

        class LocalizedClass
        {
            public string ClassFullName { get; set; }

            public List<LocalizedItem> LocalizedItem { get; set; }
        }

        class LocalizedItem
        {  
            public string GUID { get; set; }

            public string EN_US { get; set; }

            public string ZH_CN { get; set; }
            
            public string PropertyName {  get; set; }
        }
        #endregion
    }
}
