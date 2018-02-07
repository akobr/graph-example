using Graph.Model;
using Graph.Resolver;
using System.Composition;

namespace Graph.Services.Resolver
{
    [Export(typeof(IComponent))]
    public class ServicesDependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterSingletonType<IModelConfiguration, ServicesModelConfiguration>();
        }
    }
}