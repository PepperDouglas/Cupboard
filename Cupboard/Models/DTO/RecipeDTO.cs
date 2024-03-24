namespace Cupboard.Models.DTO
{
    public class RecipeDTO
    {
        public int? RecipeToBeUpdatedID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IngredientsData { get; set; }
        public string Category { get; set; }
    }
}
