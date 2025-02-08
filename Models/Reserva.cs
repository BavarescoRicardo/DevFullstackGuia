using System;
using System.ComponentModel.DataAnnotations;

namespace DevFullstackGuia.Models
{
    public class Reserva
    {
        [Key]
        public Guid Id { get; set; }
        public required DateOnly Data { get; set; }
        public required Motel Motel { get; set; }
        public required Cliente Cliente { get; set; }
        public required Suite Suite{ get; set; }

        public Reserva() { }

        public Reserva(Motel motel, Cliente cliente, Suite suite, DateOnly data)
        {
            Id = Guid.NewGuid();
            Motel = motel;
            Cliente = cliente;
            Suite = suite;
            Data = data;
        }
    }
}