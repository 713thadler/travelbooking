namespace COMP2139_Assignment1_Nigar_Anar_Adler.Models
{
    public class AdminDashboardViewModel
    {
        // Counts for each entity type
        public int CarRentalCount { get; set; }
        public int FlightCount { get; set; }
        public int HotelCount { get; set; }

        // You could also include more detailed statistics if needed
        public int TotalBookings { get; set; }
        public decimal TotalRevenue { get; set; }
        public int AvailableCarRentals { get; set; }
        public int AvailableFlights { get; set; }
        public int AvailableRooms { get; set; }



        // Add any other properties needed for the Dashboard
        // Example: List<CarRental> RecentCarRentals { get; set; }
        // Example: List<Flight> UpcomingFlights { get; set; }
        // Example: List<Hotel> FeaturedHotels { get; set; }

        // Initialize lists to ensure they are never null
        public AdminDashboardViewModel()
        {
            // RecentCarRentals = new List<CarRental>();
            // UpcomingFlights = new List<Flight>();
            // FeaturedHotels = new List<Hotel>();

            // Initialize other properties as needed

        }
    }
}
