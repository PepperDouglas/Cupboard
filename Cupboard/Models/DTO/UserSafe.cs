using Cupboard.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Cupboard.Models.DTO
{
    public class UserSafe
    {
   
        public int UserID { get; set; }   
        public string Name { get; set; }    
        public string Email { get; set; }

        public UserSafe(int userID, string name, string email) {
            UserID = userID;
            Name = name;
            Email = email;
        }
    }
}
