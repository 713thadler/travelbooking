using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using COMP2139_Assignment1_Nigar_Anar_Adler.Data;
using COMP2139_Assignment1_Nigar_Anar_Adler.Services;
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
                  webBuilder.UseStartup<Startup>();
                  // No need to call ConfigureKestrel explicitly
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
                services.AddRazorPages();

                // Ensure the connection string is provided
                var connectionString = Configuration.GetConnectionString("SQLiteConnection")
                    ?? throw new InvalidOperationException("Missing SQLite connection string.");

                services.AddDbContext<TravelBookingContext>(options =>
                    options.UseSqlite(connectionString));
                services.AddDbContext<TravelBookingUserContext>(options =>
                    options.UseSqlite(connectionString));

                // Configuring Identity
                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<TravelBookingUserContext>();

                // Email and role services
                services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
                services.AddTransient<IEmailSender, EmailSender>();
                services.AddTransient<RoleSeedService>();
                services.AddTransient<HomeController>();

                // MVC Controllers
                services.AddControllersWithViews();

                // Simple Authorization policy
                services.AddAuthorization(options =>
                {
                    options.AddPolicy("RequireAuthenticatedUser", policy => policy.RequireAuthenticatedUser());
                });
            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthentication();
                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapRazorPages();
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapAreaControllerRoute(
                        name: "identity",
                        areaName: "Identity",
                        pattern: "Identity/{controller=Account}/{action=Index}/{id?}");
                    endpoints.MapAreaControllerRoute(
                        name: "admin",
                        areaName: "Admin",
                        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");
                });

                // Seeding database with initial data
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    IdentityDataInitializer.SeedData(userManager, roleManager).GetAwaiter().GetResult();
                }
            }
        }
    }
}
