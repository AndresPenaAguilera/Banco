using Clientes.Modelos.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreadorClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreadorClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
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
