using Microsoft.EntityFrameworkCore;

namespace Graph.Model
{
    public interface IGraphDataContext : IDataContext
    {
        DbSet<Edge> Edges { get; }

        DbSet<Node> Nodes { get; }
    }
}
