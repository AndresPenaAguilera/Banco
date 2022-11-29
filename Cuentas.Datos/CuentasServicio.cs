using Cuentas.Modelos.Entidades;
using System;
using System.Linq;

namespace Cuentas.Datos
{
    public partial class CuentasContexto
    {
        public void AgregarCuenta(Cuenta cuenta)
        {
            Cuentas.Add(cuenta);
        }

        public Cuenta ObtenerCuenta(Int64 numero)
        {
            Cuenta cuenta = Cuentas.FirstOrDefault(x => x.Numero == numero);

            if (cuenta is null)
                throw new Exception("La cuenta no existe");

            return cuenta;
        }
    }
}
