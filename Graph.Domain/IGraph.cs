namespace Graph.Domain
{
    public interface IGraph
    {
        int NodeCount { get; }

        void AddEdge(int idFrom, int idTo);

        IGraphNode AddNode(int id);

        IGraphNode GetNode(int id);

        void RemoveEdge(int idFrom, int idTo);

        bool RemoveNode(int id);

        void Clean();
    }
}