using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP2139_Assignment1_Nigar_Anar_Adler.Models;
using System.Threading.Tasks;
using COMP2139_Assignment1_Nigar_Anar_Adler.Data;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Controllers
{
    public class DashboardController : Controller
    {
        private readonly TravelBookingContext _context;

        public DashboardController(TravelBookingContext context)
        {
            _context = context;
        }


        // GET: Dashboard
        public async Task<IActionResult> Index()
        {
            var viewModel = new AdminDashboardViewModel
            {
                CarRentalCount = await _context.CarRentals.CountAsync(),
                FlightCount = await _context.Flights.CountAsync(),
                HotelCount = await _context.Hotels.CountAsync(),

            };

            return View(viewModel);
        }

        // Any additional methods required by your dashboard would go here

        // Dispose the context when the controller is disposed of
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
