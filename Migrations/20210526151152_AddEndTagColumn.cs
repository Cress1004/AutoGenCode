using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoGenCode.Migrations
{
    public partial class AddEndTagColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasEndTag",
                table: "Tags",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasEndTag",
                table: "Tags");
        }
    }
}
