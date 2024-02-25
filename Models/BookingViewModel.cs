using System;
using System.ComponentModel.DataAnnotations;
using COMP2139_Assignment1_Nigar_Anar_Adler.Models; // For referencing any enums or related models

namespace COMP2139_Assignment1_Nigar_Anar_Adler.ViewModels
{
    public class BookingViewModel
    {
        [Display(Name = "Flight")]
        public int? FlightID { get; set; } // Nullable in case flights are not part of every booking

        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(100, ErrorMessage = "Customer name must be under 100 characters.")]
        [Display(Name = "Customer Name")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Customer email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Customer Email")]
        public string? CustomerEmail { get; set; }

        [Required(ErrorMessage = "Passenger name is required.")]
        [StringLength(100, ErrorMessage = "Passenger name must be under 100 characters.")]
        [Display(Name = "Passenger Name")]
        public string? PassengerName { get; set; }

        [Required(ErrorMessage = "Passenger email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Passenger Email")]
        public string? PassengerEmail { get; set; }

        [Required(ErrorMessage = "Booking date is required.")]
        [Display(Name = "Booking Date")]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [Required(ErrorMessage = "Total price is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Total price must be greater than zero.")]
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Hotel")]
        public int? HotelID { get; set; } // Nullable for cases where a hotel is not part of the booking

        [Display(Name = "Car Rental")]
        public int? RentalID { get; set; } // Nullable for cases where a car rental is not part of the booking

        [StringLength(500, ErrorMessage = "Special requests must be under 500 characters.")]
        [Display(Name = "Special Requests")]
        public string? SpecialRequests { get; set; } // Optional

        [Required(ErrorMessage = "Check-in date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Check-In Date")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Check-out date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Check-Out Date")]
        public DateTime CheckOutDate { get; set; }

        // Navigation properties for displaying related data in the view
        public Flight? Flight { get; set; }
        public Hotel? Hotel { get; set; }
        public CarRental? CarRental { get; set; }

        // Constructor is now removed to allow for parameterless instantiation 
        // and setting properties via object initializer where necessary.
        public BookingViewModel() { }
    }
}
