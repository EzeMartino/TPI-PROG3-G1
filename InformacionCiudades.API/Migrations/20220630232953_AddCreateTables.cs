using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contents.API.Migrations
{
    public partial class AddCreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "Category", "Comment", "Duration", "Title" },
                values: new object[] { 1, "Serie", "Muy picante", 36, "Peaky Blinders" });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "Category", "Comment", "Duration", "Title" },
                values: new object[] { 2, "Serie", "Atrapante", 80, "The Walking Dead" });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "Category", "Comment", "Duration", "Title" },
                values: new object[] { 3, "Pelicula", "buena pelicula", 361, "Movie Dick" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
