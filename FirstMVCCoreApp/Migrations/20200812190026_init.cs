using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstMVCCoreApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    AuthorName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Catagory = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Totalpages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book");
        }
    }
}
