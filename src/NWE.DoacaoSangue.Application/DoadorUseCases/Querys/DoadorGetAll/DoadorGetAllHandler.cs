using MediatR;
using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Repositories;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorGetAll;

public class DoadorGetAllHandler(IDoadorRepository repository) : IRequestHandler<DoadorGetAllQuery, List<DoadorGetAllResult>?>
{
    private IDoadorRepository Repository { get; } = repository;

    public async Task<List<DoadorGetAllResult>?> Handle(DoadorGetAllQuery request, CancellationToken cancellationToken)
    {
        List<Doador>? doadores = await Repository.GetAllAsync();

        if (doadores is null)
            return null;

        List<DoadorGetAllResult>? result =
            doadores.Select(d =>
                new DoadorGetAllResult(
                    d.Id,
                    d.NomeCompleto,
                    d.Email,
                    d.DataNascimento,
                    d.Genero.ToString(),
                    d.Peso,
                    d.TipoSanguineo.ToString(),
                    d.FatorRH.ToString()))
            .ToList();

        return result;
    }
}
