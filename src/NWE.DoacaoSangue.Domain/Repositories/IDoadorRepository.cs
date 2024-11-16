using NWE.DoacaoSangue.Domain.Entities;

namespace NWE.DoacaoSangue.Domain.Repositories;

public interface IDoadorRepository
{
    public Task<List<Doador>?> GetAllAsync();
    public Task<Doador?> GetByIdAsync(Guid id);
    public Task<Doador?> GetByIdComEnderecoAsync(Guid id);
    public bool EmailJaUsado(Guid id, string email);
    public Task<Doador?> RecuperaDoacoesAsync(Guid id);
    public Task<Doador> CreateAsync(Doador doador);
    public Task<Doador> UpdateAsync(Guid id, Doador doador);
}
