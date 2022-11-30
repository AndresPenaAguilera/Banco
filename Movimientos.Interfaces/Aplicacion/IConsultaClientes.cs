using Movimientos.Modelos.Mensajes;
using System.Threading.Tasks;

namespace Movimientos.Interfaces.Aplicacion
{
    public interface IConsultaClientes
    {
        Task<(bool resultado, DatosCliente Cliente, string MensajeError )> ObtieneCliente(int id);
    }
}
