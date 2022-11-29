using MediatR;

namespace Cuentas.Modelos.DTO
{

    public class SolicitudConsultaFiltro : IRequest<CuentaDatos>
    {
        public int NumeroCuenta { get; set; }
    }
}
