using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Models
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelID { get; set; }

        [Required(ErrorMessage = "Hotel name is required.")]
        [StringLength(200, ErrorMessage = "Hotel name must be under 200 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(200, ErrorMessage = "Location must be under 200 characters.")]
        public required string Location { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public double Rating { get; set; }

        [Required(ErrorMessage = "Price per night is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price per night must be greater than zero.")]
        public decimal PricePerNight { get; set; }

        // Assuming amenities are stored as a JSON string for flexibility and extensibility
        [Display(Name = "Amenities")]
        public required string Amenities { get; set; }

        // Navigation property to Booking
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        // Additional fields and enhancements
        [StringLength(1000)]
        [Display(Name = "Description")]
        public string? Description { get; set; } // Optional field for additional hotel details

        [Display(Name = "Available Rooms")]
        [Range(0, int.MaxValue, ErrorMessage = "Available rooms must be a non-negative number.")]
        public int AvailableRooms { get; set; } // To manage room availability

        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date)]

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        // we may implement a more structured way to handle amenities.
        // For example, using a collection of amenity types or an enum if the amenities are known and finite.
        // This could improve the user interface for selecting amenities and make data processing easier.
    }
}
