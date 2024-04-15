using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Data
{
    public class TravelBookingUserContext : IdentityDbContext<IdentityUser>
    {
        public TravelBookingUserContext(DbContextOptions<TravelBookingUserContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed default roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Staff", NormalizedName = "STAFF" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            );

            // Ensure unique emails across users
            builder.Entity<IdentityUser>().HasIndex(u => u.Email).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuring the connection string directly in OnConfiguring for simplicity
            optionsBuilder.UseSqlite("Data Source=TravelBooking.db");
        }
    }
}
