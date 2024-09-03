using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Repositories;
using NWE.DoacaoSangue.Infra.Data;

namespace NWE.DoacaoSangue.Infra.Repositories;

public class EnderecoRepository(IUnitOfWork unitOfWork) : IEnderecoRepository
{
    private GenericRepository<Endereco> Repository { get; } = new(unitOfWork);

    public async Task<List<Endereco>?> GetAllAsync() => await Repository.GetAllAsync();

    public async Task<Endereco?> GetByIdAsync(Guid id) => await Repository.GetByIdAsync(id);

    public async Task<Endereco> CreateAsync(Endereco endereco)
    {
        await Repository.CreateAsync(endereco);
        await Repository.UnitOfWork.CommitAsync();

        return endereco;
    }

    public async Task<Endereco> UpdateAsync(Guid id, Endereco endereco)
    {
        if (id == endereco.Id)
        {
            Repository.Update(endereco);
            await Repository.UnitOfWork.CommitAsync();
        }

        return endereco;
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        Endereco? endereco = await Repository.GetByIdAsync(id);

        if (endereco == null)
            return false;

        Repository.Remove(endereco);
        return await Repository.UnitOfWork.CommitAsync() > 0;
    }
}
