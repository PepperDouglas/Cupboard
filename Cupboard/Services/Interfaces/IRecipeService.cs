using Cupboard.Helpers;
using Cupboard.Models.DTO;
using Cupboard.Models.Entities;

namespace Cupboard.Services.Interfaces
{
    public interface IRecipeService
    {
        ResultFlag CreateRecipe(RecipeDTO recipeDto);

        Recipe ReadRecipe(int recipeId);

        public ICollection<Recipe> ReadRecipes();

        public ICollection<Recipe> SearchRecipe(string condition);

        public ICollection<RecipeAvgDTO> GetRecipesWithReviews();

        ResultFlag UpdateRecipe(RecipeDTO recipeDto);

        void DeleteRecipe(int recipeId);
    }
}
