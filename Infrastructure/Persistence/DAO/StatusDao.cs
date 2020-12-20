using Application.Interfaces.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DM = Domain.Entities;
using PM = Infrastructure.Persistence.Models;

namespace Infrastructure.Persistence.DAO
{
    public class StatusDao : IStatusDao
    {
        private readonly AppDbContext _context;
        public StatusDao(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(int vehicleId, DM.Status status)
        {
            var newStatus = new PM.Status
            {
                VehicleID = vehicleId,
                Latitude = status.Latitude,
                Longitude = status.Longitude,
                Time = status.Time,
                Sensors = status.Sensors.ConvertAll(s => new PM.Sensor { Name = s.Name, Value = s.Value })
            };
            var result = await _context.Status.AddAsync(newStatus);
            await _context.SaveChangesAsync();
            return result.Entity.ID;
        }
    }
}
