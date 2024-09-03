using NWE.DoacaoSangue.Domain.Entities;

namespace NWE.DoacaoSangue.Domain.Repositories;

public interface IEnderecoRepository
{
    public Task<List<Endereco>?> GetAllAsync();
    public Task<Endereco?> GetByIdAsync(Guid id);
    public Task<Endereco> CreateAsync(Endereco endereco);
    public Task<Endereco> UpdateAsync(Guid id, Endereco endereco);
    public Task<bool> RemoveAsync(Guid id);
}
