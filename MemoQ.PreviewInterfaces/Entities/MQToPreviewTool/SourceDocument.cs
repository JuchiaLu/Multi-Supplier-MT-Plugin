using System;

namespace MemoQ.PreviewInterfaces.Entities
{
    public class SourceDocument
    {
        /// <summary>
        /// The guid of the document containing the preview part.
        /// </summary>
        public readonly Guid DocumentGuid;

        /// <summary>
        /// The name of the document containing the preview part.
        /// </summary>
        public readonly string DocumentName;

        /// <summary>
        /// The import path of the document containing the preview part.
        /// </summary>
        public readonly string ImportPath;

        public SourceDocument(Guid documentGuid, string documentName, string importPath)
        {
            DocumentGuid = documentGuid;
            DocumentName = documentName;
            ImportPath = importPath;
        }
    }
}
