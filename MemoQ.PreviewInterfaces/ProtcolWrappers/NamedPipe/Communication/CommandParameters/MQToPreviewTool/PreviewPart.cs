using System;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class PreviewPart
    {
        /// <summary>
        /// The identifier of the preview part.
        /// </summary>
        public string PreviewPartId;

        /// <summary>
        /// The preview properties.
        /// </summary>
        public PreviewProperty[] PreviewProperties;

        /// <summary>
        /// The source document containing the preview part.
        /// </summary>
        public SourceDocument SourceDocument;

        /// <summary>
        /// The source language of the preview part.
        /// </summary>
        public string SourceLangCode;

        /// <summary>
        /// The target language of the preview part.
        /// </summary>
        public string TargetLangCode;

        /// <summary>
        /// The source content of the preview part.
        /// </summary>
        public PreviewContent SourceContent;

        /// <summary>
        /// The target content of the preview part.
        /// </summary>
        public PreviewContent TargetContent;
    }
}
