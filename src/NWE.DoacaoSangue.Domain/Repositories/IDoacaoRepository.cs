using NWE.DoacaoSangue.Domain.Entities;

namespace NWE.DoacaoSangue.Domain.Repositories;

public interface IDoacaoRepository
{
    public Task<List<Doacao>?> GetAllAsync();
    public Task<Doacao?> GetByIdAsync(Guid id);
    public Task<Doacao> CreateAsync(Doacao doacao);
    public Task<Doacao> UpdateAsync(Guid id, Doacao doacao);
    public Task<bool> RemoveAsync(Guid id);
}
