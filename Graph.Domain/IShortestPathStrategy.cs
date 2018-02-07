using System.Collections.Generic;

namespace Graph.Domain
{
    public interface IShortestPathStrategy
    {
        ICollection<int> FindShortestPath(IGraph graph, IGraphNode fromNode, IGraphNode toNode);
    }
}
