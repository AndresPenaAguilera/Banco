using MediatR;
using Movimientos.Interfaces.Datos;
using Movimientos.Modelos.DTO;
using Movimientos.Modelos.Entidades;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Movimientos.Aplicacion
{
    public class NuevoMovimiento
    {
        public class Manejador : IRequestHandler<SolicitudCrearMovimiento>
        {
            private readonly IMovimientosContexto _contexto;

            public Manejador(IMovimientosContexto contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(SolicitudCrearMovimiento request, CancellationToken cancellationToken)
            {
                Movimiento movimiento = Movimiento.CrearDesdeSolicitud(request);

                _contexto.AgregarMovimiento(movimiento);

                var valor = await _contexto.GuardarCambiosAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se puedo insertar el movimiento");
            }
        }
    }
}
