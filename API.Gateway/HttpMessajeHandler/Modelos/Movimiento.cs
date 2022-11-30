
using System;

namespace API.Gateway.HttpMessajeHandler.Modelos
{
    public class Movimiento
    {

        public int Id { get; set; }
        public int IdCuenta { get; set; }
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }

       
    }
}
