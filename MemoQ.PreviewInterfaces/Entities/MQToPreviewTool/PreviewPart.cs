namespace MemoQ.PreviewInterfaces.Entities
{
    public class PreviewPart
    {
        /// <summary>
        /// The identifier of the preview part.
        /// </summary>
        public readonly string PreviewPartId;

        /// <summary>
        /// The preview properties.
        /// </summary>
        public readonly PreviewProperty[] PreviewProperties;

        /// <summary>
        /// The source document containing the preview part.
        /// </summary>
        public readonly SourceDocument SourceDocument;

        /// <summary>
        /// The source language of the preview part.
        /// </summary>
        public readonly string SourceLangCode;

        /// <summary>
        /// The target language of the preview part.
        /// </summary>
        public readonly string TargetLangCode;

        /// <summary>
        /// The source content of the preview part.
        /// </summary>
        public readonly PreviewContent SourceContent;

        /// <summary>
        /// The target content of the preview part.
        /// </summary>
        public readonly PreviewContent TargetContent;

        public PreviewPart(string previewPartId, PreviewProperty[] previewProperties, SourceDocument sourceDocument, string sourceLangCode, string targetLangCode, PreviewContent sourceContent, PreviewContent targetContent)
        {
            PreviewPartId = previewPartId;
            PreviewProperties = previewProperties;
            SourceDocument = sourceDocument;
            SourceLangCode = sourceLangCode;
            TargetLangCode = targetLangCode;
            SourceContent = sourceContent;
            TargetContent = targetContent;
        }
    }
}
