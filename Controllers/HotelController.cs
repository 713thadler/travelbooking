using Microsoft.AspNetCore.Mvc;
using COMP2139_Assignment1_Nigar_Anar_Adler.Models;
using COMP2139_Assignment1_Nigar_Anar_Adler.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using COMP2139_Assignment1_Nigar_Anar_Adler.ViewModels;
using System.Linq;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Controllers
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class HotelController(TravelBookingContext context) : Controller
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        private readonly TravelBookingContext _context = context;
        private Booking booking;



        // GET: Hotels
        public async Task<IActionResult> Index()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return View(hotels);
        }

        // GET: Hotel/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // GET: Hotel/Search
        public async Task<IActionResult> Search(string location)
        {
            var hotels = await _context.Hotels
                .Where(h => !string.IsNullOrEmpty(location) && h.Location.Contains(location))
                .ToListAsync();
            return View("Index", hotels); // Reuse the Index view for displaying search results
        }

        // GET: Hotel/BookHotel/5
        public async Task<IActionResult> BookHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            var bookingViewModel = new BookingViewModel
            {
                HotelID = id,
                CustomerName = string.Empty,
                CustomerEmail = string.Empty,
                PassengerName = string.Empty,
                PassengerEmail = string.Empty
            };

            return View("BookingForm", bookingViewModel);
        }

        // POST: Hotel/ConfirmBooking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmBooking([FromForm] BookingViewModel bookingViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("BookingForm", bookingViewModel);
            }

            var hotel = await _context.Hotels.FindAsync(bookingViewModel.HotelID);
            if (hotel == null)
            {
                return NotFound();
            }


            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            // Redirect to a confirmation page or another appropriate action
            return RedirectToAction(nameof(BookingConfirmation), new { id = booking.BookingID });
        }

        // GET: Hotel/BookingConfirmation
        public async Task<IActionResult> BookingConfirmation(int id)
        {
            var booking = await _context.Bookings
                .Include(b => b.Hotel)
                .FirstOrDefaultAsync(b => b.BookingID == id);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }
    }
}
