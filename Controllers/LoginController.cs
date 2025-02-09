using DevFullstackGuia.DTO;
using DevFullstackGuia.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DevFullstackGuia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService, ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _logger = logger;
        }

        [HttpPost(Name = "Logar")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cliente = await _loginService.FazerLogin(login);
                    return Ok(cliente);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error during login");
                return StatusCode(500, "An error occurred during login.");
            }
        }
    }
}