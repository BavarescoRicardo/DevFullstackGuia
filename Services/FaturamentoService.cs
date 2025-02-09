using DevFullstackGuia.DAO;
using DevFullstackGuia.DTO;
using DevFullstackGuia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DevFullstackGuia.Services
{
    public class FaturamentoService
    {
        private readonly ILogger<FaturamentoService> _logger;
        private readonly AppDbContext _context;

        public FaturamentoService(ILogger<FaturamentoService> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<FaturamentoDTO> CalcularFaturamentoMensal(int ano, int mes)
        {
            try
            {
                // Filtra as reservas do mês e ano especificados
                var reservas = await _context.Reserva
                    .Include(r => r.Suite) // Inclui os dados da suíte para calcular o valor
                    .Where(r => r.Data.Year == ano && r.Data.Month == mes)
                    .ToListAsync();

                // Calcula o faturamento total
                double faturamentoTotal = reservas.Sum(r => r.Suite.Valor);

                // Retorna o DTO com os dados do faturamento
                return new FaturamentoDTO
                {
                    Mes = mes.ToString(),
                    Ano = ano.ToString(),
                    Valor = faturamentoTotal
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao calcular o faturamento mensal.");
                throw;
            }
        }
    }
}