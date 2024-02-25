using Microsoft.EntityFrameworkCore;
using COMP2139_Assignment1_Nigar_Anar_Adler.Models;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Data
{
    public class TravelBookingContext(DbContextOptions<TravelBookingContext> options) : DbContext(options)
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<CarRental> CarRentals { get; set; }
        public DbSet<Booking> Bookings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Flight entity
            modelBuilder.Entity<Flight>()
                .Property(f => f.Price)
                .HasColumnType("decimal(18, 2)");

            // Configure Hotel entity
            modelBuilder.Entity<Hotel>()
                .Property(h => h.PricePerNight)
                .HasColumnType("decimal(18, 2)");

            // Configure CarRental entity
            modelBuilder.Entity<CarRental>()
                .Property(c => c.PricePerDay)
                .HasColumnType("decimal(18, 2)");

            // Configure Booking entity
            modelBuilder.Entity<Booking>()
                .Property(b => b.TotalPrice)
                .HasColumnType("decimal(18, 2)");

            // Further configurations can be added here as necessary

            // For example, if you have relationships like:
            // One-to-Many: A Flight can have many Bookings
            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Bookings)
                .WithOne(b => b.Flight)
                .HasForeignKey(b => b.FlightID);

            // One-to-Many: A Hotel can have many Bookings
            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Bookings)
                .WithOne(b => b.Hotel)
                .HasForeignKey(b => b.HotelID);

            // One-to-Many: A CarRental can have many Bookings
            modelBuilder.Entity<CarRental>()
                .HasMany(c => c.Bookings)
                .WithOne(b => b.CarRental)
                .HasForeignKey(b => b.RentalID);

            // Add unique constraints, default values, or other entity configurations as needed




        }
    }
}
