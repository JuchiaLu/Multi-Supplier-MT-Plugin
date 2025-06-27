using System;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class RegistrationRequestParameters
    {
        /// <summary>
        /// The unique identifier of the preview tool.
        /// </summary>
        public Guid PreviewToolId;

        /// <summary>
        /// The name of the preview tool.
        /// </summary>
        public string PreviewToolName;

        /// <summary>
        /// The description of the preview tool.
        /// </summary>
        public string PreviewToolDescription;

        /// <summary>
        /// The automatic startup command line that will be used to start the preview tool automatically.
        /// The tool will not be started automatically by memoQ if this field is not specified.
        /// </summary>
        public string AutoStartupCommand;

        /// <summary>
        /// The regular expression is used to check if the stored preview identifier of the content
        /// belongs to the preview tool at hand or not.
        /// </summary>
        public string PreviewPartIdRegex;

        /// <summary>
        /// Indicates whether the preview tool requires the base url of the web preview.
        /// </summary>
        public bool RequiresWebPreviewBaseUrl;

        /// <summary>
        /// The complexity level of the offered text when sends it to the tool. 
        /// </summary>
        public ContentComplexityLevel ContentComplexity;

        /// <summary>
        /// The names of the required properties.
        /// </summary>
        public string[] RequiredProperties;
    }
}
