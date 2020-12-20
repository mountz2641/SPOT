using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Usecases
{
    public interface IAdminUsecase
    {
        Task<String> Login();
        Task<Boolean> Logout();
    }
}
