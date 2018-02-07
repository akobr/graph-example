using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Graph.Domain.Structures
{
    public class PriorityQueue<TItem, TPriority> : IEnumerable<TItem> where TPriority : IComparable<TPriority>, IEquatable<TPriority>
    {
        private readonly SortedDictionary<TPriority, Queue<TItem>> storage;
        private int totalSize;

        public PriorityQueue()
            : this(false)
        {
            // No operation
        }

        public PriorityQueue(bool descendingComparer)
        {
            if (descendingComparer)
                storage = new SortedDictionary<TPriority, Queue<TItem>>(
                    new DescendingComparer<TPriority>());
            else
                storage = new SortedDictionary<TPriority, Queue<TItem>>();

            totalSize = 0;
        }

        public PriorityQueue(IComparer<TPriority> comparer)
        {
            storage = new SortedDictionary<TPriority, Queue<TItem>>(comparer);
            totalSize = 0;
        }

        public bool IsEmpty
        {
            get { return totalSize == 0; }
        }

        public int Count
        {
            get { return totalSize; }
        }

        public TItem Dequeue()
        {
            foreach (Queue<TItem> q in storage.Values)
            {
                if (q.Count > 0)
                {
                    totalSize--;
                    return q.Dequeue();
                }
            }

            return default(TItem);
        }


        public TItem Dequeue(TPriority priority)
        {
            totalSize--;
            return storage[priority].Dequeue();
        }

        public TItem Peek()
        {
            foreach (Queue<TItem> q in storage.Values)
            {
                if (q.Count > 0)
                    return q.Peek();
            }

            return default(TItem);
        }

        public void Enqueue(TItem item, TPriority priority)
        {
            if (!storage.ContainsKey(priority))
            {
                storage.Add(priority, new Queue<TItem>());
                storage[priority].Enqueue(item);
                totalSize++;
            }
            else
            {
                storage[priority].Enqueue(item);
                totalSize++;
            }
        }

        public bool ContainsPriority(TPriority priority)
        {
            return storage.Keys.Any(q => q.Equals(priority));
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return new PriorityQueueEnumerator<TItem, TPriority>(storage);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
