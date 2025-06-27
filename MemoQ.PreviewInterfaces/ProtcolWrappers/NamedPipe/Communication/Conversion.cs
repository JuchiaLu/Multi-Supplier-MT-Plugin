using MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters;
using System;
using System.Linq;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication
{
    internal static class Conversion
    {
        public static CommandParameters.RegistrationRequestParameters Convert(this Entities.RegistrationRequest request)
        {
            return new CommandParameters.RegistrationRequestParameters()
            {
                PreviewToolId = request.PreviewToolId,
                PreviewToolName = request.PreviewToolName,
                PreviewToolDescription = request.PreviewToolDescription,
                AutoStartupCommand = request.AutoStartupCommand,
                PreviewPartIdRegex = request.PreviewPartIdRegex,
                RequiresWebPreviewBaseUrl = request.RequiresWebPreviewBaseUrl,
                ContentComplexity = request.ContentComplexity.Convert(),
                RequiredProperties = request.RequiredProperties
            };
        }

        public static CommandParameters.ContentComplexityLevel Convert(this Entities.ContentComplexityLevel contentComplexityLevel)
        {
            switch (contentComplexityLevel)
            {
                case Entities.ContentComplexityLevel.Minimal:
                    return CommandParameters.ContentComplexityLevel.Minimal;
                case Entities.ContentComplexityLevel.PlainWithInterpretedFormatting:
                    return CommandParameters.ContentComplexityLevel.PlainWithInterpretedFormatting;
                default:
                    throw new Exception($"Unexpected complexity level: {contentComplexityLevel}.");
            }
        }

        public static CommandParameters.ChangeRuntimeSettingsRequestParameters Convert(this Entities.ChangeRuntimeSettingsRequest request, Guid previewToolId)
        {
            return new ChangeRuntimeSettingsRequestParameters()
            {
                PreviewToolId = previewToolId,
                ContentComplexity = request.ContentComplexity.Convert(),
                RequiredProperties = request.RequiredProperties
            };
        }

        public static CommandParameters.ContentUpdateRequestFromPreviewToolParameters Convert(this Entities.ContentUpdateRequestFromPreviewTool request, Guid previewToolId)
        {
            return new CommandParameters.ContentUpdateRequestFromPreviewToolParameters()
            {
                PreviewToolId = previewToolId,
                PreviewPartIds = request.PreviewPartIds,
                TargetLangCodes = request.TargetLangCodes
            };
        }

        public static CommandParameters.ChangeHighlightRequestFromPreviewToolParameters Convert(this Entities.ChangeHighlightRequestFromPreviewTool request, Guid previewToolId)
        {
            return new CommandParameters.ChangeHighlightRequestFromPreviewToolParameters()
            {
                PreviewToolId = previewToolId,
                PreviewPartId = request.PreviewPartId,
                SourceLangCode = request.SourceLangCode,
                TargetLangCode = request.TargetLangCode,
                SourceContent = request.SourceContent,
                TargetContent = request.TargetContent,
                SourceFocusedRange = request.SourceFocusedRange == null ? null : request.SourceFocusedRange.Convert(),
                TargetFocusedRange = request.TargetFocusedRange == null ? null : request.TargetFocusedRange.Convert()
            };
        }

        public static CommandParameters.FocusedRange Convert(this Entities.FocusedRange focusedRange)
        {
            return new CommandParameters.FocusedRange()
            {
                StartIndex = focusedRange.StartIndex,
                Length = focusedRange.Length
            };
        }

        public static Entities.RequestStatus Convert(this CommandParameters.RequestAcceptedParameters response)
        {
            return Entities.RequestStatus.Success();
        }

        public static Entities.RequestStatus Convert(this CommandParameters.RequestRefusedParameters response)
        {
            switch (response.ErrorCode)
            {
                case CommandParameters.ErrorCodes.RegistrationRequestRefused:
                    return Entities.RequestStatus.Failed(Entities.ErrorCodes.RegistrationRequestRefused, response.ErrorMessage);
                case CommandParameters.ErrorCodes.NoEnabledPreviewToolWithThisId:
                    return Entities.RequestStatus.Failed(Entities.ErrorCodes.NoEnabledPreviewToolWithThisId, response.ErrorMessage);
                case CommandParameters.ErrorCodes.PreviewToolAlreadyConnectedWithThisId:
                    return Entities.RequestStatus.Failed(Entities.ErrorCodes.PreviewToolAlreadyConnectedWithThisId, response.ErrorMessage);
                default:
                    throw new Exception("Unexpected case.");
            }
        }

        public static Entities.RequestStatus Convert(this CommandParameters.InvalidRequestParameters response)
        {
            return Entities.RequestStatus.Failed(Entities.ErrorCodes.InvalidRequestParameters, response.ErrorMessage);
        }

        public static Entities.ContentUpdateRequestFromMQ Convert(this CommandParameters.ContentUpdateRequestFromMQParameters request)
        {
            return new Entities.ContentUpdateRequestFromMQ(request.PreviewParts.Select(p => p.Convert()).ToArray());
        }

        public static Entities.PreviewPart Convert(this CommandParameters.PreviewPart previewPart)
        {
            return new Entities.PreviewPart(
                previewPart.PreviewPartId,
                previewPart.PreviewProperties.Select(p => p.Convert()).ToArray(),
                previewPart.SourceDocument.Convert(),
                previewPart.SourceLangCode,
                previewPart.TargetLangCode,
                previewPart.SourceContent.Convert(),
                previewPart.TargetContent.Convert());
        }

        public static Entities.PreviewPartWithFocusedRange Convert(this CommandParameters.PreviewPartWithFocusedRange previewPart)
        {
            return new Entities.PreviewPartWithFocusedRange(
                previewPart.PreviewPartId,
                previewPart.PreviewProperties.Select(p => p.Convert()).ToArray(),
                previewPart.SourceDocument.Convert(),
                previewPart.SourceLangCode,
                previewPart.TargetLangCode,
                previewPart.SourceContent.Convert(),
                previewPart.TargetContent.Convert(),
                previewPart.SourceFocusedRange == null ? null : previewPart.SourceFocusedRange.Convert(),
                previewPart.TargetFocusedRange == null ? null : previewPart.TargetFocusedRange.Convert());
        }

        public static Entities.FocusedRange Convert(this CommandParameters.FocusedRange focusedRange)
        {
            return new Entities.FocusedRange(focusedRange.StartIndex, focusedRange.Length);
        }

        public static Entities.PreviewProperty Convert(this CommandParameters.PreviewProperty previewProperty)
        {
            return new Entities.PreviewProperty(previewProperty.Name, previewProperty.Value);
        }

        public static Entities.SourceDocument Convert(this CommandParameters.SourceDocument sourceDocument)
        {
            return new Entities.SourceDocument(sourceDocument.DocumentGuid, sourceDocument.DocumentName, sourceDocument.ImportPath);
        }

        public static Entities.PreviewContent Convert(this CommandParameters.PreviewContent previewContent)
        {
            return new Entities.PreviewContent(
                previewContent.Complexity.Convert(),
                previewContent.Content);
        }

        public static Entities.ContentComplexityLevel Convert(this CommandParameters.ContentComplexityLevel contentComplexityLevel)
        {
            switch (contentComplexityLevel)
            {
                case CommandParameters.ContentComplexityLevel.Minimal:
                    return Entities.ContentComplexityLevel.Minimal;
                case CommandParameters.ContentComplexityLevel.PlainWithInterpretedFormatting:
                    return Entities.ContentComplexityLevel.PlainWithInterpretedFormatting;
                default:
                    throw new Exception($"Unexpected complexity level: {contentComplexityLevel}.");
            }
        }

        public static Entities.ChangeHighlightRequestFromMQ Convert(this CommandParameters.ChangeHighlightRequestFromMQParameters request)
        {
            return new Entities.ChangeHighlightRequestFromMQ(request.ActivePreviewParts.Select(p => p.Convert()).ToArray());
        }

        public static Entities.PreviewPartIdUpdateRequestFromMQ Convert(this CommandParameters.PreviewPartIdUpdateRequestFromMQParameters request)
        {
            return new Entities.PreviewPartIdUpdateRequestFromMQ(request.PreviewPartIds);
        }
    }
}
