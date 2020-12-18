﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Application.Interfaces
{
    public interface IVehicleUsecase
    {
        Task<String> Register();
        Task<Boolean> Update(Status status);
        Task<Vehicle> GetVehicle(string vehicleId);
        Task<List<Status>> GetStatus(string vehicleId, DateTime from, DateTime to);
        Task<Status> GetStatus(string vehicleId);
    }
}
