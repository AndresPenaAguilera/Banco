using MediatR;
using System;

namespace Movimientos.Modelos.DTO
{

    public class SolicitudConsultaReporte : IRequest<ReporteMovimientosDatos>
    {
        public int IdCliente { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
    }
}
