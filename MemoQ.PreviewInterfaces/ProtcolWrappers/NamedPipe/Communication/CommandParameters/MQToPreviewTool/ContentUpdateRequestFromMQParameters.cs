using System;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class ContentUpdateRequestFromMQParameters
    {
        /// <summary>
        /// The preview parts.
        /// </summary>
        public PreviewPart[] PreviewParts;
    }
}
