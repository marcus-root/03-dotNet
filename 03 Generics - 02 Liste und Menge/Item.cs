namespace dotNet_03_Generics_02_Liste_und_Menge
{
    internal class Item<T> where T : IComparable
    {
        public T Value { get; private set; }
        public Item<T> Next { get; set; }

        public Item(T value)
        {
            this.Value = value;
        }
    }
}
