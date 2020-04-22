using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using youShouldCheckOutThisBand.Contexts;
using youShouldCheckOutThisBand.Data;
using Microsoft.Extensions.DependencyInjection;

namespace youShouldCheckOutThisBand
{
    public class Program
    {
        

        //this whole prgram is just a console app with webpages
        public static void Main(string[] args)
        {
            //temporary code for setting up database
            //context.Database.EnsureCreated();
            //BuildWebHost(args).Run();
            var host = BuildWebHost(args);

            //only happens on the start of every web server creation
            RunSeeding(host);

            host.Run();


        }

        private static void RunSeeding(IWebHost host)
        {
            //services object was set up
            //contains scoped dependencies so we need a scope factory
            //this is a way outside a web server to create a scope
            //creates a scope through a request
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<YSCOTBSeeder>();
                seeder.Seed();
            }           

        }

        //public static IWebHostBuilder BuildWebHost(string[] args) =>

        //    WebHost.CreateDefaultBuilder(args)
        //    //set up configuration manually
        //        .ConfigureAppConfiguration(SetupConfiguration)
        //        .UseStartup<Startup>()
        //        .Build();

        public static IWebHost BuildWebHost(string[] args) =>
        /*when this console app is run, 
        build a host, create a web host and run that host*/
        WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(SetupConfiguration)
            .UseStartup<Startup>()
            .Build();

        private static void SetupConfiguration (WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            //removing default configuration options
            builder.Sources.Clear();



            //mix files into single set of configurations
            //the order in which these "add" funcs are called is the heirarchy
            //goes from first to last
            //tell the system we require a file called config.json
            //the file is required
            //reload on change = true
            builder.AddJsonFile("config.json", false, true)
                .AddXmlFile("config.xml", true)
                //AddEnvironmentVariables() lets you set things for deployment
                //this allows productions to change variables without storing secret variables in the config
                .AddEnvironmentVariables();
        }
    }
}
