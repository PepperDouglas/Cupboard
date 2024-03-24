using System.ComponentModel.DataAnnotations;

namespace Cupboard.Models.Entities
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public int Grade { get; set; }

        public int? UserID { get; set; }
        public int? RecipeID { get; set; }
        public virtual User User { get; set; }
        public virtual Recipe Recipe { get; set; }

        public Review(int grade, int? userID, int? recipeID) {
            Grade = grade;
            UserID = userID;
            RecipeID = recipeID;
        }
    }
}
