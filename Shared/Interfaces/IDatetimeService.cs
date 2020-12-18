using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IDatetimeService
    {
        public DateTime FromISO(string s);
    }
}
