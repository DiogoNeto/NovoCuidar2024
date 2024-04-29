using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    /// <inheritdoc />
    public partial class ContactoPrioritario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concelho",
                table: "Responsavel");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Responsavel");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Responsavel");

            migrationBuilder.DropColumn(
                name: "Observações",
                table: "Responsavel");

            migrationBuilder.RenameColumn(
                name: "SNS",
                table: "Responsavel",
                newName: "UtenteId");

            migrationBuilder.RenameColumn(
                name: "NomePrincipal",
                table: "Responsavel",
                newName: "Parentesco");

            migrationBuilder.RenameColumn(
                name: "NomeApelido",
                table: "Responsavel",
                newName: "Pais");

            migrationBuilder.RenameColumn(
                name: "Nacionalidade",
                table: "Responsavel",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "EstadoCivil",
                table: "Responsavel",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "CC",
                table: "Responsavel",
                newName: "NumPorta");

            migrationBuilder.AddColumn<int>(
                name: "Andar",
                table: "Responsavel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Responsavel",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Fracao",
                table: "Responsavel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Andar",
                table: "Responsavel");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Responsavel");

            migrationBuilder.DropColumn(
                name: "Fracao",
                table: "Responsavel");

            migrationBuilder.RenameColumn(
                name: "UtenteId",
                table: "Responsavel",
                newName: "SNS");

            migrationBuilder.RenameColumn(
                name: "Parentesco",
                table: "Responsavel",
                newName: "NomePrincipal");

            migrationBuilder.RenameColumn(
                name: "Pais",
                table: "Responsavel",
                newName: "NomeApelido");

            migrationBuilder.RenameColumn(
                name: "NumPorta",
                table: "Responsavel",
                newName: "CC");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Responsavel",
                newName: "Nacionalidade");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Responsavel",
                newName: "EstadoCivil");

            migrationBuilder.AddColumn<string>(
                name: "Concelho",
                table: "Responsavel",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataNascimento",
                table: "Responsavel",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Responsavel",
                type: "varchar(1)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Observações",
                table: "Responsavel",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
