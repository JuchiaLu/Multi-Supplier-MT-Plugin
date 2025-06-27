namespace MemoQ.PreviewInterfaces.Entities
{
    public class ChangeHighlightRequestFromMQ
    {
        /// <summary>
        /// The active preview parts.
        /// </summary>
        public readonly PreviewPartWithFocusedRange[] ActivePreviewParts;

        public ChangeHighlightRequestFromMQ(PreviewPartWithFocusedRange[] activePreviewParts)
        {
            ActivePreviewParts = activePreviewParts;
        }
    }
}
