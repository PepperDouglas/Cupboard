﻿using Cupboard.Models.Entities;

namespace Cupboard.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);

        //For login and reading
        User ReadUser(string username);

        void UpdateUser(User user);

        void DeleteUser(User user);
    }
}