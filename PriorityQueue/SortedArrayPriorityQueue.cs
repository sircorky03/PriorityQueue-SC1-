using System;

namespace PriorityQueue
{
    public class SortedArrayPriorityQueue<T> where T : IComparable<T>
    {
        private readonly T[] storage;
        private readonly int capacity;
        private int tailIndex;

        public SortedArrayPriorityQueue(int size)
        {
            storage = new T[size];
            capacity = size;
            tailIndex = -1;
        }

        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            return storage[0];
        }

        public void Add(T item)
        {
            tailIndex++;
            if (tailIndex >= capacity)
            {
                tailIndex--;
                throw new QueueOverflowException();
            }

            int i = tailIndex;
            while (i > 0 && storage[i - 1].CompareTo(item) > 0)
            {
                storage[i] = storage[i - 1];
                i--;
            }
            storage[i] = item;
        }

        public void Remove()
        {
            if (IsEmpty()) throw new QueueUnderflowException();
            for (int i = 0; i < tailIndex; i++)
            {
                storage[i] = storage[i + 1];
            }
            tailIndex--;
        }

        public bool IsEmpty() => tailIndex < 0;

        public override string ToString()
        {
            if (IsEmpty()) throw new QueueUnderflowException("No items to display");

            var result = "[";
            for (int i = 0; i <= tailIndex; i++)
            {
                if (i > 0)
                {
                    result += ", ";
                }
                result += storage[i];
            }
            result += "]";
            return result;
        }
    }
}
