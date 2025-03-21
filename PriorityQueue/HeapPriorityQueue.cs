using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    internal class HeapPriorityQueue<T> : PriorityQueue<T>
    {
        private readonly PriorityItem<T>[] heap;
        private readonly int capacity;
        private int count;

        public HeapPriorityQueue(int size)
        {
            capacity = size;
            heap = new PriorityItem<T>[capacity];
            count = 0;
        }

        public void Add(T item, int priority)
        {
            //throw exception if too many items added to the queue
            if (count >= capacity)
            {
                throw new QueueOverflowException();
            }

            PriorityItem<T> newItem = new PriorityItem<T>(item, priority);
            heap[count] = newItem;
            HeapifyUp(count);
            count++;
        }

        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            return heap[0].Item;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        //called if the queue is empty
        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            heap[0] = heap[count - 1];
            count--;
            HeapifyDown(0);
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }

            string result = "[";
            for (int i = 0; i < count; i++)
            {
                result += heap[i].ToString();
                if (i < count - 1)
                {
                    result += ", ";
                }
            }
            result += "]";
            return result;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (heap[parentIndex] == null || heap[index].Priority <= heap[parentIndex].Priority)
                {
                    break;
                }
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        private void HeapifyDown(int index)
        {
            while (true)
            {
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;
                int largestIndex = index;

                if (leftChildIndex < count && heap[leftChildIndex].Priority > heap[largestIndex].Priority)
                {
                    largestIndex = leftChildIndex;
                }

                if (rightChildIndex < count && heap[rightChildIndex].Priority > heap[largestIndex].Priority)
                {
                    largestIndex = rightChildIndex;
                }

                if (largestIndex == index)
                {
                    break;
                }

                Swap(index, largestIndex);
                index = largestIndex;
            }
        }

        private void Swap(int index1, int index2)
        {
            PriorityItem<T> temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }
    }
}
