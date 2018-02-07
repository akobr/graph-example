using System.Collections.Generic;

namespace Graph.Domain
{
    public class Graph : IGraph
    {
        private Dictionary<int, GraphNode> nodes;

        public Graph()
        {
            nodes = new Dictionary<int, GraphNode>();
        }

        public int NodeCount => nodes.Count;

        public IGraphNode AddNode(int id)
        {
            return GetOrAddNode(id);
        }

        public bool RemoveNode(int id)
        {
            return nodes.Remove(id);
        }

        public IGraphNode GetNode(int id)
        {
            return GetNodeImplementation(id);
        }

        public void AddEdge(int idFrom, int idTo)
        {
            GraphNode fromNode = GetOrAddNode(idFrom);
            GraphNode toNode = GetOrAddNode(idTo);
            fromNode.AddEdge(toNode);
        }

        public void RemoveEdge(int idFrom, int idTo)
        {
            GraphNode fromNode = GetNodeImplementation(idFrom);
            GraphNode toNode = GetNodeImplementation(idTo);

            if (fromNode == null || toNode == null)
            {
                return;
            }

            fromNode.RemoveEdge(toNode);
        }

        private GraphNode GetOrAddNode(int id)
        {
            GraphNode node;

            if (nodes.TryGetValue(id, out node))
            {
                return node;
            }

            node = new GraphNode(id);
            nodes.Add(id, node);
            return node;
        }

        private GraphNode GetNodeImplementation(int id)
        {
            nodes.TryGetValue(id, out GraphNode result);
            return result;
        }

        public void Clean()
        {
            foreach (GraphNode node in nodes.Values)
            {
                node.Clean();
            }
        }
    }
}
