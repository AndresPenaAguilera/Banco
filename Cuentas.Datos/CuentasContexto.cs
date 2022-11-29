using Cuentas.Datos.ModelBuilders;
using Cuentas.Interfaces.Datos;
using Cuentas.Modelos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;


namespace Cuentas.Datos
{
   

    public partial class CuentasContexto : DbContext, ICuentasContexto
    {
        public DbSet<Cuenta> Clientes { get; init; }

        public CuentasContexto(DbContextOptions<CuentasContexto> options, IHostEnvironment host) : base(options)
        {
            if (host.IsDevelopment() is false)
            {
                Database.Migrate();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.ApplyConfiguration(new CuentaModelBuilder());
            base.OnModelCreating(modelBuilder);
        }

        public void GuardarCambios() => SaveChanges();
        public Task<int> GuardarCambiosAsync() => SaveChangesAsync();

    }
}
