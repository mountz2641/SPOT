﻿using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class DateTimeService : IDatetimeService
    {
        public DateTime FromISO (string s)
        {
            _ = DateTime.TryParse(s, out DateTime dt);
            return dt;
        }
    }
}
