using Autofac;
using Autofac.Dnx;
using System;
using System.Collections.Generic;

public class ModSys
{
    private readonly IContainer _container;

    public static Dictionary<string, ILifetimeScope> scopes = new Dictionary<string, ILifetimeScope>();

    public ModSys(IContainer container)
    {
        _container = container;
    }

    public void RegisterModule<T>() // where T is ModuleStartup, etc.
    {
        // Create a "child container" for the module.
        var tag = typeof(T).Assembly.FullName;
        var module = (IModuleStartup)Activator.CreateInstance(typeof(T));
        var scope = _container.BeginLifetimeScope(tag, b => b.Populate(module.GetServices()));

        // Keep track of child scopes, as they are not accessible via the root scope/container.
        scopes.Add(tag, scope);
    }
}