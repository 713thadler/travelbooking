using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Migrations.TravelBookingUser
{
    /// <inheritdoc />
    public partial class IdentityChanges1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1161fab3-c9c1-45a6-b4c5-9a3901361e43", null, "Staff", "STAFF" },
                    { "49793f36-6c74-4a05-a093-d7fd8c0692ac", null, "User", "USER" },
                    { "75ef3131-e796-4355-815d-6e87babc44d5", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1161fab3-c9c1-45a6-b4c5-9a3901361e43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49793f36-6c74-4a05-a093-d7fd8c0692ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75ef3131-e796-4355-815d-6e87babc44d5");

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
    }
}
