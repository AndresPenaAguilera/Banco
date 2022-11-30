using MediatR;

namespace Movimientos.Modelos.DTO
{

    public class SolicitudConsultaReporte : IRequest<ReporteMovimientosDatos>
    {
        public int IdCliente { get; set; }
    }
}
