using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Interfaces.DAO;
using Domain.Entities;
using Infrastructure.Persistence.Models;

namespace Infrastructure.Persistence.DAO
{
    public class VehicleDao : IVehicleDao
    {
        private readonly DataContext _context;
        public VehicleDao(DataContext context)
        {
            _context = context;
        }
        public async Task<string> Register(Vehicle vehicle, string code)
        {
            var result = await _context.Vehicles.AddAsync(new VehicleModel { Name = vehicle.Name, Code = code });
            await _context.SaveChangesAsync();
            return result.Entity.Code;
        }
    }
}
