using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MySiteDAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogId", "url" },
                values: new object[,]
                {
                    { 1, "http://blogs.packtpub.com/dotnet" },
                    { 2, "http://blogs.packtpub.com/dotnetcore" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BlogId", "Content", "PublishedDateTime", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Dotnet 4.7 Released Contents", new DateTime(2022, 11, 8, 11, 16, 10, 954, DateTimeKind.Local).AddTicks(9040), "Dotnet 4.7 Released" },
                    { 2, 1, "Dotnet 4.8 Released Contents", new DateTime(2022, 11, 8, 11, 16, 10, 954, DateTimeKind.Local).AddTicks(9075), "Dotnet 4.8 Released" },
                    { 3, 2, "testContent", new DateTime(2022, 11, 8, 11, 16, 10, 954, DateTimeKind.Local).AddTicks(9076), "testTitle" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Author", "Content", "PostId", "Title" },
                values: new object[,]
                {
                    { 1, "Packt", "Dotnet 4.7 Released Contents", 1, "Dotnet 4.7 Released" },
                    { 2, "Packt", "Dotnet 4.8 Released Contents", 1, "Dotnet 4.8 Released" },
                    { 3, "Packt", "Dotnet 4.7 Released Contents", 2, "Dotnet 4.7 Released" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "BlogId",
                keyValue: 1);
        }
    }
}
