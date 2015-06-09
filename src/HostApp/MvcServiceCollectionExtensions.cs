using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace HostApp
{
    public static class MvcServiceCollectionExtensions
    {
        public static IServiceCollection WithControllersAsServices2(this IServiceCollection services, IEnumerable<Type> controllerTypes)
        {
            var controllerTypeProvider = new FixedSetControllerTypeProvider();

            foreach (var type in controllerTypes)
            {
                services.TryAdd(ServiceDescriptor.Transient(type, type));
                controllerTypeProvider.ControllerTypes.Add(type.GetTypeInfo());
            }

            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ChildContainerControllerActivator>());
            services.Replace(ServiceDescriptor.Instance<IControllerTypeProvider>(controllerTypeProvider));

            return services;
        }
    }
}
