﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IDateTimeService
    {
        public DateTime FromISO(string iso);
        public DateTime FromUnixMilliSecond(long ms);
    }
}
