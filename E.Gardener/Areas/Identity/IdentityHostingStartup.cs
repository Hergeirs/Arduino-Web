using System;
using E.Gardener.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Concrete;

[assembly: HostingStartup(typeof(E.Gardener.Areas.Identity.IdentityHostingStartup))]
namespace E.Gardener.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EGardenerContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EGardenerContextConnection")));

//                services.AddDefaultIdentity<IdentityUser>()
//                    .AddEntityFrameworkStores<EGardenerContext>();
            });
        }
    }
}