namespace AdSet.Veiculos.Application.Dtos.Veiculo
{
    public class VeiculoDto
    {
        public long Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public int? Km { get; set; }
        public string Cor { get; set; }
        public decimal Preco { get; set; }
        public List<long> Opcionais { get; set; } = new();
    }
}
