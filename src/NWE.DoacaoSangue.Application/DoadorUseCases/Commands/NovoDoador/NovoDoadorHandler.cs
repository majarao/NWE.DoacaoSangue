using MediatR;
using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Integrations;
using NWE.DoacaoSangue.Domain.Repositories;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Commands.NovoDoador;

public class NovoDoadorHandler(IDoadorRepository repository, ICEPService cepService) :
    IRequestHandler<NovoDoadorCommand, NovoDoadorResult>
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

        doador = await Repository.CreateAsync(doador);

        NovoDoadorResult result = new(
            doador.Id,
            doador.NomeCompleto,
            doador.Email,
            doador.DataNascimento,
            doador.Genero.ToString(),
            doador.Peso,
            doador.TipoSanguineo.ToString(),
            doador.FatorRH.ToString());

        return result;
    }
}
