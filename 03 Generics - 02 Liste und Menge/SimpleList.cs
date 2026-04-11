namespace dotNet_03_Generics_02_Liste_und_Menge
{
    internal class SimpleList<T> where T : IComparable
    {
        protected Item<IComparable> first;
        protected Item<IComparable> last;

        public virtual bool AddItem(T value)
        {
            Item<IComparable> itemToAdd = new Item<IComparable>(value);
            if (object.Equals(first, null))
            {
                first = itemToAdd;
                last = itemToAdd;
            }
            else
            {
                last.Next = itemToAdd;
                last = itemToAdd;
            }
            return true;
        }

        public int RemoveItem(T value)
        {
            Item<IComparable> itemToRemove = new Item<IComparable>(value);
            Item<IComparable> currentItem = first;
            Item<IComparable> nextItem = first.Next;
            int gelöscht = 0;
            while (nextItem != null)
            {
                if (nextItem.Value == itemToRemove.Value)
                {
                    currentItem.Next = nextItem.Next;
                    gelöscht++;
                    currentItem = nextItem.Next;
                    nextItem = null;
                    nextItem = currentItem.Next;
                }
                else
                {
                    currentItem = nextItem;
                    nextItem = currentItem.Next;
                }

            }
            return gelöscht;

        }

        public int SearchItem(T value)
        {
            Item<IComparable> itemToSearch = new Item<IComparable>(value);
            Item<IComparable> currentItem = first;
            Item<IComparable> nextItem = null;
            if (first != null && first.Next != null) { nextItem = first.Next; }
            int funde = 0;
            while (nextItem != null)
            {
                if (nextItem.Value == itemToSearch.Value)
                {
                    funde++;
                }
                currentItem = nextItem;
                nextItem = currentItem.Next;
            }
            return funde;
        }

        public int CountItems()
        {
            int counter = 0;
            Item<IComparable> item = first;
            while (item != null)
            {
                counter++;
                item = item.Next;
            }
            return counter;
        }

        public Item<IComparable>[] GetArray()
        {
            int itemCount = CountItems();
            Item<IComparable>[] array = new Item<IComparable>[itemCount];

            Item<IComparable> item = first;
            for (int i = 0; i < itemCount; i++)
            {
                array[i] = item;
                item = item.Next;
            }
            return array;
        }

        public override string ToString()
        {
            String rück = $"{this.GetType().Name} ({CountItems()} Elemente)\n";
            foreach (Item<IComparable> item in GetArray())
            {
                rück = rück + item.Value + " (" + item.Value.GetType().Name + ")\n";
            }
            return rück;
        }
    }
}
