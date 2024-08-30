using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NWE.DoacaoSangue.Domain.Entities;

namespace NWE.DoacaoSangue.Infra.Configurations;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("Enderecos");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Logradouro)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Cidade)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Estado)
            .IsRequired()
            .HasMaxLength(2);

        builder.Property(e => e.CEP)
            .IsRequired()
            .HasMaxLength(9);

        builder
            .HasOne(e => e.Doador)
            .WithOne(d => d.Endereco)
            .HasForeignKey<Doador>(d => d.Id);
    }
}
