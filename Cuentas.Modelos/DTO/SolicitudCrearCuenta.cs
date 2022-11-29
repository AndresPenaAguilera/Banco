using MediatR;

namespace Cuentas.Modelos.DTO
{
    public class SolicitudCrearCuenta : IRequest
    {
        public int IdCliente { get; set; }
        public int Id { get; set; }
        public int Numero { get; set; }
        public char Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
    }
}
