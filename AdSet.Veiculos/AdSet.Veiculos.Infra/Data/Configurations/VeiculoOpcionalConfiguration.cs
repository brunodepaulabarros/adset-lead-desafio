using AdSet.Veiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdSet.Veiculos.Infra.Data.Configurations
{
    public class VeiculoOpcionalConfiguration : IEntityTypeConfiguration<VeiculoOpcional>
    {
        public void Configure(EntityTypeBuilder<VeiculoOpcional> builder)
        {
            builder.HasKey(vo => new { vo.VeiculoId, vo.OpcionalId });

            builder.HasOne(vo => vo.Veiculo)
                   .WithMany(v => v.VeiculoOpcionais)
                   .HasForeignKey(vo => vo.VeiculoId);

            builder.HasOne(vo => vo.Opcional)
                   .WithMany(o => o.VeiculoOpcionais)
                   .HasForeignKey(vo => vo.OpcionalId);
        }
    }
}
