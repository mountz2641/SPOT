using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Entities;

namespace WebApi.Models
{
    public class StatusDTO
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<SensorDTO> Sensors { get; set; }

        public static StatusDTO FromStatus(Status status)
        {
            return new StatusDTO()
            {
                Latitude = status.Latitude,
                Longitude = status.Longitude,
                Sensors = (List<SensorDTO>)status.Sensors.Select(s => SensorDTO.FromSensor(s))
            };
        }
    }
}
