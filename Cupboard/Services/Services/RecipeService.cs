using Cupboard.Helpers;
using Cupboard.Models.DTO;
using Cupboard.Models.Entities;
using Cupboard.Repository.Interfaces;
using Cupboard.Repository.Repos;
using Cupboard.Services.Interfaces;

namespace Cupboard.Services.Services
{
    public class RecipeService : IRecipeService
    {

        public readonly IRecipeRepo _recipeRepo;
        public readonly ICategoryRepo _categoryRepo;

        public RecipeService(IRecipeRepo recipeRepo, ICategoryRepo categoryRepo) {
            _recipeRepo = recipeRepo;
            _categoryRepo = categoryRepo;
        }

        public ResultFlag CreateRecipe(RecipeDTO recipeDto) {
            ResultFlag flag = new ResultFlag(false, "Something went wrong");
            //see if logged in
            if (UserLogger.IsLogged == false) {
                flag.Message = "No user logged in";
                return flag;
            }
            //see if category is correct, see Update version for better practice
            var validCategories = _categoryRepo.GetCategories();
            bool foundCat = false;
            int foundCatInt = 0;
            if (validCategories == null) {
                flag.Message = "Contact admin";
                return flag;
            } else {
                foreach ( var category in validCategories ) {
                    if ( category.Name.ToLower() == recipeDto.Category.ToLower() ) { 
                        foundCat = true;
                        foundCatInt = category.CategoryID;
                    }
                }
            }
            //dto that bad boy
            Recipe recipe = new Recipe();
            if ( foundCat ) {
                recipe.Title = recipeDto.Title;
                recipe.Description = recipeDto.Description;
                recipe.IngredientsData = recipeDto.IngredientsData;
                recipe.CategoryID = foundCatInt;
                recipe.UserID = UserLogger.UserId;
            } else {
                flag.Message = "No such category";
                return flag;
            }
            //send it
            try {
                _recipeRepo.CreateRecipe(recipe);
                flag.Message = "Success!";
                flag.Success = true;
                return flag;
            }
            catch (Exception ex) {
                flag.Message = ex.Message;
                return flag;
            }
        }

        public void DeleteRecipe(int recipeId) {
            var recipe = _recipeRepo.ReadRecipe(recipeId) ?? throw new Exception("Recipe not found");
            if ( recipe.UserID !=  UserLogger.UserId ) {
                throw new Exception("You cannot remove this recipe");
            }
            _recipeRepo.DeleteRecipe(recipeId);
        }

        public Recipe ReadRecipe(int recipeId) {
            return _recipeRepo.ReadRecipe(recipeId);
        }

        public ICollection<Recipe> ReadRecipes() {
            return _recipeRepo.ReadRecipes();
        }

        public ICollection<Recipe> SearchRecipe(string condition) {
            var recipes = _recipeRepo.SearchRecipe(condition);
            if (recipes.Count != 0) {
                return recipes;
            }
            throw new Exception("No matching results");
        }

        public ResultFlag UpdateRecipe(RecipeDTO recipeDto) {
            //see if category is fine
            ResultFlag flag = new ResultFlag(false, "Something went wrong");
            //bool categoryValid = _categoryRepo.CategoryExists(recipeDto.Category);
            var category = _categoryRepo.GetCategoryByName(recipeDto.Category);
            if (category== null) {
                flag.Message = "Invalid category";
                return flag;
            }
            if (!UserLogger.IsLogged) {
                flag.Message = "No user logged in";
                return flag;
            }
            //see if loggedid is same as recipe
            var recipe = _recipeRepo.ReadRecipe(recipeDto.RecipeToBeUpdatedID.GetValueOrDefault());
            if (recipe == null) {
                flag.Message = "No such recipe";
                return flag;
            }
            if (recipe.UserID != UserLogger.UserId) {
                flag.Message = "Can only update your own recipes";
                return flag;
            }
            recipe.Title = recipeDto.Title;
            recipe.Description = recipeDto.Description;
            recipe.IngredientsData = recipeDto.IngredientsData;
            recipe.CategoryID = category.CategoryID;

            _recipeRepo.UpdateRecipe(recipe);
            flag.Message = "Success";
            flag.Success = true;
            return flag;
        }
    }
}
