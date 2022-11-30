using Movimientos.Modelos.Entidades;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Movimientos.Interfaces.Datos;
using Microsoft.EntityFrameworkCore;
using Movimientos.Datos;

namespace Cuentas.Test.Datos
{
    [TestClass]
    public class MovimientosUnitTest
    {
        private Movimiento _movimiento;
        private IMovimientosContexto _movimientoContexto;

        [TestInitialize]
        public void Inicializar()
        {
            _movimiento = new Movimiento(1,2000, new DateTime(2022, 01, 01));
        }

        [TestMethod]
        public void Debe_ObtenerCuenta()
        {
            int idEsperado = 1;
            DateTime fechaEsperada = new DateTime(2022,01,01);

            var options = new DbContextOptionsBuilder<MovimientosContexto>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            IHostEnvironment host = new HostingEnvironment { EnvironmentName = Environments.Development };

            _movimientoContexto = new MovimientosContexto(options, host);

            _movimientoContexto.AgregarMovimiento(_movimiento);
            _movimientoContexto.GuardarCambios();

            Movimiento actual = _movimientoContexto.ObtenerMovimiento(_movimiento.Id);

            Assert.AreEqual(idEsperado, actual.Id);
            Assert.AreEqual(fechaEsperada, actual.Fecha);
        }
    }
}
