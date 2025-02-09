using DevFullstackGuia.DAO;
using DevFullstackGuia.DTO;
using DevFullstackGuia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DevFullstackGuia.Services
{
    public class LoginService
    {
        private readonly ILogger<LoginService> _logger;
        private readonly AppDbContext _context;

        public LoginService(ILogger<LoginService> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Cliente> FazerLogin(LoginDTO loginDTO)
        {
            if (string.IsNullOrEmpty(loginDTO.Email) || string.IsNullOrEmpty(loginDTO.Senha))
            {
                throw new ArgumentException("Email and password are required.");
            }

            // Search for the cliente by email and password
            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(c => c.Email == loginDTO.Email && c.Senha == loginDTO.Senha);

            if (cliente == null)
            {
                throw new ArgumentException("Invalid email or password.");
            }

            return cliente;
        }
    }
}