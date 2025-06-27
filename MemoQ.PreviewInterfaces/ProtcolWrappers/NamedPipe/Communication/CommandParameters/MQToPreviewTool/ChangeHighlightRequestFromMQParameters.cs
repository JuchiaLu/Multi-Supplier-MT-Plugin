using System;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class ChangeHighlightRequestFromMQParameters
    {
        /// <summary>
        /// The active preview parts.
        /// </summary>
        public PreviewPartWithFocusedRange[] ActivePreviewParts;
    }
}
