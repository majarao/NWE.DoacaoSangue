using Microsoft.EntityFrameworkCore;
using NWE.DoacaoSangue.Domain.Entities;
using System.Reflection;

namespace NWE.DoacaoSangue.Infra.Data;

public class DoacaoSangueContext : DbContext
{
    public DbSet<Doador> Doadores { get; set; } = null!;
    public DbSet<Doacao> Doacoes { get; set; } = null!;
    public DbSet<DoacaoEstoque> DoacoesEstoque { get; set; } = null!;
    public DbSet<Endereco> Enderecos { get; set; } = null!;

    public DoacaoSangueContext(DbContextOptions<DoacaoSangueContext> options) : base(options) =>
        Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
