using Clientes.Datos;
using Clientes.Interfaces.Datos;
using Clientes.Modelos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Clientes.Tests.Datos
{
    [TestClass]
    public  class ClientesUnitTest
    {
        private Cliente _cliente;
        private IClientesContexto _clientesContexto;

        [TestInitialize]
        public void Inicializar()
        {
            _cliente = new Cliente("CC","999", "Andres",'M', "01/01/1990", "Calle 98 # 98 -98 ", "9999999" );
        }

        [TestMethod]
        public void Debe_ObtenerCliente()
        {
            int idEsperado = 1;

            var options = new DbContextOptionsBuilder<ClientesContexto>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            IHostEnvironment host = new HostingEnvironment { EnvironmentName = Environments.Development };

            _clientesContexto = new ClientesContexto(options, host);
            
            _clientesContexto.AgregarCliente(_cliente);
            
            Cliente actual =  _clientesContexto.ObtenerCliente(_cliente.Id);

            Assert.AreEqual(idEsperado, actual.Id);
        }

       
    }
}
