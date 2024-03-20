using Cupboard.Models.Entities;
using Cupboard.Repository.Interfaces;
using Cupboard.Services.Interfaces;

namespace Cupboard.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo) {
            _categoryRepo = categoryRepo;
        }

        public void CreateCategory(Category category) {
            _categoryRepo.CreateCategory(category);
        }

        public ICollection<Category> GetCategories() {
            return _categoryRepo.GetCategories();
        }

        public Category GetCategory(int id) {
            return _categoryRepo.GetCategory(id);
        }
    }
}
