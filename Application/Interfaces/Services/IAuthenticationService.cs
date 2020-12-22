using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<bool> Login(string userName, string password);
        Task Logout();
    }
}
