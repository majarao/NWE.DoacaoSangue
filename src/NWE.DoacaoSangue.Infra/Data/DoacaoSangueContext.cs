using Microsoft.EntityFrameworkCore;
using NWE.DoacaoSangue.Domain.Entities;
using System.Reflection;

namespace NWE.DoacaoSangue.Infra.Data;

public class DoacaoSangueContext : DbContext
{
    public DoacaoSangueContext(DbContextOptions<DoacaoSangueContext> options) : base(options) => Database.EnsureCreated();

    public DbSet<Doacao> Doacoes { get; set; }
    public DbSet<Doador> Doadores { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<EstoqueSangue> EstoquesSangue { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
