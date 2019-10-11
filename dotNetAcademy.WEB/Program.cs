using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using dotNetAcademy.DAL.Context;
using dotNetAcademy.DAL.Entities;
using dotNetAcademy.DAL.InitialData;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace dotNetAcademy.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var dbContext = serviceProvider.GetRequiredService<DotNetAcademyDbContext>();

                    var userManager = serviceProvider.
                        GetRequiredService<UserManager<Customer>>();

                    var roleManager = serviceProvider.
                        GetRequiredService<RoleManager<IdentityRole>>();

                    DataInitializer.SeedData
                        (userManager, roleManager,dbContext);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            host.Run();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
