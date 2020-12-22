using Infrastructure.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class Initializer
    {
        private readonly AppDbContext _appDbContext;
        public Initializer(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Initialize()
        {
            // Seed Role
            Role[] roles = (Role[])Enum.GetValues(typeof(Role));
            foreach (var role in roles)
            {
                var identityRole = new IdentityRole(role.GetRoleName());

                var roleStore = new RoleStore<IdentityRole>(_appDbContext);

                if (!_appDbContext.Roles.Any(r => r.Name == role.GetRoleName()))
                {
                    roleStore.CreateAsync(new IdentityRole(role.GetRoleName())
                    {
                        NormalizedName = role.GetRoleName().ToUpper()
                    });
                }
            }
            
            // Seed User
            var user = new AppUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };

            if (!_appDbContext.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "secretpassword");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(_appDbContext);
                var result = userStore.CreateAsync(user);
                userStore.AddToRoleAsync(user, Role.Admin.ToString().ToUpper());
            }

            //Seed Vehicle

            var seedVehicles = new Vehicle[] {
                new Vehicle { Name = "A", Code = "xsbdtMg4Tn_8gDadSzu0SG-ywlZpW1FP5saA6HAxumE=" },
                new Vehicle { Name = "B", Code = "pam3_aYivlj7wBOePvIi217ebIVrrgnoVDPQM27sFow=" },
                new Vehicle { Name = "C", Code = "No7H531QEvhAnvJKNYW_TfiodFn1ozV0wk5JtNr3Huw=" },
                new Vehicle { Name = "D", Code = "5mMiPIRcb4_0KnvtwQ8tN2zem8v42IWF-qPuG7xQ_YA=" },
            };

            foreach (var vehicle in seedVehicles)
            {
                if (!_appDbContext.Vehicles.Any(v => v.Name == vehicle.Name))
                {
                    _appDbContext.Vehicles.Add(vehicle);
                }
            }

            //Seed Status
            var seedStatus = new Status[] {
                new Status { VehicleID = 1, Time = 0,
                    Latitude = 13.0, Longitude = 100.0,
                    Sensors = new List<Sensor> { 
                        new Sensor { Name = "", Value = "" } 
                    } 
                },
                new Status { VehicleID = 1, Time = 0,
                    Latitude = 13.0, Longitude = 100.0,
                    Sensors = new List<Sensor> { 
                        new Sensor { Name = "", Value = "" } 
                    } 
                },
                new Status { VehicleID = 1, Time = 0,
                    Latitude = 13.0, Longitude = 100.0,
                    Sensors = new List<Sensor> { 
                        new Sensor { Name = "", Value = "" } 
                    } 
                },
                new Status { VehicleID = 2, Time = 0,
                    Latitude = 13.0, Longitude = 100.0,
                    Sensors = new List<Sensor> { 
                        new Sensor { Name = "", Value = "" } 
                    } 
                },
                new Status { VehicleID = 2, Time = 0,
                    Latitude = 13.0, Longitude = 100.0,
                    Sensors = new List<Sensor> { 
                        new Sensor { Name = "", Value = "" } 
                    } 
                },
                new Status { VehicleID = 2, Time = 0,
                    Latitude = 13.0, Longitude = 100.0,
                    Sensors = new List<Sensor> { 
                        new Sensor { Name = "", Value = "" } 
                    } 
                },
                new Status { VehicleID = 3, Time = 0,
                    Latitude = 13.0, Longitude = 100.0,
                    Sensors = new List<Sensor> { 
                        new Sensor { Name = "", Value = "" } 
                    } 
                },
                new Status { VehicleID = 3, Time = 0,
                    Latitude = 13.0, Longitude = 100.0,
                    Sensors = new List<Sensor> { 
                        new Sensor { Name = "", Value = "" } 
                    } 
                },
                new Status { VehicleID = 4, Time = 0,
                    Latitude = 13.0, Longitude = 100.0,
                    Sensors = new List<Sensor> { 
                        new Sensor { Name = "", Value = "" } 
                    } 
                },
            };
            _appDbContext.SaveChanges();
        }
    }
}
