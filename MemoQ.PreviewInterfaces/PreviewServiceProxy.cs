using MemoQ.PreviewInterfaces.Entities;
using MemoQ.PreviewInterfaces.Exceptions;
using MemoQ.PreviewInterfaces.Interfaces;
using MemoQ.PreviewInterfaces.ProtcolWrappers;
using MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe;
//using MemoQ.PreviewInterfaces.ProtcolWrappers.REST;
using System;

namespace MemoQ.PreviewInterfaces
{
    public class PreviewServiceProxy : IDisposable
    {
        private const string DefaultNamedPipeBaseAddress = "MQ_PREVIEW_PIPE";
        private const string DefaultRestBaseAddress = "http://localhost:8088/MQPreviewService";

        private Guid connectedPreviewToolId;
        private readonly ProtocolWrapperBase protocolWrapper;
        private readonly CallbackHandler callbackHandler;

        public PreviewServiceProxy(IPreviewToolCallback previewToolCallback)
        {
            if (previewToolCallback == null)
                throw new ArgumentNullException(nameof(previewToolCallback));

            callbackHandler = new CallbackHandler(previewToolCallback);

            try { protocolWrapper = createProtocolWrapper(DefaultNamedPipeBaseAddress, CommunicationProtocols.NamedPipe); }
            catch { protocolWrapper = createProtocolWrapper(DefaultRestBaseAddress, CommunicationProtocols.REST); }
            protocolWrapper.ConnectionClosed += onConnectionClosed;
        }

        public PreviewServiceProxy(IPreviewToolCallback previewToolCallback, string baseAddress)
        {
            if (previewToolCallback == null)
                throw new ArgumentNullException(nameof(previewToolCallback));

            if (string.IsNullOrEmpty(baseAddress))
                throw new ArgumentNullException(nameof(baseAddress));

            callbackHandler = new CallbackHandler(previewToolCallback);

            Uri baseUri;
            if (Uri.TryCreate(baseAddress, UriKind.Absolute, out baseUri))
                protocolWrapper = createProtocolWrapper(baseAddress, CommunicationProtocols.REST);
            else protocolWrapper = createProtocolWrapper(baseAddress, CommunicationProtocols.NamedPipe);
            protocolWrapper.ConnectionClosed += onConnectionClosed;
        }

        public PreviewServiceProxy(IPreviewToolCallback previewToolCallback, string baseAddress, CommunicationProtocols communicationProtocol)
        {
            if (previewToolCallback == null)
                throw new ArgumentNullException(nameof(previewToolCallback));

            if (string.IsNullOrEmpty(baseAddress))
                throw new ArgumentNullException(nameof(baseAddress));

            callbackHandler = new CallbackHandler(previewToolCallback);

            protocolWrapper = createProtocolWrapper(baseAddress, communicationProtocol);
            protocolWrapper.ConnectionClosed += onConnectionClosed;
        }

        public Guid ConnectedPreviewToolId
        {
            get
            {
                lock (this)
                {
                    return connectedPreviewToolId;
                }
            }
        }

        public RequestStatus Register(RegistrationRequest registrationRequest)
        {
            lock (this)
            {
                assertPreviewToolIsNotYetConnected();

                var requestStatus = protocolWrapper.Register(registrationRequest);
                if (requestStatus.RequestAccepted)
                    connectedPreviewToolId = registrationRequest.PreviewToolId;

                return requestStatus;
            }
        }

        public RequestStatus Connect(Guid previewToolId)
        {
            lock (this)
            {
                assertPreviewToolIsNotYetConnected();

                var requestStatus = protocolWrapper.Connect(previewToolId);
                if (requestStatus.RequestAccepted)
                    connectedPreviewToolId = previewToolId;

                return requestStatus;
            }
        }

        public RequestStatus RequestRuntimeSettingsChange(ChangeRuntimeSettingsRequest changeRuntimeSettingsRequest)
        {
            lock (this)
            {
                assertPreviewToolIsAlreadyConnected();

                return protocolWrapper.RequestRuntimeSettingsChange(connectedPreviewToolId, changeRuntimeSettingsRequest);
            }
        }

        public RequestStatus ConnectAndRequestRuntimeSettingsChange(Guid previewToolId, ChangeRuntimeSettingsRequest changeRuntimeSettingsRequest)
        {
            lock (this)
            {
                assertPreviewToolIsNotYetConnected();

                var requestStatus = protocolWrapper.RequestRuntimeSettingsChange(previewToolId, changeRuntimeSettingsRequest);
                if (requestStatus.RequestAccepted)
                    connectedPreviewToolId = previewToolId;

                return requestStatus;
            }
        }

        public RequestStatus RequestContentUpdate(ContentUpdateRequestFromPreviewTool contentUpdateRequest)
        {
            lock (this)
            {
                assertPreviewToolIsAlreadyConnected();

                return protocolWrapper.RequestContentUpdate(connectedPreviewToolId, contentUpdateRequest);
            }
        }

        public RequestStatus ConnectAndRequestContentUpdate(Guid previewToolId, ContentUpdateRequestFromPreviewTool contentUpdateRequest)
        {
            lock (this)
            {
                assertPreviewToolIsNotYetConnected();

                var requestStatus = protocolWrapper.RequestContentUpdate(previewToolId, contentUpdateRequest);
                if (requestStatus.RequestAccepted)
                    connectedPreviewToolId = previewToolId;

                return requestStatus;
            }
        }

        public RequestStatus RequestHighlightChange(ChangeHighlightRequestFromPreviewTool changeHighlightRequest)
        {
            lock (this)
            {
                assertPreviewToolIsAlreadyConnected();

                return protocolWrapper.RequestHighlightChange(connectedPreviewToolId, changeHighlightRequest);
            }
        }

        public RequestStatus ConnectAndRequestHighlightChange(Guid previewToolId, ChangeHighlightRequestFromPreviewTool changeHighlightRequest)
        {
            lock (this)
            {
                assertPreviewToolIsNotYetConnected();

                var requestStatus = protocolWrapper.RequestHighlightChange(previewToolId, changeHighlightRequest);
                if (requestStatus.RequestAccepted)
                    connectedPreviewToolId = previewToolId;

                return requestStatus;
            }
        }

        public RequestStatus RequestPreviewPartIdUpdate()
        {
            lock (this)
            {
                assertPreviewToolIsAlreadyConnected();

                return protocolWrapper.RequestPreviewPartIdUpdate(connectedPreviewToolId);
            }
        }

        public RequestStatus ConnectAndRequestPreviewPartIdUpdate(Guid previewToolId)
        {
            lock (this)
            {
                assertPreviewToolIsNotYetConnected();

                var requestStatus = protocolWrapper.RequestPreviewPartIdUpdate(previewToolId);
                if (requestStatus.RequestAccepted)
                    connectedPreviewToolId = previewToolId;

                return requestStatus;
            }
        }

        public RequestStatus Disconnect()
        {
            lock (this)
            {
                assertPreviewToolIsAlreadyConnected();

                var requestStatus = protocolWrapper.Disconnect(connectedPreviewToolId);
                if (requestStatus.RequestAccepted)
                    connectedPreviewToolId = Guid.Empty;

                return requestStatus;
            }
        }

        public void Dispose()
        {
            callbackHandler.Stop();
        }

        private ProtocolWrapperBase createProtocolWrapper(string baseAddress, CommunicationProtocols communicationProtocol)
        {
            switch (communicationProtocol)
            {
                case CommunicationProtocols.NamedPipe:
                    return new NamedPipeProtocolWrapper(baseAddress, callbackHandler);
                //case CommunicationProtocols.REST:
                //    return new RestProtocolWrapper(baseAddress, callbackHandler);
                default:
                    throw new Exception("Unexpected case.");
            }
        }

        private void onConnectionClosed(object sender, EventArgs e)
        {
            lock (this)
            {
                protocolWrapper.ConnectionClosed -= onConnectionClosed;
                connectedPreviewToolId = Guid.Empty;
            }
        }

        private void assertPreviewToolIsNotYetConnected()
        {
            if (connectedPreviewToolId != Guid.Empty)
                throw new PreviewToolAlreadyConnectedException();
        }

        private void assertPreviewToolIsAlreadyConnected()
        {
            if (connectedPreviewToolId == Guid.Empty)
                throw new PreviewToolNotConnectedException();
        }
    }
}
