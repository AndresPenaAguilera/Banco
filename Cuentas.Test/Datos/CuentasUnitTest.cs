using Cuentas.Datos;
using Cuentas.Interfaces.Datos;
using Cuentas.Modelos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cuentas.Test.Datos
{
    [TestClass]
    public class CuentasUnitTest
    {
        private Cuenta _cuenta;
        private ICuentasContexto _cuentaContexto;

        [TestInitialize]
        public void Inicializar()
        {
            _cuenta = new Cuenta(1,'A',1000, 1, true);
        }

        [TestMethod]
        public void Debe_ObtenerCuenta()
        {
            int idEsperado = 1;

            var options = new DbContextOptionsBuilder<CuentasContexto>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            IHostEnvironment host = new HostingEnvironment { EnvironmentName = Environments.Development };

            _cuentaContexto = new CuentasContexto(options, host);

            _cuentaContexto.AgregarCuenta(_cuenta);
            _cuentaContexto.GuardarCambios();

            Cuenta actual = _cuentaContexto.ObtenerCuenta(_cuenta.Numero);

            Assert.AreEqual(idEsperado, actual.Id);
        }
    }
}
