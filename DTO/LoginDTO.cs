using DevFullstackGuia.DTO;

namespace DevFullstackGuia.DTO
{
    public class LoginDTO
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }

        public LoginDTO() { }

        public LoginDTO(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
    }
}
