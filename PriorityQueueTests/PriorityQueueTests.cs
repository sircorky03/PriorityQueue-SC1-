using NUnit.Framework;
using PriorityQueue;

namespace PriorityQueue.Tests
{
    [TestFixture]
    public class PriorityQueueTests
    {
        [Test]
        public void SortedArrayPriorityQueue_AddAndHead_ReturnsHighestPriorityItem()
        {
            var queue = new SortedArrayPriorityQueue<string>(5);
            queue.Add("Item1", 1);
            queue.Add("Item2", 3);
            queue.Add("Item3", 2);

            Assert.That(queue.Head(), Is.EqualTo("Item2"));
        }

        [Test]
        public void SortedArrayPriorityQueue_Remove_RemovesHighestPriorityItem()
        {
            var queue = new SortedArrayPriorityQueue<string>(5);
            queue.Add("Item1", 1);
            queue.Add("Item2", 3);
            queue.Add("Item3", 2);

            queue.Remove();

            Assert.That(queue.Head(), Is.EqualTo("Item3"));
        }

        [Test]
        public void UnsortedLinkedPriorityQueue_AddAndHead_ReturnsHighestPriorityItem()
        {
            var queue = new UnsortedLinkedPriorityQueue<string>(5);
            queue.Add("Item1", 1);
            queue.Add("Item2", 3);
            queue.Add("Item3", 2);

            Assert.That(queue.Head(), Is.EqualTo("Item2"));
        }

        [Test]
        public void UnsortedLinkedPriorityQueue_Remove_RemovesHighestPriorityItem()
        {
            var queue = new UnsortedLinkedPriorityQueue<string>(5);
            queue.Add("Item1", 1);
            queue.Add("Item2", 3);
            queue.Add("Item3", 2);

            queue.Remove();

            Assert.That(queue.Head(), Is.EqualTo("Item3"));
        }

        [Test]
        public void HeapPriorityQueue_AddAndHead_ReturnsHighestPriorityItem()
        {
            var queue = new HeapPriorityQueue<string>(5);
            queue.Add("Item1", 1);
            queue.Add("Item2", 3);
            queue.Add("Item3", 2);

            Assert.That(queue.Head(), Is.EqualTo("Item2"));
        }

        [Test]
        public void HeapPriorityQueue_Remove_RemovesHighestPriorityItem()
        {
            var queue = new HeapPriorityQueue<string>(5);
            queue.Add("Item1", 1);
            queue.Add("Item2", 3);
            queue.Add("Item3", 2);

            queue.Remove();

            Assert.That(queue.Head(), Is.EqualTo("Item3"));
        }

        [Test]
        public void IsEmpty_ReturnsTrueForEmptyQueue()
        {
            var queue = new SortedArrayPriorityQueue<string>(5);
            Assert.IsTrue(queue.IsEmpty());
        }

        [Test]
        public void IsEmpty_ReturnsFalseForNonEmptyQueue()
        {
            var queue = new SortedArrayPriorityQueue<string>(5);
            queue.Add("Item1", 1);
            Assert.IsFalse(queue.IsEmpty());
        }

        [Test]
        public void QueueUnderflowException_IsThrownWhenHeadCalledOnEmptyQueue()
        {
            var queue = new SortedArrayPriorityQueue<string>(5);
            Assert.Throws<QueueUnderflowException>(() => queue.Head());
        }

        [Test]
        public void QueueOverflowException_IsThrownWhenQueueIsFull()
        {
            var queue = new SortedArrayPriorityQueue<string>(2);
            queue.Add("Item1", 1);
            queue.Add("Item2", 2);
            Assert.Throws<QueueOverflowException>(() => queue.Add("Item3", 3));
        }
    }
}