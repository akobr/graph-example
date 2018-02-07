using System.Collections.Generic;
using Graph.Model;

namespace Graph.Domain
{
    public class DefaultGraphBuilder : IGraphBuilder
    {
        public IGraph BuildGraph(IList<Node> nodes)
        {
            IGraph graph = new Graph();

            foreach (Node node in nodes)
            {
                graph.AddNode(node.Id);

                foreach (Edge edge in node.OutEdges)
                {
                    graph.AddNode(edge.IdTo);
                    graph.AddEdge(node.Id, edge.IdTo);
                }
            }

            return graph;
        }
    }
}
