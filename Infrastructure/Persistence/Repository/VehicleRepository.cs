using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using DM = Domain.Entities;
using PM = Infrastructure.Persistence.Models;
using Application.Interfaces.Repository;

namespace Infrastructure.Persistence.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _context;
        public VehicleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(Vehicle vehicle)
        {
            var newVehicle = new PM.Vehicle { Name = vehicle.Name, Code = vehicle.Code };
            var result = await _context.Vehicles.AddAsync(newVehicle);
            await _context.SaveChangesAsync();
            return result.Entity.ID;
        }

        public async Task<Vehicle> FindByCode(string code)
        {
            var result = await _context.Vehicles.Where(x => x.Code == code).SingleOrDefaultAsync();
            var vehicle = new Vehicle
            {
                ID = result.ID,
                Code = result.Code,
                Name = result.Name
            };
            return vehicle;
        }

        public async Task<Vehicle> FindByID(int id)
        {
            var result = await _context.Vehicles.Where(x => x.ID == id).SingleOrDefaultAsync();
            var vehicle = new Vehicle
            {
                ID = result.ID,
                Code = result.Code,
                Name = result.Name
            };
            return vehicle;
        }

        public async Task<List<Vehicle>> GetVehicles(int offset, int limit)
        {
            var result = await _context.Vehicles.Skip(offset).Take(limit).ToListAsync();
            var vehicles = result.ConvertAll(x =>
                new Vehicle
                {
                    ID = x.ID,
                    Code = x.Code,
                    Name = x.Name
                }
            );
            return vehicles;
        }
    }
}
