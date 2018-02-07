using CommonServiceLocator;
using Graph.Model;
using Graph.Model.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Graph.Services
{
    public class Graph : IGraph
    {
        public IList<INode> GetGraph()
        {
            Activator.Initialise();

            IGraphStorageService storage = ServiceLocator.Current.GetInstance<IGraphStorageService>();
            return storage.RetrieveGraph();
        }

        public IList<IEdge> GetShortestPath(string idFrom, string idTo)
        {
            Activator.Initialise();

            return null;
        }
    }
}
