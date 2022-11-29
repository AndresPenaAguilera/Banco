using MediatR;

namespace Clientes.Modelos.DTO
{

    public class SolicitudConsultaFiltro : IRequest<ClienteDatos>
    {
        public int Id { get; set; }
    }
}
