using AutoMapper;
using Clientes.Modelos.DTO;
using Clientes.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
