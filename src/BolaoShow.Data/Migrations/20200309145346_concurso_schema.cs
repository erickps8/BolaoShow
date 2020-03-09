using Microsoft.EntityFrameworkCore.Migrations;

namespace BolaoShow.Data.Migrations
{
    public partial class concurso_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apostas_Concurso_ConcursoId",
                schema: "bolao",
                table: "Apostas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sorteios_Concurso_ConcursoId",
                schema: "bolao",
                table: "Sorteios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concurso",
                table: "Concurso");

            migrationBuilder.RenameTable(
                name: "Concurso",
                newName: "Concursos",
                newSchema: "bolao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concursos",
                schema: "bolao",
                table: "Concursos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apostas_Concursos_ConcursoId",
                schema: "bolao",
                table: "Apostas",
                column: "ConcursoId",
                principalSchema: "bolao",
                principalTable: "Concursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sorteios_Concursos_ConcursoId",
                schema: "bolao",
                table: "Sorteios",
                column: "ConcursoId",
                principalSchema: "bolao",
                principalTable: "Concursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apostas_Concursos_ConcursoId",
                schema: "bolao",
                table: "Apostas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sorteios_Concursos_ConcursoId",
                schema: "bolao",
                table: "Sorteios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concursos",
                schema: "bolao",
                table: "Concursos");

            migrationBuilder.RenameTable(
                name: "Concursos",
                schema: "bolao",
                newName: "Concurso");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concurso",
                table: "Concurso",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apostas_Concurso_ConcursoId",
                schema: "bolao",
                table: "Apostas",
                column: "ConcursoId",
                principalTable: "Concurso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sorteios_Concurso_ConcursoId",
                schema: "bolao",
                table: "Sorteios",
                column: "ConcursoId",
                principalTable: "Concurso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
