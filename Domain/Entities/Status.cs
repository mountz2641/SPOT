using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Status
    {
        public long Time { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Sensor> Sensors { get; set; }
    }
}
