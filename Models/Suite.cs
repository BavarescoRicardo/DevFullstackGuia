using System;
using System.ComponentModel.DataAnnotations;

namespace DevFullstackGuia.Models
{
    public class Suite
    {
        [Key]
        public Guid Id { get; }
        public required string Numero { get; set; }
        public required double Valor { get; set; }
        public required string Tipo { get; set; }

        public Suite() { }

        public Suite(string nome, double valor, string tipo)
        {
            Id = Guid.NewGuid();
            Numero = nome;
            Valor = valor;
            Tipo = tipo;
        }
    }
}