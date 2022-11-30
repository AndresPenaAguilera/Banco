using API.Gateway.HttpMessajeHandler.Modelos;
using System.Threading.Tasks;

namespace API.Gateway.HttpMessajeHandler.Interfaces
{
    public interface IClienteConsulta
    {
        Task<(bool resultado, Cliente Cliente, string MensajeError)> ObtieneCliente(int id);
    }


}
