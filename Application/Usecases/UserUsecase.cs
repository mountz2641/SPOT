using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Application.DTO;
using Application.Interfaces.Services;
using Application.Interfaces.Usecases;
using Domain.Entities;

namespace Application.Usecases
{
    public class UserUsecase : IUserUsecase
    {
        private readonly IAuthenticationService _authenticationService;

        public UserUsecase(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<bool> Login(LoginModel loginModel)
        {
            var result = await _authenticationService.Login(loginModel.UserName, loginModel.Password);
            
            return result;
        }

        public async Task Logout()
        {
            await _authenticationService.Logout();
        }
    }
}
