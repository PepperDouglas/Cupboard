using Cupboard.Models.Entities;

namespace Cupboard.Repository.Interfaces
{
    public interface IUserRepo
    {

        void CreateUser(User user);
        
        User ReadUser(string username);

        public User ReadUserById(int id);

        void UpdateUser(User user);

        void DeleteUser(User user);


    }
}