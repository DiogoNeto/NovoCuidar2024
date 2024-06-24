using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    /// <inheritdoc />
    public partial class fotosvisitaForign2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FotosVisita_Visita_FotoVisita",
                table: "FotosVisita");

            migrationBuilder.RenameColumn(
                name: "FotoVisita",
                table: "FotosVisita",
                newName: "VisitaId");

            migrationBuilder.RenameIndex(
                name: "IX_FotosVisita_FotoVisita",
                table: "FotosVisita",
                newName: "IX_FotosVisita_VisitaId");

            migrationBuilder.AddForeignKey(
                name: "FK_FotosVisita_Visita_VisitaId",
                table: "FotosVisita",
                column: "VisitaId",
                principalTable: "Visita",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FotosVisita_Visita_VisitaId",
                table: "FotosVisita");

            migrationBuilder.RenameColumn(
                name: "VisitaId",
                table: "FotosVisita",
                newName: "FotoVisita");

            migrationBuilder.RenameIndex(
                name: "IX_FotosVisita_VisitaId",
                table: "FotosVisita",
                newName: "IX_FotosVisita_FotoVisita");

            migrationBuilder.AddForeignKey(
                name: "FK_FotosVisita_Visita_FotoVisita",
                table: "FotosVisita",
                column: "FotoVisita",
                principalTable: "Visita",
                principalColumn: "Id");
        }
    }
}
