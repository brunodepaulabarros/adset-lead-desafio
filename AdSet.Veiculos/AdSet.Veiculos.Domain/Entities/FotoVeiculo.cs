namespace AdSet.Veiculos.Domain.Entities
{
    public class FotoVeiculo
    {
        public long Id { get; set; }
        public long VeiculoId { get; set; }
        public string CaminhoArquivo { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
