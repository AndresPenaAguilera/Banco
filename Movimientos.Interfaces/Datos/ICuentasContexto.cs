
using Movimientos.Modelos.Entidades;
using System.Threading.Tasks;

namespace Movimientos.Interfaces.Datos
{
    public interface IMovimientosContexto
    {
        void AgregarMovimiento(Movimiento movimiento);
        void GuardarCambios();
        Task<int> GuardarCambiosAsync();
        Movimiento ObtenerMovimiento(int id);
    }
}
