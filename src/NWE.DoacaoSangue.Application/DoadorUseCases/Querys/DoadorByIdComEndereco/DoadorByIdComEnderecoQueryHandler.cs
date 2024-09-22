using MediatR;
using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Repositories;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorByIdComEndereco;

public class DoadorByIdComEnderecoQueryHandler(IDoadorRepository repository) : IRequestHandler<DoadorByIdComEnderecoQuery, DoadorByIdComEnderecoResult?>
{
    private IDoadorRepository Repository { get; } = repository;

    public async Task<DoadorByIdComEnderecoResult?> Handle(DoadorByIdComEnderecoQuery request, CancellationToken cancellationToken)
    {
        Doador? doador = await Repository.GetByIdComEnderecoAsync(request.Id);

        if (doador is not null)
            return new DoadorByIdComEnderecoResult(
                doador.Id,
                doador.NomeCompleto,
                doador.Email,
                doador.DataNascimento,
                doador.Genero,
                doador.Peso,
                doador.TipoSanguineo,
                doador.FatorRH,
                doador.Endereco is null ? null : new(doador.Endereco.CEP, doador.Endereco.Logradouro, doador.Endereco.Cidade, doador.Endereco.Estado));

        return null;
    }
}
