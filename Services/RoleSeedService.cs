using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace COMP2139_Assignment1_Nigar_Anar_Adler.Services
{
    public class RoleSeedService
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "Staff", "User" };

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    var role = new IdentityRole { Name = roleName };
                    var result = await roleManager.CreateAsync(role);

                    if (!result.Succeeded)
                    {
                        throw new Exception($"Failed to create role '{roleName}'.");
                    }
                }
            }
        }
    }
}
