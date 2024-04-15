using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Areas.Identity.Pages.Account
{
    [Authorize] // Ensures only authenticated users can access this method
    public class LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger) : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager = signInManager;
        private readonly ILogger<LogoutModel> _logger = logger;

        public async Task<IActionResult> OnPostAsync()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToPage("/Index");  // Redirecting to home page after logout
        }

        // write the logic for Model.ShowLogoutPrompt
        public bool ShowLogoutPrompt { get; set; }
        // model.ReturnUrl to go back to the page where the user was before logging out
        public string ReturnUrl { get; set; }

        public void OnGet(string? returnUrl = null)
        {
            ShowLogoutPrompt = false;
            if (returnUrl != null)
            {
                ShowLogoutPrompt = true;
                ReturnUrl = returnUrl;
            }
        }

    }
}

