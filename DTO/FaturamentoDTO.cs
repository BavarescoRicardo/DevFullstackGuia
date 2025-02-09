using DevFullstackGuia.DTO;

namespace DevFullstackGuia.DTO
{
    public class FaturamentoDTO
    {
        public required string Mes { get; set; }
        public required string Ano { get; set; }
        public required double Valor { get; set; }

        public FaturamentoDTO() { }

        public FaturamentoDTO(string mes, string ano, double valor)
        {
            Mes = mes;
            Ano = ano;
            Valor = valor;
        }
    }
}
