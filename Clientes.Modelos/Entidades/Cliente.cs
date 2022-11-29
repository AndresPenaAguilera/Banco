using Clientes.Modelos.DTO;
using Clientes.Modelos.Extensiones;
using System;

namespace Clientes.Modelos.Entidades
{
    public  class Cliente
    {
        public static readonly string TipoIdentificacionRequerido = "TipoIdentificacionRequerido";
        public static readonly string IdentificacionRequerido = "IdentificacionRequerido";
        public static readonly string NombreRequerido = "NombreRequerido";
        public static readonly string TelefonoRequerido = "TelefonoRequerido";

        public int Id { get; internal set; }
        public string TipoIdentificacion { get; internal set; }
        public string Identificacion { get; internal set; }
        public string Nombre { get; internal set; }
        public Char Genero { get; internal set; }
        public string FechaNacimiento { get; internal set; }
        public string Direccion { get; internal set; }
        public string Telefono { get; internal set; }

        public Cliente(
            string tipoIdentificacion,
            string identificacion,
            string nombre,
            Char genero,
            string fechaNacimiento,
            string direccion,
            string telefono
        )
        {
            ValidarCamposVacios(tipoIdentificacion, identificacion, nombre, telefono);

            TipoIdentificacion = tipoIdentificacion;
            Identificacion = identificacion;
            Nombre = nombre;
            Genero = genero;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            Telefono = telefono;
        }

        private void ValidarCamposVacios(
           string tipoIdentificacion, 
           string identificacion, 
           string nombre, 
           string telefono
        )
        {
            tipoIdentificacion.ExcepcionCampoVacio(TipoIdentificacionRequerido);
            identificacion.ExcepcionCampoVacio(IdentificacionRequerido);
            nombre.ExcepcionCampoVacio(NombreRequerido);
            telefono.ExcepcionCampoVacio(TelefonoRequerido);
        }

        public static Cliente CrearDesdeSolicitud(SolicitudCrearCliente SolicitudNuevoCliente) =>
            new(
                    SolicitudNuevoCliente.TipoIdentificacion,
                    SolicitudNuevoCliente.Identificacion,
                    SolicitudNuevoCliente.Nombre,
                    SolicitudNuevoCliente.Genero,
                    SolicitudNuevoCliente.FechaNacimiento,
                    SolicitudNuevoCliente.Direccion,
                    SolicitudNuevoCliente.Telefono
               );
    }
}
