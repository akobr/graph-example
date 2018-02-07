using Graph.Model.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

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

        [IgnoreDataMember]
        [XmlIgnore]
        [JsonIgnore]
        public HashSet<Edge> OutEdges { get; set; }

        [IgnoreDataMember]
        [XmlIgnore]
        [JsonIgnore]
        public HashSet<Edge> InEdges { get; set; }

        [IgnoreDataMember]
        [XmlIgnore]
        [JsonIgnore]
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
