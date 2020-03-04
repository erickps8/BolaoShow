using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BolaoShow.Data.Migrations
{
    public partial class cria_aposta_sorteio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apostas_Sorteios_SorteioId",
                table: "Apostas");

            migrationBuilder.DropIndex(
                name: "IX_Apostas_SorteioId",
                table: "Apostas");

            migrationBuilder.DropColumn(
                name: "SorteioId",
                table: "Apostas");

            migrationBuilder.CreateTable(
                name: "Aposta_Sorteios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApostaId = table.Column<Guid>(nullable: false),
                    SorteioId = table.Column<Guid>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aposta_Sorteios");

            migrationBuilder.AddColumn<Guid>(
                name: "SorteioId",
                table: "Apostas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Apostas_SorteioId",
                table: "Apostas",
                column: "SorteioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apostas_Sorteios_SorteioId",
                table: "Apostas",
                column: "SorteioId",
                principalTable: "Sorteios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
