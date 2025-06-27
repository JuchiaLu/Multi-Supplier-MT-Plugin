namespace MemoQ.PreviewInterfaces.Entities
{
    public class ContentUpdateRequestFromMQ
    {
        /// <summary>
        /// The preview parts.
        /// </summary>
        public readonly PreviewPart[] PreviewParts;

        public ContentUpdateRequestFromMQ(PreviewPart[] previewParts)
        {
            PreviewParts = previewParts;
        }
    }
}
