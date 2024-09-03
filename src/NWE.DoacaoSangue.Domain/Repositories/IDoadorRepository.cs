using NWE.DoacaoSangue.Domain.Entities;

namespace NWE.DoacaoSangue.Domain.Repositories;

public interface IDoadorRepository
{
    public Task<List<Doador>?> GetAllAsync();
    public Task<Doador?> GetByIdAsync(Guid id);
    public Task<Doador> CreateAsync(Doador doador);
    public Task<Doador> UpdateAsync(Guid id, Doador doador);
    public Task<bool> RemoveAsync(Guid id);
}
