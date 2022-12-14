

using Movimientos.Modelos.Entidades;
using System;

namespace Movimientos.Modelos.DTO
{
    public class MovimientoDatos
    {
        public MovimientoDatos(Movimiento movimiento)
        {
            Id = movimiento.Id;
            IdCuenta = movimiento.IdCuenta;
            Valor = movimiento.Valor;
            Fecha = movimiento.Fecha;

        }

        public int Id { get; set; }
        public int IdCuenta { get; set; }
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }
    }
}
