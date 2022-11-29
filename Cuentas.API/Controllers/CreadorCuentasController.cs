using Cuentas.Modelos.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cuentas.API.Controllers
{
    [ApiController]
    public class CreadorCuentasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreadorCuentasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Cuenta")]
        public async Task<ActionResult<Unit>> Crear(SolicitudCrearCuenta solicitudCrearCuenta)
        {
            return await _mediator.Send(solicitudCrearCuenta);
        }

        [HttpGet("{numeroCuenta}")]
        public async Task<ActionResult<CuentaDatos>> ObtenerCliente(int numeroCuenta)
        {
            return await _mediator.Send(new SolicitudConsultaFiltro { NumeroCuenta = numeroCuenta });
        }
    }
}
