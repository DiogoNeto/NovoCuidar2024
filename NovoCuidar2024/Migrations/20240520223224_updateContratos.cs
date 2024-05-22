using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    /// <inheritdoc />
    public partial class updateContratos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFim",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "NumeroContrato",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "TipoContrato",
                table: "Contrato");

            migrationBuilder.RenameColumn(
                name: "UtenteId",
                table: "Contrato",
                newName: "Ficheiro");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "Contrato",
                newName: "DataAssinatura");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Contrato",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Contrato");

            migrationBuilder.RenameColumn(
                name: "Ficheiro",
                table: "Contrato",
                newName: "UtenteId");

            migrationBuilder.RenameColumn(
                name: "DataAssinatura",
                table: "Contrato",
                newName: "DataInicio");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataFim",
                table: "Contrato",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "NumeroContrato",
                table: "Contrato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TipoContrato",
                table: "Contrato",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
