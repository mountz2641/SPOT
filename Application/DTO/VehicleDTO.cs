using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Entities;

namespace Application.DTO
{
    public class VehicleRegisterInputModel
    {
        public string Name { get; set; }
    }
    public class VehicleWithStatusOutputModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public StatusOutputModel Status { get; set; }

        public static VehicleWithStatusOutputModel FromVehicle(Vehicle vehicle, Status status)
        {
            return new VehicleWithStatusOutputModel
            {
                Name = vehicle.Name,
                Status = StatusOutputModel.FromStatus(status)
            };
        }
    }

    public class VehicleOutputModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public static VehicleOutputModel FromVehicle(Vehicle vehicle)
        {
            return new VehicleOutputModel
            {
                Name = vehicle.Name,
            };
        }
    }
}
