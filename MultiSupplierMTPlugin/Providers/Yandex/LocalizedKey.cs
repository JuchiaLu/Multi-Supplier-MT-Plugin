using MultiSupplierMTPlugin.Localized;

namespace MultiSupplierMTPlugin.Providers.Yandex
{
    class LocalizedKey : LocalizedKeyBase
    {
        public LocalizedKey(string name) : base(name)
        {
        }

        static LocalizedKey()
        {
            AutoInit<LocalizedKey>();
        }


        [LocalizedValue("5a57eb3d-acec-4747-a3b8-bf1657463244", "Yandex", "Yandex")]
        public static LocalizedKey Form { get; private set; }

        [LocalizedValue("6ab66d23-8ad9-4708-863d-da6f860fd0f2", "Authorization", "认证")]
        public static LocalizedKey GroupBoxAuthorization { get; private set; }

        [LocalizedValue("eefdc0d1-8bc4-4e29-af5c-d443d8a3891e", "Key | Token", "Key | Token")]
        public static LocalizedKey LinkLabelKeyOrToken { get; private set; }

        [LocalizedValue("cf1053a3-dcdf-426e-b8df-4bdf98f666ef", "Folder Id", "Folder Id")]
        public static LocalizedKey LabelFolderId { get; private set; }

        [LocalizedValue("bbd35cda-f93a-491e-8f01-d2473616c154", "Tyep", "类型")]
        public static LocalizedKey LabelTyep { get; private set; }

        [LocalizedValue("18298182-3522-42c8-a43a-457c749c9e23", "API Key", "API Key")]
        public static LocalizedKey RadioButtonApiKey { get; private set; }

        [LocalizedValue("ef6f1e5d-1721-4948-80e8-6e941ddd1769", "IAM Token", "IAM Token")]
        public static LocalizedKey RadioButtonIamToken { get; private set; }

        [LocalizedValue("747f916d-61ba-4880-b433-d8eb929632b1", "Glossary", "术语")]
        public static LocalizedKey GroupBoxGlossary { get; private set; }

        [LocalizedValue("668adef8-6235-4448-905e-975b312af0ef", "Exact", "精确形式")]
        public static LocalizedKey LabelGlossaryExact { get; private set; }

        [LocalizedValue("30809495-d14d-4d02-afe3-7ae6b82f8c2d", "Enable", "启用")]
        public static LocalizedKey RadioButtonExactEnable { get; private set; }

        [LocalizedValue("c74464bf-fc14-48b9-9c77-19fea4362083", "Disable", "禁用")]
        public static LocalizedKey RadioButtonExactDisable { get; private set; }

        [LocalizedValue("73fbd4ff-b4f9-4b3a-ae6a-b3f1ffe778e1", "Delimiter", "分隔符")]
        public static LocalizedKey LabelGlossaryDelimiter { get; private set; }

        [LocalizedValue("24c60832-fa49-4bc9-b33b-737ee86f94ab", "File Path", "文件路径")]
        public static LocalizedKey LabelGlossaryFilePath { get; private set; }

        [LocalizedValue("fb667f13-3f02-41c4-9f43-a3946d1158cd", "Select", "选择")]
        public static LocalizedKey ButtonGlossarySelect { get; private set; }

        [LocalizedValue("ed763852-8bda-4dab-b277-48c8aed85744", "Other", "其他")]
        public static LocalizedKey GroupBoxOther { get; private set; }

        [LocalizedValue("42fa1057-333b-4573-8d00-60a12e45ccb4", "Speller", "拼写检查")]
        public static LocalizedKey LabelSpeller { get; private set; }

        [LocalizedValue("7007841e-b598-4810-a18f-6e1722e29e7d", "Enable", "启用")]
        public static LocalizedKey RadioButtonSpellerEnable { get; private set; }

        [LocalizedValue("918b8e35-a170-4a86-ae18-811a82b73782", "Disable", "禁用")]
        public static LocalizedKey RadioButtonSpellerDisable { get; private set; }

        [LocalizedValue("3f54bf33-6398-4fc1-8253-964303c67f70", "Model", "模型")]
        public static LocalizedKey LabelModel { get; private set; }
    }
}
