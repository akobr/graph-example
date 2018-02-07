using CommonServiceLocator;
using Graph.Model;
using Graph.Model.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Graph.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Graph" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Graph.svc or Graph.svc.cs at the Solution Explorer and start debugging.
    public class Graph : IGraph
    {
        public IList<INode> GetGraph()
        {
            Activator.Initialise();

            IGraphStorageService storage = ServiceLocator.Current.GetInstance<IGraphStorageService>();
            return storage.RetrieveGraph().ToList();
        }

        public IList<IEdge> GetShortestPath(string idFrom, string idTo)
        {
            Activator.Initialise();

            return null;
        }
    }
}
