using Microsoft.Framework.DependencyInjection;

// This would be in a separate "XYZ Module System" assembly.
public interface IModuleStartup
{
    IServiceCollection GetServices();
}