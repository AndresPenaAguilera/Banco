using MediatR;

namespace Movimientos.Modelos.DTO
{

    public class SolicitudConsultaFiltro : IRequest<MovimientoDatos>
    {
        public int Id { get; set; }
    }
}
