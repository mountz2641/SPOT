using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Application.Interfaces.Repository
{
    public interface IVehicleRepository
    {
        Task<int> CreateAsync(Vehicle vehicle);
        Task<Vehicle> FindByCode(string code);
        Task<Vehicle> FindByID(int id);
        Task<List<Vehicle>> GetVehicles(int offset, int limit);
    }
}
