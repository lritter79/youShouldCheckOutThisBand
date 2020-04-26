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
using Newtonsoft.Json;
using youShouldCheckOutThisBand.Models;
using AutoMapper;
using System.Reflection;
using youShouldCheckOutThisBand.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.IdentityModel.Tokens;

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
            //identity roll is incase we're configuring roles, it can be a type of data that's about a user
            services.AddIdentity<AppUser, IdentityRole>(cfg => 
            {
                //let's you set rules for user logins and such
                cfg.User.RequireUniqueEmail = true;
            })
                //maps the users to our contexts
                .AddEntityFrameworkStores<YSCOTBContext>();

            //configure the tokens we want to use
            services.AddAuthentication()
                .AddCookie()
                //tell start up to use our json token
                .AddJwtBearer(cfg =>
                {
                    //params that need to be used to validate th etoken we sent in
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = _config["Tokens:Issuer"],
                        ValidAudience = _config["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]))
                    };
                });

            //make db context part of services collection so we can inject it where we need it
            services.AddDbContext<YSCOTBContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("AppConnectionString"));
            });

            //makes it so that appseeder can be created through the service layer
            services.AddTransient<YSCOTBSeeder>();

            //add IYSCOTBRepository as a service
            //but use YSCOTBRepository as the implementation
            services.AddScoped<IYSCOTBRepository, YSCOTBRepository>();

            services.AddScoped<SpotifyToken>();

            services.AddScoped<ISpotifyApiRepository, SpotifyApiRepository>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddControllersWithViews();

            //this tell automapper to look for prfiles for mapping that we need
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(options =>
                {
                    //this is to get rid of self referencing loops that can happen with ef core because of object nestings
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });



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

            //.UseCookiePolicy();

            app.UseStaticFiles();

            //must be called before routing and endpoints
            //authentication is about identifying the user
            app.UseAuthentication();
            

            //turns on generic routing to find indivual views and controllers
            app.UseRouting();

            //authorization is about what they have access to
            app.UseAuthorization();

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
