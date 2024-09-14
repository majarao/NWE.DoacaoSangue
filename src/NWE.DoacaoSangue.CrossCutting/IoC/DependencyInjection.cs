using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NWE.DoacaoSangue.Domain.Repositories;
using NWE.DoacaoSangue.Infra.Data;
using NWE.DoacaoSangue.Infra.Integrations;
using NWE.DoacaoSangue.Infra.Repositories;
using NWE.DoacaoSangue.Shared.Integrations;

namespace NWE.DoacaoSangue.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DoacaoSangueContext>(option => option
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IDoacaoRepository, DoacaoRepository>();
        services.AddScoped<IDoadorRepository, DoadorRepository>();
        services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        services.AddScoped<IEstoqueSangueRepository, EstoqueSangueRepository>();

        return services;
    }

    public static IServiceCollection AddIntegrations(this IServiceCollection services)
    {
        services.AddScoped<ICEPService, ViaCEPService>();

        return services;
    }
}
