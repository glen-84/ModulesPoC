using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Autofac;
using System;
using Autofac.Dnx;
using System.Collections.Generic;
using HostApp.Controllers;
using MyModule.Controllers;

namespace HostApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // This should probably be moved into the module system with the ability to list additional non-module assemblies.
            services.WithControllersAsServices2(new List<Type>()
            {
                typeof(ValuesController),
                typeof(AnotherValuesController)
            });

            // Create the Autofac container builder.
            var builder = new ContainerBuilder();

            // Add any Autofac modules or registrations.
            builder.RegisterModule(new AutofacModule());

            // Populate the services.
            builder.Populate(services);

            // Build the container.
            var container = builder.Build();

            // "ModSys" represents a module loading system.
            var mods = new ModSys(container);

            // Register a module.
            mods.RegisterModule<MyModule.ModuleStartup>();

            // Resolve and return the service provider.
            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc();
        }
    }
}
