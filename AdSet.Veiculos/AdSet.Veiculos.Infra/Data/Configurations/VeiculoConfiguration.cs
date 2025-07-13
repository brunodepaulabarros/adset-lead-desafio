using AdSet.Veiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdSet.Veiculos.Infra.Data.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Marca).IsRequired().HasMaxLength(100);
            builder.Property(v => v.Modelo).IsRequired().HasMaxLength(100);
            builder.Property(v => v.Placa).IsRequired().HasMaxLength(10);
            builder.Property(v => v.Cor).IsRequired().HasMaxLength(50);
            builder.Property(v => v.Preco).IsRequired().HasPrecision(18, 2);
            builder.Property(v => v.Ano).IsRequired();
            builder.Property(v => v.Km).IsRequired(false);

            builder.HasMany(v => v.Fotos)
                   .WithOne(f => f.Veiculo)
                   .HasForeignKey(f => f.VeiculoId);

            builder.HasMany(v => v.VeiculoOpcionais)
                   .WithOne(vo => vo.Veiculo)
                   .HasForeignKey(vo => vo.VeiculoId);

            builder.HasMany(v => v.PacotesSelecionados)
                   .WithOne(p => p.Veiculo)
                   .HasForeignKey(p => p.VeiculoId);
        }
    }
}
