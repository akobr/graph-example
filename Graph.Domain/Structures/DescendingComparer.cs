using System;
using System.Collections.Generic;

namespace Graph.Domain.Structures
{
    public class DescendingComparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return -x.CompareTo(y);
        }
    }
}