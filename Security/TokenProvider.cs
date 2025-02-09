using DevFullstackGuia.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DevFullstackGuia.Security
{
    public class TokenProvider(IConfiguration configuration)
    {
        public string Create(Cliente cliente)
        {
            string secretKey = configuration["Jwt:Secret"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, cliente.Id.ToString()),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, cliente.Email)

                ]),
                Expires = DateTime.UtcNow.AddMinutes(configuration.GetValue<int>("Jwt:Expiration")),
                SigningCredentials = credentials,
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"],
            };

            var handler = new JsonWebTokenHandler();
            string token = handler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
