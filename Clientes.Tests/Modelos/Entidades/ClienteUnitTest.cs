using Clientes.Modelos.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Clientes.Tests.Modelos.Entidades
{
    [TestClass]
    public class ClienteUnitTest
    {

        [TestMethod]
        public void Debe_CuandoTipoIdentificacionEsNull_LanzaError(){
            
            string mensajeEsperado = "TipoIdentificacionRequerido";

            string mensajeActual = Assert.ThrowsException<Exception>(() =>
            {
                new Cliente(null, "999", "Andres", 'M', "01/01/1990", "Calle 98 # 98 -98 ", "9999999");
            }).Message;

            Assert.AreEqual(mensajeEsperado, mensajeActual);
        }

        [TestMethod]
        public void Debe_CuandoIdentificacionEsNull_LanzaError()
        {

            string mensajeEsperado = "IdentificacionRequerido";

            string mensajeActual = Assert.ThrowsException<Exception>(() =>
            {
                new Cliente("CC", null, "Andres", 'M', "01/01/1990", "Calle 98 # 98 -98 ", "9999999");
            }).Message;

            Assert.AreEqual(mensajeEsperado, mensajeActual);
        }

        [TestMethod]
        public void Debe_CuandoNombreEsNull_LanzaError()
        {

            string mensajeEsperado = "NombreRequerido";

            string mensajeActual = Assert.ThrowsException<Exception>(() =>
            {
                new Cliente("CC", "999", null, 'M', "01/01/1990", "Calle 98 # 98 -98 ", "9999999");
            }).Message;

            Assert.AreEqual(mensajeEsperado, mensajeActual);
        }

        [TestMethod]
        public void Debe_CuandoTelefonoEsNull_LanzaError()
        {

            string mensajeEsperado = "TelefonoRequerido";

            string mensajeActual = Assert.ThrowsException<Exception>(() =>
            {
                new Cliente("CC", "999", "Andres", 'M', "01/01/1990", "Calle 98 # 98 -98 ", null);
            }).Message;

            Assert.AreEqual(mensajeEsperado, mensajeActual);
        }
    }
}
