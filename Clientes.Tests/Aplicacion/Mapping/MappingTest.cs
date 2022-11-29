using AutoMapper;
using Clientes.Modelos.DTO;
using Clientes.Modelos.Entidades;

namespace Clientes.Tests.Aplicacion.Mapping
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<Cliente, ClienteDatos>();
        }
    }
}
