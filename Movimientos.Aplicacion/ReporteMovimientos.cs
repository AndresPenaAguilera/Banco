using MediatR;
using Movimientos.Aplicacion.ConsultasExternas;
using Movimientos.Interfaces.Aplicacion;
using Movimientos.Interfaces.Datos;
using Movimientos.Modelos.DTO;
using Movimientos.Modelos.Mensajes;
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
                DatosCliente cliente;
                var responseCliente = await _consultaClientes.ObtieneCliente(requestConsulta.IdCliente);
                if (responseCliente.resultado)
                {
                    cliente = responseCliente.Cliente;
                }

                var reporteMovimientos = new ReporteMovimientosDatos();
                return reporteMovimientos;
            }
        }
    }
}
