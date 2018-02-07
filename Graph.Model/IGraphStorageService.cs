using System.Collections.Generic;
using Graph.Model.Interfaces;

namespace Graph.Model
{
    public interface IGraphStorageService
    {
        void DeleteGraph();

        IEnumerable<INode> RetrieveGraph();

        void SaveGraph(IList<Node> nodes);
    }
}