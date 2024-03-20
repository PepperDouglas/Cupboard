using System.ComponentModel.DataAnnotations;

namespace Cupboard.Models.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Password { get; set; }

        public virtual ICollection<Recipe>? Recipes { get; set;}
    }
}
