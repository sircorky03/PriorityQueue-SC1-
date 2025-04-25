using PriorityQueue;
using System;

namespace PriorityQueue
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Priority { get; set; }

        public int CompareTo(Person other)
        {
            return this.Priority.CompareTo(other.Priority);
        }

        public Person(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
