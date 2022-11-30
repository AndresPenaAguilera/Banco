using MediatR;

namespace Movimientos.Modelos.DTO
{
    public class SolicitudCrearMovimiento : IRequest
    {
        public int idCuenta { get; set; }
        public decimal valor { get; set; }
        public string fecha { get; set; }
    }
}
