using Microsoft.EntityFrameworkCore;
using COMP2139_Assignment1_Nigar_Anar_Adler.Models;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Data
{
    public class TravelBookingContext : DbContext
    {
        public TravelBookingContext(DbContextOptions<TravelBookingContext> options) : base(options)
        { }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<CarRental> CarRentals { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Entity configurations
            modelBuilder.Entity<Flight>().Property(f => f.Price).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Hotel>().Property(h => h.PricePerNight).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<CarRental>().Property(c => c.PricePerDay).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Booking>().Property(b => b.TotalPrice).HasColumnType("decimal(18, 2)");

            // Relationships
            modelBuilder.Entity<Flight>().HasMany(f => f.Bookings).WithOne(b => b.Flight).HasForeignKey(b => b.FlightID);
            modelBuilder.Entity<Hotel>().HasMany(h => h.Bookings).WithOne(b => b.Hotel).HasForeignKey(b => b.HotelID);
            modelBuilder.Entity<CarRental>().HasMany(c => c.Bookings).WithOne(b => b.CarRental).HasForeignKey(b => b.RentalID);
        }
    }
}
