using Cuentas.Modelos.Entidades;
using System;
using System.Threading.Tasks;

namespace Cuentas.Interfaces.Datos
{
    public interface ICuentasContexto
    {
        void AgregarCuenta(Cuenta cuenta);
        void GuardarCambios();
        Task<int> GuardarCambiosAsync();
        Cuenta ObtenerCuenta(Int64 numero);
    }
}
