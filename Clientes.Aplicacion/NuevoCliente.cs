using Clientes.Interfaces.Datos;
using Clientes.Modelos.DTO;
using Clientes.Modelos.Entidades;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clientes.Aplicacion
{
    public class NuevoCliente
    {
        
        public class Manejador : IRequestHandler<SolicitudCrearCliente>
        {
            public readonly IClientesContexto _contexto;

            public Manejador(IClientesContexto clientesContexto) 
            {
                _contexto = clientesContexto;
            }

            public async Task<Unit> Handle(SolicitudCrearCliente request, CancellationToken cancellationToken)
            {
                Cliente cliente = Cliente.CrearDesdeSolicitud(request);

                _contexto.AgregarCliente(cliente);

                var valor = await _contexto.GuardarCambiosAsync();

                if (valor > 0) 
                {
                    return Unit.Value;
                }

                throw new Exception("No se puedo insertar el cliente");
            }
        }


    }
}
