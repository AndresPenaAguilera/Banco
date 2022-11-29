

using Cuentas.Modelos.Entidades;
using System;

namespace Cuentas.Modelos.DTO
{
    public class CuentaDatos
    {
        public CuentaDatos(Cuenta cuenta)
        {
            IdCliente = cuenta.IdCliente;
            Numero = cuenta.Numero;
            Tipo = cuenta.Tipo;
            SaldoInicial = cuenta.SaldoInicial;
            Estado = cuenta.Estado;
        }

        public int IdCliente { get; set; }
        public Int64 Numero { get; set; }
        public char Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
    }
}
