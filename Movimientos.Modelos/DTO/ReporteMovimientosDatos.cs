﻿

using Movimientos.Modelos.Entidades;
using System.Collections.Generic;

namespace Movimientos.Modelos.DTO
{
    public class ReporteMovimientosDatos
    {
        public int idCliente { get; set; }
        public List<Movimiento> movimientos { get; set; }
    }
}
