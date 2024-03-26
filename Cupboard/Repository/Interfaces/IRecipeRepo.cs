using Cupboard.Models.Entities;

namespace Cupboard.Repository.Interfaces
{
    public interface IRecipeRepo
    {
        void CreateRecipe(Recipe recipe);

        Recipe ReadRecipe(int recipeId);

        public ICollection<Recipe> ReadRecipes();

        public ICollection<Recipe> SearchRecipe(string condition);

        public ICollection<Recipe> ReadRecipesWithReviews();

        void UpdateRecipe(Recipe recipe);

        void DeleteRecipe(int recipeId);
    }
}
