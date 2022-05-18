using Microsoft.EntityFrameworkCore.Migrations;

namespace TheGoodOldLibrary.Data.Migrations
{
    public partial class createDataBase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Periodicals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Periodicals_AuthorId",
                table: "Periodicals",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Periodicals_Authors_AuthorId",
                table: "Periodicals",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Periodicals_Authors_AuthorId",
                table: "Periodicals");

            migrationBuilder.DropIndex(
                name: "IX_Periodicals_AuthorId",
                table: "Periodicals");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Periodicals");
        }
    }
}
