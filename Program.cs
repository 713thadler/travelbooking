using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using COMP2139_Assignment1_Nigar_Anar_Adler.Data;
using COMP2139_Assignment1_Nigar_Anar_Adler.Services;
using Microsoft.AspNetCore.Builder;
using COMP2139_Assignment1_Nigar_Anar_Adler.Areas.Identity.Pages.Account;
using COMP2139_Assignment1_Nigar_Anar_Adler.Controllers;

namespace COMP2139_Assignment1_Nigar_Anar_Adler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    _ = webBuilder.UseStartup<Startup>();
                });

        public class Startup
        {
            public IConfiguration Configuration { get; }

            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public void ConfigureServices(IServiceCollection services)
            {
                // Configure the SQLite connection string for travel-related data
                var travelConnectionString = Configuration.GetConnectionString("SQLiteConnection");
                if (string.IsNullOrEmpty(travelConnectionString))
                {
                    throw new InvalidOperationException("The SQLite travel booking connection string is missing in the app settings.");
                }

                // Configure the SQLite connection string for user data
                var userConnectionString = Configuration.GetConnectionString("SQLiteConnection");
                if (string.IsNullOrEmpty(userConnectionString))
                {
                    throw new InvalidOperationException("The SQLite user context connection string is missing in the app settings.");
                }

                // Register DbContexts
                _ = services.AddDbContext<TravelBookingContext>(options =>
                    options.UseSqlite(travelConnectionString));

                _ = services.AddDbContext<TravelBookingUserContext>(options =>
                    options.UseSqlite(userConnectionString));

                // Identity configuration
                _ = services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<TravelBookingUserContext>();

                // Email service configuration
                _ = services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
                _ = services.AddTransient<IEmailSender, EmailSender>();
                _ = services.AddTransient<RoleSeedService>();
                _ = services.AddTransient<HomeController>();
                _ = services.AddTransient<LogoutModel>();




                // MVC and Razor Pages
                _ = services.AddControllersWithViews();
                _ = services.AddRazorPages();



                // Authorization policies
                _ = services.AddAuthorization(options =>
                {
                    options.AddPolicy("RequireAuthenticatedUser", policy =>
                        policy.RequireAuthenticatedUser());
                });
            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    _ = app.UseDeveloperExceptionPage();
                }
                else
                {
                    _ = app.UseExceptionHandler("/Home/Error");
                }

                _ = app.UseStaticFiles();
                _ = app.UseRouting();
                _ = app.UseAuthentication();
                _ = app.UseAuthorization();

                _ = app.UseEndpoints(endpoints =>
                {
                    _ = endpoints.MapAreaControllerRoute(
                        name: "admin_area",
                        areaName: "Admin",
                        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

                    _ = endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");

                    _ = endpoints.MapRazorPages();

                    // Define the route for the Logout page
                    _ = endpoints.MapPost("/Account/Logout", async context =>
                    {
                        var logoutModel = context.RequestServices.GetService<LogoutModel>();
                        _ = await logoutModel.OnPostAsync();


                    });
                    app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{area:exists}/{controller=Identity}/{action?}/{id?}");
    endpoints.MapRazorPages();
});

                });
            }
        }
    }
}
