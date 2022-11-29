using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movimientos.Modelos.Entidades;


namespace Movimientos.Datos.ModelBuilders
{
    public class MovimientoModelBuilder : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> entidad)
        {
            entidad.ToTable("Movimientos", "dbo");
            entidad.HasKey(propiedad => new { propiedad.Id });
            entidad.Property(propiedad => propiedad.Id).HasColumnName("Id");
            entidad.Property(propiedad => propiedad.IdCuenta).HasColumnName("IdCuenta");
            entidad.Property(propiedad => propiedad.Valor).HasColumnName("Valor");
        }
    }
}
