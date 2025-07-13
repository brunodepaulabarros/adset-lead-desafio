using AdSet.Veiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdSet.Veiculos.Infra.Data.Configurations
{
    public class VeiculoPacoteConfiguration : IEntityTypeConfiguration<VeiculoPacote>
    {
        public void Configure(EntityTypeBuilder<VeiculoPacote> builder)
        {
            builder.HasKey(vp => vp.Id);
            builder.Property(vp => vp.Portal).IsRequired();
            builder.Property(vp => vp.Pacote).IsRequired();
        }
    }
}
