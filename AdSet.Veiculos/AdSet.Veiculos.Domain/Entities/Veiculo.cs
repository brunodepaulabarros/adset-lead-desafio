namespace AdSet.Veiculos.Domain.Entities
{
    public class Veiculo
    {
        public long Id { get; set; }
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public int Ano { get; set; }
        public string Placa { get; set; } = null!;
        public string Cor { get; set; } = null!;
        public decimal Preco { get; set; }
        public int? Km { get; set; }
        public ICollection<VeiculoOpcional> VeiculoOpcionais { get; set; } = new List<VeiculoOpcional>();
        public ICollection<FotoVeiculo> Fotos { get; set; } = new List<FotoVeiculo>();
        public ICollection<VeiculoPacote> PacotesSelecionados { get; set; } = new List<VeiculoPacote>();
    }
}
