using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Cuentas.Interfaces.Datos;
using Cuentas.Datos;
using Cuentas.Modelos.DTO;
using Cuentas.Aplicacion;

namespace Cuentas.Test.Aplicacion
{
    [TestClass]
    public class CreadorCuentasUnitTest
    {
        private ICuentasContexto _cuentasContexto;

        [TestMethod]
        public async Task Debe_Consulta_ObtenerClientePorId()
        {
            int numeroCuentaEsperado = 1;

            var options = new DbContextOptionsBuilder<CuentasContexto>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            IHostEnvironment host = new HostingEnvironment { EnvironmentName = Environments.Development };

            _cuentasContexto = new CuentasContexto(options, host);

            SolicitudCrearCuenta request = new SolicitudCrearCuenta()
            {
                Numero = 1,
                SaldoInicial = 2000,
                Estado = true,
                IdCliente = 1,
                Tipo = 'A',
            };

            await new NuevaCuenta.Manejador(_cuentasContexto).Handle(request, new System.Threading.CancellationToken());

            SolicitudConsultaFiltro requestConsulta = new SolicitudConsultaFiltro()
            {
                NumeroCuenta = 1
            };

            var cuenta = await new ConsultaFiltro.Manejador(_cuentasContexto).Handle(requestConsulta, new System.Threading.CancellationToken());

            Assert.AreEqual(numeroCuentaEsperado, cuenta.Numero);
        }


    }
}
