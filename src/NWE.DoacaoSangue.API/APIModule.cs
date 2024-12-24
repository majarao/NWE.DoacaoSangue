using NWE.DoacaoSangue.API.BackgroundServices;
using NWE.DoacaoSangue.API.Options;

namespace NWE.DoacaoSangue.API;

public static class APIModule
{
    public static IServiceCollection AddServicesAPI(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddOptions(configuration)
            .AddBackgroundServices();

        return services;
    }

    private static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EstoqueAbaixoMinimoOptions>(configuration.GetSection("EstoqueAbaixoMinimo"));

        return services;
    }

    private static IServiceCollection AddBackgroundServices(this IServiceCollection services)
    {
        services.AddHostedService<EstoqueAbaixoMinimoService>();

        return services;
    }
}
