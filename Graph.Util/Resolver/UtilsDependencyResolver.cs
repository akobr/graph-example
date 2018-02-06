using Graph.Resolver;
using Graph.Util.Arguments;
using Graph.Util.Help;
using System.Composition;

namespace Graph.Util.Resolver
{
    [Export(typeof(IComponent))]
    public class UtilsDependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IArgumentsParser, DefaultArgumentsParser>();
            registerComponent.RegisterType<IHelpGenerator, DefaultHelpGenerator>();
        }
    }
}
