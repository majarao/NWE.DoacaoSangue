using MediatR;
using NWE.DoacaoSangue.Application.Models;
using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Repositories;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoacoesDoDoador;

public class DoacoesDoDoadorHandler(IDoadorRepository repository) : IRequestHandler<DoacoesDoDoadorQuery, DoacoesDoDoadorResult?>
{
    IDoadorRepository Repository { get; } = repository;

    public async Task<DoacoesDoDoadorResult?> Handle(DoacoesDoDoadorQuery request, CancellationToken cancellationToken)
    {
        Doador? doador = await Repository.RecuperaDoacoesAsync(request.Id);

        if (doador is null)
            return null;

        DoacoesDoDoadorResult? result = new(
            doador.Id,
            doador.NomeCompleto,
            doador.TipoSanguineo,
            doador.FatorRH,
            doador.Doacoes?.Select(d => new DoacaoModel(d.DataDoacao, d.QuantidadeML)).ToList());

        return result;
    }
}
