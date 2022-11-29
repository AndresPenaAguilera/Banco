using Microsoft.EntityFrameworkCore.Migrations;

namespace Clientes.Datos.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIdentificacion = table.Column<string>(type: "varchar(2)", nullable: true),
                    Identificacion = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Genero = table.Column<string>(type: "varchar(1)", nullable: false),
                    FechaNacimiento = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "dbo");
        }
    }
}
