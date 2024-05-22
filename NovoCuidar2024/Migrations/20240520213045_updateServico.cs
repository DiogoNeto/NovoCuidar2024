using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    /// <inheritdoc />
    public partial class updateServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrigemContacto",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "UtenteId",
                table: "Servico");

            migrationBuilder.RenameColumn(
                name: "ServicoContratado",
                table: "Servico",
                newName: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Servico",
                newName: "ServicoContratado");

            migrationBuilder.AddColumn<string>(
                name: "OrigemContacto",
                table: "Servico",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Preco",
                table: "Servico",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UtenteId",
                table: "Servico",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
