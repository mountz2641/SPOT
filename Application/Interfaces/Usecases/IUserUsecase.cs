﻿using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Usecases
{
    public interface IUserUsecase
    {
        Task<bool> Login(LoginModel loginModel);
        Task Logout();
    }
}
