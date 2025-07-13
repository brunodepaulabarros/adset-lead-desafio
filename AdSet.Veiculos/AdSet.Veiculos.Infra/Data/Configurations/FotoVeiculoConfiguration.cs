using AdSet.Veiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdSet.Veiculos.Infra.Data.Configurations
{
    public class FotoVeiculoConfiguration : IEntityTypeConfiguration<FotoVeiculo>
    {
        public void Configure(EntityTypeBuilder<FotoVeiculo> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.CaminhoArquivo).IsRequired().HasMaxLength(200);
        }
    }
}
