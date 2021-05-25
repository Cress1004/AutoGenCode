using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoGenCode.Migrations
{
    public partial class AddRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenUITags_GenUIs_GenUIId",
                table: "GenUITags");

            migrationBuilder.DropForeignKey(
                name: "FK_GenUITags_Tags_TagId",
                table: "GenUITags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenUITags",
                table: "GenUITags");

            migrationBuilder.DropColumn(
                name: "GenUITagId",
                table: "GenUITags");

            migrationBuilder.RenameTable(
                name: "GenUITags",
                newName: "GenUITag");

            migrationBuilder.RenameIndex(
                name: "IX_GenUITags_TagId",
                table: "GenUITag",
                newName: "IX_GenUITag_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenUITag",
                table: "GenUITag",
                columns: new[] { "GenUIId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GenUITag_GenUIs_GenUIId",
                table: "GenUITag",
                column: "GenUIId",
                principalTable: "GenUIs",
                principalColumn: "GenUIId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenUITag_Tags_TagId",
                table: "GenUITag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenUITag_GenUIs_GenUIId",
                table: "GenUITag");

            migrationBuilder.DropForeignKey(
                name: "FK_GenUITag_Tags_TagId",
                table: "GenUITag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenUITag",
                table: "GenUITag");

            migrationBuilder.RenameTable(
                name: "GenUITag",
                newName: "GenUITags");

            migrationBuilder.RenameIndex(
                name: "IX_GenUITag_TagId",
                table: "GenUITags",
                newName: "IX_GenUITags_TagId");

            migrationBuilder.AddColumn<int>(
                name: "GenUITagId",
                table: "GenUITags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenUITags",
                table: "GenUITags",
                columns: new[] { "GenUIId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GenUITags_GenUIs_GenUIId",
                table: "GenUITags",
                column: "GenUIId",
                principalTable: "GenUIs",
                principalColumn: "GenUIId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenUITags_Tags_TagId",
                table: "GenUITags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
