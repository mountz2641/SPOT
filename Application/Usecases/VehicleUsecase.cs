using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces.DAO;
using Application.Interfaces.Services;
using Application.Interfaces.Usecases;
using Domain.Entities;

namespace Application.Usecases
{
    public class VehicleUsecase : IVehicleUsecase
    {
        private readonly IVehicleDao _vehicleDao;
        private readonly IVehicleCodeGenerator _vehicleCodeGenerator;
        private readonly IStatusDao _statusDao;

        public VehicleUsecase(IVehicleDao vehicleDao, IVehicleCodeGenerator vehicleCodeGenerator, IStatusDao statusDao)
        {
            _vehicleDao = vehicleDao;
            _vehicleCodeGenerator = vehicleCodeGenerator;
            _statusDao = statusDao;
        }

        public Task<List<StatusOutputModel>> GetStatus(string vehicleId, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public Task<StatusOutputModel> GetStatus(string vehicleId)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleOutputModel> GetVehicle(string vehicleId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Register(string name)
        {
            var code = await _vehicleCodeGenerator.GenerateAsync();
            var vehicle = new Vehicle { Name = name, Code = code };
            var result = await _vehicleDao.CreateAsync(vehicle);
            return code;
        }

        public async Task<bool> Update(StatusInputModel status)
        {
            var vehicle = await _vehicleDao.FindByCode(status.Code);
            var s = StatusInputModel.ToStatus(status);
            var result = await _statusDao.CreateAsync(vehicle.ID, s);
            return result > 0;
        }
    }
}
