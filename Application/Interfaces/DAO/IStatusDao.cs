using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.DAO
{
    public interface IStatusDao
    {
        Task<int> CreateAsync(int vehicleId, Status status);
        Task<Status> GetLatest(int vehicleId);
        Task<List<Status>> GetRange(int vehicleId, long from, long to);
    }
}
