using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class HeapPriorityQueue<T> : PriorityQueue<T>
    {
        private readonly PriorityItem<T>[] heap;    //array representing the heap
        private readonly int capacity;  //max capacity of the heap
        private int count;  //current no. of elements in the heap

        //constructor initialises heap with a given size
        public HeapPriorityQueue(int size)
        {
            capacity = size;
            heap = new PriorityItem<T>[capacity];
            count = 0;
        }

        //add a new item with a priority to the heap
        public void Add(T item, int priority)
        {
            //throw exception if too many items added to the queue
            if (count >= capacity)
            {
                throw new QueueOverflowException();
            }

            PriorityItem<T> newItem = new PriorityItem<T>(item, priority);
            heap[count] = newItem;
            HeapifyUp(count);   //maintain heap property after insertion
            count++;
        }

        //returns item with the highest priority (root of the heap)
        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            return heap[0].Item;
        }

        //checks if heap is empty
        public bool IsEmpty()
        {
            return count == 0;
        }

        //removes item of the highest priority (root of the heap)
        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            heap[0] = heap[count - 1];  //replace root with the last element
            count--;
            HeapifyDown(0); //maintain heap property after removal
        }

        //covert the heap to string format
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

        //maintains heap property after insertion
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

        //maintains heap property after removal
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

        //swaps 2 elements in the heap
        private void Swap(int index1, int index2)
        {
            PriorityItem<T> temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }
    }
}
