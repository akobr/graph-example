using Graph.Model.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Graph.Model
{
    public partial class Node : INode
    {
        public Node()
        {
            OutEdges = new HashSet<Edge>();
            InEdges = new HashSet<Edge>();
        }

        public int Id { get; set; }

        public string Label { get; set; }

        [JsonIgnore]
        public HashSet<Edge> OutEdges { get; set; }

        [JsonIgnore]
        public HashSet<Edge> InEdges { get; set; }

        IEnumerable<int> INode.AdjacentNodes
        {
            get
            {
                foreach (Edge edge in OutEdges)
                {
                    yield return edge.IdTo;
                }
            }
        }
    }
}
