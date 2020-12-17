using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    class Vehicle
    {
        public string Name { get; set; }
        public List<Status> Statuses { get; set; }
    }
}
