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

        ResultFlag UpdateRecipe(RecipeDTO recipeDto);

        //might need user id here too tbh
        //but preferable, this will be solved in the service layer imo
        //because this is ONLY a commandeering layer
        void DeleteRecipe(int recipeId);
    }
}
