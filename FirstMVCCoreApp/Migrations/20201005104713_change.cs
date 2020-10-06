using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstMVCCoreApp.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookgallery_book_Booksid",
                table: "Bookgallery");

            migrationBuilder.DropIndex(
                name: "IX_Bookgallery_Booksid",
                table: "Bookgallery");

            migrationBuilder.DropColumn(
                name: "Booksid",
                table: "Bookgallery");

            migrationBuilder.AddColumn<int>(
                name: "Bookidid",
                table: "Bookgallery",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookgallery_Bookidid",
                table: "Bookgallery",
                column: "Bookidid");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookgallery_book_Bookidid",
                table: "Bookgallery",
                column: "Bookidid",
                principalTable: "book",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookgallery_book_Bookidid",
                table: "Bookgallery");

            migrationBuilder.DropIndex(
                name: "IX_Bookgallery_Bookidid",
                table: "Bookgallery");

            migrationBuilder.DropColumn(
                name: "Bookidid",
                table: "Bookgallery");

            migrationBuilder.AddColumn<int>(
                name: "Booksid",
                table: "Bookgallery",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookgallery_Booksid",
                table: "Bookgallery",
                column: "Booksid");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookgallery_book_Booksid",
                table: "Bookgallery",
                column: "Booksid",
                principalTable: "book",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
