using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace NWE.DoacaoSangue.Domain;

public static class DomainModule
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddEvents();

        return services;
    }

    private static IServiceCollection AddEvents(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}
