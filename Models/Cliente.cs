using System;
using System.ComponentModel.DataAnnotations;

namespace DevFullstackGuia.Models
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }

        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required string Documento { get; set; }
        public required DateOnly DataNascimento { get; set; }

        // Parameterless constructor (required for object initialization)
        public Cliente() { }

        // Optional: Parameterized constructor (if needed)
        public Cliente(string nome, string email, string senha, string documento, DateOnly dataNascimento)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Senha = senha;
            Documento = documento;
            DataNascimento = dataNascimento;
        }
    }
}