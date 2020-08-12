using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstMVCCoreApp.Migrations
{
    public partial class addedcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "book",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "book",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "book");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "book");
        }
    }
}
