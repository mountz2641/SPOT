using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces.Repository;
using Application.Interfaces.Services;
using Application.Interfaces.Usecases;
using Domain.Entities;

namespace Application.Usecases
{
    public class VehicleUsecase : IVehicleUsecase
    {
        private readonly IVehicleRepository _vehicleDao;
        private readonly IVehicleCodeGenerator _vehicleCodeGenerator;
        private readonly IStatusRepository _statusDao;

        public VehicleUsecase(IVehicleRepository vehicleDao, IVehicleCodeGenerator vehicleCodeGenerator, IStatusRepository statusDao)
        {
            _vehicleDao = vehicleDao;
            _vehicleCodeGenerator = vehicleCodeGenerator;
            _statusDao = statusDao;
        }

        public async Task<List<StatusOutputModel>> GetStatus(int vehicleId, DateTime from, DateTime to)
        {
            var newFrom = new DateTimeOffset(from).ToUnixTimeMilliseconds();
            var newTo = new DateTimeOffset(to).ToUnixTimeMilliseconds();
            var result = await _statusDao.GetRange(vehicleId, newFrom, newTo);
            return result.ConvertAll(r => StatusOutputModel.FromStatus(r));
        }

        public async Task<StatusOutputModel> GetStatus(int vehicleId)
        {
            var result = await _statusDao.GetLatest(vehicleId);
            return StatusOutputModel.FromStatus(result);
        }

        public async Task<VehicleWithStatusOutputModel> GetVehicle(int vehicleId)
        {
            var result = await _vehicleDao.FindByID(vehicleId);
            var status = await _statusDao.GetLatest(vehicleId);
            return VehicleWithStatusOutputModel.FromVehicle(result, status);
        }

        public async Task<List<VehicleOutputModel>> GetVehicles(int offset, int limit)
        {
            var result = await _vehicleDao.GetVehicles(offset, limit);
            return result.ConvertAll(x => VehicleOutputModel.FromVehicle(x));
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
