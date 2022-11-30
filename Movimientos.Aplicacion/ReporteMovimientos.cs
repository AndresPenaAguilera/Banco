using MediatR;
using Movimientos.Interfaces.Aplicacion;
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
            private readonly IConsultaClientes _consultaClientes;
            public Manejador(IMovimientosContexto contexto, IConsultaClientes consultaClientes)
            {
                _contexto = contexto;
                _consultaClientes = consultaClientes;
            }

            public async Task<ReporteMovimientosDatos> Handle(SolicitudConsultaReporte requestConsulta, CancellationToken cancellationToken)
            {
                var movimientos = _contexto.ObtenerMovimientos(requestConsulta.IdCliente);
                return new ReporteMovimientosDatos() { idCliente = requestConsulta.IdCliente, movimientos = movimientos };
            }
        }
    }
}
