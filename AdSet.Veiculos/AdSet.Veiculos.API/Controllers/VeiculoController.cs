using AdSet.Veiculos.Application.Dtos.Veiculo;
using AdSet.Veiculos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdSet.Veiculos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<VeiculoDto>>> GetAll()
        {
            var veiculos = await _veiculoService.GetAllAsync();
            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoDto>> GetById(long id)
        {
            try
            {
                var veiculo = await _veiculoService.GetByIdAsync(id);
                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreateVeiculoDto dto)
        {
            var id = await _veiculoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateVeiculoDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID do corpo e da URL não correspondem.");
            }

            try
            {
                await _veiculoService.UpdateAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _veiculoService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
