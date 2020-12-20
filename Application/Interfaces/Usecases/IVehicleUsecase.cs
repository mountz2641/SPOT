using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Usecases
{
    public interface IVehicleUsecase
    {
        Task<string> Register(string name);
        Task<bool> Update(StatusInputModel status);
        Task<VehicleWithStatusOutputModel> GetVehicle(int vehicleId);
        Task<List<StatusOutputModel>> GetStatus(int vehicleId, DateTime from, DateTime to);
        Task<StatusOutputModel> GetStatus(int vehicleId);
    }
}
