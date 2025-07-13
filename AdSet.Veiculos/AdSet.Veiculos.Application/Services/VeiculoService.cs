using AdSet.Veiculos.Application.Dtos.Veiculo;
using AdSet.Veiculos.Application.Interfaces;
using AdSet.Veiculos.Domain.Entities;
using AdSet.Veiculos.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace AdSet.Veiculos.Application.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly AppDbContext _context;
        public VeiculoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<VeiculoDto>> GetAllAsync()
        {
            var veiculos = await _context.Veiculos
                .Include(v => v.VeiculoOpcionais)
                    .ThenInclude(vo => vo.Opcional)
                .ToListAsync();

            return veiculos.Select(v => new VeiculoDto
            {
                Id = v.Id,
                Marca = v.Marca,
                Modelo = v.Modelo,
                Ano = v.Ano,
                Placa = v.Placa,
                Km = v.Km,
                Cor = v.Cor,
                Preco = v.Preco,
                Opcionais = v.VeiculoOpcionais.Select(vo => vo.Opcional.Id).ToList()
            }).ToList();
        }

        public async Task<VeiculoDto> GetByIdAsync(long id)
        {
            var veiculo = await _context.Veiculos
                .Include(v => v.VeiculoOpcionais)
                    .ThenInclude(vo => vo.Opcional)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (veiculo == null)
            {
                throw new Exception("Veículo não encontrado.");
            }

            return new VeiculoDto
            {
                Id = veiculo.Id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Ano = veiculo.Ano,
                Placa = veiculo.Placa,
                Km = veiculo.Km,
                Cor = veiculo.Cor,
                Preco = veiculo.Preco,
                Opcionais = veiculo.VeiculoOpcionais.Select(vo => vo.Opcional.Id).ToList()
            };
        }

        public async Task<long> CreateAsync(CreateVeiculoDto dto)
        {
            var veiculo = new Veiculo
            {
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                Ano = dto.Ano,
                Placa = dto.Placa,
                Km = dto.Km,
                Cor = dto.Cor,
                Preco = dto.Preco,
                VeiculoOpcionais = dto.OpcionaisIds?.Select(id => new VeiculoOpcional
                {
                    OpcionalId = id
                }).ToList()
            };

            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return veiculo.Id;
        }

        public async Task UpdateAsync(UpdateVeiculoDto dto)
        {
            var veiculo = await _context.Veiculos
                .Include(v => v.VeiculoOpcionais)
                .FirstOrDefaultAsync(v => v.Id == dto.Id);

            if (veiculo == null)
            {
                throw new Exception("Veículo não encontrado.");
            }

            veiculo.Marca = dto.Marca;
            veiculo.Modelo = dto.Modelo;
            veiculo.Ano = dto.Ano;
            veiculo.Placa = dto.Placa;
            veiculo.Km = dto.Km;
            veiculo.Cor = dto.Cor;
            veiculo.Preco = dto.Preco;

            veiculo.VeiculoOpcionais.Clear();
            if (dto.OpcionaisIds != null)
            {
                foreach (var opcionalId in dto.OpcionaisIds)
                {
                    veiculo.VeiculoOpcionais.Add(new VeiculoOpcional
                    {
                        VeiculoId = veiculo.Id,
                        OpcionalId = opcionalId
                    });
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null)
            {
                throw new Exception("Veículo não encontrado.");
            }

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
        }
    }
}
