using Microsoft.AspNetCore.Mvc;
using COMP2139_Assignment1_Nigar_Anar_Adler.Models;
using COMP2139_Assignment1_Nigar_Anar_Adler.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using COMP2139_Assignment1_Nigar_Anar_Adler.ViewModels;
using System;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Controllers
{
    public class BookingController : Controller
    {
        private readonly TravelBookingContext _context;

        public BookingController(TravelBookingContext context)
        {
            _context = context;
        }

        // Lists all bookings
        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.Hotel)
                .Include(b => b.CarRental)
                .ToListAsync();

            return View(bookings);
        }

        // Displays booking form pre-populated based on selected service
        public async Task<IActionResult> BookingForm(int? flightId, int? hotelId, int? rentalId)
        {
            var viewModel = new BookingViewModel();


            // Load details if an ID is provided
            if (flightId.HasValue)
            {
                var flight = await _context.Flights.FindAsync(flightId);
                if (flight != null)
                {
                    viewModel.FlightID = flight.FlightID;
                    viewModel.Flight = flight;
                    viewModel.TotalPrice = flight.Price; // Adjust TotalPrice based on the entity
                }
            }
            if (hotelId.HasValue)
            {
                var hotel = await _context.Hotels.FindAsync(hotelId);
                if (hotel != null)
                {
                    viewModel.HotelID = hotel.HotelID;
                    viewModel.Hotel = hotel;
                    viewModel.TotalPrice += hotel.PricePerNight; // Assuming you want to accumulate prices
                }
            }
            if (rentalId.HasValue)
            {
                var rental = await _context.CarRentals.FindAsync(rentalId);
                if (rental != null)
                {
                    viewModel.RentalID = rental.RentalID;
                    viewModel.CarRental = rental;
                    viewModel.TotalPrice += rental.PricePerDay; // Assuming you want to accumulate prices
                }
            }

            return View(viewModel);
        }

        // Processes booking form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmBooking(BookingViewModel bookingViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("BookingForm", bookingViewModel);
            }

#pragma warning disable CS8601 // Possible null reference assignment.
            var booking = new Booking
            {
                FlightID = bookingViewModel.FlightID,
                HotelID = bookingViewModel.HotelID,
                RentalID = bookingViewModel.RentalID,
                BookingDate = bookingViewModel.BookingDate,
                TotalPrice = bookingViewModel.TotalPrice,
                SpecialRequests = bookingViewModel.SpecialRequests,
                CheckInDate = bookingViewModel.CheckInDate,
                CheckOutDate = bookingViewModel.CheckOutDate,
                CustomerName = bookingViewModel.CustomerName,
                CustomerEmail = bookingViewModel.CustomerEmail,
                PassengerName = bookingViewModel.PassengerName,
                PassengerEmail = bookingViewModel.PassengerEmail,

                Status = "Confirmed"
            };
#pragma warning restore CS8601 // Possible null reference assignment.

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(BookingConfirmation), new { id = booking.BookingID });
        }

        // Shows booking confirmation details
        public async Task<IActionResult> BookingConfirmation(int id)
        {
            var booking = await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.Hotel)
                .Include(b => b.CarRental)
                .FirstOrDefaultAsync(b => b.BookingID == id);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // Cancels a booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null)
            {
                return NotFound();
            }

            booking.Status = "Cancelled";
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // View details of a specific booking
        public async Task<IActionResult> ViewBooking(int bookingId)
        {
            var booking = await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.Hotel)
                .Include(b => b.CarRental)
                .FirstOrDefaultAsync(b => b.BookingID == bookingId);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }
    }
}
