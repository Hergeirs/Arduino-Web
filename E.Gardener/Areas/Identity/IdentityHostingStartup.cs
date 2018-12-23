﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Concrete;
using Repository.Models;

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

                services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<EGardenerContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders()
                    ;

            });
        }
    }
}