namespace dotNet_04_Indexer_01_Liste
{
    internal class SimpleList<T> where T : IComparable<T>
    {
        Entry<T> First;
        Entry<T> Last;
        T[] array;

        public T this[int index]
        {
            get
            {
                return Search(index).Value;
            }
            set
            {
                Search(index).Value = value;
            }

        }
        public void Add(T value)
        {
            if (First == null)
            {
                First = new Entry<T>(value);
                Last = First;
            }
            else
            {
                Add(First, value);
            }
        }

        private void Add(Entry<T> entry, T value)
        {
            if (entry.Next == null) entry.Next = new Entry<T>(value);
            else Add(entry.Next, value);
        }

        public void Delete(T value)
        {
            if (First == null) return;
            else if (First.Value.Equals(value)) First = First.Next;
            else Delete(First, value);
        }

        private void Delete(Entry<T> entry, T value)
        {
            if (entry.Next == null) return;
            else if (entry.Next.Value.Equals(value))
            {
                Entry<T> del = entry.Next;
                entry.Next = del.Next;
                del = null;
            }
            else Delete(entry.Next, value);
        }

        public Entry<T> Search(T value)
        {
            return Search(First, value);
        }

        private Entry<T> Search(Entry<T> entry, T value)
        {
            if (entry.Value.Equals(value)) return entry;
            else if (entry.Next == null) return null;
            else return Search(entry.Next, value);
        }

        private Entry<T> Search(int index)
        {
            return Search(First, index);
        }

        private Entry<T> Search(Entry<T> entry, int index)
        {
            if (entry == null) throw new IndexOutOfRangeException();
            else if (index == 0) return entry;
            else return Search(entry.Next, index - 1);
        }

        public int Length()
        {
            int länge = 0;
            if (First == null) return länge;
            else return Length(First, länge);
        }

        private int Length(Entry<T> entry, int länge)
        {
            if (entry == null) return länge;
            else return Length(entry.Next, länge + 1);
        }

        public T[] ToArray()
        {
            array = new T[Length()];
            return ToArray(First, 0, Length() - 1);
        }

        private T[] ToArray(Entry<T> entry, int index, int length)
        {
            if (entry == null) return array;
            array[index] = entry.Value;
            if (index == length)
            {
                return array;
            }
            else
            {
                return ToArray(entry.Next, index + 1, length);
            }
        }




    }
}
