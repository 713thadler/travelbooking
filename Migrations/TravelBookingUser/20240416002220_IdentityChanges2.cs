using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Migrations.TravelBookingUser
{
    /// <inheritdoc />
    public partial class IdentityChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "6898c48c-8bb3-47d0-9370-03d5a831870d", null, "Admin", "ADMIN" },
                    { "939a1ee5-132d-485c-b60a-20f07b37428e", null, "Staff", "STAFF" },
                    { "bb5d1943-a43b-4faa-a0b9-5714a0e0462b", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6898c48c-8bb3-47d0-9370-03d5a831870d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "939a1ee5-132d-485c-b60a-20f07b37428e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb5d1943-a43b-4faa-a0b9-5714a0e0462b");

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
    }
}
