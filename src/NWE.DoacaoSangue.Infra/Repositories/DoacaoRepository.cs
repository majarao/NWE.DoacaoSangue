using Microsoft.EntityFrameworkCore;
using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Repositories;
using NWE.DoacaoSangue.Infra.Data;

namespace NWE.DoacaoSangue.Infra.Repositories;

public class DoacaoRepository(IUnitOfWork unitOfWork) : IDoacaoRepository
{
    private GenericRepository<Doacao> Repository { get; } = new(unitOfWork);

    public async Task<List<Doacao>?> GetAllAsync() => await Repository.GetAllAsync();

    public async Task<Doacao?> GetByIdAsync(Guid id) => await Repository.GetByIdAsync(id);

    public async Task<Doacao?> RecuperaUltimaDoacaoDoDoadorAsync(Guid doadorId) =>
        await Repository.UnitOfWork.Context.Doacoes
            .OrderBy(d => d.DataDoacao)
            .LastOrDefaultAsync(d => d.DoadorId == doadorId);

    public async Task<Doacao> CreateAsync(Doacao doacao)
    {
        await Repository.CreateAsync(doacao);
        await Repository.UnitOfWork.CommitAsync();

        return doacao;
    }
}
