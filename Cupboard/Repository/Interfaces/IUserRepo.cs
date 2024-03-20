﻿using Cupboard.Models.Entities;

namespace Cupboard.Repository.Interfaces
{
    public interface IUserRepo
    {

        void CreateUser(User user);
        
        //For login and reading
        User ReadUser(string username);

        void UpdateUser(User user);

        void DeleteUser(User user);


    }
}