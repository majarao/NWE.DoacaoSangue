using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NWE.DoacaoSangue.Domain.Entities;

namespace NWE.DoacaoSangue.Infra.Configurations;

public class DoadorConfiguration : IEntityTypeConfiguration<Doador>
{
    public void Configure(EntityTypeBuilder<Doador> builder)
    {
        builder.ToTable("Doadores");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.NomeCompleto)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.DataNascimento).IsRequired();

        builder.Property(d => d.Genero)
            .IsRequired()
            .HasMaxLength(1);

        builder.Property(d => d.Peso)
            .IsRequired();

        builder.Property(d => d.TipoSanguineo)
            .IsRequired();

        builder.Property(d => d.FatorRH)
            .IsRequired();

        builder
            .HasMany(d => d.Doacoes)
            .WithOne(x => x.Doador)
            .HasForeignKey(d => d.DoadorId);
    }
}
