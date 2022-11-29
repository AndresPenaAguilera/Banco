using MediatR;
using Movimientos.Interfaces.Datos;
using Movimientos.Modelos.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace Movimientos.Aplicacion
{
    public class ConsultaFiltro
    {
        public class Manejador : IRequestHandler<SolicitudConsultaFiltro, MovimientoDatos>
        {
            private readonly IMovimientosContexto _contexto;

            public Manejador(IMovimientosContexto contexto)
            {
                _contexto = contexto;
            }

            public async Task<MovimientoDatos> Handle(SolicitudConsultaFiltro requestConsulta, CancellationToken cancellationToken)
            {
                var movimiento = _contexto.ObtenerMovimiento(requestConsulta.Id);
                var movimientoDatos = new MovimientoDatos(movimiento);
                return movimientoDatos;
            }
        }
    }
}
