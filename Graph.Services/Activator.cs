﻿using CommonServiceLocator;
using Graph.Domain;
using Graph.Model;
using Graph.Resolver;
using Graph.Services.Resolver;
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
                Assembly.GetAssembly(typeof(ModelDependencyResolver)),
                Assembly.GetAssembly(typeof(DomainDependencyResolver)));
        }
    }
}