using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Movimientos.Interfaces.Datos;
using Movimientos.Datos;
using Movimientos.Modelos.DTO;
using Movimientos.Aplicacion;

namespace Movimientos.Test.Aplicacion
{
    [TestClass]
    public class CreadorMovimientosUnitTest
    {
        private IMovimientosContexto _contexto;

        [TestMethod]
        public async Task Debe_Consulta_ObtenerClientePorId()
        {
            int valorMovimientoEsperado = 20000;

            var options = new DbContextOptionsBuilder<MovimientosContexto>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            IHostEnvironment host = new HostingEnvironment { EnvironmentName = Environments.Development };

            _contexto = new MovimientosContexto(options, host);

            SolicitudCrearMovimiento request = new SolicitudCrearMovimiento()
            {
                IdCuenta = 1,
                Valor = 20000
            };

            await new NuevoMovimiento.Manejador(_contexto).Handle(request, new System.Threading.CancellationToken());

            SolicitudConsultaFiltro requestConsulta = new SolicitudConsultaFiltro()
            {
                Id = 1
            };

            var cuenta = await new ConsultaFiltro.Manejador(_contexto).Handle(requestConsulta, new System.Threading.CancellationToken());

            Assert.AreEqual(valorMovimientoEsperado, cuenta.Valor);
        }


    }
}
