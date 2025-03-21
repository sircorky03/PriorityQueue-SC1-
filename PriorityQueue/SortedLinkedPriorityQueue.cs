using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class SortedLinkedPriorityQueue<T> : PriorityQueue<T>
    {
        private PriorityItem<T> head; //corrected head variable type
        private readonly int capacity;
        private int count;

        public SortedLinkedPriorityQueue(int size)
        {
            this.capacity = size;
            head = null;
            count = 0;
        }

        //the item at the front of the queue
        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            return head.Item;
        }

        public void Add(T item, int priority)
        {
            if (count >= capacity)
            {
                throw new QueueOverflowException();
            }

            PriorityItem<T> newItem = new PriorityItem<T>(item, priority);

            if (head == null || priority > head.Priority)
            {
                newItem.Next = head;
                head = newItem;
            }
            else
            {
                PriorityItem<T> current = head;
                while (current.Next != null && current.Next.Priority >= priority)
                {
                    current = current.Next;
                }
                newItem.Next = current.Next;
                current.Next = newItem;
            }
            count++;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            head = head.Next;
            count--;
        }

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