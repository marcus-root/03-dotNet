namespace dotNet_03_Generics_02_Liste_und_Menge
{
    internal class Set<T> : SimpleList<T> where T : IComparable
    {
        public override bool AddItem(T value)
        {
            Item<IComparable> itemToAdd = new Item<IComparable>(value);
            if (SearchItem(value) == 0 && first == null)
            {
                first = itemToAdd;
                last = itemToAdd;
                return true;
            }
            else if (SearchItem(value) == 0)
            {
                last.Next = itemToAdd;
                last = itemToAdd;
                return true;
            }
            return false;
        }

        public Set<T> Join(Set<T> setToJoin)
        {
            Set<T> joinedSet = new Set<T>();
            Item<IComparable> currentItem = this.first;
            while (currentItem != null)
            {
                joinedSet.AddItem((T)currentItem.Value);
                currentItem = currentItem.Next;
            }
            currentItem = setToJoin.first;
            while (currentItem != null)
            {
                if (this.SearchItem((T)currentItem.Value) == 0)
                {
                    joinedSet.AddItem((T)currentItem.Value);
                }
                currentItem = currentItem.Next;
            }
            return joinedSet;
        }

        public Set<T> Schnittmenge(Set<T> SetToCompare)
        {
            Set<T> newSet = new Set<T>();
            Item<IComparable> currentItem = this.first;
            while (currentItem != null)
            {
                if (SetToCompare.SearchItem((T)currentItem.Value) >= 1)
                {
                    newSet.AddItem((T)currentItem.Value);
                }
                currentItem = currentItem.Next;
            }
            return newSet;
        }

    }
}
