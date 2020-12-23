using Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class DbHealthChecker : IDbHealthChecker
    {
        private readonly AppDbContext _context;
        public DbHealthChecker(AppDbContext context)
        {
            _context = context;
        }
        public bool IsConnected()
        {
            try
            {
                return _context.Database.CanConnect();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
