using Microsoft.Extensions.Options;
using NWE.DoacaoSangue.API.Options;
using NWE.DoacaoSangue.Domain.Models;
using NWE.DoacaoSangue.Domain.Repositories;

namespace NWE.DoacaoSangue.API.BackgroundServices;

public class EstoqueAbaixoMinimoService(IServiceProvider services, IOptions<EstoqueAbaixoMinimoOptions> options) : BackgroundService
{
    private IServiceProvider Services { get; } = services;
    private int ParametroEstoqueMinimo { get; } = options.Value.ParametroEstoqueMinimo;
    private int IntervaloNotificacao { get; } = options.Value.IntervaloNotificacao;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using PeriodicTimer timer = new(TimeSpan.FromSeconds(IntervaloNotificacao));

        while (await timer.WaitForNextTickAsync(stoppingToken))
            await NotificaEstoqueAbaixoMinimo();
    }

    private Task NotificaEstoqueAbaixoMinimo()
    {
        List<Estoque> estoqueMinimos = [];

        using (var scope = Services.CreateScope())
        {
            IDoacaoRepository repository =
                scope.ServiceProvider
                    .GetRequiredService<IDoacaoRepository>();

            estoqueMinimos = repository.GetEstoqueMinimoAsync(ParametroEstoqueMinimo).Result;
        }

        foreach (Estoque estoque in estoqueMinimos)
            Console.WriteLine($"O estoque de {estoque.TipoSanguineo} {estoque.FatorRH} está com estoque de {estoque.Quantidade} e está abaixo do mínimo {ParametroEstoqueMinimo}");

        return Task.CompletedTask;
    }
}
