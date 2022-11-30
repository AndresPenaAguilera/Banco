

using Movimientos.Modelos.Entidades;
using System;

namespace Movimientos.Modelos.DTO
{
    public class ReporteMovimientosDatos
    {
        

        public int Id { get; set; }
        public int IdCuenta { get; set; }
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }
    }
}
