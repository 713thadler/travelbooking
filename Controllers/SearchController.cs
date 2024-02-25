using Microsoft.AspNetCore.Mvc;
using COMP2139_Assignment1_Nigar_Anar_Adler.Data;
using COMP2139_Assignment1_Nigar_Anar_Adler.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Controllers
{
    public class SearchController : Controller
    {
        private readonly TravelBookingContext _context;

        public SearchController(TravelBookingContext context)
        {
            _context = context;
        }

        // Assume a direct search functionality without an Index page
        // This action could be called from other parts of the application or directly with query parameters
        public async Task<IActionResult> Results(SearchViewModel searchModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultViewModel = new SearchResultsViewModel();

            switch (searchModel.ServiceType)
            {
                case ServiceType.Flights:
#pragma warning disable CS8604 // Possible null reference argument.
                    resultViewModel.Flights = await _context.Flights
                        .Where(f => f.Destination.Contains(searchModel.Destination) && f.DepartureTime >= searchModel.StartDate && f.ArrivalTime <= searchModel.EndDate)
                        .ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
                    break;
                case ServiceType.Hotels:
#pragma warning disable CS8604 // Possible null reference argument.
                    resultViewModel.Hotels = await _context.Hotels
                        .Where(h => h.Location.Contains(searchModel.Destination) && h.CheckInDate <= searchModel.StartDate && h.CheckOutDate >= searchModel.EndDate)
                        .ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
                    break;
                case ServiceType.CarRentals:
#pragma warning disable CS8604 // Possible null reference argument.
                    resultViewModel.CarRentals = await _context.CarRentals
                        .Where(c => c.Location.Contains(searchModel.Destination) && c.AvailableFrom <= searchModel.StartDate && c.AvailableUntil >= searchModel.EndDate)
                        .ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
                    break;
                default:
                    // Optionally handle an unsupported service type
                    break;
            }

            // Directly return the SearchResults view with the populated ViewModel
            return View("SearchResults", resultViewModel);
        }

        // The Details action remains unchanged
        public async Task<IActionResult> Details(int? id, ServiceType serviceType)
        {
            if (id == null)
            {
                return NotFound();
            }

            switch (serviceType)
            {
                case ServiceType.Flights:
                    var flight = await _context.Flights.FirstOrDefaultAsync(f => f.FlightID == id);
                    if (flight == null) return NotFound();
                    return View("Details", flight);

                case ServiceType.Hotels:
                    var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.HotelID == id);
                    if (hotel == null) return NotFound();
                    return View("Details", hotel);

                case ServiceType.CarRentals:
                    var carRental = await _context.CarRentals.FirstOrDefaultAsync(c => c.RentalID == id);
                    if (carRental == null) return NotFound();
                    return View("Details", carRental);

                default:
                    return NotFound();
            }
        }
    }
}
