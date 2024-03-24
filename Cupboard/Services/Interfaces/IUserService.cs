using Cupboard.Helpers;
using Cupboard.Models.DTO;
using Cupboard.Models.Entities;

namespace Cupboard.Services.Interfaces
{
    public interface IUserService
    {
        ResultFlag CreateUser(User user);

        //For login and reading
        UserSafe ReadUser(string username);

        void UpdateUser(User user);

        void DeleteUser(User user);

        ResultFlag Login(UserLogin userLogin);

        void Logout();
    }
}
