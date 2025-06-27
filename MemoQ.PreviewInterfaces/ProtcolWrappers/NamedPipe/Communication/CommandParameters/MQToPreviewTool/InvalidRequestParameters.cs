using System;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class InvalidRequestParameters
    {
        /// <summary>
        /// The original request.
        /// </summary>
        public PipeCommand OriginalRequest;

        /// <summary>
        /// The description of the problem.
        /// </summary>
        public string ErrorMessage;
    }
}
