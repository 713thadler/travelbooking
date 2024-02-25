using COMP2139_Assignment1_Nigar_Anar_Adler.Models; // Assuming models are in this namespace
using System.Collections.Generic;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.ViewModels
{
    public class SearchResultsViewModel
    {
        // Add properties for each type of search result
        // foreign key to search query
        public int SearchQueryID { get; set; }
        public ServiceType ServiceType { get; set; }
        public string? Destination { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public string? Departure { get; set; }


        public IEnumerable<Flight> Flights { get; set; } = new List<Flight>();
        public IEnumerable<Hotel> Hotels { get; set; } = new List<Hotel>();
        public IEnumerable<CarRental> CarRentals { get; set; } = new List<CarRental>();
    }
}
