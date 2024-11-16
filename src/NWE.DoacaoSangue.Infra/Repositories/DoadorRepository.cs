﻿using Microsoft.EntityFrameworkCore;
using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Repositories;
using NWE.DoacaoSangue.Infra.Data;

namespace NWE.DoacaoSangue.Infra.Repositories;

public class DoadorRepository(IUnitOfWork unitOfWork) : IDoadorRepository
{
    private GenericRepository<Doador> Repository { get; } = new(unitOfWork);

    public async Task<List<Doador>?> GetAllAsync() => await Repository.GetAllAsync();

    public async Task<Doador?> GetByIdAsync(Guid id) => await Repository.GetByIdAsync(id);

    public bool EmailJaUsado(Guid id, string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        Doador? doador =
            Repository.UnitOfWork.Context.Doadores
                .AsNoTracking()
                .FirstOrDefault(d => d.Email == email && d.Id != id);

        return doador is not null;
    }

    public async Task<Doador?> GetByIdComEnderecoAsync(Guid id) =>
        await Repository.UnitOfWork.Context.Doadores
            .AsNoTracking()
            .Include(d => d.Endereco)
            .SingleOrDefaultAsync(d => d.Id == id);

    public async Task<Doador?> RecuperaDoacoesAsync(Guid id) =>
        await Repository.UnitOfWork.Context.Doadores
            .AsNoTracking()
            .Include(d => d.Doacoes)
            .SingleOrDefaultAsync(d => d.Id == id);

    public async Task<Doador> CreateAsync(Doador doador)
    {
        await Repository.CreateAsync(doador);

        if (doador.Endereco is not null)
            await Repository.UnitOfWork.Context.Enderecos.AddAsync(doador.Endereco);

        await Repository.UnitOfWork.CommitAsync();

        return doador;
    }

    public async Task<Doador> UpdateAsync(Guid id, Doador doador)
    {
        if (id == doador.Id)
        {
            Repository.Update(doador);

            if (doador.Endereco is null)
            {
                Endereco? endereco = await Repository.UnitOfWork.Context.Enderecos.FirstOrDefaultAsync(e => e.DoadorId == id);

                if (endereco != null)
                    Repository.UnitOfWork.Context.Enderecos.Remove(endereco);
            }

            await Repository.UnitOfWork.CommitAsync();
        }

        return doador;
    }
}
