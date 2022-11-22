using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySiteDAL.Migrations
{
    public partial class Initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublishedDateTime",
                value: new DateTime(2022, 11, 22, 9, 50, 44, 650, DateTimeKind.Local).AddTicks(941));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublishedDateTime",
                value: new DateTime(2022, 11, 22, 9, 50, 44, 650, DateTimeKind.Local).AddTicks(989));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublishedDateTime",
                value: new DateTime(2022, 11, 22, 9, 50, 44, 650, DateTimeKind.Local).AddTicks(992));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublishedDateTime",
                value: new DateTime(2022, 11, 22, 9, 12, 26, 484, DateTimeKind.Local).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublishedDateTime",
                value: new DateTime(2022, 11, 22, 9, 12, 26, 484, DateTimeKind.Local).AddTicks(183));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublishedDateTime",
                value: new DateTime(2022, 11, 22, 9, 12, 26, 484, DateTimeKind.Local).AddTicks(185));
        }
    }
}
