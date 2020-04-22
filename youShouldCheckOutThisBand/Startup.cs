using youShouldCheckOutThisBand.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using youShouldCheckOutThisBand.Data;

namespace youShouldCheckOutThisBand
{
    public class Startup
    {
        private readonly IConfiguration _config;

        //set up configuration
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //make db context part of services collection so we can inject it where we need it
            services.AddDbContext<YSCOTBContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("AppConnectionString"));
            });

            //makes it so that appseeder can be created through the service layer
            services.AddTransient<YSCOTBSeeder>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddControllersWithViews();
           // _ = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //environemn variables in properties determine environment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");              
            }

            app.UseNodeModules();

            app.UseCookiePolicy();

            app.UseStaticFiles();

            //turns on generic routing to find indivual views and controllers
            app.UseRouting();

            //end points allows a bunch of different technogoies to use different end points
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    //pattern to look for to tell the system to find a controller
                    pattern: "{controller}/{action}/{id?}",
                    //anonymous objects with defaults if pattern isnt specified
                    new { controller = "App", action = "Index" });
              
            });
        }
    }
}
