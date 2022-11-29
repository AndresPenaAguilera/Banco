using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Modelos.DTO
{

    public class SolicitudConsultaFiltro : IRequest<ClienteDatos>
    {
        public int Id { get; set; }
    }
}
