using Graph.Model;
using Graph.Model.Interfaces;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Graph.Services
{
    [ServiceContract]
    public interface IGraph
    {
        [OperationContract]
        [WebGet(UriTemplate = "graph")]
        ICollection<Node> GetGraph();

        [OperationContract]
        [WebGet(UriTemplate = "path/{idFrom}/{idTo}")]
        ICollection<int> GetShortestPath(string idFrom, string idTo);
    }
}
