using Cupboard.Models.Entities;

namespace Cupboard.Repository.Interfaces
{
    public interface ICategoryRepo
    {
        Category GetCategory(int id);

        ICollection<Category> GetCategories();
    }
}
