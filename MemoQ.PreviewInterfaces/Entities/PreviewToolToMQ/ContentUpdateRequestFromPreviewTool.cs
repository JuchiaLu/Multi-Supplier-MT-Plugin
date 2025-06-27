using System;

namespace MemoQ.PreviewInterfaces.Entities
{
    public class ContentUpdateRequestFromPreviewTool
    {
        /// <summary>
        /// The requested preview part ids.
        /// </summary>
        public readonly string[] PreviewPartIds;

        /// <summary>
        /// The target language codes.
        /// </summary>
        public readonly string[] TargetLangCodes;

        public ContentUpdateRequestFromPreviewTool(string[] previewPartIds, string[] targetLangCodes)
        {
            if (previewPartIds == null || previewPartIds.Length == 0)
                throw new ArgumentException("There is no preview part id in the request.", nameof(previewPartIds));

            foreach (var previewPartId in previewPartIds)
            {
                if (string.IsNullOrWhiteSpace(previewPartId))
                    throw new ArgumentException("There is at least one invalid preview part id.", nameof(previewPartIds));
            }

            if (targetLangCodes != null)
            {
                foreach (var targetLangCode in targetLangCodes)
                {
                    if (string.IsNullOrWhiteSpace(targetLangCode))
                        throw new ArgumentException("There is at least one invalid target language code.", nameof(targetLangCodes));
                }
            }

            PreviewPartIds = previewPartIds;
            TargetLangCodes = targetLangCodes;
        }
    }
}
