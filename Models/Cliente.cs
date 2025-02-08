using System;
using System.ComponentModel.DataAnnotations;

namespace DevFullstackGuia.Models
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }

        public required string Nome { get; set; }
        public required string Documento { get; set; }
        public required DateOnly DataNascimento { get; set; }

        // Parameterless constructor (required for object initialization)
        public Cliente() { }

        // Optional: Parameterized constructor (if needed)
        public Cliente(string nome, string documento, DateOnly dataNascimento)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Documento = documento;
            DataNascimento = dataNascimento;
        }
    }
}