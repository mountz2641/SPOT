using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using DM = Domain.Entities;
using PM = Infrastructure.Persistence.Models;
using Application.Interfaces.Repository;

namespace Infrastructure.Persistence.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext _context;
        public StatusRepository(AppDbContext context)
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

        public async Task<DM.Status> GetLatest(int vehicleId)
        {
            var result = await _context.Status.Where(x => x.VehicleID == vehicleId)
                            .OrderByDescending(x => x.Time).SingleOrDefaultAsync();
            var status = new DM.Status
            {
                ID = result.ID,
                Time = result.Time,
                Latitude = result.Latitude,
                Longitude = result.Longitude,
                Sensors = result.Sensors.ConvertAll(s => new DM.Sensor { ID = s.ID, Name = s.Name, Value = s.Value })
            };
            return status;
        }

        public async Task<List<DM.Status>> GetRange(int vehicleId, long from, long to)
        {
            var result = await _context.Status.Where(x => x.VehicleID == vehicleId && x.Time >= from && x.Time <= to)
                            .OrderBy(x => x.Time).ToListAsync();
            var status = result.ConvertAll(s => new DM.Status
            {
                ID = s.ID,
                Time = s.Time,
                Latitude = s.Latitude,
                Longitude = s.Longitude,
                Sensors = s.Sensors.ConvertAll(z => new DM.Sensor { ID = z.ID, Name = z.Name, Value = z.Value })
            });
            return status;
        }
    }
}
