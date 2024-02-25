using Microsoft.AspNetCore.Mvc;
using COMP2139_Assignment1_Nigar_Anar_Adler.Models;
using COMP2139_Assignment1_Nigar_Anar_Adler.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Controllers
{
    public class CarRentalController : Controller
    {
        private readonly TravelBookingContext _context;

        public CarRentalController(TravelBookingContext context)
        {
            _context = context;
        }

        // GET: CarRentals
        public async Task<IActionResult> Index()
        {
            var carRentals = await _context.CarRentals.ToListAsync();
            return View(carRentals);
        }

        // GET: CarRental/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarRental/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Company,Model,PricePerDay,Location,Availability,AvailableFrom,AvailableUntil,Description")] CarRental carRental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carRental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carRental);
        }

        // GET: CarRental/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRental = await _context.CarRentals.FindAsync(id);
            if (carRental == null)
            {
                return NotFound();
            }
            return View(carRental);
        }

        // POST: CarRental/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalID,Company,Model,PricePerDay,Location,Availability,AvailableFrom,AvailableUntil,Description")] CarRental carRental)
        {
            if (id != carRental.RentalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carRental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarRentalExists(carRental.RentalID))
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
            return View(carRental);
        }

        // GET: CarRental/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRental = await _context.CarRentals
                .FirstOrDefaultAsync(m => m.RentalID == id);
            if (carRental == null)
            {
                return NotFound();
            }

            return View(carRental);
        }

        // POST: CarRental/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carRental = await _context.CarRentals.FindAsync(id);
            if (carRental != null)
            {
                _context.CarRentals.Remove(carRental);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CarRental/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRental = await _context.CarRentals
                .FirstOrDefaultAsync(m => m.RentalID == id);
            if (carRental == null)
            {
                return NotFound();
            }

            return View(carRental);
        }

        private bool CarRentalExists(int id)
        {
            return _context.CarRentals.Any(e => e.RentalID == id);
        }
    }
}
