using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Repositories;
using NWE.DoacaoSangue.Infra.Data;

namespace NWE.DoacaoSangue.Infra.Repositories;

public class DoadorRepository(IUnitOfWork unitOfWork) : IDoadorRepository
{
    private GenericRepository<Doador> Repository { get; } = new(unitOfWork);

    public async Task<List<Doador>?> GetAllAsync() => await Repository.GetAllAsync();

    public async Task<Doador?> GetByIdAsync(Guid id) => await Repository.GetByIdAsync(id);

    public async Task<Doador> CreateAsync(Doador doador)
    {
        await Repository.CreateAsync(doador);
        await Repository.UnitOfWork.CommitAsync();

        return doador;
    }

    public async Task<Doador> UpdateAsync(Guid id, Doador doador)
    {
        if (id == doador.Id)
        {
            Repository.Update(doador);
            await Repository.UnitOfWork.CommitAsync();
        }

        return doador;
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        Doador? doador = await Repository.GetByIdAsync(id);

        if (doador == null)
            return false;

        Repository.Remove(doador);
        return await Repository.UnitOfWork.CommitAsync() > 0;
    }
}
