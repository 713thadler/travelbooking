using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using COMP2139_Assignment1_Nigar_Anar_Adler.Data;

namespace COMP2139_Assignment1_Nigar_Anar_Adler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // This will build and run the web application
            CreateHostBuilder(args).Build().Run();
        }

        // Sets up a host for the web application with pre-configured defaults
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Specifies the Startup class that should be used by the web host
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class Startup
    {
        public IConfiguration Configuration { get; }

        // Constructor to initialize the configuration that reads from appsettings.json by default
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Adds services to the application's DI container
        public void ConfigureServices(IServiceCollection services)
        {
            // This uses the SQLite connection string from appsettings.json
            services.AddDbContext<TravelBookingContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("SQLiteConnection")));

            services.AddControllersWithViews();
        }


        // Sets up the application's request processing pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Provides detailed error information in development
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // A generic error handler for non-development environments
                app.UseExceptionHandler("/Home/Error");
                // Enforces the use of HTTPS
                app.UseHsts();
            }

            // Redirects all HTTP requests to HTTPS
            app.UseHttpsRedirection();
            // Serves static files (such as images, CSS, JavaScript files)
            app.UseStaticFiles();

            // Adds endpoint routing to the middleware pipeline
            app.UseRouting();

            // Adds authorization middleware to the pipeline
            app.UseAuthorization();

            // Configures the endpoints for the application
            app.UseEndpoints(endpoints =>
            {
                // Area routing for the admin area
                endpoints.MapAreaControllerRoute(
                    name: "admin_area",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

                // Default routing for non-area controllers
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
