using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    /// <inheritdoc />
    public partial class updateUtente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CC",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "ResponsavelId",
                table: "Utente");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Utente",
                newName: "Vivencia");

            migrationBuilder.RenameColumn(
                name: "TecnicoResponsavelId",
                table: "Utente",
                newName: "ResponsavelTecnicoId");

            migrationBuilder.RenameColumn(
                name: "SubSistemaId",
                table: "Utente",
                newName: "IdInterno");

            migrationBuilder.RenameColumn(
                name: "SNS",
                table: "Utente",
                newName: "FamiliaId");

            migrationBuilder.RenameColumn(
                name: "NomePrincipal",
                table: "Utente",
                newName: "SegurancaSocialNum");

            migrationBuilder.RenameColumn(
                name: "NomeApelido",
                table: "Utente",
                newName: "OrigemContrato");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Utente",
                newName: "NomeEmpresa");

            migrationBuilder.AddColumn<string>(
                name: "ContactoEmail",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ContactoTelemovel",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataInscricao",
                table: "Utente",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "DocIdentificacaoNum",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DocIdentificacaoTipo",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DocIdentificacaoValidade",
                table: "Utente",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "Utente",
                type: "longblob",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Habilitacoes",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HabitacaoPartilhada",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HabitacaoTipo",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Utente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamiliaUtentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamiliaUtentes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tecnico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnico", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamiliaUtentes");

            migrationBuilder.DropTable(
                name: "Tecnico");

            migrationBuilder.DropColumn(
                name: "ContactoEmail",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "ContactoTelemovel",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "DataInscricao",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "DocIdentificacaoNum",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "DocIdentificacaoTipo",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "DocIdentificacaoValidade",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "Habilitacoes",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "HabitacaoPartilhada",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "HabitacaoTipo",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Utente");

            migrationBuilder.RenameColumn(
                name: "Vivencia",
                table: "Utente",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "SegurancaSocialNum",
                table: "Utente",
                newName: "NomePrincipal");

            migrationBuilder.RenameColumn(
                name: "ResponsavelTecnicoId",
                table: "Utente",
                newName: "TecnicoResponsavelId");

            migrationBuilder.RenameColumn(
                name: "OrigemContrato",
                table: "Utente",
                newName: "NomeApelido");

            migrationBuilder.RenameColumn(
                name: "NomeEmpresa",
                table: "Utente",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "IdInterno",
                table: "Utente",
                newName: "SubSistemaId");

            migrationBuilder.RenameColumn(
                name: "FamiliaId",
                table: "Utente",
                newName: "SNS");

            migrationBuilder.AddColumn<int>(
                name: "CC",
                table: "Utente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResponsavelId",
                table: "Utente",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
