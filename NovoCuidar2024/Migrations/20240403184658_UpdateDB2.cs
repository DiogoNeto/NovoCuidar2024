using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //migrationBuilder.AddColumn<int>(
            //    name: "UtenteId",
            //    table: "SubSistema",
            //    type: "int",
            //    nullable: true);
            
            //migrationBuilder.CreateIndex(
            //    name: "IX_SubSistema_UtenteId",
            //    table: "SubSistema",
            //    column: "UtenteId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_SubSistema_Pessoa_UtenteId",
            //    table: "SubSistema",
            //    column: "UtenteId",
            //    principalTable: "Pessoa",
            //    principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_SubSistema_Pessoa_UtenteId",
            //    table: "SubSistema");

            //migrationBuilder.DropIndex(
            //    name: "IX_SubSistema_UtenteId",
            //    table: "SubSistema");

            //migrationBuilder.DropColumn(
            //    name: "UtenteId",
            //    table: "SubSistema");

            //migrationBuilder.AddColumn<int>(
            //    name: "SubSistemaId",
            //    table: "Pessoa",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Pessoa_SubSistema_SubSistemaId",
            //    table: "Pessoa",
            //    column: "SubSistemaId",
            //    principalTable: "SubSistema",
            //    principalColumn: "Id");
        }
    }
}
