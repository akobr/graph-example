using CommonServiceLocator;
using Graph.Domain;
using Graph.Model;
using System.Collections.Generic;

namespace Graph.Services
{
    public class Graph : IGraph
    {
        public ICollection<Node> GetGraph()
        {
            Activator.Initialise();

            IGraphStorageService storage = ServiceLocator.Current.GetInstance<IGraphStorageService>();
            return storage.RetrieveGraph();
        }

        public ICollection<int> GetShortestPath(string idFromValue, string idToValue)
        {
            Activator.Initialise();

            int idFrom, idTo;

            if (!int.TryParse(idFromValue, out idFrom)
                || !int.TryParse(idToValue, out idTo))
            {
                return new List<int>();
            }

            IGraphStorageService storage = ServiceLocator.Current.GetInstance<IGraphStorageService>();
            IGraphBuilder builder = ServiceLocator.Current.GetInstance<IGraphBuilder>();
            IShortestPathStrategy pathStrategy = ServiceLocator.Current.GetInstance<IShortestPathStrategy>();

            Domain.IGraph graph = builder.BuildGraph(storage.RetrieveGraph());
            IGraphNode fromNode = graph.GetNode(idFrom);
            IGraphNode toNode = graph.GetNode(idTo);

            if (fromNode == null || toNode == null)
            {
                return new List<int>();
            }

            return pathStrategy.FindShortestPath(graph, fromNode, toNode);
        }
    }
}
