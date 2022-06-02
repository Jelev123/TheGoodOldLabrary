using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheGoodOldLibrary.Data.Migrations
{
    public partial class aaa22sds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnAt",
                table: "BookTakings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TakeAt",
                table: "BookTakings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnAt",
                table: "BookTakings");

            migrationBuilder.DropColumn(
                name: "TakeAt",
                table: "BookTakings");
        }
    }
}
