using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Movimientos.Resolver
{
    public static class RegistrarContextoExtension
    {
        public static IServiceCollection RegisterContext<TContexto>(this IServiceCollection serviceCollection) where TContexto : DbContext
        {
            serviceCollection.AddDbContext<TContexto>((serviceProvider, dbContextOptionsBuilder) =>
            {
                var BuilderConnection = serviceProvider.GetRequiredService<IBuilderConnection>();
                BuilderConnection.SetUp(serviceProvider, dbContextOptionsBuilder);
            });
            return serviceCollection;
        }

        public static IServiceCollection RegisterContext<TIContexto, TContexto>(this IServiceCollection serviceCollection)
           where TContexto : DbContext, TIContexto where TIContexto : class
        {
            serviceCollection.RegisterContext<TContexto>();
            serviceCollection.AddScoped<TIContexto>(provider => provider.GetService<TContexto>());
            return serviceCollection;
        }
    }

    public class BuilderConnection : IBuilderConnection
    {
        public void SetUp(IServiceProvider serviceProvider, DbContextOptionsBuilder options)
        {
            options.UseSqlServer(serviceProvider.GetService<ISesion>().ConnectionString);
        }
    }

    public interface IBuilderConnection
    {
        void SetUp(IServiceProvider serviceProvider, DbContextOptionsBuilder options);
    }

    public interface ISesion
    {
        string ConnectionString { get; }
    }
}
