using DevFullstackGuia.DTO;

namespace DevFullstackGuia.DTO
{
    public class ReservaDTO
    {
        public required DateOnly Data { get; set; }
        public required string Motel { get; set; }
        public required string Cliente { get; set; }
        public required string Suite { get; set; }

        public ReservaDTO() { }

        public ReservaDTO(string motel, string cliente, string suite, DateOnly data)
        {
            Motel = motel;
            Cliente = cliente;
            Suite = suite;
            Data = data;
        }
    }
}
