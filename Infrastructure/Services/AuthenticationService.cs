using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Interfaces.Services;
using Infrastructure.Persistence.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public AuthenticationService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<bool> Login(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(
                userName: userName,
                password: password,
                isPersistent: true,
                lockoutOnFailure: true
            );
            if (result.IsLockedOut)
            {
                return false;
            }
            else if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
