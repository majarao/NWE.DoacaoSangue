using Microsoft.EntityFrameworkCore;
using NWE.DoacaoSangue.Domain.Entities;
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
}
