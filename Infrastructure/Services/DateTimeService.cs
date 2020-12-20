using Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime FromISO (string s)
        {
            DateTime.TryParse(s, out var dt);
            return dt;
        }
    }
}
