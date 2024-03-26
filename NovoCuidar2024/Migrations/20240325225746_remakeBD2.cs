using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    /// <inheritdoc />
    public partial class remakeBD2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubSistemaId",
                table: "Pessoa",
                newName: "SubSistema");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_SubSistema",
                table: "Pessoa",
                column: "SubSistema");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Subsistema_SubSistema",
                table: "Pessoa",
                column: "SubSistema",
                principalTable: "SubSistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Subsistema_SubSistema",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_SubSistema",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "SubSistema",
                table: "Pessoa",
                newName: "SubSistemaId");
        }
    }
}
