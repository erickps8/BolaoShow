using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BolaoShow.Data.Migrations
{
    public partial class todas_dezenas_aposta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                schema: "bolao",
                table: "Apostas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Dezena_06",
                schema: "bolao",
                table: "Apostas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dezena_07",
                schema: "bolao",
                table: "Apostas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dezena_08",
                schema: "bolao",
                table: "Apostas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dezena_09",
                schema: "bolao",
                table: "Apostas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dezena_10",
                schema: "bolao",
                table: "Apostas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                schema: "bolao",
                table: "Apostas");

            migrationBuilder.DropColumn(
                name: "Dezena_06",
                schema: "bolao",
                table: "Apostas");

            migrationBuilder.DropColumn(
                name: "Dezena_07",
                schema: "bolao",
                table: "Apostas");

            migrationBuilder.DropColumn(
                name: "Dezena_08",
                schema: "bolao",
                table: "Apostas");

            migrationBuilder.DropColumn(
                name: "Dezena_09",
                schema: "bolao",
                table: "Apostas");

            migrationBuilder.DropColumn(
                name: "Dezena_10",
                schema: "bolao",
                table: "Apostas");
        }
    }
}
