using Clientes.Modelos.Entidades;
using System;

namespace Clientes.Modelos.DTO
{
    public class ClienteDatos
    {
        public ClienteDatos(Cliente cliente)
        {
            TipoIdentificacion = cliente.TipoIdentificacion;
            Identificacion = cliente.Identificacion.ToString();
            Nombre  = cliente.Nombre.ToString();
            Genero = cliente.Genero;
            FechaNacimiento = cliente.FechaNacimiento.ToString();
            Direccion = cliente.Direccion.ToString();
            Telefono = cliente.Telefono.ToString();
        }

        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public Char Genero { get; set; }
        public string FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
