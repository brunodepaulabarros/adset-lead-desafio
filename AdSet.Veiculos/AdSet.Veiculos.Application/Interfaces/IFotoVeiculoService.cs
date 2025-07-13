using Microsoft.AspNetCore.Http;

namespace AdSet.Veiculos.Application.Interfaces
{
    public interface IFotoVeiculoService
    {
        Task UploadFotosAsync(long veiculoId, List<IFormFile> arquivos);
    }
}
