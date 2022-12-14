// <auto-generated />
using Clientes.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clientes.Datos.Migrations
{
    [DbContext(typeof(ClientesContexto))]
    [Migration("20221129035855_MigracionInicial")]
    partial class MigracionInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Clientes.Modelos.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Direccion");

                    b.Property<string>("FechaNacimiento")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FechaNacimiento");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("Genero");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Identificacion");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nombre");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Telefono");

                    b.Property<string>("TipoIdentificacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes", "dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
