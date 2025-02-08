using DevFullstackGuia.DAO; // Add this namespace for AppDbContext
using DevFullstackGuia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFullstackGuia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuiteController : ControllerBase
    {
        private readonly ILogger<SuiteController> _logger;
        private readonly AppDbContext _context;

        // Inject both ILogger and AppDbContext
        public SuiteController(ILogger<SuiteController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetCliente")]
        public IEnumerable<Suite> Get()
        {
            // Return a list of users with mock data
            return Enumerable.Range(1, 5).Select(index => new Suite
            {
                Numero = $"User {index}",
                Disponivel = true,
                Tipo = $"senha {index}"
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Suite suite)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Suite.Add(suite);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = suite.Id }, suite);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error criando cliente");
                return StatusCode(500, "Error ao criar cliente.");
            }
        }
    }
}