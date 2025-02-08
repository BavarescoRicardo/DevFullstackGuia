using System;
using System.ComponentModel.DataAnnotations;

namespace DevFullstackGuia.Models
{
    public class Suite
    {
        [Key]
        public Guid Id { get; }
        public required string Numero { get; set; }
        public required bool Disponivel { get; set; }
        public required string Tipo { get; set; }

        public Suite() { }

        public Suite(string nome, bool disponivel, string tipo)
        {
            Id = Guid.NewGuid();
            Numero = nome;
            Disponivel = disponivel;
            Tipo = tipo;
        }
    }
}