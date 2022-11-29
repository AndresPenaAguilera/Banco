

using Movimientos.Modelos.Entidades;

namespace Movimientos.Modelos.DTO
{
    public class MovimientoDatos
    {
        public MovimientoDatos(Movimiento movimiento)
        {
            Id = movimiento.Id;
            IdCuenta = movimiento.IdCuenta;
            Valor = movimiento.Valor;
        }

        public int Id { get; set; }
        public int IdCuenta { get; set; }
        public decimal Valor { get; set; }
    }
}
