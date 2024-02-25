using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightID { get; set; } // Ensuring it's identified as the primary key and auto-generated

        [Required(ErrorMessage = "Airline name is required.")]
        [StringLength(100, ErrorMessage = "Airline name must be under 100 characters.")]
        public required string Airline { get; set; }

        [Required(ErrorMessage = "Origin is required.")]
        [StringLength(100, ErrorMessage = "Origin must be under 100 characters.")]
        public required string Origin { get; set; }

        [Required(ErrorMessage = "Destination is required.")]
        [StringLength(100, ErrorMessage = "Destination must be under 100 characters.")]
        public required string Destination { get; set; }

        [Required(ErrorMessage = "Departure time is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime DepartureTime { get; set; }

        [Required(ErrorMessage = "Arrival time is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ArrivalTime { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        // Navigation property to Booking
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>(); // Initialize to ensure it's never null

        // Additional fields to consider
        [StringLength(100)]
        [Display(Name = "Flight Number")]
        public string? FlightNumber { get; set; } // Optional, but useful for managing flights

        [Display(Name = "Number of Seats")]
        [Range(1, 1000, ErrorMessage = "Number of seats must be between 1 and 1000.")]
        public int NumberOfSeats { get; set; } // Assuming a default value or set during creation

        [Display(Name = "Available Seats")]
        [Range(1, 1000, ErrorMessage = "Available seats must be between 1 and 1000.")]
        public int AvailableSeats { get; set; } // Can be adjusted as bookings are made
        public string? Description { get; set; } // Optional field for additional details about the flight
        // Consider adding more properties as needed, such as flight duration, layovers, etc.
    }
}
