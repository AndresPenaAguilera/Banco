using Movimientos.Modelos.DTO;
using System;
using System.Globalization;

namespace Movimientos.Modelos.Entidades
{
    public class Movimiento
    {

        public Movimiento(int idCuenta, decimal valor, DateTime fecha)
        {
            IdCuenta = idCuenta;
            Valor = valor;
            Fecha = fecha;
        }

        public int Id { get; set; }
        public int IdCuenta { get; set; }
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }

        public static Movimiento CrearDesdeSolicitud(SolicitudCrearMovimiento SolicitudNuevoMovimiento) =>
             new(
                   SolicitudNuevoMovimiento.idCuenta,
                   SolicitudNuevoMovimiento.valor,
                   ConvierteStringADatetime(SolicitudNuevoMovimiento.fecha)
              );

        private static DateTime ConvierteStringADatetime(string fecha)
        {
            return DateTime.ParseExact(fecha, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
