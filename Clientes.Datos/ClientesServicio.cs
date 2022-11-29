using Clientes.Modelos.Entidades;
using System;

namespace Clientes.Datos
{
    public partial class ClientesContexto
    {
        public void AgregarCliente(Cliente cliente) => Clientes.Add(cliente);


        public Cliente ObtenerCliente(int id)
        {
            Cliente cliente = Clientes.Find(id);

            if (cliente is null)
                throw new Exception("El cliente no existe");

            return cliente;
        }
    }
}
