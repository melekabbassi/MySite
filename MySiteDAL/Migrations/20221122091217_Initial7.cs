using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySiteDAL.Migrations
{
    public partial class Initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Blogs");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublishedDateTime",
                value: new DateTime(2022, 11, 22, 10, 12, 17, 528, DateTimeKind.Local).AddTicks(3881));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublishedDateTime",
                value: new DateTime(2022, 11, 22, 10, 12, 17, 528, DateTimeKind.Local).AddTicks(3919));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublishedDateTime",
                value: new DateTime(2022, 11, 22, 10, 12, 17, 528, DateTimeKind.Local).AddTicks(3921));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
