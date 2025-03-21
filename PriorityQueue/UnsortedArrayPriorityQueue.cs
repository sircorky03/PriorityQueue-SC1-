using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class UnsortedArrayPriorityQueue<T> : PriorityQueue<T>
    {
        private readonly PriorityItem<T>[] storage; //array to store PriorityItem objects
        private readonly int capacity;  //max capacity of the queue
        private int tailIndex;  //index of last element in queue

        //constructor initialises queue with a given size
        public UnsortedArrayPriorityQueue(int size)
        {
            storage = new PriorityItem<T>[size];
            capacity = size;
            tailIndex = -1; //indicates empty queue
        }

        //adds items with priority to the queue
        public void Add(T item, int priority)
        {
            tailIndex++;    //increment to add new item at the next available position
            if (tailIndex >= capacity)
            {
                tailIndex--;    //decrement to revert to the previous valid position
                throw new QueueOverflowException();
            }

            storage[tailIndex] = new PriorityItem<T>(item, priority);   //add new item to the storage array
        }

        //returns item with the highest priority without removing it
        public T Head()
        {
            //throw exception if the queue is empty
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            int highestPriorityIndex = 0;   //initialise the index of the highest priority item to the first element

            //find item with the highest priority
            for (int i = 1; i <= tailIndex; i++)
            {
                if (storage[i].Priority > storage[highestPriorityIndex].Priority)
                {
                    highestPriorityIndex = i;   //update index of the highest priority item
                }
            }
            return storage[highestPriorityIndex].Item;  //return item with the highest priority
        }

        //removes item with the highest priority from the queue
        public void Remove()
        {
            //throw exception if empty
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            int highestPriorityIndex = 0;   //initialise the index of the highest priority item to the first element

            //find item with the highest priority
            for (int i = 1; i <= tailIndex; i++)
            {
                if (storage[i].Priority > storage[highestPriorityIndex].Priority)
                {
                    highestPriorityIndex = i;   //update index of the highest priority item
                }
            }

            //shift elements to remove the highest priority item
            for (int i = highestPriorityIndex; i < tailIndex; i++)
            {
                storage[i] = storage[i + 1];    //shift items to the left, overwriting the removed item
            }

            tailIndex--;    //decrement to reflect the removed item
        }

        //converts the queue to string format
        public override string ToString()
        {
            //throw exception if empty
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }

            string result = "[";    //start building the string
            for (int i = 0; i <= tailIndex; i++)
            {
                if (i > 0)
                {
                    result += ", "; //add a comma and space between items
                }
                result += storage[i];   //add current item to the string
            }

            //finish building and return the strong
            result += "]";
            return result;
        }

        //checks if the queue is empty
        public bool IsEmpty()
        {
            return tailIndex < 0;   //return true if tailIndex = -1, indicating an empty queue
        }
    }
}
