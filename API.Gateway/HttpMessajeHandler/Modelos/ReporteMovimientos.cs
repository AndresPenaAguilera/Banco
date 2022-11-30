using System;
using System.Collections.Generic;
using System.Globalization;

namespace API.Gateway.HttpMessajeHandler.Modelos
{
    public class ReporteMovimientos
    {
       

        public string Fecha { get; set; }
        public string Nombre { get; set; }
        public string NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public string SaldoInicial { get; set; }
        public string Estado { get; set; }
        public string Movimiento { get; set; }
        public string SaldoDisponible { get; set; }

        internal static List<ReporteMovimientos> CrearDesdeSolicitud(string nombre, List<Movimiento> movimientos)
        {
            List<ReporteMovimientos> resultado = new List<ReporteMovimientos>();

            foreach(var movimiento in movimientos)
            {
                var movimientoReporte = new ReporteMovimientos() {
                    Fecha = movimiento.Fecha.ToString("dd/MM/yyyy"),
                    Nombre = nombre,
                    NumeroCuenta = "",
                    Tipo = "",
                    SaldoInicial = "",
                    Estado = "",
                    Movimiento = String.Format(CultureInfo.InvariantCulture, "{0:0,0.0}", movimiento.Valor),
                    SaldoDisponible = ""
                };
                resultado.Add(movimientoReporte);
            }

            return resultado;
        }
    }
}
