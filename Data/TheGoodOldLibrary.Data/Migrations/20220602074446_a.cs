using Microsoft.EntityFrameworkCore.Migrations;

namespace TheGoodOldLibrary.Data.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Periodicals",
                newName: "OriginalUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OriginalUrl",
                table: "Periodicals",
                newName: "ImageUrl");
        }
    }
}
