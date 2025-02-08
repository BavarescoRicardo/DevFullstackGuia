using System;
using System.ComponentModel.DataAnnotations;

namespace DevFullstackGuia.Models
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        public required string Nome { get; set; }
        public required string Documento { get; set; }
        public required DateOnly DataNascimento { get; set; }

        // Parameterless constructor (required for object initialization)
        public Usuario() { }

        // Optional: Parameterized constructor (if needed)
        public Usuario(string nome, string documento, DateOnly dataNascimento)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Documento = documento;
            DataNascimento = dataNascimento;
        }
    }
}