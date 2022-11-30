using API.Gateway.HttpMessajeHandler.Modelos;
using System.Threading.Tasks;

namespace API.Gateway.HttpMessajeHandler.Interfaces
{
    public interface ICuentaConsulta
    {
        Task<(bool resultado, Cuenta cuenta, string MensajeError)> ObtieneCuenta(int id);
    }


}
