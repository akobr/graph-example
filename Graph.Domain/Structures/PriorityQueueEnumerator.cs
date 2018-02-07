using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Graph.Domain.Structures
{
    public class PriorityQueueEnumerator<TItem, TPriority> : IEnumerator<TItem>
    {
        private readonly List<TPriority> priorities;
        private SortedDictionary<TPriority, Queue<TItem>> storage;
        private IEnumerator<TItem> activeEnumerator;
        private int activePriorityIndex;

        public PriorityQueueEnumerator(SortedDictionary<TPriority, Queue<TItem>> storage)
        {
            this.storage = storage;
            priorities = new List<TPriority>(storage.Where(si => si.Value.Count > 0).Select(si => si.Key));

            Reset();
        }

        public void Dispose()
        {
            storage = null;
        }

        public bool MoveNext()
        {
            if (activeEnumerator == null)
                return false;

            if (!activeEnumerator.MoveNext())
            {
                if (++activePriorityIndex >= priorities.Count)
                    return false;
                activeEnumerator = storage[priorities[activePriorityIndex]].GetEnumerator();
            }
            else
                return true;

            return activeEnumerator.MoveNext();
        }

        public void Reset()
        {
            activePriorityIndex = 0;

            if (priorities.Count > 0)
                activeEnumerator = storage[priorities[0]].GetEnumerator();
            else
                activeEnumerator = null;
        }

        public TItem Current
        {
            get { return activeEnumerator.Current; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}