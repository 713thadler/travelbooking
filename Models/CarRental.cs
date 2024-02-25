using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Models
{
    public class CarRental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentalID { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        [StringLength(100, ErrorMessage = "Company name must be under 100 characters.")]
        public required string Company { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [StringLength(100, ErrorMessage = "Model must be under 100 characters.")]
        public required string Model { get; set; }

        [Required(ErrorMessage = "Price per day is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price per day must be greater than zero.")]
        public required decimal PricePerDay { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(200, ErrorMessage = "Location must be under 200 characters.")]
        public required string Location { get; set; }

        [Required]
        public bool Availability { get; set; }

        // Added fields
        [DataType(DataType.Date)]
        [Display(Name = "Available From")]
        public DateTime AvailableFrom { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Available Until")]
        public DateTime? AvailableUntil { get; set; } // Nullable in case of open-ended availability

        // Navigation property to Booking
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>(); // Initialize to ensure it's never null

        // Additional enhancements
        [StringLength(500)]
        [Display(Name = "Description")]
        public string? Description { get; set; } // Optional field for additional details about the car







    }

}
