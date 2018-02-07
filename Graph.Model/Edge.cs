using Graph.Model.Interfaces;
using Newtonsoft.Json;

namespace Graph.Model
{
    public partial class Edge : IEdge
    {
        public int IdFrom { get; set; }

        public int IdTo { get; set; }

        [JsonIgnore]
        public Node FromNode { get; set; }

        [JsonIgnore]
        public Node ToNode { get; set; }
    }
}
