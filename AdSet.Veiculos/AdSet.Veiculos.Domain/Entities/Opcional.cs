namespace AdSet.Veiculos.Domain.Entities
{
    public class Opcional
    {
        public long Id { get; set; }
        public string Nome { get; set; } = null!;
        public ICollection<VeiculoOpcional> VeiculoOpcionais { get; set; } = new List<VeiculoOpcional>();
    }
}
