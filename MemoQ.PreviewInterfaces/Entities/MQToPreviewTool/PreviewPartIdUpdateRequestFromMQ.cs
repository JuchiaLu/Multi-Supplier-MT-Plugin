namespace MemoQ.PreviewInterfaces.Entities
{
    public class PreviewPartIdUpdateRequestFromMQ
    {
        /// <summary>
        /// The preview part identifiers.
        /// </summary>
        public readonly string[] PreviewPartIds;

        public PreviewPartIdUpdateRequestFromMQ(string[] previewPartIds)
        {
            PreviewPartIds = previewPartIds;
        }
    }
}
