using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    internal class UnsortedLinkedPriorityQueue<T> : PriorityQueue<T>
    {
        private PriorityItem<T> head;
        private readonly int capacity;
        private int count;

        public UnsortedLinkedPriorityQueue(int size)
        {
            this.capacity = size;
            head = null;
            count = 0;
        } //end method

        /*
         * method for adding a new element to the queue
         */
        public void Add(T item, int priority)
        {
            if (count >= capacity)
            {
                throw new QueueOverflowException();
            }

            PriorityItem<T> newItem = new PriorityItem<T>(item, priority);
            newItem.Next = head;
            head = newItem;
            count++;
        } //end method

        /*
         * method returns the element at the head of the queue
         */
        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            PriorityItem<T> highestPriorityItem = head;
            PriorityItem<T> current = head.Next;

            while (current != null)
            {
                if (current.Priority > highestPriorityItem.Priority)
                {
                    highestPriorityItem = current;
                }
                current = current.Next;
            }

            return highestPriorityItem.Item;
        } //end method

        /*
         * 
         */
        public bool IsEmpty()
        {
            return count == 0;
        } //end method

        /*
         * 
         */
        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            if (head == null)
            {
                head = null;
                count--;
                return;
            }

            PriorityItem<T> previous = null;
            PriorityItem<T> current = head;
            PriorityItem<T> highestPriorityItem = head;

            while (current != null)
            {
                if (current.Priority > highestPriorityItem.Priority)
                {
                    highestPriorityItem = current;
                }
                current = current.Next;
            }

            current = head;
            previous = null;

            if (highestPriorityItem == head)
            {
                head = head.Next;
                count--;
                return;
            }

            while (current != highestPriorityItem)
            {
                previous = current;
                current = current.Next;
            }

            previous.Next = current.Next;
            count--;
        } //end method

        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }

            string result = "[";
            PriorityItem<T> current = head;
            while (current != null)
            {
                result += current.ToString();
                if (current.Next != null)
                {
                    result += ", ";
                }
                current = current.Next;
            }
            result += "]";
            return result;
        }

    }
}