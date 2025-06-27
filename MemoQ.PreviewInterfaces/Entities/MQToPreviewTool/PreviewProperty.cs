namespace MemoQ.PreviewInterfaces.Entities
{
    public class PreviewProperty
    {
        /// <summary>
        /// The name of the property.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The value of the property.
        /// </summary>
        public readonly object Value;

        public PreviewProperty(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
