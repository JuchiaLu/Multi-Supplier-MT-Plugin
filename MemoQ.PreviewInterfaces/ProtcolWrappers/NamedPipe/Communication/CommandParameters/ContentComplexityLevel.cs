namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    internal enum ContentComplexityLevel
    {
        /// <summary>
        /// The final plain text of the segment part without any inline tags or formatting.
        /// </summary>
        Minimal,
        /// <summary>
        /// The final plain text of the segment part with interpreted formatting (b/i/u/sup/sub in html format).
        /// </summary>
        PlainWithInterpretedFormatting
    }
}
