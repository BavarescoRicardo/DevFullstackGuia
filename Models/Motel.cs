using System;
using System.ComponentModel.DataAnnotations;

namespace DevFullstackGuia.Models
{
    public class Motel
    {
        [Key]
        public Guid Id { get; set; }

        public required string Nome { get; set; }
        public required string Documento { get; set; }
        public string? Observacao { get; set; }

        // Parameterless constructor (required for object initialization)
        public Motel() { }

        // Optional: Parameterized constructor (if needed)
        public Motel(string nome, string documento, string observacao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Documento = documento;
            Observacao = observacao;
        }
    }
}