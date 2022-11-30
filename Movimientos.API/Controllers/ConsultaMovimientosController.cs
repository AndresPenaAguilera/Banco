
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movimientos.Modelos.DTO;
using System.Threading.Tasks;

namespace Movimientos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaMovimientosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultaMovimientosController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ReporteMovimientosDatos>> ObtenerMovimientos([FromQuery] int idCliente, [FromQuery] string fechaInicio, [FromQuery] string fechaFin)
        {
            return await _mediator.Send(new SolicitudConsultaReporte() { IdCliente =idCliente, FechaInicio =fechaInicio, FechaFin = fechaFin });
        }
    }
}
