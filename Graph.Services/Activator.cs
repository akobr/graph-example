using CommonServiceLocator;
using Graph.Model;
using Graph.Resolver;
using Graph.Services.Resolver;
using System.IO;
using System.Reflection;
using Unity;
using Unity.ServiceLocation;

namespace Graph.Services
{
    public static class Activator
    {
        public static void Initialise()
        {
            IUnityContainer container = new UnityContainer();
            RegisterComponent register = new RegisterComponent(container);
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));

            ComponentLoader.LoadContainer(register,
                Assembly.GetExecutingAssembly(),
                Assembly.LoadFile(Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "bin","Graph.Model.dll")));
        }
    }
}