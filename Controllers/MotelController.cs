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
    public class MotelController : ControllerBase
    {
        private readonly ILogger<MotelController> _logger;
        private readonly AppDbContext _context;

        public MotelController(ILogger<MotelController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetMotel")]
        public async Task<ActionResult<IEnumerable<Motel>>> Get()
        {
            try
            {
                var motels = await _context.Motel.ToListAsync();

                return Ok(motels);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error fetching motels from the database");
                return StatusCode(500, "An error occurred while fetching motels.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Motel motel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Motel.Add(motel);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = motel.Id }, motel);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error criando motel");
                return StatusCode(500, "Error ao criar motel.");
            }
        }
    }
}