using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using youShouldCheckOutThisBand.Areas.Identity.Data;
using youShouldCheckOutThisBand.Contexts;

[assembly: HostingStartup(typeof(youShouldCheckOutThisBand.Areas.Identity.IdentityHostingStartup))]
namespace youShouldCheckOutThisBand.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<YSCOTBContext>(cfg =>
                {
                    cfg.UseSqlServer(context.Configuration.GetConnectionString("AppConnectionString"));
                });

                services.AddDefaultIdentity<IdentityUser>(options => options.User.RequireUniqueEmail = true)
                .AddEntityFrameworkStores<YSCOTBContext>();
                    
            });
        }
    }
}