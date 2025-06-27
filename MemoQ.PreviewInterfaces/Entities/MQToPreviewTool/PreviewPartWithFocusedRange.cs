namespace MemoQ.PreviewInterfaces.Entities
{
    public class PreviewPartWithFocusedRange : PreviewPart
    {
        /// <summary>
        /// The focused range on the source side.
        /// </summary>
        public readonly FocusedRange SourceFocusedRange;

        /// <summary>
        /// The focused range on the target side.
        /// </summary>
        public readonly FocusedRange TargetFocusedRange;

        public PreviewPartWithFocusedRange(string previewPartId, PreviewProperty[] previewProperties, SourceDocument sourceDocument, string sourceLangCode, string targetLangCode, PreviewContent sourceContent, PreviewContent targetContent, FocusedRange sourceFocusedRange, FocusedRange targetFocusedRange)
            : base(previewPartId, previewProperties, sourceDocument, sourceLangCode, targetLangCode, sourceContent, targetContent)
        {
            SourceFocusedRange = sourceFocusedRange;
            TargetFocusedRange = targetFocusedRange;
        }
    }
}
