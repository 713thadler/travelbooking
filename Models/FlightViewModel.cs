using System;
using System.ComponentModel.DataAnnotations;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Models
{
    public class FlightViewModel
    {
        public int FlightID { get; set; }

        [Required(ErrorMessage = "Airline name is required.")]
        [Display(Name = "Airline")]
        [StringLength(100, ErrorMessage = "Airline name must be under 100 characters.")]
        public required string Airline { get; set; }

        [Required(ErrorMessage = "Origin is required.")]
        [Display(Name = "Origin")]
        [StringLength(100, ErrorMessage = "Origin must be under 100 characters.")]
        public required string Origin { get; set; }

        [Required(ErrorMessage = "Destination is required.")]
        [Display(Name = "Destination")]
        [StringLength(100, ErrorMessage = "Destination must be under 100 characters.")]
        public required string Destination { get; set; }

        [Required(ErrorMessage = "Departure time is required.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Departure Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime DepartureTime { get; set; }

        [Required(ErrorMessage = "Arrival time is required.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Arrival Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ArrivalTime { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        // Additional fields for the ViewModel to match the enhanced Flight model
        [Display(Name = "Flight Number")]
        [StringLength(100)]
        public string? FlightNumber { get; set; } // Optional, useful for user display and selection

        [Display(Name = "Available Seats")]
        public int AvailableSeats { get; set; } // Display current seat availability to the user

        // Consider including any other relevant information that would be useful for users making a booking decision, such as layovers, flight duration, etc.
    }
}
