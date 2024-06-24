using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    /// <inheritdoc />
    public partial class addViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Foto",
                table: "Foto");

            migrationBuilder.RenameTable(
                name: "Foto",
                newName: "FotoViewModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FotoViewModel",
                table: "FotoViewModel",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FotoViewModel",
                table: "FotoViewModel");

            migrationBuilder.RenameTable(
                name: "FotoViewModel",
                newName: "Foto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foto",
                table: "Foto",
                column: "Id");
        }
    }
}
