using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    /// <inheritdoc />
    public partial class updateUtenteMoradaAndUtente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodPostal1",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "CodPostal2",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "Concelho1",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "Concelho2",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "Localidade1",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "Localidade2",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "Morada1",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "Morada2",
                table: "Utente");

            migrationBuilder.AddColumn<int>(
                name: "Andar",
                table: "MoradaUtente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Fracao",
                table: "MoradaUtente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "NumPorta",
                table: "MoradaUtente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "MoradaUtente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Andar",
                table: "MoradaUtente");

            migrationBuilder.DropColumn(
                name: "Fracao",
                table: "MoradaUtente");

            migrationBuilder.DropColumn(
                name: "NumPorta",
                table: "MoradaUtente");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "MoradaUtente");

            migrationBuilder.AddColumn<string>(
                name: "CodPostal1",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CodPostal2",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Concelho1",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Concelho2",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Localidade1",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Localidade2",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Morada1",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Morada2",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
