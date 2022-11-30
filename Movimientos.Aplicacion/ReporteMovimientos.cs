using MediatR;
using Movimientos.Interfaces.Datos;
using Movimientos.Modelos.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace Movimientos.Aplicacion
{
    public class ReporteMovimientos
    {
        public class Manejador : IRequestHandler<SolicitudConsultaReporte, ReporteMovimientosDatos>
        {
            private readonly IMovimientosContexto _contexto;
            public Manejador(IMovimientosContexto contexto)
            {
                _contexto = contexto;
            }

            public async Task<ReporteMovimientosDatos> Handle(SolicitudConsultaReporte requestConsulta, CancellationToken cancellationToken)
            {
                var movimientos = _contexto.ObtenerMovimientos(requestConsulta.IdCliente);
                return new ReporteMovimientosDatos() { idCliente = requestConsulta.IdCliente, movimientos = movimientos };
            }
        }
    }
}
