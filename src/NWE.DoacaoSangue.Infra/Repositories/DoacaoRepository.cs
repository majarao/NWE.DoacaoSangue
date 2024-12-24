using Microsoft.EntityFrameworkCore;
using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Enums;
using NWE.DoacaoSangue.Domain.Models;
using NWE.DoacaoSangue.Domain.Repositories;
using NWE.DoacaoSangue.Infra.Data;

namespace NWE.DoacaoSangue.Infra.Repositories;

internal class DoacaoRepository(IUnitOfWork unitOfWork, IDoadorRepository doadorRepository) : IDoacaoRepository
{
    private GenericRepository<Doacao> Repository { get; } = new(unitOfWork);
    private IDoadorRepository DoadorRepository { get; } = doadorRepository;

    public async Task<Doacao?> RecuperaUltimaDoacaoDoDoadorAsync(Guid doadorId) =>
        await Repository.UnitOfWork.Context.Doacoes
            .OrderBy(d => d.DataDoacao)
            .LastOrDefaultAsync(d => d.DoadorId == doadorId);

    public async Task<Doacao> CreateAsync(Doacao doacao)
    {
        await Repository.CreateAsync(doacao);

        Doador? doador = await DoadorRepository.GetByIdAsync(doacao.DoadorId);

        DoacaoEstoque estoque = new(doador!.TipoSanguineo, doador.FatorRH, doacao.QuantidadeML);
        await Repository.UnitOfWork.Context.DoacoesEstoque.AddAsync(estoque);

        await Repository.UnitOfWork.CommitAsync();

        return doacao;
    }

    public async Task<List<Estoque>> GetEstoqueAsync()
    {
        List<Estoque> estoques = [];

        foreach (ETipoSanguineo tipo in Enum.GetValues<ETipoSanguineo>())
        {
            foreach (EFatorRH fator in Enum.GetValues<EFatorRH>())
            {
                Estoque estoque = new(
                    tipo.ToString(),
                    fator.ToString(),
                    await Repository.UnitOfWork.Context.DoacoesEstoque
                        .Where(e => e.TipoSanguineo == tipo && e.FatorRH == fator)
                        .SumAsync(e => e.QuantidadeML));

                estoques.Add(estoque);
            }
        }

        return estoques;
    }

    public async Task<List<Estoque>> GetEstoqueMinimoAsync(int abaixoMinimo)
    {
        List<Estoque> estoques = await GetEstoqueAsync();

        estoques = estoques.Where(e => e.Quantidade < abaixoMinimo).ToList();

        return estoques;
    }
}
