using AutoMapper;
using Clientes.Interfaces.Datos;
using Clientes.Modelos.DTO;
using Clientes.Modelos.Entidades;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clientes.Aplicacion
{
    public class ConsultaFiltro
    {
        public class Manejador : IRequestHandler<SolicitudConsultaFiltro, ClienteDatos>
        {

            public readonly IClientesContexto _contexto;

            public Manejador(IClientesContexto clientesContexto)
            {
                _contexto = clientesContexto;
            }

            public async Task<ClienteDatos> Handle(SolicitudConsultaFiltro request, CancellationToken cancellationToken)
            {
                var cliente =  _contexto.ObtenerCliente(request.Id);
                var clienteDatos = new ClienteDatos(cliente);
                return clienteDatos;
            }
        }
    }
}
