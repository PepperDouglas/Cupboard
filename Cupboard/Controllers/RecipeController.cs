using Cupboard.Models.DTO;
using Cupboard.Services.Interfaces;
using Cupboard.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cupboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService) {
            _recipeService = recipeService;
        }

        [HttpPost]
        public IActionResult PostRecipe(RecipeDTO recipeDTO) {
            var status = _recipeService.CreateRecipe(recipeDTO);
            if (status.Success) {
                return Ok(status.Message);
            }
            return BadRequest(status.Message);
        }

        [HttpGet("{id}")]
        public IActionResult GetRecipe(int id) {
            try {
                var recipe = _recipeService.ReadRecipe(id);
                return Ok(recipe);  
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("detail")]
        public IActionResult GetRecipesWithReviews() {
            try {
                var recipes = _recipeService.GetRecipesWithReviews();
                return Ok(recipes);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/search/{condition}")]
        public IActionResult SearchRecipe(string condition) {
            try {
                var recipes = _recipeService.SearchRecipe(condition);
                return Ok(recipes);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetRecipes() {
            try {
                var recipes = _recipeService.ReadRecipes();
                return Ok(recipes);
            }
            catch (Exception ex) {
                return NotFound(ex.Message);
            }
        }

        //is route and body data combinable?
        [HttpPut]
        public IActionResult UpdateRecipe(RecipeDTO recipeDto) {
            try {
                var status = _recipeService.UpdateRecipe(recipeDto);
                if (status.Success) {
                    return Ok(status.Message);
                }
                return BadRequest(status.Message);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id) {
            try {
                _recipeService.DeleteRecipe(id);
                return Ok("Recipe removed");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

    }
}
