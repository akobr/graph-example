using Graph.Model.Interfaces;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Graph.Model
{
    [DataContract]
    public partial class Edge : IEdge
    {
        [DataMember]
        public int IdFrom { get; set; }

        [DataMember]
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
