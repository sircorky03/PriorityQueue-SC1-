using NUnit.Framework;
using PriorityQueue;

namespace PriorityQueue.Tests
{
    [TestFixture]
    public class PriorityQueueTests
    {
        //test 1: confirm that adding items to SortedArrayPriorityQueue and calling Head() returns the item with the highest priority
        [Test]
        public void SortedArrayPriorityQueue_AddAndHead_ReturnsHighestPriorityItem()
        {
            var queue = new SortedArrayPriorityQueue<string>(5);
            queue.Add("Item1", 1);
            queue.Add("Item2", 3);
            queue.Add("Item3", 2);

            Assert.That(queue.Head(), Is.EqualTo("Item2"));
        }

        //test 2: confirm that calling Remove() on SortedArrayPriorityQueue removes the item of the highest priority
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

        //test 3: confirm that adding items to UnsortedLinkedPriorityQueue and calling Head() returns the item with the highest priority
        [Test]
        public void UnsortedLinkedPriorityQueue_AddAndHead_ReturnsHighestPriorityItem()
        {
            var queue = new UnsortedLinkedPriorityQueue<string>(5);
            queue.Add("Item1", 1);
            queue.Add("Item2", 3);
            queue.Add("Item3", 2);

            Assert.That(queue.Head(), Is.EqualTo("Item2"));
        }

        //test 4: confirm that calling Remove() on UnsortedLinkedPriorityQueue removes the item with the highest priority
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

        //test 5: confirm that adding items to HeapPriorityQueue and calling Head() returns the item with the highest priority
        [Test]
        public void HeapPriorityQueue_AddAndHead_ReturnsHighestPriorityItem()
        {
            var queue = new HeapPriorityQueue<string>(5);
            queue.Add("Item1", 1);
            queue.Add("Item2", 3);
            queue.Add("Item3", 2);

            Assert.That(queue.Head(), Is.EqualTo("Item2"));
        }

        //test 6: confirm that calling Remove() on HeapPriorityQueue removes the item with the highest priority
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

        //test 7: confirm that IsEmpty() returns true for an empty SortedArrayPriorityQueue
        [Test]
        public void IsEmpty_ReturnsTrueForEmptyQueue()
        {
            var queue = new SortedArrayPriorityQueue<string>(5);
            Assert.IsTrue(queue.IsEmpty());
        }

        //test 8: confirm that IsEmpty() returns false for a non-empty SortedArrayPriorityQueue
        [Test]
        public void IsEmpty_ReturnsFalseForNonEmptyQueue()
        {
            var queue = new SortedArrayPriorityQueue<string>(5);
            queue.Add("Item1", 1);
            Assert.IsFalse(queue.IsEmpty());
        }

        //test 9: confirm that QueueUnderflowException is thrown when Head() is called on an empty SortedArrayPriorityQueue
        [Test]
        public void QueueUnderflowException_IsThrownWhenHeadCalledOnEmptyQueue()
        {
            var queue = new SortedArrayPriorityQueue<string>(5);
            Assert.Throws<QueueUnderflowException>(() => queue.Head());
        }

        //test 10: confirm that QueueOverflowException is thrown when Head() is called on a full SortedArrayPriorityQueue
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