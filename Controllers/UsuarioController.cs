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
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly AppDbContext _context;

        // Inject both ILogger and AppDbContext
        public UsuarioController(ILogger<UsuarioController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetUsuario")]
        public IEnumerable<Cliente> Get()
        {
            // Return a list of users with mock data
            return Enumerable.Range(1, 5).Select(index => new Cliente
            {
                Nome = $"User {index}",
                Documento = $"0000000{index}",
                DataNascimento = DateOnly.FromDateTime(DateTime.Now.AddDays(index))
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cliente user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.User.Add(user);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error creating user");
                return StatusCode(500, "An error occurred while creating the user.");
            }
        }
    }
}