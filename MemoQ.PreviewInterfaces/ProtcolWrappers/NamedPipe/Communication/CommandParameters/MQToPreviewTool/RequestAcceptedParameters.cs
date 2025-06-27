using System;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class RequestAcceptedParameters
    {
        /// <summary>
        /// The type of the accepted command.
        /// </summary>
        public string CommandType;
    }
}
