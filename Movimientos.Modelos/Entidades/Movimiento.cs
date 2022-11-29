using Movimientos.Modelos.DTO;

namespace Movimientos.Modelos.Entidades
{
    public class Movimiento
    {
       
        public Movimiento(int idCuenta, decimal valor)
        {
            IdCuenta = idCuenta;
            Valor = valor;
        }

        public int Id { get; set; }
        public int IdCuenta { get; set; }
        public decimal Valor { get; set; }

        public static Movimiento CrearDesdeSolicitud(SolicitudCrearMovimiento SolicitudNuevoMovimiento)=>
             new(
                   SolicitudNuevoMovimiento.IdCuenta,
                   SolicitudNuevoMovimiento.Valor
              );


    }
}
