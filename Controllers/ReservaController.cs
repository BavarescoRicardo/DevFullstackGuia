using DevFullstackGuia.DTO;
using DevFullstackGuia.Services;
using Microsoft.AspNetCore.Mvc;
using DevFullstackGuia.Models;
using Microsoft.AspNetCore.Authorization;

namespace DevFullstackGuia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaService _reservaService;
        private readonly ILogger<ReservaController> _logger;

        public ReservaController(ReservaService reservaService, ILogger<ReservaController> logger)
        {
            _reservaService = reservaService;
            _logger = logger;
        }

        [HttpGet(Name = "GetReserva")]
        public async Task<ActionResult<IEnumerable<Reserva>>> Get()
        {
            try
            {
                var reservas = await _reservaService.GetReservas();
                return Ok(reservas);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error fetching reservas from the database");
                return StatusCode(500, "An error occurred while fetching reservas.");
            }
        }


        [HttpGet("GetReservaByData")]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservasPorData(int ano, int mes, int? dia = null)
        {
            try
            {
                var reservas = await _reservaService.GetReservasPorData(ano, mes, dia);
                return Ok(reservas);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error fetching reservas by date from the database");
                return StatusCode(500, "An error occurred while fetching reservas by date.");
            }
        }

        [HttpPost(Name = "FazerReserva")]
        public async Task<IActionResult> Create([FromBody] ReservaDTO reservaDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Use the ReservaService to create the Reserva
                    var reserva = await _reservaService.FazerReserva(reservaDTO);

                    // Return the created Reserva
                    return CreatedAtAction(nameof(Get), new { id = reserva.Id }, reserva);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error creating reserva");
                return StatusCode(500, "An error occurred while creating the reserva.");
            }
        }
    }
}