using Microsoft.EntityFrameworkCore;

namespace Graph.Model
{
    public partial class GraphDataContext : DbContext, IGraphDataContext
    {
        private IModelConfiguration configuration;

        public GraphDataContext(IModelConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public virtual DbSet<Edge> Edges { get; set; }

        public virtual DbSet<Node> Nodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Edge>(entity =>
            {
                entity.HasKey(e => new { e.IdFrom, e.IdTo });

                entity.HasOne(d => d.FromNode)
                    .WithMany(p => p.OutEdges)
                    .HasForeignKey(d => d.IdFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Edge_From_Node");

                entity.HasOne(d => d.ToNode)
                    .WithMany(p => p.InEdges)
                    .HasForeignKey(d => d.IdTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Edge_To_Node");
            });

            modelBuilder.Entity<Node>(entity =>
            {
                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }
    }
}
