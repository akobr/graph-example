using Graph.Model;
using System.Collections.Generic;

namespace Graph.Domain
{
    public interface IGraphBuilder
    {
        IGraph BuildGraph(IList<Node> nodes);
    }
}
