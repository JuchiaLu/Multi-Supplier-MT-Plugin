using System;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class ContentUpdateRequestFromPreviewToolParameters
    {
        /// <summary>
        /// The unique identifier of the preview tool.
        /// </summary>
        public Guid PreviewToolId;

        /// <summary>
        /// The requested preview part ids.
        /// </summary>
        public string[] PreviewPartIds;

        /// <summary>
        /// The target language codes.
        /// </summary>
        public string[] TargetLangCodes;
    }
}
