using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BolaoShow.Data.Migrations
{
    public partial class cria_concurso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aposta_Sorteios");

            migrationBuilder.DropColumn(
                name: "NumeroConcurso",
                table: "Sorteios");

            migrationBuilder.AddColumn<Guid>(
                name: "ConcursoId",
                table: "Sorteios",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConcursoId",
                table: "Apostas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Concurso",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    NumeroConcurso = table.Column<int>(nullable: false),
                    DataInicioConcurso = table.Column<DateTime>(nullable: false),
                    DataFimConcurso = table.Column<DateTime>(nullable: false),
                    ApostaId = table.Column<Guid>(nullable: false),
                    SorteioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concurso", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sorteios_ConcursoId",
                table: "Sorteios",
                column: "ConcursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Apostas_ConcursoId",
                table: "Apostas",
                column: "ConcursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apostas_Concurso_ConcursoId",
                table: "Apostas",
                column: "ConcursoId",
                principalTable: "Concurso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sorteios_Concurso_ConcursoId",
                table: "Sorteios",
                column: "ConcursoId",
                principalTable: "Concurso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apostas_Concurso_ConcursoId",
                table: "Apostas");

            migrationBuilder.DropForeignKey(
                name: "FK_Sorteios_Concurso_ConcursoId",
                table: "Sorteios");

            migrationBuilder.DropTable(
                name: "Concurso");

            migrationBuilder.DropIndex(
                name: "IX_Sorteios_ConcursoId",
                table: "Sorteios");

            migrationBuilder.DropIndex(
                name: "IX_Apostas_ConcursoId",
                table: "Apostas");

            migrationBuilder.DropColumn(
                name: "ConcursoId",
                table: "Sorteios");

            migrationBuilder.DropColumn(
                name: "ConcursoId",
                table: "Apostas");

            migrationBuilder.AddColumn<int>(
                name: "NumeroConcurso",
                table: "Sorteios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Aposta_Sorteios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApostaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SorteioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aposta_Sorteios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aposta_Sorteios_Apostas_ApostaId",
                        column: x => x.ApostaId,
                        principalTable: "Apostas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aposta_Sorteios_Sorteios_SorteioId",
                        column: x => x.SorteioId,
                        principalTable: "Sorteios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aposta_Sorteios_ApostaId",
                table: "Aposta_Sorteios",
                column: "ApostaId");

            migrationBuilder.CreateIndex(
                name: "IX_Aposta_Sorteios_SorteioId",
                table: "Aposta_Sorteios",
                column: "SorteioId");
        }
    }
}
