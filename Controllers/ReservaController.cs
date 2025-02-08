using DevFullstackGuia.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFullstackGuia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ReservaController> _logger;

        public ReservaController(ILogger<ReservaController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetReserva")]
        public IEnumerable<Reserva> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Reserva
            {
                Cliente = null,
                Suite = null,
                Data = DateOnly.FromDateTime(DateTime.Now.AddDays(index))
            })
            .ToArray();
        }
    }
}
