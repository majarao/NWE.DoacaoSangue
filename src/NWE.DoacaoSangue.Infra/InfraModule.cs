using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NWE.DoacaoSangue.Domain.Integrations;
using NWE.DoacaoSangue.Domain.Repositories;
using NWE.DoacaoSangue.Infra.Data;
using NWE.DoacaoSangue.Infra.Integrations;
using NWE.DoacaoSangue.Infra.Repositories;

namespace NWE.DoacaoSangue.Infra;

public static class InfraModule
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddContext(configuration)
            .AddRepository()
            .AddIntegrations();

        return services;
    }

    private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DoacaoSangueContext>(option => option
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

    private static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IDoacaoRepository, DoacaoRepository>();
        services.AddScoped<IDoadorRepository, DoadorRepository>();

        return services;
    }

    private static IServiceCollection AddIntegrations(this IServiceCollection services)
    {
        services.AddScoped<ICEPService, ViaCEPService>();

        return services;
    }
}
