
using Microsoft.Extensions.DependencyInjection;
using Movimientos.Aplicacion.ConsultasExternas;
using Movimientos.Datos;
using Movimientos.Interfaces.Aplicacion;
using Movimientos.Interfaces.Datos;

namespace Movimientos.Resolver
{
    public static class Resolver
    {
        public static void AgregarServiciosMovimientos(this IServiceCollection servicios)
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
            servicios.AddScoped<IConsultaClientes, ConsultaClientes>();
        }

        private static void Contextos(IServiceCollection servicios)
        {
            servicios.RegisterContext<IMovimientosContexto, MovimientosContexto>();
        }
    }

}
