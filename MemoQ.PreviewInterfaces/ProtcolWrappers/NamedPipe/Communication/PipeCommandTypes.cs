namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    public static class PipeCommandTypes
    {
        public const string NegotiationRequest = "negotiation-request";
        public const string NegotiationResponse = "negotiation-response";
        public const string RegistrationRequest = "registration-request";
        public const string ConnectionRequest = "connection-request";
        public const string ChangeRuntimeSettingsRequest = "change-runtime-settings-request";
        public const string ContentUpdateRequestFromPreviewTool = "content-update-request-from-preview-tool";
        public const string ContentUpdateRequestFromMQ = "content-update-request-from-mq";
        public const string ChangeHighlightRequestFromPreviewTool = "change-highlight-request-from-preview-tool";
        public const string ChangeHighlightRequestFromMQ = "change-highlight-request-from-mq";
        public const string PreviewPartIdUpdateRequestFromPreviewTool = "preview-part-id-update-request-from-preview-tool";
        public const string PreviewPartIdUpdateRequestFromMQ = "preview-part-id-update-request-from-mq";
        public const string RequestAccepted = "request-accepted";
        public const string RequestRefused = "request-refused";
        public const string InvalidRequest = "invalid-request";
    }
}
