using DevFullstackGuia.DTO;
using DevFullstackGuia.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DevFullstackGuia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FaturamentoController : ControllerBase
    {
        private readonly FaturamentoService _faturamentoService;
        private readonly ILogger<FaturamentoController> _logger;

        public FaturamentoController(FaturamentoService faturamentoService, ILogger<FaturamentoController> logger)
        {
            _faturamentoService = faturamentoService;
            _logger = logger;
        }

        [HttpGet("mensal")]
        public async Task<ActionResult<FaturamentoDTO>> GetFaturamentoMensal(int ano, int mes)
        {
            try
            {
                var faturamento = await _faturamentoService.CalcularFaturamentoMensal(ano, mes);
                if (faturamento == null)
                {
                    return NotFound("Nenhum faturamento encontrado para o período especificado.");
                }
                return Ok(faturamento);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao calcular o faturamento mensal.");
                return StatusCode(500, "Ocorreu um erro ao processar sua solicitação.");
            }
        }
    }
}