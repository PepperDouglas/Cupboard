using Cupboard.Models.Entities;

namespace Cupboard.Repository.Interfaces
{
    public interface ICategoryRepo
    {
        void CreateCategory(Category category);
        
        Category GetCategory(int id);

        ICollection<Category> GetCategories();

        public bool CategoryExists(string name);

        Category GetCategoryByName(string name);

    }
}
