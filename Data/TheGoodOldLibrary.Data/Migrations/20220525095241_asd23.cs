using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheGoodOldLibrary.Data.Migrations
{
    public partial class asd23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reader");

            migrationBuilder.AddColumn<int>(
                name: "PeriodicalCount",
                table: "Periodicals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookCount",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodicalId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PeriodicalId",
                table: "AspNetUsers",
                column: "PeriodicalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Periodicals_PeriodicalId",
                table: "AspNetUsers",
                column: "PeriodicalId",
                principalTable: "Periodicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Periodicals_PeriodicalId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PeriodicalId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PeriodicalCount",
                table: "Periodicals");

            migrationBuilder.DropColumn(
                name: "BookCount",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PeriodicalId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Reader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodicalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reader_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reader_Periodicals_PeriodicalId",
                        column: x => x.PeriodicalId,
                        principalTable: "Periodicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reader_BookId",
                table: "Reader",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reader_IsDeleted",
                table: "Reader",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Reader_PeriodicalId",
                table: "Reader",
                column: "PeriodicalId");
        }
    }
}
