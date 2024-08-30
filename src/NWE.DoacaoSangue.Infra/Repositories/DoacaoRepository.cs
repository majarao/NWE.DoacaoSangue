using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Repositories;
using NWE.DoacaoSangue.Infra.Data;

namespace NWE.DoacaoSangue.Infra.Repositories;

public class DoacaoRepository(IUnitOfWork unitOfWork) : IDoacaoRepository
{
    private AbstractCrud<Doacao> Crud { get; } = new(unitOfWork);

    public async Task<List<Doacao>> GetAllAsync() => await Crud.GetAllAsync();

    public async Task<Doacao> GetByIdAsync(Guid id) => await Crud.GetByIdAsync(id);

    public async Task<Doacao> CreateAsync(Doacao doacao)
    {
        await Crud.CreateAsync(doacao);
        await Crud.UnitOfWork.CommitAsync();

        return doacao;
    }

    public async Task<Doacao> UpdateAsync(Guid id, Doacao doacao)
    {
        if (id == doacao.Id)
        {
            Crud.Update(doacao);
            await Crud.UnitOfWork.CommitAsync();
        }

        return doacao;
    }

    public async Task<bool> RemoveAsync(Guid id, Doacao doacao)
    {
        if (id != doacao.Id) 
            return false;

        Crud.Remove(doacao);
        return await Crud.UnitOfWork.CommitAsync() > 0;
    }
}
