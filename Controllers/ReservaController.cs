using DevFullstackGuia.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFullstackGuia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {

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
                Motel = null,
                Cliente = null,
                Suite = null,
                Data = DateOnly.FromDateTime(DateTime.Now.AddDays(index))
            })
            .ToArray();
        }
    }
}
