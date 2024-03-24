using Cupboard.Contexts;
using Cupboard.Models.Entities;
using Cupboard.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        //helt not needed pga nedanstående metod?
        public bool CategoryExists(string name) { 
            return _context.Categories.Any(c => EF.Functions.Like(c.Name.ToLower(), name.ToLower()));
        }

        public Category GetCategoryByName(string name) {
            return _context.Categories.SingleOrDefault(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
