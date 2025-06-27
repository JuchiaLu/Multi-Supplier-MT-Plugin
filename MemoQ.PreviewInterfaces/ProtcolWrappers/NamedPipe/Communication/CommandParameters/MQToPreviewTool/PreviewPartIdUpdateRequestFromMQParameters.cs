using System;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class PreviewPartIdUpdateRequestFromMQParameters
    {
        /// <summary>
        /// The preview part identifiers.
        /// </summary>
        public string[] PreviewPartIds;
    }
}
