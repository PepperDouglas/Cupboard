using System.ComponentModel.DataAnnotations;

namespace Cupboard.Models.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Recipe>? Recipes { get; set; }
    }
}
