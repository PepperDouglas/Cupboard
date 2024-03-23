using Cupboard.Helpers;
using Cupboard.Models.Entities;
using Cupboard.Repository.Interfaces;
using Cupboard.Services.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cupboard.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo) {
            _userRepo = userRepo;
        }

        public ResultFlag CreateUser(User user) {
            var nameExists = _userRepo.ReadUser(user.Name);
            ResultFlag result = new ResultFlag();
            if (nameExists == null) {
                _userRepo.CreateUser(user);
                result.Success = true;
            } else {
                result.Success = false;
                result.Message = "Username is already taken";
            }
            return result;
        }

        public void DeleteUser(User user) {
            _userRepo.DeleteUser(user);
        }

        public User ReadUser(string username) {
            return _userRepo.ReadUser(username);
        }

        public void UpdateUser(User user) {
            _userRepo.UpdateUser(user);
        }
    }
}
