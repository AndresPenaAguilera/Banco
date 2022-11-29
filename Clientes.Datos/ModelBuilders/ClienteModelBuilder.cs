using Clientes.Modelos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Clientes.Datos.ModelBuilders
{
    public class ClienteModelBuilder : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entidad)
        {
            entidad.ToTable("Clientes","dbo");
            entidad.HasKey( propiedad => new { propiedad.Id });
            entidad.Property(propiedad => propiedad.Id ).HasColumnName("Id");
            entidad.Property(propiedad => propiedad.Identificacion).HasColumnName("Identificacion");
            entidad.Property(propiedad => propiedad.Nombre).HasColumnName("Nombre");
            entidad.Property(propiedad => propiedad.Genero).HasColumnName("Genero");
            entidad.Property(propiedad => propiedad.FechaNacimiento).HasColumnName("FechaNacimiento");
            entidad.Property(propiedad => propiedad.Direccion).HasColumnName("Direccion");
            entidad.Property(propiedad => propiedad.Telefono).HasColumnName("Telefono");
        }
    }


}
