using System;
using System.ComponentModel.DataAnnotations;

namespace DevFullstackGuia.Models
{
    public class Suite
    {
        [Key]
        public Guid Id { get; set; }
        public required string Numero { get; set; }
        public required bool Disponivel { get; set; }
        public required string Tipo { get; set; }

        // Parameterless constructor (required for object initialization)
        public Suite() { }

        // Optional: Parameterized constructor (if needed)
        public Suite(string nome, bool disponivel, string tipo)
        {
            Id = Guid.NewGuid();
            Numero = nome;
            Disponivel = disponivel;
            Tipo = tipo;
        }
    }
}