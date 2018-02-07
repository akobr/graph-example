using Graph.Resolver;
using Unity;

namespace Graph.Services.Resolver
{
    internal class RegisterComponent : IRegisterComponent
    {
        private readonly IUnityContainer container;

        public RegisterComponent(IUnityContainer container)
        {
            this.container = container;
        }

        public void RegisterType<TInterface, TClass>()
            where TClass : TInterface
        {
            container.RegisterType<TInterface, TClass>();
        }

        public void RegisterSingletonType<TInterface, TClass>()
            where TClass : TInterface
        {
            container.RegisterSingleton<TInterface, TClass>();
        }
    }
}
