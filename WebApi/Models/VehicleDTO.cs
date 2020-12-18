using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace WebApi.Models
{
    public class VehicleDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public StatusDTO Status { get; set; }

        public static VehicleDTO FromVehicle(Vehicle vehicle, Status status)
        {
            return new VehicleDTO()
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                Status = StatusDTO.FromStatus(status)
            };
        }
    }
}
