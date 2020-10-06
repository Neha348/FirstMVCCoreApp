using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstMVCCoreApp.Migrations
{
    public partial class addnewtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookgallery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Booksid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookgallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookgallery_book_Booksid",
                        column: x => x.Booksid,
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookgallery_Booksid",
                table: "Bookgallery",
                column: "Booksid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookgallery");
        }
    }
}
