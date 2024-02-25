using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarRentals",
                columns: table => new
                {
                    RentalID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Company = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Availability = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvailableFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AvailableUntil = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentals", x => x.RentalID);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Airline = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Origin = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Destination = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FlightNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    NumberOfSeats = table.Column<int>(type: "INTEGER", nullable: false),
                    AvailableSeats = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightID);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Amenities = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    AvailableRooms = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelID);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CustomerEmail = table.Column<string>(type: "TEXT", nullable: false),
                    PassengerName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PassengerEmail = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    FlightID = table.Column<int>(type: "INTEGER", nullable: true),
                    HotelID = table.Column<int>(type: "INTEGER", nullable: true),
                    RentalID = table.Column<int>(type: "INTEGER", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SpecialRequests = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CheckInDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_CarRentals_RentalID",
                        column: x => x.RentalID,
                        principalTable: "CarRentals",
                        principalColumn: "RentalID");
                    table.ForeignKey(
                        name: "FK_Bookings_Flights_FlightID",
                        column: x => x.FlightID,
                        principalTable: "Flights",
                        principalColumn: "FlightID");
                    table.ForeignKey(
                        name: "FK_Bookings_Hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotels",
                        principalColumn: "HotelID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FlightID",
                table: "Bookings",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelID",
                table: "Bookings",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RentalID",
                table: "Bookings",
                column: "RentalID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "CarRentals");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
