using Cupboard.Models.Entities;

namespace Cupboard.Services.Interfaces
{
    public interface ICategoryService
    {
        void CreateCategory(Category category);

        Category GetCategory(int id);

        ICollection<Category> GetCategories();
    }
}
