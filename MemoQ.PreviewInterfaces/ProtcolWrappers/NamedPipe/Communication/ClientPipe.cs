using MemoQ.PreviewInterfaces.Exceptions;
using MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication
{
    internal class ClientPipe
    {
        private static readonly int BufferSize = 4096;

        private readonly string pipeName;
        private readonly JsonSerializerSettings serializerSettings;
        private NamedPipeClientStream pipe;
        private bool pipeClosedByUs;

        public event EventHandler<PipeEventArgs> OnDataRead;
        public event EventHandler<EventArgs> OnPipeClosed;

        public ClientPipe(string pipeName)
        {
            this.pipeName = pipeName;

            serializerSettings = new JsonSerializerSettings();
            serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public void EnsureIsConnected()
        {
            if (pipe == null)
            {
                pipe = new NamedPipeClientStream(".", string.Format("{0}_{1}", pipeName, Process.GetCurrentProcess().SessionId), PipeDirection.InOut, PipeOptions.Asynchronous);
                pipeClosedByUs = false;
            }

            if (pipe.IsConnected)
                return;

            try
            {
                pipe.Connect(2000);
                pipe.ReadMode = PipeTransmissionMode.Message;
            }
            catch (TimeoutException)
            {
                throw new PreviewServiceUnavailableException();
            }

            startReadingAsync();
        }

        public Task SendCommandAsync(string commandType, object commandParameters)
        {
            return sendCommandAsync(new PipeCommand(commandType, commandParameters));
        }

        public void Close()
        {
            if (pipe.IsConnected)
                pipe.WaitForPipeDrain();

            pipeClosedByUs = true;
            pipe.Close();
            pipe.Dispose();
            pipe = null;
        }

        private void startReadingAsync()
        {
            Task.Factory.StartNew(() =>
            {
                using (var pipeCommandStream = new MemoryStream())
                {
                    var buffer = new byte[BufferSize];
                    do
                    {
                        var readLength = pipe.Read(buffer, 0, BufferSize);
                        if (readLength == 0)
                        {
                            if (!pipeClosedByUs)
                                OnPipeClosed?.Invoke(this, EventArgs.Empty);
                            return;
                        }

                        pipeCommandStream.Write(buffer, 0, readLength);
                        buffer = new byte[BufferSize];
                    }
                    while (!pipe.IsMessageComplete);

                    var pipeCommandDataArray = pipeCommandStream.ToArray();
                    OnDataRead?.Invoke(this, new PipeEventArgs(pipeCommandDataArray, pipeCommandDataArray.Length));

                    if (pipe != null)
                        startReadingAsync();
                }
            });
            }

        private Task sendCommandAsync(PipeCommand pipeCommand)
        {
            string jsonSerializedPipeCommand = JsonConvert.SerializeObject(pipeCommand, serializerSettings);
            byte[] serializedPipeCommand = Encoding.UTF8.GetBytes(jsonSerializedPipeCommand);
            return pipe.WriteAsync(serializedPipeCommand, 0, serializedPipeCommand.Length);
        }
    }
}
