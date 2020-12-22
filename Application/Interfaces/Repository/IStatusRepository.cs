using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IStatusRepository
    {
        Task<int> CreateAsync(int vehicleId, Status status);
        Task<Status> GetLatest(int vehicleId);
        Task<List<Status>> GetRange(int vehicleId, long from, long to);
    }
}
