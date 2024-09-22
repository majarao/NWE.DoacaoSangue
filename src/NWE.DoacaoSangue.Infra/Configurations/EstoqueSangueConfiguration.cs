using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NWE.DoacaoSangue.Domain.Entities;

namespace NWE.DoacaoSangue.Infra.Configurations;

public class EstoqueSangueConfiguration : IEntityTypeConfiguration<EstoqueSangue>
{
    public void Configure(EntityTypeBuilder<EstoqueSangue> builder)
    {
        builder.ToTable("EstoquesSangue");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.TipoSanguineo)
            .IsRequired();

        builder.Property(e => e.FatorRH)
            .IsRequired();

        builder.Property(e => e.QuantidadeML)
            .IsRequired();
    }
}
