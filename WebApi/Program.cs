using Application.Interfaces.Services;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            using (var scope = host.Services.CreateScope())
            {
                WaitForDb(scope.ServiceProvider);
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();

                var dataSeeder = scope.ServiceProvider.GetService<Initializer>();
                await dataSeeder.Initialize();
            }
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void WaitForDb(IServiceProvider service)
        {
            var checker = service.GetService<IDbHealthChecker>();
            var maxAttemps = 10;
            var delay = 5000;

            for (int i = 0; i < maxAttemps; i++)
            {
                Console.Write("Try Connecting DB {0}...", i);
                if (checker.IsConnected())
                {
                    Console.WriteLine("DB Connected");
                    return;
                }
                Console.WriteLine("Connection Failed");
                Thread.Sleep(delay);
            }
            throw new Exception("Can't Access Database");
        }
    }
}
