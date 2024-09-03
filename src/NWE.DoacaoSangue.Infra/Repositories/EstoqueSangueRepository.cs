using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Repositories;
using NWE.DoacaoSangue.Infra.Data;

namespace NWE.DoacaoSangue.Infra.Repositories;

public class EstoqueSangueRepository(IUnitOfWork unitOfWork) : IEstoqueSangueRepository
{
    private GenericRepository<EstoqueSangue> Repository { get; } = new(unitOfWork);

    public async Task<List<EstoqueSangue>?> GetAllAsync() => await Repository.GetAllAsync();

    public async Task<EstoqueSangue?> GetByIdAsync(Guid id) => await Repository.GetByIdAsync(id);

    public async Task<EstoqueSangue> CreateAsync(EstoqueSangue estoqueSangue)
    {
        await Repository.CreateAsync(estoqueSangue);
        await Repository.UnitOfWork.CommitAsync();

        return estoqueSangue;
    }

    public async Task<EstoqueSangue> UpdateAsync(Guid id, EstoqueSangue estoqueSangue)
    {
        if (id == estoqueSangue.Id)
        {
            Repository.Update(estoqueSangue);
            await Repository.UnitOfWork.CommitAsync();
        }

        return estoqueSangue;
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        EstoqueSangue? estoqueSangue = await Repository.GetByIdAsync(id);

        if (estoqueSangue == null)
            return false;

        Repository.Remove(estoqueSangue);
        return await Repository.UnitOfWork.CommitAsync() > 0;
    }
}
