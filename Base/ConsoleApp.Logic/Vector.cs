using System;
using System.Collections;

namespace ConsoleApp.Logic
{
    public class Vector<T> : IEnumerable
    {
        private int filled = 0;
        private int capacity = 4;
        private T[] items;

        public T this[int i]
        {
            get
            {
                if (i >= filled)
                {
                    throw new IndexOutOfRangeException();
                }
                return items[i];
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

            if (filled >= capacity)
            {
                IncreaseCapacity();
            }

            items[filled++] = item;
        }

        public IEnumerator GetEnumerator()
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

        public class VectorEnumerator<TItem> : IEnumerator
        {
            public object Current { get; private set; }

            private Vector<TItem> _vector;
            private int position = -1;

            public VectorEnumerator(Vector<TItem> vector)
            {
                _vector = vector;
            }

            public bool MoveNext()
            {
                if (position >= _vector.filled)
                {
                    return false;
                }

                Current = _vector.items[++position];

                return true;
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
}