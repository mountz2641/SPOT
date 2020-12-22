using Application.DTO;
using Application.Interfaces.Usecases;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserUsecase _userUsecase;

        public UserController(IUserUsecase userUsecase)
        {
            _userUsecase = userUsecase;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            
            var result = await _userUsecase.Login(loginModel);
            if(result)
            {
                return Ok();
            } else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userUsecase.Logout();
            return Ok();
        }
    }
}
