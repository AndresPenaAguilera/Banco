
using Movimientos.Modelos.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movimientos.Interfaces.Datos
{
    public interface IMovimientosContexto
    {
        void AgregarMovimiento(Movimiento movimiento);
        void GuardarCambios();
        Task<int> GuardarCambiosAsync();
        Movimiento ObtenerMovimiento(int id);
        List<Movimiento> ObtenerMovimientos(int idCliente);
    }
}
