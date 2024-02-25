using Microsoft.AspNetCore.Mvc;
using COMP2139_Assignment1_Nigar_Anar_Adler.Models;
using COMP2139_Assignment1_Nigar_Anar_Adler.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using COMP2139_Assignment1_Nigar_Anar_Adler.ViewModels;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Controllers
{
    public class FlightController : Controller
    {
        private readonly TravelBookingContext _context;

        public FlightController(TravelBookingContext context)
        {
            _context = context;
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            var flights = await _context.Flights.ToListAsync();
            return View(flights);
        }

        // GET: Flight/SearchFlights
        public async Task<IActionResult> SearchFlights(string departure, string arrival, DateTime? date)
        {
            var flights = await _context.Flights
                .Where(f => f.Origin == departure && f.Destination == arrival && (!date.HasValue || f.DepartureTime.Date == date.Value.Date))
                .ToListAsync();

            return View("SearchResults", flights);
        }

        // GET: Flight/CheckAvailability
        public async Task<IActionResult> CheckAvailability(int flightId)
        {
            var flight = await _context.Flights.FindAsync(flightId);

            if (flight == null)
            {
                return NotFound();
            }

            ViewBag.AvailabilityMessage = "This flight is currently available for booking.";

            return View(flight);
        }

        // GET: Flight/GetFlightDetails
        public async Task<IActionResult> GetFlightDetails(int flightId)
        {
            var flight = await _context.Flights.FindAsync(flightId);

            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flight/ManageFlights
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ManageFlights()
        {
            var flights = await _context.Flights.ToListAsync();
            return View(flights);
        }

        // GET: Flight/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flight/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightID,Airline,Origin,Destination,DepartureTime,ArrivalTime,Price")] Flight flight)
        {
            if (id != flight.FlightID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Flights.Any(e => e.FlightID == flight.FlightID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flight/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .FirstOrDefaultAsync(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flight/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .FirstOrDefaultAsync(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flight/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Flight/ListFlights
        public async Task<IActionResult> ListFlights()
        {
            var flights = await _context.Flights
                .Select(f => new FlightViewModel
                {
                    FlightID = f.FlightID,
                    Airline = f.Airline,
                    Origin = f.Origin,
                    Destination = f.Destination,
                    DepartureTime = f.DepartureTime,
                    ArrivalTime = f.ArrivalTime,
                    Price = f.Price
                })
                .ToListAsync();

            return View(flights);
        }
    }
}
