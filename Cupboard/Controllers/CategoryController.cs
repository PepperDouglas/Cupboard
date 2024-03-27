using Cupboard.Models.Entities;
using Cupboard.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cupboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult PostCategory(Category category) {
            try {
                _categoryService.CreateCategory(category);
                return Created();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id) {
            if (id == 0) {
                return BadRequest("Invalid id");
            }
            try {
                var category = _categoryService.GetCategory(id);
                if (category == null) {
                    return BadRequest("No such category");
                }
                return Ok(category);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetCategories() {
            try {
                return Ok(_categoryService.GetCategories());
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
