using System.Collections.Generic;
using Graph.Model.Interfaces;

namespace Graph.Model
{
    public interface IGraphStorageService
    {
        void DeleteGraph();

        IList<INode> RetrieveGraph();

        void SaveGraph(IList<Node> nodes);
    }
}