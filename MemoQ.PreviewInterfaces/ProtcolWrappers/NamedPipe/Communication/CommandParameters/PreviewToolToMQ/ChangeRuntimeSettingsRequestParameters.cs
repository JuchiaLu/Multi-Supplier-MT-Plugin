using System;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class ChangeRuntimeSettingsRequestParameters
    {
        /// <summary>
        /// The unique identifier of the preview tool.
        /// </summary>
        public Guid PreviewToolId;

        /// <summary>
        /// The complexity of the preview content.
        /// </summary>
        public ContentComplexityLevel ContentComplexity;

        /// <summary>
        /// The names of the required properties.
        /// </summary>
        public string[] RequiredProperties;
    }
}
