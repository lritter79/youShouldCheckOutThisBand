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

namespace youShouldCheckOutThisBand
{
    public class Program
    {
        private static YSCOTBContext context = new YSCOTBContext();

        //this whole prgram is just a console app with webpages
        public static void Main(string[] args)
        {
            //temporary code for setting up database
            context.Database.EnsureCreated();
            CreateWebHostBuilder(args).Build().Run();
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            /*when this console app is run, 
            build a host, create a web host and run that host*/
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
