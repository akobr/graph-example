using Graph.Model.Interfaces;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Graph.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGraph" in both code and config file together.
    [ServiceContract]
    public interface IGraph
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "graph")]
        IList<INode> GetGraph();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "path/{idFrom}/{idTo}")]
        IList<IEdge> GetShortestPath(string idFrom, string idTo);
    }
}
