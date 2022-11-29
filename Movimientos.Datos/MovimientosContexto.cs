using Movimientos.Datos.ModelBuilders;
using Movimientos.Interfaces.Datos;
using Movimientos.Modelos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Movimientos.Datos
{

    public partial class MovimientosContexto : DbContext, IMovimientosContexto
    {
        public DbSet<Movimiento> Movimientos { get; init; }

        public MovimientosContexto(DbContextOptions<MovimientosContexto> options, IHostEnvironment host) : base(options)
        {
            if (host.IsDevelopment() is false)
            {
                Database.Migrate();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovimientoModelBuilder());
            base.OnModelCreating(modelBuilder);
        }

        public void GuardarCambios() => SaveChanges();
        public Task<int> GuardarCambiosAsync() => SaveChangesAsync();

      
    }
}
