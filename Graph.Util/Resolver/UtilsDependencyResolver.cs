using Graph.Model;
using Graph.Resolver;
using Graph.Util.Domain;
using System.Composition;

namespace Graph.Util.Resolver
{
    [Export(typeof(IComponent))]
    public class UtilsDependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterSingletonType<IArgumentsParser, DefaultArgumentsParser>();
            registerComponent.RegisterSingletonType<IHelpGenerator, DefaultHelpGenerator>();
            registerComponent.RegisterSingletonType<IGraphLoader, DefaultGraphLoader>();
            registerComponent.RegisterSingletonType<IModelConfiguration, UtilModelConfiguration>();
        }
    }
}
