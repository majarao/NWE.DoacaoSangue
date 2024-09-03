using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace NWE.DoacaoSangue.Infra.Data;

public class DoacaoSangueContext : DbContext
{
    public DoacaoSangueContext(DbContextOptions<DoacaoSangueContext> options) : base(options) =>
        Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
