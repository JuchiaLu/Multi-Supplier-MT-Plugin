using System;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class ChangeHighlightRequestFromPreviewToolParameters
    {
        /// <summary>
        /// The unique identifier of the preview tool.
        /// </summary>
        public Guid PreviewToolId;

        /// <summary>
        /// The identifier of the preview part.
        /// </summary>
        public string PreviewPartId;

        /// <summary>
        /// The source language of the preview part.
        /// </summary>
        public string SourceLangCode;

        /// <summary>
        /// The target language of the preview part.
        /// </summary>
        public string TargetLangCode;

        /// <summary>
        /// The source content of the preview part.
        /// </summary>
        public string SourceContent;

        /// <summary>
        /// The target content of the preview part.
        /// </summary>
        public string TargetContent;

        /// <summary>
        /// The focused range on the source side.
        /// </summary>
        public FocusedRange SourceFocusedRange;

        /// <summary>
        /// The focused range on the target side.
        /// </summary>
        public FocusedRange TargetFocusedRange;
    }
}
