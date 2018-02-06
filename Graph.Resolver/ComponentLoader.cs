using System.Collections.Generic;
using System.Composition.Hosting;
using System.Reflection;

namespace Graph.Resolver
{
    public static class ComponentLoader
    {
        public static void LoadContainer(IRegisterComponent register, params Assembly[] assemblies)
        {
            LoadContainer(register, (IEnumerable<Assembly>)assemblies);
        }

        public static void LoadContainer(IRegisterComponent register, IEnumerable<Assembly> assemblies)
        {
            ContainerConfiguration configuration = new ContainerConfiguration().WithAssemblies(assemblies);

            using (CompositionHost host = configuration.CreateContainer())
            {
                foreach (IComponent module in host.GetExports<IComponent>())
                {
                    module.SetUp(register);
                }
            }
        }
    }
}