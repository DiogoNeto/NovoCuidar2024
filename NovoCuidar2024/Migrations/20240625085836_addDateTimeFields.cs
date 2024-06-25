using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    /// <inheritdoc />
    public partial class addDateTimeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Apagado",
                table: "Utente",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Utente",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Utente",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UtilizadorAtualizador",
                table: "Utente",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UtilizadorCriador",
                table: "Utente",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apagado",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "UtilizadorAtualizador",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "UtilizadorCriador",
                table: "Utente");
        }
    }
}
