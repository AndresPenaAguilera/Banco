using Clientes.Aplicacion;
using Clientes.Modelos.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Clientes.API.Controllers
{
    [ApiController]
    public class CreadorClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreadorClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Cliente")]
        public async Task<ActionResult<Unit>> Crear(SolicitudCrearCliente solicitudCrearCliente)
        {
            return await _mediator.Send(solicitudCrearCliente);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDatos>> ObtenerCliente(string id)
        {
            return await _mediator.Send(new SolicitudConsultaFiltro { Id = int.Parse(id) });
        }
    }
}
