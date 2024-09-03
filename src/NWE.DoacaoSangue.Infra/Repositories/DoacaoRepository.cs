using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Repositories;
using NWE.DoacaoSangue.Infra.Data;

namespace NWE.DoacaoSangue.Infra.Repositories;

public class DoacaoRepository(IUnitOfWork unitOfWork) : IDoacaoRepository
{
    private GenericRepository<Doacao> Repository { get; } = new(unitOfWork);

    public async Task<List<Doacao>?> GetAllAsync() => await Repository.GetAllAsync();

    public async Task<Doacao?> GetByIdAsync(Guid id) => await Repository.GetByIdAsync(id);

    public async Task<Doacao> CreateAsync(Doacao doacao)
    {
        await Repository.CreateAsync(doacao);
        await Repository.UnitOfWork.CommitAsync();

        return doacao;
    }

    public async Task<Doacao> UpdateAsync(Guid id, Doacao doacao)
    {
        if (id == doacao.Id)
        {
            Repository.Update(doacao);
            await Repository.UnitOfWork.CommitAsync();
        }

        return doacao;
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        Doacao? doacao = await Repository.GetByIdAsync(id);

        if (doacao == null)
            return false;

        Repository.Remove(doacao);
        return await Repository.UnitOfWork.CommitAsync() > 0;
    }
}
