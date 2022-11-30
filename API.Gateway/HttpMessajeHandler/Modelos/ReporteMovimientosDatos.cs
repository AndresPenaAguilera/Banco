using System.Collections.Generic;

namespace API.Gateway.HttpMessajeHandler.Modelos
{
    public class ReporteMovimientosDatos
    {
        public int idCliente { get; set; }
        public List<Movimiento> movimientos { get; set; }
    }
}
