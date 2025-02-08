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

        public SuiteController(ILogger<SuiteController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetSuite")]
        public async Task<ActionResult<IEnumerable<Suite>>> Get()
        {
            try
            {
                var suites = await _context.Suite.ToListAsync();

                return Ok(suites);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error fetching suites from the database");
                return StatusCode(500, "An error occurred while fetching suites.");
            }
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