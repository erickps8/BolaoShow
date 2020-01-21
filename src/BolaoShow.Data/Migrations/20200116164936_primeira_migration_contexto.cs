using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BolaoShow.Data.Migrations
{
    public partial class primeira_migration_contexto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sorteios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Dezena_01 = table.Column<int>(nullable: false),
                    Dezena_02 = table.Column<int>(nullable: false),
                    Dezena_03 = table.Column<int>(nullable: false),
                    Dezena_04 = table.Column<int>(nullable: false),
                    Dezena_05 = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    NumeroConcurso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorteios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apostas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SorteioId = table.Column<Guid>(nullable: false),
                    Dezena_01 = table.Column<int>(nullable: false),
                    Dezena_02 = table.Column<int>(nullable: false),
                    Dezena_03 = table.Column<int>(nullable: false),
                    Dezena_04 = table.Column<int>(nullable: false),
                    Dezena_05 = table.Column<int>(nullable: false),
                    ValorAposta = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apostas_Sorteios_SorteioId",
                        column: x => x.SorteioId,
                        principalTable: "Sorteios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apostas_SorteioId",
                table: "Apostas",
                column: "SorteioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apostas");

            migrationBuilder.DropTable(
                name: "Sorteios");
        }
    }
}
