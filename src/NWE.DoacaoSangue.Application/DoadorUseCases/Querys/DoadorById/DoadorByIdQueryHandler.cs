using MediatR;
using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Repositories;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorById;

public class DoadorByIdQueryHandler(IDoadorRepository repository) : IRequestHandler<DoadorByIdQuery, DoadorByIdResult?>
{
    private IDoadorRepository Repository { get; } = repository;

    public async Task<DoadorByIdResult?> Handle(DoadorByIdQuery request, CancellationToken cancellationToken)
    {
        Doador? doador = await Repository.GetByIdAsync(request.Id);

        if (doador is not null)
            return new DoadorByIdResult(
                doador.Id,
                doador.NomeCompleto,
                doador.Email,
                doador.DataNascimento,
                doador.Genero,
                doador.Peso,
                doador.TipoSanguineo,
                doador.FatorRH);

        return null;
    }
}
