using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobApplicationSystem.Migrations
{
    /// <inheritdoc />
    public partial class MakeCVNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95541040-2c01-4391-ba9d-4f11da68cb25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e80166c0-b9d0-4bd9-a7fd-18140c3b5bfb");

            migrationBuilder.DropColumn(
                name: "CV",
                table: "Applicants");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c1c2c95-4201-49dc-aa53-68198f164d2e", null, "User", "USER" },
                    { "9f0ed498-3928-4602-a12a-fabcef9725ee", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c1c2c95-4201-49dc-aa53-68198f164d2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f0ed498-3928-4602-a12a-fabcef9725ee");

            migrationBuilder.AddColumn<string>(
                name: "CV",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "95541040-2c01-4391-ba9d-4f11da68cb25", null, "Admin", "ADMIN" },
                    { "e80166c0-b9d0-4bd9-a7fd-18140c3b5bfb", null, "User", "USER" }
                });
        }
    }
}
