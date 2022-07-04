using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Infrastructure.Migrations
{
    public partial class addCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategotyId",
                table: "book",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategotyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategotyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_CategotyId",
                table: "book",
                column: "CategotyId");

            migrationBuilder.AddForeignKey(
                name: "FK_book_Categories_CategotyId",
                table: "book",
                column: "CategotyId",
                principalTable: "Categories",
                principalColumn: "CategotyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_Categories_CategotyId",
                table: "book");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_book_CategotyId",
                table: "book");

            migrationBuilder.DropColumn(
                name: "CategotyId",
                table: "book");
        }
    }
}
