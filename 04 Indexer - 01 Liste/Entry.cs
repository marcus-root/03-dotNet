namespace dotNet_04_Indexer_01_Liste
{
    internal class Entry<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public Entry<T> Next { get; set; }

        public Entry(T value)
        {
            Value = value;
        }

    }
}
