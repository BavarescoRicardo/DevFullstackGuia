using DevFullstackGuia.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFullstackGuia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FaturamentoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<FaturamentoController> _logger;

        public FaturamentoController(ILogger<FaturamentoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetFaturamento")]
        public IEnumerable<Weather> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Weather
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
