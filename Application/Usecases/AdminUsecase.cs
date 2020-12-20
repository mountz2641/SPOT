using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Interfaces.Usecases;

namespace Application.Usecases
{
    public class AdminUsecase : IAdminUsecase
    {
        public Task<string> Login()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }
    }
}
