using Graph.Resolver;
using System.Composition;

namespace Graph.Model
{
    [Export(typeof(IComponent))]
    public class ModelDependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IDataContext, GraphDataContext>();
            registerComponent.RegisterType<IUnitOfWork, DefaultUnitOfWork>();
            registerComponent.RegisterType<IGraphStorageService, GraphStorageService>();
        }
    }
}
