using MediatR;
using System;

namespace Clientes.Modelos.DTO
{
    public class SolicitudCrearCliente : IRequest
    {
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public Char Genero { get; set; }
        public string FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
