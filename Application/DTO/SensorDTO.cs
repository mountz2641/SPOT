using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Entities;

namespace Application.DTO
{
    public class SensorInputModel
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public static Sensor ToSensor(SensorInputModel sensor)
        {
            return new Sensor
            {
                Name = sensor.Name,
                Value = sensor.Value
            };
        }
    }

    public class SensorOutputModel
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public static SensorOutputModel FromSensor(Sensor sensor)
        {
            return new SensorOutputModel
            {
                Name = sensor.Name,
                Value = sensor.Value
            };
        }
    }
}
