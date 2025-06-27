using System;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class PreviewPartWithFocusedRange : PreviewPart
    {
        /// <summary>
        /// The focused range on the source side.
        /// </summary>
        public FocusedRange SourceFocusedRange;
        
        /// <summary>
        /// The focused range on the target side.
        /// </summary>
        public FocusedRange TargetFocusedRange;
    }
}
