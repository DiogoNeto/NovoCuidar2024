using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    /// <inheritdoc />
    public partial class Subsistema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Tecnico");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Tecnico",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Tecnico",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Tecnico");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Tecnico");

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Tecnico",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
