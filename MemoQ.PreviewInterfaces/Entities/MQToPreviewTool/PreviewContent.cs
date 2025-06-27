namespace MemoQ.PreviewInterfaces.Entities
{
    public class PreviewContent
    {
        /// <summary>
        /// The complexity of the preview content.
        /// </summary>
        public readonly ContentComplexityLevel Complexity;

        /// <summary>
        /// The preview content.
        /// </summary>
        public readonly string Content;

        public PreviewContent(ContentComplexityLevel complexity, string content)
        {
            Complexity = complexity;
            Content = content;
        }
    }
}
