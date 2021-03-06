﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Accoon.BuildingBlocks.Common.Infastructure;
using Accoon.CQRSCLApi.Domain.Entities;
using Accoon.CQRSCLApi.Persistence;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Accoon.CQRSCAApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // get configurations
            var configuration = GetConfiguration();

            // get builded host
            var host = BuildWebHost(configuration, args);

            //// run migrations using extension method
            host.MigrateDbContext<CqrscaDbContext>((context, services) =>
            {
                context.Customers.Add(new Customer()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sandun",
                    Age = 27
                });

                if (!context.Customers.Any())
                {
                    context.SaveChanges();
                }

            });

            host.Run();
        }


        // get config settings and values
        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            var config = builder.Build();
            return builder.Build();
        }

        // get web host and build
        private static IWebHost BuildWebHost(IConfiguration configuration, string[] args) =>
              WebHost.CreateDefaultBuilder(args)
                  .CaptureStartupErrors(false)
                  .UseStartup<Startup>()
                 .UseContentRoot(Directory.GetCurrentDirectory())
                  .UseConfiguration(configuration)
                 .Build();
    }


}
