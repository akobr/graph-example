using System;

namespace Graph.Resolver
{
    public interface IRegisterComponent
    {
        void RegisterType<TInterface, TClass>()
            where TClass : TInterface;

        void RegisterSingletonType<TInterface, TClass>()
            where TClass : TInterface;
    }
}