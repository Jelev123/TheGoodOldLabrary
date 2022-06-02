using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheGoodOldLibrary.Data.Migrations
{
    public partial class aaa22sds2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnAt",
                table: "PeriodicalTakings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TakeAt",
                table: "PeriodicalTakings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnAt",
                table: "PeriodicalTakings");

            migrationBuilder.DropColumn(
                name: "TakeAt",
                table: "PeriodicalTakings");
        }
    }
}
