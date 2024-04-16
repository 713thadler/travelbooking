using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Areas.Identity.Pages.Account
{
    [Authorize] // Ensures only authenticated users can access this page
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public void OnGet()
        {
            // Intentionally left blank: the method exists to render the logout confirmation page.
        }

        public async Task<IActionResult> OnPostAsync()
        {   
            // kill the session
            
                 

            await _signInManager.SignOutAsync();  // This line signs the user out.
            _logger.LogInformation("User logged out.");
            return RedirectToPage("Login");  // Redirects the user to the login page after logout.
        }


    }
}


