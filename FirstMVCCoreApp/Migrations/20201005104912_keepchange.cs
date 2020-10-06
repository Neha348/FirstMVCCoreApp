using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstMVCCoreApp.Migrations
{
    public partial class keepchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Bookgallery_BookId",
                table: "Bookgallery",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookgallery_book_BookId",
                table: "Bookgallery",
                column: "BookId",
                principalTable: "book",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookgallery_book_BookId",
                table: "Bookgallery");

            migrationBuilder.DropIndex(
                name: "IX_Bookgallery_BookId",
                table: "Bookgallery");

            migrationBuilder.AddColumn<int>(
                name: "Bookidid",
                table: "Bookgallery",
                type: "int",
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
    }
}
