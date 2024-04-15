using System;
using COMP2139_Assignment1_Nigar_Anar_Adler.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(COMP2139_Assignment1_Nigar_Anar_Adler.Areas.Identity.IdentityHostingStartup))]
namespace COMP2139_Assignment1_Nigar_Anar_Adler.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
