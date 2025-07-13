using AdSet.Veiculos.Application.Interfaces;
using AdSet.Veiculos.Domain.Entities;
using AdSet.Veiculos.Infra.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace AdSet.Veiculos.Application.Services
{
    public class FotoVeiculoService : IFotoVeiculoService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FotoVeiculoService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task UploadFotosAsync(long veiculoId, List<IFormFile> arquivos)
        {
            if (arquivos.Count > 15)
            {
                throw new Exception("Máximo de 15 fotos por veículo.");
            }

            var veiculo = await _context.Veiculos
                .Include(v => v.Fotos)
                .FirstOrDefaultAsync(v => v.Id == veiculoId);

            if (veiculo == null)
            {
                throw new Exception("Veículo não encontrado.");
            }

            if (veiculo.Fotos.Count + arquivos.Count > 15)
            {
                throw new Exception("Número total de fotos excede o limite de 15.");
            }

            var uploadDir = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadDir);

            foreach (var arquivo in arquivos)
            {
                var nomeArquivo = $"{Guid.NewGuid()}_{arquivo.FileName}";
                var caminhoFisico = Path.Combine(uploadDir, nomeArquivo);
                var caminhoRelativo = $"/uploads/{nomeArquivo}";

                using (var stream = new FileStream(caminhoFisico, FileMode.Create))
                {
                    await arquivo.CopyToAsync(stream);
                }

                veiculo.Fotos.Add(new FotoVeiculo
                {
                    CaminhoArquivo = caminhoRelativo
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
