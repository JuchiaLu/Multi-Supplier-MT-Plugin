using System;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    public class PipeCommand
    {
        public string CommandType;
        public object CommandParameters;

        public PipeCommand()
        { }

        public PipeCommand(string commandType, object commandParameters)
        {
            CommandType = commandType;
            CommandParameters = commandParameters;
        }
    }
}
