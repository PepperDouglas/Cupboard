using Cupboard.Contexts;
using Cupboard.Models.Entities;
using Cupboard.Repository.Interfaces;

namespace Cupboard.Repository.Repos
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly CupboardContext _context;

        public ReviewRepo(CupboardContext context) {
            _context = context;
        }

        public void CreateReview(Review review) {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public ICollection<Review> ReadAllReviews(int recipeId) {
            return _context.Reviews.Where(r => r.RecipeID == recipeId).ToList();
        }

        public Review ReadReview(int reviewId) {
            return _context.Reviews.SingleOrDefault(r => r.ReviewID == reviewId);
        }
    }
}
