using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Application.Interfaces.DAO
{
    public interface IVehicleDao
    {
        Task<string> Register(Vehicle vehicle, string code);
    }
}
