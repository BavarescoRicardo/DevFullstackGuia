using DevFullstackGuia.DAO; // Add this namespace for AppDbContext
using DevFullstackGuia.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            try
            {
                var clientes = await _context.Cliente.ToListAsync();

                return Ok(clientes);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error fetching clientes from the database");
                return StatusCode(500, "An error occurred while fetching clientes.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Cliente.Add(cliente);
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