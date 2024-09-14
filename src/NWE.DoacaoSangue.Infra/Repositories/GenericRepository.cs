using Microsoft.EntityFrameworkCore;
using NWE.DoacaoSangue.Infra.Data;
using NWE.DoacaoSangue.Shared.Entities;

namespace NWE.DoacaoSangue.Infra.Repositories;

public sealed class GenericRepository<T>(IUnitOfWork unitOfWork) where T : Entity
{
    public IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task<List<T>?> GetAllAsync() => await UnitOfWork.Context.Set<T>().ToListAsync();

    public async Task<T?> GetByIdAsync(Guid id) => await UnitOfWork.Context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);

    public async Task<T> CreateAsync(T data)
    {
        await UnitOfWork.Context.Set<T>().AddAsync(data);
        return data;
    }

    public T Update(T data)
    {
        UnitOfWork.Context.Set<T>().Update(data);
        return data;
    }

    public void Remove(T data) => UnitOfWork.Context.Set<T>().Remove(data);
}
