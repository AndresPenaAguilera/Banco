using Clientes.Aplicacion;
using Clientes.Datos;
using Clientes.Interfaces.Datos;
using Clientes.Modelos.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Clientes.Tests.Aplicacion
{
    [TestClass]
    public class CreadorClientesUnitTest
    {
        private IClientesContexto _clientesContexto;

        [TestMethod]
        public async Task Debe_Consulta_ObtenerClientePorId()
        {
            var identificacionEsperado = "999";

            var options = new DbContextOptionsBuilder<ClientesContexto>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            IHostEnvironment host = new HostingEnvironment { EnvironmentName = Environments.Development };

            _clientesContexto = new ClientesContexto(options, host);

            SolicitudCrearCliente request = new SolicitudCrearCliente()
            {
                TipoIdentificacion = "CC",
                Identificacion = "999",
                Nombre = "Andres",
                Genero = 'M',
                FechaNacimiento = "01/01/1990",
                Direccion = "Calle 98 # 98 -98 ",
                Telefono = "9999999"
            };

            await new NuevoCliente.Manejador(_clientesContexto).Handle(request, new System.Threading.CancellationToken());

            SolicitudConsultaFiltro requestConsulta = new SolicitudConsultaFiltro()
            {
                Id =1
            };

            var cliente = await new ConsultaFiltro.Manejador(_clientesContexto).Handle(requestConsulta, new System.Threading.CancellationToken());

            Assert.AreEqual(identificacionEsperado, cliente.Identificacion);
        }


    }
}
