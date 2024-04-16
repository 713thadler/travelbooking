using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Migrations.TravelBookingUser
{
    /// <inheritdoc />
    public partial class IdentityChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24c57f06-bd03-4f2a-8cf6-51a2128414ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27d9b250-8d23-425a-8da4-e57ed27379c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bfb8d8c-3516-4e65-8674-a8b053c4f24f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0072fa60-2c2b-4e8a-aeb1-ca40c53bbf63", null, "User", "USER" },
                    { "84699a77-4200-4e0c-8723-16b44c4a1b44", null, "Admin", "ADMIN" },
                    { "e0050d46-6968-475c-a5d3-ed936d19a387", null, "Staff", "STAFF" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0072fa60-2c2b-4e8a-aeb1-ca40c53bbf63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84699a77-4200-4e0c-8723-16b44c4a1b44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0050d46-6968-475c-a5d3-ed936d19a387");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24c57f06-bd03-4f2a-8cf6-51a2128414ec", null, "Staff", "STAFF" },
                    { "27d9b250-8d23-425a-8da4-e57ed27379c0", null, "User", "USER" },
                    { "9bfb8d8c-3516-4e65-8674-a8b053c4f24f", null, "Admin", "ADMIN" }
                });
        }
    }
}
