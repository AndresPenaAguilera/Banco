using Cuentas.Modelos.DTO;
using System;

namespace Cuentas.Modelos.Entidades
{
    public class Cuenta
    {
        public Cuenta(Int64 numero, char tipo, decimal saldoInicial, int idCliente, bool estado)
        {
            Numero = numero;
            Tipo = tipo;
            SaldoInicial = saldoInicial;
            IdCliente = idCliente;
            Estado = estado;
        }

        public int IdCliente { get; set; }
        public int Id { get; set; }
        public Int64 Numero { get; set; }
        public char Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }

        public static Cuenta CrearDesdeSolicitud(SolicitudCrearCuenta SolicitudNuevaCuenta) =>
            new(
                   SolicitudNuevaCuenta.Numero,
                   SolicitudNuevaCuenta.Tipo,
                   SolicitudNuevaCuenta.SaldoInicial,
                   SolicitudNuevaCuenta.IdCliente,
                   true
              );
        
    }
}
