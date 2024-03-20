using System.ComponentModel.DataAnnotations;

namespace Cupboard.Models.Entities
{
    public class Recipe {
        [Key]
        public int RecipeID { get; set; }
        [StringLength(20)]
        public string Title { get; set; }
        [StringLength(400)]
        public string Description { get; set; }
        //just as a delimited string
        public string IngredientsData { get; set; }

        //why not just make it correctly?
        public int? CategoryID { get; set; }
        public int? UserID { get; set; }
        public virtual Category Category { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Review>? Reviews { get; set; }
    }
}
