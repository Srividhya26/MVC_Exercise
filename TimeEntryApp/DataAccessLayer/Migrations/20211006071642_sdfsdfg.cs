using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class sdfsdfg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entry_AspNetUsers_ApplicationUserId",
                table: "Entry");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Entry",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_Entry_ApplicationUserId",
                table: "Entry",
                newName: "IX_Entry_ApplicationUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Entry_AspNetUsers_ApplicationUser",
                table: "Entry",
                column: "ApplicationUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entry_AspNetUsers_ApplicationUser",
                table: "Entry");

            migrationBuilder.RenameColumn(
                name: "ApplicationUser",
                table: "Entry",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Entry_ApplicationUser",
                table: "Entry",
                newName: "IX_Entry_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entry_AspNetUsers_ApplicationUserId",
                table: "Entry",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
