using AdSet.Veiculos.Application.Dtos.Veiculo;

namespace AdSet.Veiculos.Application.Interfaces
{
    public interface IVeiculoService
    {
        Task<List<VeiculoDto>> GetAllAsync();
        Task<VeiculoDto> GetByIdAsync(long id);
        Task<long> CreateAsync(CreateVeiculoDto dto);
        Task UpdateAsync(UpdateVeiculoDto dto);
        Task DeleteAsync(long id);
    }
}
