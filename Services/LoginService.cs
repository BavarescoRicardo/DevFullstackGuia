using DevFullstackGuia.DAO;
using DevFullstackGuia.DTO;
using DevFullstackGuia.Models;
using DevFullstackGuia.Security;
using Microsoft.AspNetCore.Mvc;
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
        private readonly TokenProvider _tokenProvider;

        public LoginService(ILogger<LoginService> logger, AppDbContext context, TokenProvider tokenProvider)
        {
            _logger = logger;
            _context = context;
            _tokenProvider = tokenProvider;
        }

        public async Task<string> FazerLogin(LoginDTO loginDTO)
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

            // Generate JWT token
            var token = _tokenProvider.Create(cliente);
            if (token == null)
            {
                throw new ArgumentException("Erro nas credenciais.");
            }
            return token;
        }
    }
}