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

        public static void Main(string[] args)
        {
            //temporary code for setting up database
            context.Database.EnsureCreated();
            CreateWebHostBuilder(args).Build().Run();
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
