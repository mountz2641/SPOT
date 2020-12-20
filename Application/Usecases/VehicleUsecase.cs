using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Interfaces.DAO;
using Application.Interfaces.Usecases;
using Domain.Entities;

namespace Application.Usecases
{
    public class VehicleUsecase : IVehicleUsecase
    {
        private readonly IVehicleDao _vehicleDao;

        public VehicleUsecase(IVehicleDao vehicleDao)
        {
            _vehicleDao = vehicleDao;
        }

        public Task<List<Status>> GetStatus(string vehicleId, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public Task<Status> GetStatus(string vehicleId)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> GetVehicle(string vehicleId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Register(string name)
        {
            var vehicle = new Vehicle { Name = name };
            var result = await _vehicleDao.Register(vehicle, "alskjdfhlakjsdhf"); // Test
            return result.ToString();
        }

        public Task<bool> Update(Status status)
        {
            throw new NotImplementedException();
        }
    }
}
