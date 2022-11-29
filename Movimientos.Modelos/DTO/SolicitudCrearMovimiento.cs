using MediatR;

namespace Movimientos.Modelos.DTO
{
    public class SolicitudCrearMovimiento : IRequest
    {
        public int Id { get; set; }
        public int IdCuenta { get; set; }
        public decimal Valor { get; set; }
    }
}
