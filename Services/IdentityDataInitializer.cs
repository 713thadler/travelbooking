using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Services
{
    public static class IdentityDataInitializer
    {
        public static async Task SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seed roles
            await SeedRoles(roleManager);

            // Seed the default admin user
            await SeedDefaultAdmin(userManager);
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            // Check if the Admin role exists, if not, create it
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            // Check if the User role exists, if not, create it
            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            // Optionally, check and create a "Staff" role
            if (!await roleManager.RoleExistsAsync("Staff"))
            {
                await roleManager.CreateAsync(new IdentityRole("Staff"));
            }
        }

        private static async Task SeedDefaultAdmin(UserManager<IdentityUser> userManager)
        {
            // Define the admin's email and password
            var adminEmail = "admin@example.com";
            var adminPassword = "Admin123!";  // Ensure this password meets the required policy

            // Check if an admin user already exists
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                // No admin user exists, create a new admin user
                adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };

                // Create the admin user with the specified password
                var createAdminResult = await userManager.CreateAsync(adminUser, adminPassword);
                if (createAdminResult.Succeeded)
                {
                    // Confirm the email immediately after creating the user
                    adminUser.EmailConfirmed = true;
                    await userManager.UpdateAsync(adminUser);

                    // Admin user created and email confirmed, now add the user to the Admin role
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
                else
                {
                    // Handle errors or log them
                    foreach (var error in createAdminResult.Errors)
                    {
                        Console.WriteLine($"Error creating admin user: {error.Description}");
                    }
                }
            }
            else if (!adminUser.EmailConfirmed)
            {
                // The admin user exists but the email is not confirmed, confirm it now
                adminUser.EmailConfirmed = true;
                await userManager.UpdateAsync(adminUser);
            }
        }

    }
}

