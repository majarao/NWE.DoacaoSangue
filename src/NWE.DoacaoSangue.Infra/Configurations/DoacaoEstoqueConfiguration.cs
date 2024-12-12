using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NWE.DoacaoSangue.Domain.Entities;

namespace NWE.DoacaoSangue.Infra.Configurations;

public class DoacaoEstoqueConfiguration : IEntityTypeConfiguration<DoacaoEstoque>
{
    public void Configure(EntityTypeBuilder<DoacaoEstoque> builder)
    {
        builder.ToTable("DoacoesEstoque");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.TipoSanguineo)
            .IsRequired();

        builder.Property(e => e.FatorRH)
            .IsRequired();

        builder.Property(e => e.QuantidadeML)
            .IsRequired();
    }
}
