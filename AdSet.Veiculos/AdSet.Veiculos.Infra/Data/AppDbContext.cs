using AdSet.Veiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdSet.Veiculos.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<FotoVeiculo> FotosVeiculo { get; set; }
        public DbSet<Opcional> Opcionais { get; set; }
        public DbSet<VeiculoOpcional> VeiculoOpcionais { get; set; }
        public DbSet<VeiculoPacote> VeiculoPacotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
