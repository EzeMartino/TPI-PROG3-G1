using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformacionCiudades.API.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PuntosDeInteres_Ciudades_CiudadId",
                table: "PuntosDeInteres");

            migrationBuilder.AlterColumn<int>(
                name: "CiudadId",
                table: "PuntosDeInteres",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 1, "The one with that big park.", "New York City" });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 2, "The one with the cathedral that was never really finished.", "Antwerp" });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 3, "The one with that big tower.", "Paris" });

            migrationBuilder.InsertData(
                table: "PuntosDeInteres",
                columns: new[] { "Id", "CiudadId", "Descripcion", "Nombre" },
                values: new object[] { 1, 1, "The most visited urban park in the United States.", "Central Park" });

            migrationBuilder.InsertData(
                table: "PuntosDeInteres",
                columns: new[] { "Id", "CiudadId", "Descripcion", "Nombre" },
                values: new object[] { 2, 1, "A 102-story skyscraper located in Midtown Manhattan.", "Empire State Building" });

            migrationBuilder.InsertData(
                table: "PuntosDeInteres",
                columns: new[] { "Id", "CiudadId", "Descripcion", "Nombre" },
                values: new object[] { 3, 2, "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans.", "Cathedral of Our Lady" });

            migrationBuilder.InsertData(
                table: "PuntosDeInteres",
                columns: new[] { "Id", "CiudadId", "Descripcion", "Nombre" },
                values: new object[] { 4, 2, "The the finest example of railway architecture in Belgium.", "Antwerp Central Station" });

            migrationBuilder.InsertData(
                table: "PuntosDeInteres",
                columns: new[] { "Id", "CiudadId", "Descripcion", "Nombre" },
                values: new object[] { 5, 3, "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel.", "Eiffel Tower" });

            migrationBuilder.InsertData(
                table: "PuntosDeInteres",
                columns: new[] { "Id", "CiudadId", "Descripcion", "Nombre" },
                values: new object[] { 6, 3, "The world's largest museum.", "The Louvre" });

            migrationBuilder.AddForeignKey(
                name: "FK_PuntosDeInteres_Ciudades_CiudadId",
                table: "PuntosDeInteres",
                column: "CiudadId",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PuntosDeInteres_Ciudades_CiudadId",
                table: "PuntosDeInteres");

            migrationBuilder.DeleteData(
                table: "PuntosDeInteres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PuntosDeInteres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PuntosDeInteres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PuntosDeInteres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PuntosDeInteres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PuntosDeInteres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "CiudadId",
                table: "PuntosDeInteres",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_PuntosDeInteres_Ciudades_CiudadId",
                table: "PuntosDeInteres",
                column: "CiudadId",
                principalTable: "Ciudades",
                principalColumn: "Id");
        }
    }
}
