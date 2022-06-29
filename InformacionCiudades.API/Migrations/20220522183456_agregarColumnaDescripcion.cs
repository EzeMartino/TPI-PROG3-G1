using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformacionCiudades.API.Migrations
{
    public partial class agregarColumnaDescripcion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "PuntosDeInteres",
                type: "TEXT",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "PuntosDeInteres");
        }
    }
}
