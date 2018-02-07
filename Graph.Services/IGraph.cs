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
        IList<INode> GetGraph();

        [OperationContract]
        [WebGet(UriTemplate = "path/{idFrom}/{idTo}")]
        IList<IEdge> GetShortestPath(string idFrom, string idTo);
    }
}
