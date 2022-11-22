using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySiteDAL.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDateTime",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Blogs",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublishedDateTime",
                value: new DateTime(2022, 11, 22, 8, 49, 42, 974, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublishedDateTime",
                value: new DateTime(2022, 11, 22, 8, 49, 42, 974, DateTimeKind.Local).AddTicks(9354));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublishedDateTime",
                value: new DateTime(2022, 11, 22, 8, 49, 42, 974, DateTimeKind.Local).AddTicks(9356));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Blogs");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDateTime",
                table: "Posts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublishedDateTime",
                value: new DateTime(2022, 11, 8, 11, 16, 10, 954, DateTimeKind.Local).AddTicks(9040));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublishedDateTime",
                value: new DateTime(2022, 11, 8, 11, 16, 10, 954, DateTimeKind.Local).AddTicks(9075));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublishedDateTime",
                value: new DateTime(2022, 11, 8, 11, 16, 10, 954, DateTimeKind.Local).AddTicks(9076));
        }
    }
}
