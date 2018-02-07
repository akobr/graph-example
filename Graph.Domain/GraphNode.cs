using System.Collections.Generic;

namespace Graph.Domain
{
    public class GraphNode : IGraphNode
    {
        private LinkedList<GraphNode> successors;

        public GraphNode(int id)
        {
            Id = id;
            successors = new LinkedList<GraphNode>();

            Clean();
        }

        public int Id { get; }

        public IReadOnlyCollection<IGraphNode> Successors => successors;

        public int Weight { get; set; }

        public IGraphNode PreviousNode { get; set; }

        public void Clean()
        {
            Weight = int.MaxValue;
            PreviousNode = null;
        }

        internal void AddEdge(GraphNode nodeTo)
        {
            successors.AddLast(nodeTo);
        }

        internal bool RemoveEdge(GraphNode nodeTo)
        {
            return successors.Remove(nodeTo);
        }
    }
}
