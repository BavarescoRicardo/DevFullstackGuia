using System;
using System.ComponentModel.DataAnnotations;

namespace DevFullstackGuia.Models
{
    public class Motel
    {
        [Key]
        public Guid Id { get; }
        public required string Nome { get; set; }
        public required string Documento { get; set; }
        public string? Observacao { get; set; }

        public Motel() { }

        public Motel(string nome, string documento, string observacao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Documento = documento;
            Observacao = observacao;
        }
    }
}