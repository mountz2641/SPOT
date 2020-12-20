using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Models
{
    public class Sensor
    {
        public int ID { get; set; }
        public int StatusID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
