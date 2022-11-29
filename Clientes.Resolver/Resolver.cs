using Clientes.Datos;
using Clientes.Interfaces.Datos;
using Microsoft.Extensions.DependencyInjection;

namespace Clientes.Resolver
{
    public static class Resolver
    {
        public static void AgregarServiciosClientes(this IServiceCollection servicios)
        {
            Contextos(servicios);
            Aplicacion(servicios);
            Dominio(servicios);

        }

        private static void Dominio(IServiceCollection servicios)
        {
            
        }

        private static void Aplicacion(IServiceCollection servicios)
        {
           

        }

        private static void Contextos(IServiceCollection servicios)
        {
            servicios.RegisterContext<IClientesContexto, ClientesContexto>();
        }
    }

  
}
