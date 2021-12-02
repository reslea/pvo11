using System;
using System.Collections;

namespace ConsoleApp.Logic
{
    public class Vector<T> : IList<T>
    {
        private int filled = 0;
        private int capacity = 4;
        private T[] items;

        public int Count => filled;

        public bool IsReadOnly { get; set; } = false;

        public T this[int i]
        {
            get
            {
                if (i < 0 || i >= filled)
                {
                    throw new IndexOutOfRangeException();
                }
                return items[i];
            }
            set
            {
                if (i < 0 || i >= filled)
                {
                    throw new IndexOutOfRangeException();
                }
                items[i] = value;
            }
        }

        public Vector()
        {
            items = new T[capacity];
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new Exception();
            }

            if (filled == capacity)
            {
                IncreaseCapacity();
            }

            items[filled++] = item;
        }

        public IEnumerator GetEnumerator()
        {
            return new VectorEnumerator<T>(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new VectorEnumerator<T>(this);
        }

        private void IncreaseCapacity()
        {
            capacity *= 2;

            T[] newItems = new T[capacity];

            for (int i = 0; i < items.Length; i++)
            {
                newItems[i] = items[i];
            }

            items = newItems;
        }

        public void Clear()
        {
            capacity = 4;
            items = new T[capacity];
            filled = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length < arrayIndex + filled)
            {
                throw new ArgumentException("There is no place for all items");
            }

            for (int i = 0; i < filled; i++)
            {
                array[arrayIndex + i] = items[i];
            }
        }

        public bool Remove(T item)
        {
            int foundIdex = IndexOf(item);

            if (foundIdex < 0)
            {
                return false;
            }

            RemoveAt(foundIdex);
            return true;
        }

        public int IndexOf(T item)
        {
            int foundIdex = -1;

            for (int i = 0; i < filled; i++)
            {
                if (items[i]!.Equals(item))
                {
                    foundIdex = i;
                }
            }

            return foundIdex;
        }

        public void Insert(int index, T item)
        {
            if (item == null)
            {
                throw new Exception();
            }

            if (filled == capacity)
            {
                IncreaseCapacity();
            }

            for (int i = index; i < filled; i++)
            {
                items[i + 1] = items[i];
            }
            filled++;
            items[index] = item;
        }

        public void RemoveAt(int index)
        {
            filled--;
            for (; index < filled; index++)
            {
                items[index] = items[index + 1];
            }
        }

        public class VectorEnumerator<TItem> : IEnumerator<TItem>
        {
            private Vector<TItem> _vector;
            private int position = -1;

            private TItem current;
            public TItem Current { 
                get
                { 
                    if(position == -1) throw new IndexOutOfRangeException();
                    return current;
                }
                set
                {
                    current = value;
                }
            }

            object IEnumerator.Current { get { return Current!; } }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            public VectorEnumerator(Vector<TItem> vector)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            {
                _vector = vector;
            }

            public bool MoveNext()
            {
                if (position >= _vector.filled)
                {
                    return false;
                }

                //Console.WriteLine($"move next() called, current: {Current}");
                Current = _vector.items[++position];

                return true;
            }

            public void Reset()
            {
                position = -1;
            }

            public void Dispose()
            {

            }
        }
    }
}