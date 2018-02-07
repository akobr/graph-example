using Graph.Model.Interfaces;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Graph.Model
{
    public partial class Edge : IEdge
    {
        public int IdFrom { get; set; }

        public int IdTo { get; set; }

        [IgnoreDataMember]
        [XmlIgnore]
        [JsonIgnore]
        public Node FromNode { get; set; }

        [IgnoreDataMember]
        [XmlIgnore]
        [JsonIgnore]
        public Node ToNode { get; set; }
    }
}
