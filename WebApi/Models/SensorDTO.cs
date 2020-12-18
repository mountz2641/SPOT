using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Entities;

namespace WebApi.Models
{
    public class SensorDTO
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public static SensorDTO FromSensor(Sensor sensor)
        {
            return new SensorDTO()
            {
                Name = sensor.Name,
                Value = sensor.Value
            };
        }
    }
}
