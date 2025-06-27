using MemoQ.PreviewInterfaces.Entities;
using MemoQ.PreviewInterfaces.Exceptions;
using MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication;
using MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe
{
    internal class NamedPipeProtocolWrapper : ProtocolWrapperBase
    {
        private readonly AutoResetEvent negotiationResponseReceived;
        private readonly AutoResetEvent registrationResponseReceived;
        private readonly AutoResetEvent connectionResponseReceived;
        private readonly AutoResetEvent changeRuntimeSettingsReponseReceived;
        private readonly AutoResetEvent contentUpdateReponseReceived;
        private readonly AutoResetEvent changeHighlightReponseReceived;
        private readonly AutoResetEvent previewPartIdUpdateReponseReceived;
        private readonly ClientPipe pipe;

        private NegotiationResponseParameters negotiationResponse;
        private RequestStatus registrationRequestStatus;
        private RequestStatus connectionRequestStatus;
        private RequestStatus changeRuntimeSettingsRequestStatus;
        private RequestStatus contentUpdateRequestStatus;
        private RequestStatus changeHighlightRequestStatus;
        private RequestStatus previewPartIdUpdateRequestStatus;

        public NamedPipeProtocolWrapper(string baseAddress, CallbackHandler callbackHandler)
            : base(baseAddress, callbackHandler)
        {
            negotiationResponseReceived = new AutoResetEvent(false);
            registrationResponseReceived = new AutoResetEvent(false);
            connectionResponseReceived = new AutoResetEvent(false);
            changeRuntimeSettingsReponseReceived = new AutoResetEvent(false);
            contentUpdateReponseReceived = new AutoResetEvent(false);
            changeHighlightReponseReceived = new AutoResetEvent(false);
            previewPartIdUpdateReponseReceived = new AutoResetEvent(false);

            pipe = new ClientPipe(baseAddress);
            pipe.OnDataRead += onDataRead;
            pipe.OnPipeClosed += onPipeClosed;

            sendCommand(PipeCommandTypes.NegotiationRequest, new NegotiationRequestParameters() { KnownProtocolVersions = new string[] { ProtocolVersions.V1 } }, negotiationResponseReceived);
            if (string.IsNullOrEmpty(negotiationResponse.ProtocolVersion))
                throw new NegotiationFailedException();
        }

        public override RequestStatus Register(RegistrationRequest registrationRequest)
        {
            sendCommand(PipeCommandTypes.RegistrationRequest, registrationRequest.Convert(), registrationResponseReceived);
            return registrationRequestStatus;
        }

        public override RequestStatus Connect(Guid previewToolId)
        {
            sendCommand(PipeCommandTypes.ConnectionRequest, new SimpleConnectionRequestParameters() { PreviewToolId = previewToolId }, connectionResponseReceived);
            return connectionRequestStatus;
        }

        public override RequestStatus RequestRuntimeSettingsChange(Guid previewToolId, ChangeRuntimeSettingsRequest changeRuntimeSettingsRequest)
        {
            sendCommand(PipeCommandTypes.ChangeRuntimeSettingsRequest, changeRuntimeSettingsRequest.Convert(previewToolId), changeRuntimeSettingsReponseReceived);
            return changeRuntimeSettingsRequestStatus;
        }

        public override RequestStatus RequestContentUpdate(Guid previewToolId, ContentUpdateRequestFromPreviewTool contentUpdateRequest)
        {
            sendCommand(PipeCommandTypes.ContentUpdateRequestFromPreviewTool, contentUpdateRequest.Convert(previewToolId), contentUpdateReponseReceived);
            return contentUpdateRequestStatus;
        }

        public override RequestStatus RequestHighlightChange(Guid previewToolId, ChangeHighlightRequestFromPreviewTool changeHighlightRequest)
        {
            sendCommand(PipeCommandTypes.ChangeHighlightRequestFromPreviewTool, changeHighlightRequest.Convert(previewToolId), changeHighlightReponseReceived);
            return changeHighlightRequestStatus;
        }

        public override RequestStatus RequestPreviewPartIdUpdate(Guid previewToolId)
        {
            sendCommand(PipeCommandTypes.PreviewPartIdUpdateRequestFromPreviewTool, new PreviewPartIdUpdateRequestFromPreviewToolParameters() { PreviewToolId = previewToolId }, previewPartIdUpdateReponseReceived);
            return previewPartIdUpdateRequestStatus;
        }

        public override RequestStatus Disconnect(Guid previewToolId)
        {
            pipe.Close();

            return RequestStatus.Success();
        }

        private void sendCommand(string commandType, object commandParameters, AutoResetEvent waithHandle)
        {
            pipe.EnsureIsConnected();

            waithHandle.Reset();
            pipe.SendCommandAsync(commandType, commandParameters);
            waithHandle.WaitOne();
        }

        private void onDataRead(object sender, PipeEventArgs e)
        {
            var jsonSerializedPipeCommand = Encoding.UTF8.GetString(e.Data);
            var pipeCommand = JsonConvert.DeserializeObject<PipeCommand>(jsonSerializedPipeCommand);
            dynamic parsedParameters = JsonConvert.DeserializeObject(pipeCommand.CommandParameters.ToString());

            if (pipeCommand.CommandType == PipeCommandTypes.InvalidRequest)
            {
                var invalidRequestParameters = JsonConvert.DeserializeObject<InvalidRequestParameters>(pipeCommand.CommandParameters.ToString());
                processCommandResponse(invalidRequestParameters.OriginalRequest.CommandType, invalidRequestParameters.Convert());
            }
            else if (pipeCommand.CommandType == PipeCommandTypes.RequestAccepted)
            {
                var requestAcceptedParameters = JsonConvert.DeserializeObject<RequestAcceptedParameters>(pipeCommand.CommandParameters.ToString());
                processCommandResponse(requestAcceptedParameters.CommandType, requestAcceptedParameters.Convert());
            }
            else if (pipeCommand.CommandType == PipeCommandTypes.RequestRefused)
            {
                var requestRefusedParameters = JsonConvert.DeserializeObject<RequestRefusedParameters>(pipeCommand.CommandParameters.ToString());
                processCommandResponse(requestRefusedParameters.CommandType, requestRefusedParameters.Convert());
            }
            else if (pipeCommand.CommandType == PipeCommandTypes.NegotiationResponse)
            {
                negotiationResponse = JsonConvert.DeserializeObject<NegotiationResponseParameters>(pipeCommand.CommandParameters.ToString());
                negotiationResponseReceived.Set();
            }
            else if (pipeCommand.CommandType == PipeCommandTypes.ContentUpdateRequestFromMQ)
            {
                var contentUpdateRequest = JsonConvert.DeserializeObject<ContentUpdateRequestFromMQParameters>(pipeCommand.CommandParameters.ToString()).Convert();
                CallbackHandler.QueueContentUpdateRequest(contentUpdateRequest);
            }
            else if (pipeCommand.CommandType == PipeCommandTypes.ChangeHighlightRequestFromMQ)
            {
                var changeHighlightRequest = JsonConvert.DeserializeObject<ChangeHighlightRequestFromMQParameters>(pipeCommand.CommandParameters.ToString()).Convert();
                CallbackHandler.QueueChangeHighlightRequest(changeHighlightRequest);
            }
            else if (pipeCommand.CommandType == PipeCommandTypes.PreviewPartIdUpdateRequestFromMQ)
            {
                var previewPartIdUpdateRequest = JsonConvert.DeserializeObject<PreviewPartIdUpdateRequestFromMQParameters>(pipeCommand.CommandParameters.ToString()).Convert();
                CallbackHandler.QueuePreviewPartIdUpdateRequest(previewPartIdUpdateRequest);
            }
        }

        private void onPipeClosed(object sender, EventArgs e)
        {
            lock (this)
            {
                OnConnectionClosed();
                CallbackHandler.QueueDisconnectRequest();
            }
        }

        private void processCommandResponse(string commandType, RequestStatus requestStatus)
        {
            switch (commandType)
            {
                case PipeCommandTypes.RegistrationRequest:
                    registrationRequestStatus = requestStatus;
                    registrationResponseReceived.Set();
                    break;
                case PipeCommandTypes.ConnectionRequest:
                    connectionRequestStatus = requestStatus;
                    connectionResponseReceived.Set();
                    break;
                case PipeCommandTypes.ChangeRuntimeSettingsRequest:
                    changeRuntimeSettingsRequestStatus = requestStatus;
                    changeRuntimeSettingsReponseReceived.Set();
                    break;
                case PipeCommandTypes.ContentUpdateRequestFromPreviewTool:
                    contentUpdateRequestStatus = requestStatus;
                    contentUpdateReponseReceived.Set();
                    break;
                case PipeCommandTypes.ChangeHighlightRequestFromPreviewTool:
                    changeHighlightRequestStatus = requestStatus;
                    changeHighlightReponseReceived.Set();
                    break;
                case PipeCommandTypes.PreviewPartIdUpdateRequestFromPreviewTool:
                    previewPartIdUpdateRequestStatus = requestStatus;
                    previewPartIdUpdateReponseReceived.Set();
                    break;
                default:
                    throw new Exception($"Unexpected command type {commandType}.");
            }
        }
    }
}
