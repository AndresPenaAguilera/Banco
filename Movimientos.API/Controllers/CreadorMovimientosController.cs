
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movimientos.Modelos.DTO;
using System.Threading.Tasks;

namespace Movimientos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreadorMovimientosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreadorMovimientosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(SolicitudCrearMovimiento solicitudCrearCuenta)
        {
            return await _mediator.Send(solicitudCrearCuenta);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientoDatos>> ObtenerCliente(int id)
        {
            return await _mediator.Send(new SolicitudConsultaFiltro { Id = id });
        }
    }
}
