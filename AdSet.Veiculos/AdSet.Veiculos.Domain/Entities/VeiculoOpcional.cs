namespace AdSet.Veiculos.Domain.Entities
{
    public class VeiculoOpcional
    {
        public long VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; } = null!;
        public long OpcionalId { get; set; }
        public Opcional Opcional { get; set; } = null!;
    }
}
