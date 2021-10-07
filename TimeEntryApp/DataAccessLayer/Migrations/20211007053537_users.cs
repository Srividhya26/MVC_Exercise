using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Break_Entry_EntryID",
                table: "Break");

            migrationBuilder.DropForeignKey(
                name: "FK_Entry_AspNetUsers_ApplicationUser",
                table: "Entry");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ApplicationUser",
                table: "Entry",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Entry_ApplicationUser",
                table: "Entry",
                newName: "IX_Entry_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "EntryID",
                table: "Break",
                newName: "EntryId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Break",
                newName: "BreakID");

            migrationBuilder.RenameIndex(
                name: "IX_Break_EntryID",
                table: "Break",
                newName: "IX_Break_EntryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OutTime",
                table: "Entry",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InTime",
                table: "Entry",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Entry",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BreakOut",
                table: "Break",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BreakIn",
                table: "Break",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Break_Entry_EntryId",
                table: "Break",
                column: "EntryId",
                principalTable: "Entry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entry_AspNetUsers_ApplicationUserId",
                table: "Entry",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Break_Entry_EntryId",
                table: "Break");

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

            migrationBuilder.RenameColumn(
                name: "EntryId",
                table: "Break",
                newName: "EntryID");

            migrationBuilder.RenameColumn(
                name: "BreakID",
                table: "Break",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Break_EntryId",
                table: "Break",
                newName: "IX_Break_EntryID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OutTime",
                table: "Entry",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InTime",
                table: "Entry",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Entry",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BreakOut",
                table: "Break",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BreakIn",
                table: "Break",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Break_Entry_EntryID",
                table: "Break",
                column: "EntryID",
                principalTable: "Entry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entry_AspNetUsers_ApplicationUser",
                table: "Entry",
                column: "ApplicationUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
