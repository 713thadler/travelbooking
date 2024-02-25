using Microsoft.AspNetCore.Mvc;
using COMP2139_Assignment1_Nigar_Anar_Adler.ViewModels;
using System.Diagnostics;
using System;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Controllers
{
    public class HomeController : Controller
    {
        // Action for the Index page (the homepage of your travel website)
        public IActionResult Index()
        {
            var viewModel = new SearchViewModel
            {
                BackgroundImageUrl = GetRandomBackgroundImageUrl(),
                // Initialize other properties as needed for the search form
                Destination = string.Empty,
                Departure = string.Empty,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1), // Example default end date
                ServiceType = ServiceType.Flights // Example default service type
            };

            return View(viewModel);
        }

        // Action for the About page (provides information about your travel agency)
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        // Action for the Contact page (provides contact information and form)
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        private string GetRandomBackgroundImageUrl()
        {
            var random = new Random();
            var imageNumber = random.Next(1, 9); // Adjust range if you have more or fewer images
            return $"/images/background{imageNumber}.jpg";
        }

        // Assuming ErrorViewModel exists and is correctly defined in your project
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Simplified Search action without the Offer entity
        [HttpPost]
        public IActionResult Search(SearchViewModel searchCriteria)
        {
            // Here, you would process the searchCriteria to perform the search operation
            // For demonstration, we'll just log the search criteria and return the Index view

            Debug.WriteLine($"Search initiated for {searchCriteria.ServiceType} in {searchCriteria.Departure} from {searchCriteria.StartDate.ToShortDateString()} to {searchCriteria.EndDate.ToShortDateString()}.");

            // After processing the search, redirect to the Index view with or without search results
            // In a real scenario, you'd likely want to display the search results on a different view or update the Index view to show the results
            return View("Index", searchCriteria);
        }
    }
}
