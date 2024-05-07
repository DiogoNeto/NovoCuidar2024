using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    /// <inheritdoc />
    public partial class corrigirBugGrupoSanguineo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GrupoSanguinio",
                table: "DadosClinicos",
                newName: "GrupoSanguineo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GrupoSanguineo",
                table: "DadosClinicos",
                newName: "GrupoSanguinio");
        }
    }
}
