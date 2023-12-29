using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SparrowAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d74d64c-495a-496a-b135-ba78c2d0e331", null, "Administrator", "ADMINISTRATOR" },
                    { "f0dfd7cc-6eb5-4891-8ad2-7a72fcaf2145", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d74d64c-495a-496a-b135-ba78c2d0e331");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0dfd7cc-6eb5-4891-8ad2-7a72fcaf2145");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 1, "", "Політика" },
                    { 2, "", "Технології" },
                    { 3, "", "Наука" }
                });
        }
    }
}
