using MediatR;
using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Repositories;
using NWE.DoacaoSangue.Shared.Integrations;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Commands.AtualizaDoador;

public class AtualizaDoadorHandler(IDoadorRepository repository, ICEPService cepService) : IRequestHandler<AtualizaDoadorCommand, AtualizaDoadorResult>
{
    private IDoadorRepository Repository { get; } = repository;
    private ICEPService CEPService { get; } = cepService;

    public async Task<AtualizaDoadorResult> Handle(AtualizaDoadorCommand request, CancellationToken cancellationToken)
    {
        Doador? doador = await Repository.GetByIdAsync(request.Id);

        if (doador == null)
            return new(request.Id, request.Email, request.Peso, null);

        doador.Atualiza(Repository, request.Email, request.Peso, request.CEP is null ? null : new(CEPService, request.CEP));

        doador = await Repository.UpdateAsync(request.Id, doador);

        AtualizaDoadorResult result = new(
            doador.Id,
            doador.Email,
            doador.Peso,
            doador.Endereco is null ? null : new(doador.Endereco.CEP, doador.Endereco.Logradouro, doador.Endereco.Cidade, doador.Endereco.Estado));

        return result;
    }
}
