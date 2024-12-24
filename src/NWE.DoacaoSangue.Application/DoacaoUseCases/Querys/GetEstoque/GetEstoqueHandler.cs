using MediatR;
using NWE.DoacaoSangue.Domain.Models;
using NWE.DoacaoSangue.Domain.Repositories;

namespace NWE.DoacaoSangue.Application.DoacaoUseCases.Querys.GetEstoque;

public class GetEstoqueHandler(IDoacaoRepository repository) : IRequestHandler<GetEstoqueQuery, List<Estoque>>
{
    private IDoacaoRepository Repository { get; } = repository;

    public async Task<List<Estoque>> Handle(GetEstoqueQuery request, CancellationToken cancellationToken)
    {
        List<Estoque> estoques = await Repository.GetEstoqueAsync();

        return estoques;
    }
}
