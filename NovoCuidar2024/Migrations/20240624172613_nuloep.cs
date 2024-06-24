using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    /// <inheritdoc />
    public partial class nuloep : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "Vivencia",
                table: "Utente",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SegurancaSocialNum",
                table: "Utente",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsavelTecnicoId",
                table: "Utente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "OrigemContacto",
                table: "Utente",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nacionalidade",
                table: "Utente",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "HabitacaoTipo",
                table: "Utente",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "HabitacaoPartilhada",
                table: "Utente",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Habilitacoes",
                table: "Utente",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Utente",
                type: "varchar(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "FamiliaId",
                table: "Utente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EstadoCivil",
                table: "Utente",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Visita_UtenteId",
                table: "Visita",
                column: "UtenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_FotosVisita_Visita_VisitaId",
                table: "FotosVisita",
                column: "VisitaId",
                principalTable: "Visita",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visita_Utente_UtenteId",
                table: "Visita",
                column: "UtenteId",
                principalTable: "Utente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FotosVisita_Visita_VisitaId",
                table: "FotosVisita");

            migrationBuilder.DropForeignKey(
                name: "FK_Visita_Utente_UtenteId",
                table: "Visita");

            migrationBuilder.DropIndex(
                name: "IX_Visita_UtenteId",
                table: "Visita");

            migrationBuilder.RenameColumn(
                name: "VisitaId",
                table: "FotosVisita",
                newName: "FotoVisita");

            migrationBuilder.RenameIndex(
                name: "IX_FotosVisita_VisitaId",
                table: "FotosVisita",
                newName: "IX_FotosVisita_FotoVisita");

            migrationBuilder.UpdateData(
                table: "Utente",
                keyColumn: "Vivencia",
                keyValue: null,
                column: "Vivencia",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Vivencia",
                table: "Utente",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Utente",
                keyColumn: "SegurancaSocialNum",
                keyValue: null,
                column: "SegurancaSocialNum",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SegurancaSocialNum",
                table: "Utente",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsavelTecnicoId",
                table: "Utente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Utente",
                keyColumn: "OrigemContacto",
                keyValue: null,
                column: "OrigemContacto",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "OrigemContacto",
                table: "Utente",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Utente",
                keyColumn: "Nacionalidade",
                keyValue: null,
                column: "Nacionalidade",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nacionalidade",
                table: "Utente",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Utente",
                keyColumn: "HabitacaoTipo",
                keyValue: null,
                column: "HabitacaoTipo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "HabitacaoTipo",
                table: "Utente",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Utente",
                keyColumn: "HabitacaoPartilhada",
                keyValue: null,
                column: "HabitacaoPartilhada",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "HabitacaoPartilhada",
                table: "Utente",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Utente",
                keyColumn: "Habilitacoes",
                keyValue: null,
                column: "Habilitacoes",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Habilitacoes",
                table: "Utente",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Utente",
                keyColumn: "Genero",
                keyValue: null,
                column: "Genero",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Utente",
                type: "varchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "FamiliaId",
                table: "Utente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Utente",
                keyColumn: "EstadoCivil",
                keyValue: null,
                column: "EstadoCivil",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "EstadoCivil",
                table: "Utente",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_FotosVisita_Visita_FotoVisita",
                table: "FotosVisita",
                column: "FotoVisita",
                principalTable: "Visita",
                principalColumn: "Id");
        }
    }
}
