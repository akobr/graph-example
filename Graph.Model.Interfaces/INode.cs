using System.Collections.Generic;

namespace Graph.Model.Interfaces
{
    public interface INode
    {
        int Id { get; }

        string Label { get; }

        IEnumerable<int> AdjacentNodes { get; }
    }
}
