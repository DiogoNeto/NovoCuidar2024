using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    /// <inheritdoc />
    public partial class updateFotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FotosVisita",
                table: "FotosVisita",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FotosVisita_FotosVisita",
                table: "FotosVisita",
                column: "FotosVisita");

            migrationBuilder.AddForeignKey(
                name: "FK_FotosVisita_Visita_FotosVisita",
                table: "FotosVisita",
                column: "FotosVisita",
                principalTable: "Visita",
                principalColumn: "Id");
        }
    }
}
