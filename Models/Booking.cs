using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Customer name must be under 100 characters.")]
        public required string CustomerName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public required string CustomerEmail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Passenger name must be under 100 characters.")]
        public required string PassengerName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public required string PassengerEmail { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Status must be under 20 characters.")]
        public required string Status { get; set; } // Consider using an enum for predefined statuses

        public int? FlightID { get; set; } // Nullable Foreign Key
        public int? HotelID { get; set; } // Nullable Foreign Key
        public int? RentalID { get; set; } // Nullable Foreign Key

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookingDate { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Total price must be greater than zero.")]
        public decimal TotalPrice { get; set; }

        // Navigation properties for relationships
        public Flight? Flight { get; set; }
        public Hotel? Hotel { get; set; }
        public CarRental? CarRental { get; set; }



        // Additional fields that might be necessary
        [StringLength(500)]
        public string? SpecialRequests { get; set; } // Optional field for any special requests or notes

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CheckInDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CheckOutDate { get; set; }

    }
}
