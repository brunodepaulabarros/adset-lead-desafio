using AdSet.Veiculos.Domain.Enums;

namespace AdSet.Veiculos.Domain.Entities
{
    public class VeiculoPacote
    {
        public long Id { get; set; }
        public long VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; } = null!;
        public PortalEnum Portal { get; set; }
        public PacoteEnum Pacote { get; set; }
    }
}
