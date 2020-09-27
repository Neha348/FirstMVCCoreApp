using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstMVCCoreApp.Migrations
{
    public partial class addedlanguagetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "book");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "book",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_LanguageId",
                table: "book",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_book_Language_LanguageId",
                table: "book",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_Language_LanguageId",
                table: "book");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropIndex(
                name: "IX_book_LanguageId",
                table: "book");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "book");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "book",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
