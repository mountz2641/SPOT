using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Entities;

namespace Application.DTO
{
    public class StatusInputModel
    {
        public string Code { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<SensorInputModel> Sensors { get; set; }

        public static Status ToStatus(StatusInputModel status)
        {
            return new Status
            {
                Latitude = status.Latitude,
                Longitude = status.Longitude,
                Sensors = status.Sensors.ConvertAll(s => SensorInputModel.ToSensor(s))
            };
        }
    }

    public class StatusOutputModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<SensorOutputModel> Sensors { get; set; }

        public static StatusOutputModel FromStatus(Status status)
        {
            return new StatusOutputModel
            {
                Latitude = status.Latitude,
                Longitude = status.Longitude,
                Sensors = (List<SensorOutputModel>)status.Sensors.Select(s => SensorOutputModel.FromSensor(s))
            };
        }
    }
}
