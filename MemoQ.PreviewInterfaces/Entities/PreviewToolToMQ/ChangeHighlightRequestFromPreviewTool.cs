using System;

namespace MemoQ.PreviewInterfaces.Entities
{
    public class ChangeHighlightRequestFromPreviewTool
    {
        /// <summary>
        /// The identifier of the preview part.
        /// </summary>
        public readonly string PreviewPartId;

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
        public readonly string SourceContent;

        /// <summary>
        /// The target content of the preview part.
        /// </summary>
        public readonly string TargetContent;

        /// <summary>
        /// The focused range on the source side.
        /// </summary>
        public readonly FocusedRange SourceFocusedRange;

        /// <summary>
        /// The focused range on the target side.
        /// </summary>
        public readonly FocusedRange TargetFocusedRange;

        public ChangeHighlightRequestFromPreviewTool(string previewPartId, string sourceLangCode, string targetLangCode, string sourceContent, string targetContent, FocusedRange sourceFocusedRange, FocusedRange targetFocusedRange)
        {
            if (string.IsNullOrWhiteSpace(previewPartId))
                throw new ArgumentException("The id of the preview part cannot be empty.", nameof(previewPartId));

            if (sourceFocusedRange != null)
            {
                if (sourceFocusedRange.StartIndex < 0 || sourceFocusedRange.Length < 0 || sourceContent == null ||
                    sourceFocusedRange.StartIndex + sourceFocusedRange.Length > sourceContent.Length)
                    throw new ArgumentException("The source focused range is not valid.", nameof(sourceFocusedRange));
            }

            if (targetFocusedRange != null)
            {
                if (targetFocusedRange.StartIndex < 0 || targetFocusedRange.Length < 0 || targetContent == null ||
                    targetFocusedRange.StartIndex + targetFocusedRange.Length > targetContent.Length)
                    throw new ArgumentException("The target focused range is not valid.", nameof(targetFocusedRange));
            }

            PreviewPartId = previewPartId;
            SourceLangCode = sourceLangCode;
            TargetLangCode = targetLangCode;
            SourceContent = sourceContent;
            TargetContent = targetContent;
            SourceFocusedRange = sourceFocusedRange;
            TargetFocusedRange = targetFocusedRange;
        }
    }
}
