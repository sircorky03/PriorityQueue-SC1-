namespace PriorityQueue
{
    public class PriorityItem<T>
    {
        public T Item { get; }
        public int Priority { get; }
        public PriorityItem<T> Next { get; set; }

        public PriorityItem(T item, int priority)
        {
            Item = item;
            Priority = priority;
        }

        public override string ToString()
        {
            return $"({Item}, {Priority})";
        }
    }
}
