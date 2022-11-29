using Movimientos.Modelos.Entidades;
using System;
using System.Linq;

namespace Movimientos.Datos
{
    public partial class MovimientosContexto
    {
        public void AgregarMovimiento(Movimiento movimiento)
        {
            Movimientos.Add(movimiento);
        }

        public Movimiento ObtenerMovimiento(int id)
        {
            Movimiento movimiento = Movimientos.FirstOrDefault(x => x.Id == id);

            if (movimiento is null)
                throw new Exception("El movimiento no existe");

            return movimiento;
        }   

    
    }
}
