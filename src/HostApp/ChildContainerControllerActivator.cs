using Autofac;
using Microsoft.AspNet.Mvc;
using System;

namespace HostApp
{
    public class ChildContainerControllerActivator : IControllerActivator
    {
        public object Create(ActionContext actionContext, Type controllerType)
        {
            var services = actionContext.HttpContext.RequestServices;

            string tag = controllerType.Assembly.FullName;

            ILifetimeScope scope;

            // Try to get a child container (scope) for the controller's assembly.
            // A static method for accessing scopes might not be ideal.
            if (ModSys.scopes.TryGetValue(tag, out scope))
            {
                return scope.Resolve(controllerType);
            }
            else
            {
                return services.GetService(controllerType);
            }
        }
    }
}