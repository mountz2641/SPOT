using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Interfaces.DAO;
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
        public async Task<string> Register(DM.Vehicle vehicle, string code)
        {
            var result = await _context.Vehicles.AddAsync(new PM.Vehicle { Name = vehicle.Name, Code = code });
            await _context.SaveChangesAsync();
            return result.Entity.Code;
        }
    }
}
