using MemoQ.PreviewInterfaces.Entities;
using System;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers
{
    internal abstract class ProtocolWrapperBase
    {
        protected readonly string BaseAddress;
        protected readonly CallbackHandler CallbackHandler;

        public event EventHandler ConnectionClosed;

        public ProtocolWrapperBase(string baseAddress, CallbackHandler callbackHandler)
        {
            BaseAddress = baseAddress;
            CallbackHandler = callbackHandler;
        }

        public abstract RequestStatus Register(RegistrationRequest registrationRequest);

        public abstract RequestStatus Connect(Guid previewToolId);

        public abstract RequestStatus RequestRuntimeSettingsChange(Guid previewToolId, ChangeRuntimeSettingsRequest changeRuntimeSettingsRequest);

        public abstract RequestStatus RequestContentUpdate(Guid previewToolId, ContentUpdateRequestFromPreviewTool contentUpdateRequest);

        public abstract RequestStatus RequestHighlightChange(Guid previewToolId, ChangeHighlightRequestFromPreviewTool changeHighlightRequest);

        public abstract RequestStatus RequestPreviewPartIdUpdate(Guid previewToolId);

        public abstract RequestStatus Disconnect(Guid previewToolId);

        protected void OnConnectionClosed()
        {
            ConnectionClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}
