using System;
using System.ComponentModel.DataAnnotations;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.ViewModels
{
    public class SearchViewModel
    {
        public string? BackgroundImageUrl { get; set; }

        [Required(ErrorMessage = "Destination is required.")]
        public string? Destination { get; set; }

        [Required(ErrorMessage = "Depurtre is required.")]
        public string? Departure { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Service type is required.")]
        public ServiceType ServiceType { get; set; } // Changed to use enum

        // Constructor to initialize non-nullable properties
        public SearchViewModel()
        {
            Destination = string.Empty;
            Departure = string.Empty;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1); // Example default end date
            ServiceType = ServiceType.Flights; // Example default service type

        }
    }
}
