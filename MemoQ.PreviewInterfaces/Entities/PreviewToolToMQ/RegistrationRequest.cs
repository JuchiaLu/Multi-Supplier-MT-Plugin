using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MemoQ.PreviewInterfaces.Entities
{
    public class RegistrationRequest
    {
        /// <summary>
        /// The unique identifier of the preview tool.
        /// </summary>
        public readonly Guid PreviewToolId;

        /// <summary>
        /// The name of the preview tool.
        /// </summary>
        public readonly string PreviewToolName;

        /// <summary>
        /// The description of the preview tool.
        /// </summary>
        public readonly string PreviewToolDescription;

        /// <summary>
        /// The automatic startup command line that will be used to start the preview tool automatically.
        /// The tool will not be started automatically by memoQ if this field is not specified.
        /// </summary>
        public readonly string AutoStartupCommand;

        /// <summary>
        /// The regular expression is used to check if the stored preview identifier of the content
        /// belongs to the preview tool at hand or not.
        /// </summary>
        public readonly string PreviewPartIdRegex;

        /// <summary>
        /// Indicates whether the preview tool requires the base url of the web preview.
        /// </summary>
        public readonly bool RequiresWebPreviewBaseUrl;

        /// <summary>
        /// The complexity level of the offered text when sends it to the tool. 
        /// </summary>
        public readonly ContentComplexityLevel ContentComplexity;

        /// <summary>
        /// The names of the required properties.
        /// </summary>
        public readonly string[] RequiredProperties;

        public RegistrationRequest(Guid previewToolId, string previewToolName, string previewToolDescription, string autoStartupCommand, string previewPartIdRegex, bool requiresWebPreviewBaseUrl, ContentComplexityLevel contentComplexity, string[] requiredProperties)
        {
            if (previewToolId == Guid.Empty)
                throw new ArgumentException("The id of the preview tool cannot be empty guid.", nameof(previewToolId));

            if (string.IsNullOrWhiteSpace(previewToolName))
                throw new ArgumentException("The name of the preview tool cannot be empty.", nameof(previewToolName));

            if (string.IsNullOrWhiteSpace(previewPartIdRegex))
                throw new ArgumentException("The preview part id regex cannot be empty.", nameof(previewPartIdRegex));
            else
            {
                try
                {
                    var regex = new Regex(previewPartIdRegex);
                }
                catch
                {
                    throw new ArgumentException("The preview part id regex is invalid.", nameof(previewPartIdRegex));
                }
            }

            if (requiredProperties == null)
                throw new ArgumentNullException(nameof(requiredProperties));
            else
            {
                foreach (var requiredProperty in requiredProperties)
                {
                    if (!PropertyNames.SupportedProperties.Contains(requiredProperty))
                        throw new ArgumentException($"The property {requiredProperty} is not supported.");
                }
            }

            PreviewToolId = previewToolId;
            PreviewToolName = previewToolName;
            PreviewToolDescription = previewToolDescription;
            AutoStartupCommand = autoStartupCommand;
            PreviewPartIdRegex = previewPartIdRegex;
            RequiresWebPreviewBaseUrl = requiresWebPreviewBaseUrl;
            ContentComplexity = contentComplexity;
            RequiredProperties = requiredProperties;
        }
    }
}
