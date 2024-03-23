using Cupboard.Contexts;
using Cupboard.Models.Entities;
using Cupboard.Repository.Interfaces;

namespace Cupboard.Repository.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly CupboardContext _context;

        public UserRepo(CupboardContext context) {
            _context = context;
        }

        public void CreateUser(User user) {
            _context.Users.Add(user);
            _context.SaveChanges();
        }


        public User ReadUser(string username) {
            return _context.Users.SingleOrDefault(u => u.Name == username);
        }

        public User ReadUserById(int id) {
            return _context.Users.SingleOrDefault(u => u.UserID == id);
        }

        public void UpdateUser(User user) {
            var existingUser = _context.Users.SingleOrDefault(u => u.UserID ==  user.UserID);
            _context.Entry(existingUser).CurrentValues.SetValues(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user) {
            _context.Remove(user);
            _context.SaveChanges();
        }
    }
}
