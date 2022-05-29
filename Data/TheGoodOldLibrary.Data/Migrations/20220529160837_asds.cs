using Microsoft.EntityFrameworkCore.Migrations;

namespace TheGoodOldLibrary.Data.Migrations
{
    public partial class asds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTakings_Periodicals_PeriodicalId",
                table: "BookTakings");

            migrationBuilder.DropIndex(
                name: "IX_BookTakings_PeriodicalId",
                table: "BookTakings");

            migrationBuilder.DropColumn(
                name: "PeriodicalId",
                table: "BookTakings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeriodicalId",
                table: "BookTakings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookTakings_PeriodicalId",
                table: "BookTakings",
                column: "PeriodicalId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTakings_Periodicals_PeriodicalId",
                table: "BookTakings",
                column: "PeriodicalId",
                principalTable: "Periodicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
