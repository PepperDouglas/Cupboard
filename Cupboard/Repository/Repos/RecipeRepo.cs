using Cupboard.Contexts;
using Cupboard.Models.Entities;
using Cupboard.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cupboard.Repository.Repos
{
    public class RecipeRepo : IRecipeRepo
    {

        private readonly CupboardContext _context;

        public RecipeRepo(CupboardContext context) {
            _context = context;
        }

        public void CreateRecipe(Recipe recipe) {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public void DeleteRecipe(int recipeId) {
            var recipe = _context.Recipes.FirstOrDefault(x => x.RecipeID == recipeId);
            if (recipe != null) {
                _context.Recipes.Remove(recipe);
                _context.SaveChanges();
            }
        }

        public Recipe ReadRecipe(int recipeId) {
            return _context.Recipes.FirstOrDefault(r => r.RecipeID == recipeId);
        }

        public ICollection<Recipe> SearchRecipe(string condition) {
            return _context.Recipes.Where(r => r.Title.Contains(condition)).ToList();
        }

        public ICollection<Recipe> ReadRecipes() {
            return _context.Recipes.ToList<Recipe>();
        }

        public ICollection<Recipe> ReadRecipesWithReviews() {
            return _context.Recipes.Include(r => r.Reviews).Include(r => r.Category).ToList();
        }

        public void UpdateRecipe(Recipe recipe) {
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
            
        }
    }
}
