using System.Collections.Generic;
using Graph.Model.Interfaces;

namespace Graph.Model
{
    public interface IGraphStorageService
    {
        void DeleteGraph();

        IList<Node> RetrieveGraph();

        void SaveGraph(IList<Node> nodes);
    }
}