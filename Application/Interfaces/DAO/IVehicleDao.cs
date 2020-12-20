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
        Task<int> CreateAsync(Vehicle vehicle);
        Task<Vehicle> FindByCode(string code);
    }
}
