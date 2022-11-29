using Clientes.Datos.ModelBuilders;
using Clientes.Interfaces.Datos;
using Clientes.Modelos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Clientes.Datos
{
    public partial class ClientesContexto : DbContext, IClientesContexto
    {
        public DbSet<Cliente> Clientes { get; init; }

        public ClientesContexto(DbContextOptions<ClientesContexto> options, IHostEnvironment host) : base(options){
            if (host.IsDevelopment() is false)
            {
                Database.Migrate();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteModelBuilder());
            base.OnModelCreating(modelBuilder);
        }

        public void GuardarCambios() => SaveChanges();
        public Task<int> GuardarCambiosAsync() => SaveChangesAsync();

    }
}
