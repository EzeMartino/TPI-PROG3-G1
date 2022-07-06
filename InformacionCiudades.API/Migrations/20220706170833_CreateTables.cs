using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contents.API.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Contents",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Comment", "Duration", "Title" },
                values: new object[] { "Category 1", "Comment 1", 12, "Title 1" });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Comment", "Duration", "Title" },
                values: new object[] { "Category 2", "Comment 2", 12, "Title 2" });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Comment", "Duration", "Title" },
                values: new object[] { "Category 3", "Comment 3", 12, "Title 3" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { 1, "email1@email.com", "password1", "User 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { 2, "email2@email.com", "password2", "User 2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { 3, "email3@email.com", "password3", "User 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Contents",
                type: "TEXT",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Comment", "Duration", "Title" },
                values: new object[] { "Serie", "Muy picante", 36, "Peaky Blinders" });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Comment", "Duration", "Title" },
                values: new object[] { "Serie", "Atrapante", 80, "The Walking Dead" });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Comment", "Duration", "Title" },
                values: new object[] { "Pelicula", "buena pelicula", 361, "Movie Dick" });
        }
    }
}
