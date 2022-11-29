using Clientes.Modelos.Entidades;
using System.Threading.Tasks;

namespace Clientes.Interfaces.Datos
{
    public interface IClientesContexto
    {
        void AgregarCliente(Cliente cliente);
        Cliente ObtenerCliente(int id);
        void GuardarCambios();
        Task<int> GuardarCambiosAsync();
    }
}
