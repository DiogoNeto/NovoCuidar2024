using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    /// <inheritdoc />
    public partial class AddGenderAndSubSistem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubSistema_Utente_UtenteId",
                table: "SubSistema");

            migrationBuilder.DropIndex(
                name: "IX_SubSistema_UtenteId",
                table: "SubSistema");

            migrationBuilder.DropColumn(
                name: "UtenteId",
                table: "SubSistema");

            migrationBuilder.AddColumn<int>(
                name: "SubSistemaId",
                table: "Utente",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubSistemaId",
                table: "Utente");

            migrationBuilder.AddColumn<int>(
                name: "UtenteId",
                table: "SubSistema",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubSistema_UtenteId",
                table: "SubSistema",
                column: "UtenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubSistema_Utente_UtenteId",
                table: "SubSistema",
                column: "UtenteId",
                principalTable: "Utente",
                principalColumn: "Id");
        }
    }
}
