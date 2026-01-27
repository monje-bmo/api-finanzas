using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class stateJournelLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a835e9af-7207-459b-8442-5cbc971482bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecbd37b5-2ec9-4398-bb00-5330b9101397");

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "JournalLines",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66f4b597-0693-40d7-960d-ad52c1e3a5e0", null, "Admin", "ADMIN" },
                    { "fd9c3b74-9e3b-48c9-b176-4bd5f7aca50e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66f4b597-0693-40d7-960d-ad52c1e3a5e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd9c3b74-9e3b-48c9-b176-4bd5f7aca50e");

            migrationBuilder.DropColumn(
                name: "State",
                table: "JournalLines");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a835e9af-7207-459b-8442-5cbc971482bb", null, "Admin", "ADMIN" },
                    { "ecbd37b5-2ec9-4398-bb00-5330b9101397", null, "User", "USER" }
                });
        }
    }
}
