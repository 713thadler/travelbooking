using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDatabaseAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d4fd827-e83f-4141-8a5d-e0742592f0d7", null, "User", "USER" },
                    { "9261c524-eb57-4249-89fa-57c4379205e7", null, "Admin", "ADMIN" },
                    { "b2d7a48b-8fed-4cb6-b1bd-76ac3bc8269f", null, "Staff", "STAFF" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d4fd827-e83f-4141-8a5d-e0742592f0d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9261c524-eb57-4249-89fa-57c4379205e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2d7a48b-8fed-4cb6-b1bd-76ac3bc8269f");
        }
    }
}
