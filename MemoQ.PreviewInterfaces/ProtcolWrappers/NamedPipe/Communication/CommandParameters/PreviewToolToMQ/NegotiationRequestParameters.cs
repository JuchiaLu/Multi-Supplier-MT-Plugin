using System;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class NegotiationRequestParameters
    {
        /// <summary>
        /// The list of the protocol versions known by the preview tool.
        /// </summary>
        public string[] KnownProtocolVersions;

    }
}
