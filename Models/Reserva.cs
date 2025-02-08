using System;
using System.ComponentModel.DataAnnotations;

namespace DevFullstackGuia.Models
{
    public class Reserva
    {
        [Key]
        public Guid Id { get; set; }
        public required DateOnly Data { get; set; }
        public required Cliente Cliente { get; set; }
        public required Suite Suite{ get; set; }

        // Parameterless constructor (required for object initialization)
        public Reserva() { }

        // Optional: Parameterized constructor (if needed)
        public Reserva(Cliente cliente, Suite suite, DateOnly data)
        {
            Id = Guid.NewGuid();
            Cliente = cliente;
            Suite = suite;
            Data = data;
        }
    }
}