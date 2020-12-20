using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Application.Interfaces.DAO;
using Domain.Entities;
using DM = Domain.Entities; // domain model
using PM = Infrastructure.Persistence.Models; // persistence model

namespace Infrastructure.Persistence.DAO
{
    public class VehicleDao : IVehicleDao
    {
        private readonly AppDbContext _context;
        public VehicleDao(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(DM.Vehicle vehicle)
        {
            var result = await _context.Vehicles.AddAsync(new PM.Vehicle { Name = vehicle.Name, Code = vehicle.Code });
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
    }
}
