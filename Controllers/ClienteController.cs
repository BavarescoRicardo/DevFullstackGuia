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
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly AppDbContext _context;

        // Inject both ILogger and AppDbContext
        public ClienteController(ILogger<ClienteController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetCliente")]
        public IEnumerable<Cliente> Get()
        {
            // Return a list of users with mock data
            return Enumerable.Range(1, 5).Select(index => new Cliente
            {
                Nome = $"User {index}",
                Email = $"email@ {index}",
                Senha = $"senha {index}",
                Documento = $"0000000{index}",
                DataNascimento = DateOnly.FromDateTime(DateTime.Now.AddDays(index))
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.User.Add(cliente);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
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