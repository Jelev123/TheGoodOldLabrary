using Microsoft.EntityFrameworkCore.Migrations;

namespace TheGoodOldLibrary.Data.Migrations
{
    public partial class aaa22sd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTaken",
                table: "PeriodicalTakings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTaken",
                table: "BookTakings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTaken",
                table: "PeriodicalTakings");

            migrationBuilder.DropColumn(
                name: "IsTaken",
                table: "BookTakings");
        }
    }
}
