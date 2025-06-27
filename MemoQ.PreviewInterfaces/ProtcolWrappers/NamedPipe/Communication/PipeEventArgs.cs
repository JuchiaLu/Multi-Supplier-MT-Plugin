namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    public class PipeEventArgs
    {
        public readonly byte[] Data;
        public readonly int DataLength;

        public PipeEventArgs(byte[] data, int dataLength)
        {
            Data = data;
            DataLength = dataLength;
        }
    }
}
