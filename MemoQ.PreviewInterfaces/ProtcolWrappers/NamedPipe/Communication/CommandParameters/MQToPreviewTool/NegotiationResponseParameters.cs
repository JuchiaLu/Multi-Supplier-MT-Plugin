namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    internal class NegotiationResponseParameters
    {
        /// <summary>
        /// The protocol version to be used. It can be null if memoQ was unable
        /// to select any communication protocol from the list specified by the
        /// preview tool.
        /// </summary>
        public string ProtocolVersion;
    }
}
