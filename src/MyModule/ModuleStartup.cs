using Microsoft.Framework.DependencyInjection;

namespace MyModule
{
    public class ModuleStartup : IModuleStartup
    {
        public IServiceCollection GetServices()
        {
            var services = new ServiceCollection();

            // Comment this out, and AnotherValuesController will instead get ValuesService from the root container (scope).
            services.AddTransient<IValuesService>(c => new AnotherValuesService(c.GetRequiredService<ILogger>()));

            return services;
        }
    }
}