namespace MemoQ.PreviewInterfaces.Entities
{
    public static class PropertyNames
    {
        public const string WebPreviewBaseUrl = "WebPreviewBaseUrl";
        public const string Wpm = "Wpm";
        public const string Cps = "Cps";
        public const string LineLengthLimit = "LineLengthLimit";
        public const string WordCount = "WordCount";
        public const string CharCount = "CharCount";

        public static readonly string[] SupportedProperties = new string[]
        {
            WebPreviewBaseUrl,
            Wpm,
            Cps,
            LineLengthLimit,
            WordCount,
            CharCount
        };
    }
}
