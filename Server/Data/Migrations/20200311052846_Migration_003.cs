using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Data.Migrations
{
    public partial class Migration_003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "book_category",
                columns: table => new
                {
                    book_category_id = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    code = table.Column<string>(maxLength: 255, nullable: true),
                    name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_category", x => x.book_category_id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    book_id = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(maxLength: 255, nullable: true),
                    detail = table.Column<string>(maxLength: 5000, nullable: true),
                    author = table.Column<string>(maxLength: 255, nullable: true),
                    publisher = table.Column<string>(maxLength: 255, nullable: true),
                    book_category_id = table.Column<Guid>(nullable: false),
                    number_of_page = table.Column<int>(nullable: false),
                    image = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.book_id);
                    table.ForeignKey(
                        name: "FK_book_book_category_book_category_id",
                        column: x => x.book_category_id,
                        principalTable: "book_category",
                        principalColumn: "book_category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_book_category_id",
                table: "book",
                column: "book_category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "book_category");
        }
    }
}
