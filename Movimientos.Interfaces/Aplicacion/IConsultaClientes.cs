using Movimientos.Modelos.Mensajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movimientos.Interfaces.Aplicacion
{
    public interface IConsultaClientes
    {
        Task<(bool resultado, DatosCliente Cliente, string MensajeError )> ObtieneCliente(int id);
    }
}
