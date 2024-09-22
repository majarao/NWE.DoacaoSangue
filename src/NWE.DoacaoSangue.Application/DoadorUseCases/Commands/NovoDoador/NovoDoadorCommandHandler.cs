using MediatR;
using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Repositories;
using NWE.DoacaoSangue.Shared.Integrations;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Commands.NovoDoador;

public class NovoDoadorCommandHandler(IDoadorRepository repository, ICEPService cepService) : IRequestHandler<NovoDoadorCommand, NovoDoadorResult>
{
    private IDoadorRepository Repository { get; } = repository;
    private ICEPService CEPService { get; } = cepService;

    public async Task<NovoDoadorResult> Handle(NovoDoadorCommand request, CancellationToken cancellationToken)
    {
        Doador doador = new(
            Repository,
            request.NomeCompleto,
            request.Email,
            request.DataNascimento,
            request.Genero,
            request.Peso,
            request.TipoSanguineo,
            request.FatorRH,
            request.CEP is null ? null : new(CEPService, request.CEP));

        await Repository.CreateAsync(doador);

        return new NovoDoadorResult(
            doador.Id,
            doador.NomeCompleto,
            doador.Email,
            doador.DataNascimento,
            doador.Genero,
            doador.Peso,
            doador.TipoSanguineo,
            doador.FatorRH);
    }
}
