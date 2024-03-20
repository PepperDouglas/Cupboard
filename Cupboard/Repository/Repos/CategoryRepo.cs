using Cupboard.Contexts;
using Cupboard.Models.Entities;
using Cupboard.Repository.Interfaces;

namespace Cupboard.Repository.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly CupboardContext _context;

        public CategoryRepo(CupboardContext context) {
            _context = context;
        }

        public void CreateCategory(Category category) {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public ICollection<Category> GetCategories() {
            return _context.Categories.ToList<Category>();
        }

        public Category GetCategory(int id) {
            return _context.Categories.SingleOrDefault(c => c.CategoryID == id);
        }
    }
}
