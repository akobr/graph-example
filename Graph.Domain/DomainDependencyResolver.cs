using Graph.Resolver;
using System.Composition;

namespace Graph.Domain
{
    [Export(typeof(IComponent))]
    public class DomainDependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterSingletonType<IGraphBuilder, DefaultGraphBuilder>();
            registerComponent.RegisterSingletonType<IShortestPathStrategy, DijkstrasShortestPathStrategy>();
        }
    }
}
