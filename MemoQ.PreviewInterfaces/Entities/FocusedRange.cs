namespace MemoQ.PreviewInterfaces.Entities
{
    public class FocusedRange
    {
        /// <summary>
        /// The start index of the focused range.
        /// </summary>
        public readonly int StartIndex;

        /// <summary>
        /// The length of the focused range.
        /// </summary>
        public readonly int Length;

        public FocusedRange(int startIndex, int length)
        {
            StartIndex = startIndex;
            Length = length;
        }
    }
}
