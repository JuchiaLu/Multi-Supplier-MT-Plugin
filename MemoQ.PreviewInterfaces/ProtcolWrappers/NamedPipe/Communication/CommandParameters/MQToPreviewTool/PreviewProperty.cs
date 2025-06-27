using System;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class PreviewProperty
    {
        /// <summary>
        /// The name of the property.
        /// </summary>
        public string Name;

        /// <summary>
        /// The value of the property.
        /// </summary>
        public object Value;
    }
}
