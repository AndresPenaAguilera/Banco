using Cuentas.Modelos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cuentas.Datos.ModelBuilders
{
    public class CuentaModelBuilder : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> entidad)
        {
            entidad.ToTable("Cuentas", "dbo");
            entidad.HasKey(propiedad => new { propiedad.Id });
            entidad.Property(propiedad => propiedad.Id).HasColumnName("Id");
            entidad.Property(propiedad => propiedad.Numero).HasColumnName("Numero");
            entidad.Property(propiedad => propiedad.Tipo).HasColumnName("Tipo");
            entidad.Property(propiedad => propiedad.SaldoInicial).HasColumnName("SaldoInicial");
            entidad.Property(propiedad => propiedad.Estado).HasColumnName("Estado");
            entidad.Property(propiedad => propiedad.IdCliente).HasColumnName("IdCliente");
        }
    }
}
