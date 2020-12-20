using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

using Application.Interfaces.Usecases;
using Application.Interfaces.DAO;
using Application.Interfaces.Services;
using Application.Usecases;
using Infrastructure.Persistence;
using Infrastructure.Persistence.DAO;
using Infrastructure.Services;


namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("MySQLConnection");
            services.AddDbContextPool<AppDbContext>(
                dbContextOption => dbContextOption.UseMySql(
                    connectionString,
                    mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)
                )
            );

            services.AddScoped<IVehicleUsecase, VehicleUsecase>();
            services.AddScoped<IVehicleDao, VehicleDao>();
            services.AddScoped<IStatusDao, StatusDao>();
            services.AddSingleton<IDateTimeService, DateTimeService>();
            services.AddSingleton<IVehicleCodeGenerator, VehicleCodeGenerator>();
            services.AddSingleton<ISecureRandomizer, RngSecureRandomizer>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
