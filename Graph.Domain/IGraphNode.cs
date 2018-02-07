using System.Collections.Generic;

namespace Graph.Domain
{
    public interface IGraphNode
    {
        int Id { get; }

        IReadOnlyCollection<IGraphNode> Successors { get; }

        int Weight { get; set; }

        IGraphNode PreviousNode { get; set; }
    }
}