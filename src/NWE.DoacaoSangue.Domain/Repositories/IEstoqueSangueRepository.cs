using NWE.DoacaoSangue.Domain.Entities;

namespace NWE.DoacaoSangue.Domain.Repositories;

public interface IEstoqueSangueRepository
{
    public Task<List<EstoqueSangue>?> GetAllAsync();
    public Task<EstoqueSangue?> GetByIdAsync(Guid id);
    public Task<EstoqueSangue> CreateAsync(EstoqueSangue estoqueSangue);
    public Task<EstoqueSangue> UpdateAsync(Guid id, EstoqueSangue estoqueSangue);
    public Task<bool> RemoveAsync(Guid id);
}
