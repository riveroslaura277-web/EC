using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUBIReVIDENCIAS.Migrations
{
    /// <inheritdoc />
    public partial class BaseFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_EstudianteId",
                table: "Asistencias",
                column: "EstudianteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Estudiantes_EstudianteId",
                table: "Asistencias",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "IdEstudiante",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Estudiantes_EstudianteId",
                table: "Asistencias");

            migrationBuilder.DropIndex(
                name: "IX_Asistencias_EstudianteId",
                table: "Asistencias");
        }
    }
}
