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

        public DateTime FromUnixMilliSecond(long ms)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(ms).ToLocalTime();
            return dtDateTime;
        }

        public long ToUnixMilliSecond(DateTime dt)
        {
            TimeSpan timeSpan = dt - new DateTime(1970, 1, 1, 0, 0, 0);

            return (long)timeSpan.TotalSeconds;
        }
    }
}
