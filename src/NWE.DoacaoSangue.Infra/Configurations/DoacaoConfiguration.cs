using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NWE.DoacaoSangue.Domain.Entities;

namespace NWE.DoacaoSangue.Infra.Configurations;

public class DoacaoConfiguration : IEntityTypeConfiguration<Doacao>
{
    public void Configure(EntityTypeBuilder<Doacao> builder)
    {
        builder.ToTable("Doacoes");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.DoadorId)
            .IsRequired();

        builder.Property(d => d.DataDoacao)
            .IsRequired();

        builder.Property(d => d.QuantidadeML)
            .IsRequired();

        builder
            .HasOne(d => d.Doador)
            .WithMany(x => x.Doacoes)
            .HasForeignKey(d => d.DoadorId);
    }
}
