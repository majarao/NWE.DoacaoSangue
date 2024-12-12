using Microsoft.EntityFrameworkCore;
using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Infra.Data;

namespace NWE.DoacaoSangue.Infra.Repositories;

internal sealed class GenericRepository<T>(IUnitOfWork unitOfWork) where T : Entity
{
    public IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task<List<T>?> GetAllAsync() => await UnitOfWork.Context.Set<T>().AsNoTracking().ToListAsync();

    public async Task<T?> GetByIdAsync(Guid id) => await UnitOfWork.Context.Set<T>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

    public async Task<T> CreateAsync(T data)
    {
        await UnitOfWork.Context.AddAsync(data);
        return data;
    }

    public T Update(T data)
    {
        UnitOfWork.Context.Update(data);
        return data;
    }

    public async Task<int> CommitAsync() => await UnitOfWork.CommitAsync();
}
