using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OOP_CA_MACINTOSH.Areas.Identity.Data;
using OOP_CA_MACINTOSH.Data;

[assembly: HostingStartup(typeof(OOP_CA_MACINTOSH.Areas.Identity.IdentityHostingStartup))]
namespace OOP_CA_MACINTOSH.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    }
                )
                    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}