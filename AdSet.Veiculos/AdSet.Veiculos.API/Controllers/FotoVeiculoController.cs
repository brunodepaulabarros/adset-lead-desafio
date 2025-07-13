using AdSet.Veiculos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdSet.Veiculos.API.Controllers
{
    [ApiController]
    [Route("api/veiculo/{veiculoId}/fotos")]
    public class FotoVeiculoController : ControllerBase
    {
        private readonly IFotoVeiculoService _fotoService;

        public FotoVeiculoController(IFotoVeiculoService fotoService)
        {
            _fotoService = fotoService;
        }

        [HttpPost]
        [RequestSizeLimit(20_000_000)]
        public async Task<IActionResult> UploadFotos(long veiculoId, [FromForm] List<IFormFile> arquivos)
        {
            try
            {
                await _fotoService.UploadFotosAsync(veiculoId, arquivos);
                return Ok("Fotos enviadas com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
