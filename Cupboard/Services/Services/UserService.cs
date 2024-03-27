using Cupboard.Helpers;
using Cupboard.Models.DTO;
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

        public ResultFlag Login(UserLogin userLogin) {
            var userdb = _userRepo.ReadUser(userLogin.Username);
            ResultFlag flag = new ResultFlag(false, "Something went wrong");
      
            if (userdb == null) {
                flag.Message = "No such user";
                return flag;
            }
            if (userdb.Password != userLogin.Password) {
                flag.Message = "Incorrect password";
                
            } else if (userdb.Password ==  userLogin.Password) {
                UserLogger.UserId = userdb.UserID;
                UserLogger.IsLogged = true;

                flag.Success = true;
                
            }
            return flag;
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

        public UserSafe ReadUser(string username) {
            var userdb = _userRepo.ReadUser(username) ?? throw new Exception("No user found");
            UserSafe user = new UserSafe(
                userdb.UserID,
                userdb.Name,
                userdb.Email
            );
            return user;
        }

        public void UpdateUser(User user) {
            _userRepo.UpdateUser(user);
        }

        public void Logout() {
            UserLogger.IsLogged = false;
            UserLogger.UserId = 0;
        }
    }
}
