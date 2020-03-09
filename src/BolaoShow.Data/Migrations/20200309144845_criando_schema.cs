using Microsoft.EntityFrameworkCore.Migrations;

namespace BolaoShow.Data.Migrations
{
    public partial class criando_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bolao");

            migrationBuilder.RenameTable(
                name: "Sorteios",
                newName: "Sorteios",
                newSchema: "bolao");

            migrationBuilder.RenameTable(
                name: "Apostas",
                newName: "Apostas",
                newSchema: "bolao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Sorteios",
                schema: "bolao",
                newName: "Sorteios");

            migrationBuilder.RenameTable(
                name: "Apostas",
                schema: "bolao",
                newName: "Apostas");
        }
    }
}
