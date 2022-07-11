using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Infrastructure.Migrations
{
    public partial class RemoveBookLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_book_lang",
                table: "book");

            migrationBuilder.DropTable(
                name: "book_language");

            migrationBuilder.DropIndex(
                name: "IX_book_language_id",
                table: "book");

            migrationBuilder.DropColumn(
                name: "language_id",
                table: "book");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "language_id",
                table: "book",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "book_language",
                columns: table => new
                {
                    language_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    language_code = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    language_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_language", x => x.language_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_language_id",
                table: "book",
                column: "language_id");

            migrationBuilder.AddForeignKey(
                name: "fk_book_lang",
                table: "book",
                column: "language_id",
                principalTable: "book_language",
                principalColumn: "language_id");
        }
    }
}
