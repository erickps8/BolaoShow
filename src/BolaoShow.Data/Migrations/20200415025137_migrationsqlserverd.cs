using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BolaoShow.Data.Migrations
{
    public partial class migrationsqlserverd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bolao");

            migrationBuilder.CreateTable(
                name: "Concursos",
                schema: "bolao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    NumeroConcurso = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataInicioConcurso = table.Column<DateTime>(nullable: false),
                    DataFimConcurso = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apostas",
                schema: "bolao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Dezena_01 = table.Column<int>(nullable: false),
                    Dezena_02 = table.Column<int>(nullable: false),
                    Dezena_03 = table.Column<int>(nullable: false),
                    Dezena_04 = table.Column<int>(nullable: false),
                    Dezena_05 = table.Column<int>(nullable: false),
                    Dezena_06 = table.Column<int>(nullable: false),
                    Dezena_07 = table.Column<int>(nullable: false),
                    Dezena_08 = table.Column<int>(nullable: false),
                    Dezena_09 = table.Column<int>(nullable: false),
                    Dezena_10 = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    ValorAposta = table.Column<decimal>(nullable: false),
                    ConcursoId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apostas_Concursos_ConcursoId",
                        column: x => x.ConcursoId,
                        principalSchema: "bolao",
                        principalTable: "Concursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sorteios",
                schema: "bolao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Dezena_01 = table.Column<int>(nullable: false),
                    Dezena_02 = table.Column<int>(nullable: false),
                    Dezena_03 = table.Column<int>(nullable: false),
                    Dezena_04 = table.Column<int>(nullable: false),
                    Dezena_05 = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    ConcursoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorteios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sorteios_Concursos_ConcursoId",
                        column: x => x.ConcursoId,
                        principalSchema: "bolao",
                        principalTable: "Concursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apostas_ConcursoId",
                schema: "bolao",
                table: "Apostas",
                column: "ConcursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Sorteios_ConcursoId",
                schema: "bolao",
                table: "Sorteios",
                column: "ConcursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apostas",
                schema: "bolao");

            migrationBuilder.DropTable(
                name: "Sorteios",
                schema: "bolao");

            migrationBuilder.DropTable(
                name: "Concursos",
                schema: "bolao");
        }
    }
}
