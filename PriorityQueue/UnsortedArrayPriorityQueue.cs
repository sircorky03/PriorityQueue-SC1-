using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class UnsortedArrayPriorityQueue<T> : PriorityQueue<T>
    {
        private readonly PriorityItem<T>[] storage;
        private readonly int capacity;
        private int tailIndex;

        public UnsortedArrayPriorityQueue(int size)
        {
            storage = new PriorityItem<T>[size];
            capacity = size;
            tailIndex = -1;
        }

        public void Add(T item, int priority)
        {
            tailIndex++;
            if (tailIndex >= capacity)
            {
                tailIndex--;
                throw new QueueOverflowException();
            }

            storage[tailIndex] = new PriorityItem<T>(item, priority);
        }

        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            int highestPriorityIndex = 0;
            for (int i = 1; i <= tailIndex; i++)
            {
                if (storage[i].Priority > storage[highestPriorityIndex].Priority)
                {
                    highestPriorityIndex = i;
                }
            }
            return storage[highestPriorityIndex].Item;
        }

        public void Remove()
        {
            //throw exception if empty
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            int highestPriorityIndex = 0;
            for (int i = 1; i <= tailIndex; i++)
            {
                if (storage[i].Priority > storage[highestPriorityIndex].Priority)
                {
                    highestPriorityIndex = i;
                }
            }

            //shift elements to remove the highest priority item
            for (int i = highestPriorityIndex; i < tailIndex; i++)
            {
                storage[i] = storage[i + 1];
            }

            tailIndex++;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }

            string result = "[";
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

        public bool IsEmpty()
        {
            return tailIndex < 0;
        }
    }
}
