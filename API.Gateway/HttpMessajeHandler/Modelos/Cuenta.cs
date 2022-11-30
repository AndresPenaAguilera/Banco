using System;

namespace API.Gateway.HttpMessajeHandler.Modelos
{
    public class Cuenta
    {
        public int IdCliente { get; set; }
        public Int64 Numero { get; set; }
        public char Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
    }
}
